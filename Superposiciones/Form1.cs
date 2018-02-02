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
            string fileText;
            opFile = new OpenFileDialog();
            opFile.Filter = "Configuration Files|*.txt";
            opFile.Title = "Choose a configuration file .txt";

            if (opFile.ShowDialog() != DialogResult.OK)
                return null;
            fileText = File.ReadAllText(opFile.FileName);
            return fileText;
        }
    }
}
