using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shields.GraphViz.Services;
using Shields.GraphViz.Components;
using Shields.GraphViz.Models;
using System.Collections.Immutable;
using System.Threading;

//NOTA: todo se guarda en int y se maneja en int hasta el momento de agregarlo
//al listview con el .ToString("X")

namespace Superposiciones
{
    public partial class Form1 : Form
    {
        public OpenFileDialog opFile;
        public string confText, longText, dirCargaStr;
        public int dirCarga;
        public Dictionary<string, Node> nodes;
        public Dictionary<string, Int32> functions;
        public Dictionary<string, Int32> caminos;

        // Graphviz
        private IRenderer renderer;
        private List<EdgeStatement> edgesGraphviz;

        private bool band = false;
        private int max = 0, min = 0;
        private int acumulador = 0;

        public Form1()
        {
            InitializeComponent();
            renderer = new Renderer(@"C:\Program Files\Graphviz2.38\bin");
            edgesGraphviz = new List<EdgeStatement>();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //carga de configuración
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = readFile();
            confText = richTextBox1.Text;
            textCarga.Enabled = true;
            treeView.Nodes.Clear();
            listViewGraphic.Items.Clear();        
            construirArbol();
            treeView.ExpandAll();

            if (treeView.Nodes.Count > 0)
            {
                botCarga.Enabled = true;
            }
            else
            {
                botCarga.Enabled = false;
            }
        }

        //carga de longitudes
        private void botCarga_Click(object sender, EventArgs e)
        {
            listViewMemory.Items.Clear();
            listViewGraphic.Items.Clear();
            if (textCarga.Text != "")
            {
                //recuperar la dirección de carga
                dirCargaStr = textCarga.Text;
                //convertir a int la cadena en hex
                dirCarga = Int32.Parse(dirCargaStr, System.Globalization.NumberStyles.HexNumber);
                //longText= File.ReadAllText(opFile.FileName);
                longText = readFile();

                if(longText != null)
                {
                    llenarTabla();
                    //Memoria maxima y minima
                    minimo();
                    maximo();
                }
            }
            else MessageBox.Show("Ingrese una dirección de carga");
        }

        private void minimo()
        {
            int min = 0;
            caminos = new Dictionary<string, int>();
            string cad = treeView.TopNode.Text + "->";
            
            recuCam(treeView.TopNode.Nodes, cad, dameLong(treeView.TopNode.Text));
            foreach (var ca in caminos)
            {
                if (min == 0 || min> ca.Value)
                {
                    min = ca.Value;
                    textBoxMin.Text = min.ToString("X") + "   " + ca.Key;
                    listViewGraphic.Items.Clear();
                    var aux = (ca.Key).Split(new[] { "->" }, StringSplitOptions.None);
                    foreach (var a in aux)
                    {
                        String[] arr = { a, (nodes[a].dRel + dirCarga).ToString("X"), (nodes[a].dRel + dirCarga + nodes[a].nSize - 1).ToString("X") };
                        ListViewItem lv = new ListViewItem(arr);
                        listViewGraphic.Items.Add(lv);
                    }
                }
            }
        }
        
        // funcion recursiva que nos ayuda al momento de generar los caminos
        private void recuCam(TreeNodeCollection nodos, string cadena, Int32 costo)
        {

            if (nodos.Count > 0)
            {
                for (int i = 0; i < nodos.Count; i++)
                {
                    recuCam(nodos[i].Nodes, cadena + nodos[i].Text + "->", costo + dameLong(nodos[i].Text));
                }
            }
            else
                caminos.Add(cadena.Remove(cadena.Length - 2, 2), costo);
        }

        private int dameLong(string seg)//Nos regresa la longitud de un segmento dado
        {
            int log = 0;
            for (int i = 0; i < listViewMemory.Items.Count; i++)
                if (string.Compare(listViewMemory.Items[i].Text, seg) == 0)
                {
                    log = int.Parse(listViewMemory.Items[i].SubItems[3].Text, System.Globalization.NumberStyles.HexNumber);
                    break;
                }
            return log;
        }

        private void maximo()
        {
            int max = 0;

            foreach (var ca in caminos)
            {
                if (max == 0)
                {
                    max = ca.Value;
                    textBoxMax.Text = max.ToString("X") + "   " + ca.Key;
                }
                else
                {
                    if (max < ca.Value)
                    {
                        max = ca.Value;
                        textBoxMax.Text = max.ToString("X") + "   " + ca.Key;
                    }
                }
            }
        }

        private void Recursive(TreeNode treeNode)
        {
            if(!band)
            {//Es una rama
                band = true;
                if(max<acumulador)
                {
                    max = acumulador;
                }//Para ver que camino es mas largo
                if(1010 > acumulador)
                {
                    min = acumulador;
                }//Para ver que camino es mas corto
                acumulador = nodes[treeNode.Parent.Name].nSize;
            }
            // Print the node.
            System.Diagnostics.Debug.WriteLine(treeNode.Text);
            acumulador+=nodes[treeNode.Text].nSize;
            foreach (TreeNode tn in treeNode.Nodes)
            {
                Recursive(tn);
                band = false;
            }
        }
        private void maxMin()
        {
            TreeNodeCollection nodes = treeView.Nodes;
            int aux;
            foreach (TreeNode n in nodes)
            {
                band = true;
                Recursive(n);
            }
            textBoxMax.Text = max.ToString("X");
            aux = Int32.Parse(listViewMemory.TopItem.SubItems[3].Text, System.Globalization.NumberStyles.HexNumber);
            min += aux;
            textBoxMin.Text = min.ToString("X");
        }

        private void llenarTabla()
        {
            getFunctions(); //recupera cada función y las guarda en un dict con sus tamaños
            foreach(var item in nodes.Values)
            {
                foreach(string func in item.Funcs)
                {
                    foreach(var f in functions.Keys)
                    {
                        if(f == func)
                        {
                            item.nSize += functions[f]; //asigna el tamaño final a cada nodo
                        }
                    }
                }
            }
            CallRecursive(treeView);
        }

        /*
         * realiza y muestra los cálculos
         */

        private void PrintRecursive(TreeNode treeNode)
        {
            string[] arr = new string[4]; //aux para llenar listView
            int tam = nodes.Values.Count;
            int[,] mat = new int[tam,tam];
            //añade elementos al listview, aquí hay que hacer el recorrido por 
            //los nodos para manejar lo de las dirs
            foreach (var item in nodes.Keys)
            {
                if (treeNode.Name == item)
                {
                    arr[0] = item; //bien
                    foreach(var it in nodes.Keys)
                    {
                        if (treeNode.Parent != null)
                        {
                            if (it == treeNode.Parent.Name)
                            {
                                nodes[item].dRel = nodes[it].nSize + nodes[it].dRel;
                            }
                        }
                        else//es el primero
                            nodes[item].dRel = 0;
                    }
                    
                    arr[1] = (nodes[item].dRel).ToString("X");//dir rel
                    arr[2] = (dirCarga + nodes[item].dRel).ToString("X"); //dir real
                    arr[3] = nodes[item].nSize.ToString("X");//bien
                    ListViewItem lv = new ListViewItem(arr);
                    listViewMemory.Items.Add(lv);
                }
            }
            //actions
            
            //llamar cada nodo recursivamente  
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn);
            }
        }

        // Call the procedure using the TreeView.  
        private void CallRecursive(TreeView treeView)
        {
            // Print each node recursively.  
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                PrintRecursive(n);
            }
        }
        /**
         * Recupera las funciones y sus tamaños en un diccionario
         * functions <string, int>
         * */
        private void getFunctions()
        {
            try
            {
                var lines = longText.Split(
                       new[] { "\r\n", "\r", "\n" },
                       StringSplitOptions.None);
                functions = new Dictionary<string, int>();

                for (int j = 0; j < lines.Length; j++)
                {
                    var directive = lines[j].Split()[0].ToUpper();
                    string funcSize;

                    foreach (var item in nodes.Values)
                    {
                        foreach (string func in item.Funcs)
                        {
                            if (directive.Contains(func))
                            {
                                funcSize = lines[j].Replace(func, "").Trim();
                                if (!functions.ContainsKey(func))
                                    functions.Add(func, Convert.ToInt32(funcSize, 16));

                            }
                        }
                    }
                }
            }
            catch { MessageBox.Show("Ocurrió un problema al leer archivo de tamaño"); }
        }
        /**
         * Leer linea por linea y decidir que hacer en caso de
         * ser SEGMENT o PARENT
         */
        private void construirArbol()
        {
            nodes = new Dictionary<string, Node>(); 
            var lines = confText.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );
            Node node;
            string parentId = "";
            bool errorFound = false;

            treeView.BeginUpdate();
            for(int i = 0; i < lines.Length && !errorFound; i++)
            {
                var directive = lines[i].Split()[0].ToUpper(); // Obtener primer palabra
                string segmentInfo;

                // Si es SEGMENT crear nuevo nodo e
                // insertar en árbol
                if (directive.Contains("SEGMENT"))
                {
                    segmentInfo = lines[i].Replace("SEGMENT", "").Trim();
                    node = new Node(segmentInfo);

                    if(parentId == "")
                    {
                        // Raiz
                        // Crear nuevo nodo de TreeView e insertarlo
                        var treeNode = new TreeNode(node.Id);
                        treeNode.Name = node.Id;
                        treeView.Nodes.Add(treeNode);
                    } else
                    {
                        // Obtener nodo padre e insertarle un nuevo nodo de TreeView
                        var parentNode = treeView.Nodes.Find(parentId, true).FirstOrDefault();
                        var treeNode = new TreeNode(node.Id);
                        treeNode.Name = node.Id;

                        parentNode.Nodes.Add(treeNode);

                        // Agregar a GraphViz
                        var label = ImmutableDictionary.CreateBuilder<Id, Id>();
                        label.Add("label", node.Id);

                        edgesGraphviz.Add(new EdgeStatement(parentId, node.Id, label.ToImmutable()));
                    }

                    // Agregar a lista de nodos
                    nodes.Add(node.Id, node);
                    parentId = node.Id;
                } else if (directive.Contains("PARENT")) {
                    segmentInfo = lines[i].Replace("PARENT", "").Trim();

                    if(nodes[segmentInfo] != null)
                    {
                        parentId = nodes[segmentInfo].Id;
                    }
                    else {
                        errorFound = true;
                        MessageBox.Show("PARENT " + nodes[segmentInfo].Id + " no existe");
                    }

                }
            }
            treeView.EndUpdate();
            GenerateTreeImage();
        }
        
        private async Task GenerateTreeImage()
        {
            Graph graph = Graph.Directed
                //.Add(AttributeStatement.Graph.Set("rankdir", "LR"))
                .Add(AttributeStatement.Graph.Set("labelloc", "t"))
                .Add(AttributeStatement.Node.Set("style", "filled"))
                .Add(AttributeStatement.Node.Set("fillcolor", "#ff6b81"))
                .Add(AttributeStatement.Edge.Set("color", "#0a3d62"))
                .AddRange(edgesGraphviz);

            using (Stream file = File.Create("graph.png"))
            {
                await renderer.RunAsync(
                    graph, file,
                    RendererLayouts.Dot,
                    RendererFormats.Png,
                    CancellationToken.None);

                pictureBox1.ImageLocation = (file as FileStream).Name;
            }
        }

        /**
         * Open Image using Windows
         */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(pictureBox1.ImageLocation != null)
                System.Diagnostics.Process.Start(pictureBox1.ImageLocation);
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AyudaForm pantAyuda = new AyudaForm();
            pantAyuda.Show();
        }

        //exit
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //método que lee archivo y abre ventana para elegirlo, 
        //regresa una cadena con todo el texto contenido
        private string readFile()
        {
            opFile = new OpenFileDialog();
            opFile.Filter = "Configuration Files|*.txt";
            opFile.Title = "Choose a configuration file .txt";

            if (opFile.ShowDialog() != DialogResult.OK)
                return null;

            return File.ReadAllText(opFile.FileName);
        }
    }
}
