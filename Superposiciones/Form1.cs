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

namespace Superposiciones
{
    public partial class Form1 : Form
    {
        public OpenFileDialog opFile;
        public string confText, longText, dirCargaStr;
        public int dirCarga;
          
        public Form1()
        {
            InitializeComponent();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //carga de configuración
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confText = readFile();
            treeView.Nodes.Clear();
            construirArbol();
        }

        //carga de longitudes
        private void botCarga_Click(object sender, EventArgs e)
        {
            longText = readFile();

            //recuperar la dirección de carga
            dirCargaStr = textCarga.Text;
            //convertir a int la cadena en hex
            dirCarga = Int32.Parse(dirCargaStr, System.Globalization.NumberStyles.HexNumber);
            
        }

        /**
         * Leer linea por linea y decidir que hacer en caso de
         * ser SEGMENT o PARENT
         */
        private void construirArbol()
        {
            var nodes = new Dictionary<string, Node>(); 
            var lines = confText.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );
            Node node;
            string parentId = "";

            treeView.BeginUpdate();
            for(int i = 0; i < lines.Length; i++)
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
                    }

                    nodes.Add(node.Id, node);
                    parentId = node.Id;
                } else if (directive.Contains("PARENT")) {
                    segmentInfo = lines[i].Replace("PARENT", "").Trim();
                    parentId = nodes[segmentInfo].Id;
                }
            }
            treeView.EndUpdate();
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
