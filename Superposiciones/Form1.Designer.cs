namespace Superposiciones
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.botCarga = new System.Windows.Forms.Button();
            this.textCarga = new System.Windows.Forms.TextBox();
            this.listViewMemory = new System.Windows.Forms.ListView();
            this.segmento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dirRelativa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dirReal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.longitud = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewGraphic = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(6, 91);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(145, 161);
            this.treeView.TabIndex = 1;
            // 
            // botCarga
            // 
            this.botCarga.Enabled = false;
            this.botCarga.Location = new System.Drawing.Point(101, 17);
            this.botCarga.Name = "botCarga";
            this.botCarga.Size = new System.Drawing.Size(50, 23);
            this.botCarga.TabIndex = 2;
            this.botCarga.Text = "Cargar";
            this.botCarga.UseVisualStyleBackColor = true;
            this.botCarga.Click += new System.EventHandler(this.botCarga_Click);
            // 
            // textCarga
            // 
            this.textCarga.Enabled = false;
            this.textCarga.Location = new System.Drawing.Point(7, 19);
            this.textCarga.Name = "textCarga";
            this.textCarga.Size = new System.Drawing.Size(73, 20);
            this.textCarga.TabIndex = 3;
            this.textCarga.Text = "0";
            // 
            // listViewMemory
            // 
            this.listViewMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.segmento,
            this.dirRelativa,
            this.dirReal,
            this.longitud});
            this.listViewMemory.GridLines = true;
            this.listViewMemory.Location = new System.Drawing.Point(6, 19);
            this.listViewMemory.Name = "listViewMemory";
            this.listViewMemory.Size = new System.Drawing.Size(244, 192);
            this.listViewMemory.TabIndex = 5;
            this.listViewMemory.UseCompatibleStateImageBehavior = false;
            this.listViewMemory.View = System.Windows.Forms.View.Details;
            this.listViewMemory.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // segmento
            // 
            this.segmento.Text = "Segmento";
            // 
            // dirRelativa
            // 
            this.dirRelativa.Text = "Dir. Relativa";
            // 
            // dirReal
            // 
            this.dirReal.Text = "Dir. Real";
            // 
            // longitud
            // 
            this.longitud.Text = "Longitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.treeView);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 258);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Árbol de trayectorias";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.botCarga);
            this.groupBox2.Controls.Add(this.textCarga);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 52);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dirección de carga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "H";
            // 
            // richTextBox1
            // 
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(172, 69);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(186, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 94);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Archivo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listViewMemory);
            this.groupBox4.Location = new System.Drawing.Point(186, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 220);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabla de memoria";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxMin);
            this.groupBox5.Controls.Add(this.textBoxMax);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(384, 253);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(320, 94);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Recorridos";
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(98, 60);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(216, 20);
            this.textBoxMin.TabIndex = 11;
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(98, 28);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(216, 20);
            this.textBoxMax.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Memoria Mínima";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Memoria Máxima";
            // 
            // listViewGraphic
            // 
            this.listViewGraphic.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewGraphic.GridLines = true;
            this.listViewGraphic.Location = new System.Drawing.Point(12, 23);
            this.listViewGraphic.Name = "listViewGraphic";
            this.listViewGraphic.Size = new System.Drawing.Size(229, 187);
            this.listViewGraphic.TabIndex = 14;
            this.listViewGraphic.UseCompatibleStateImageBehavior = false;
            this.listViewGraphic.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SEGMENTO";
            this.columnHeader1.Width = 76;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "INICIO";
            this.columnHeader2.Width = 69;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "FIN";
            this.columnHeader3.Width = 70;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listViewGraphic);
            this.groupBox6.Location = new System.Drawing.Point(458, 28);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(247, 219);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Recorrido mínimo en memoria";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 64);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 359);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Superposiciones";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button botCarga;
        private System.Windows.Forms.TextBox textCarga;
        private System.Windows.Forms.ListView listViewMemory;
        private System.Windows.Forms.ColumnHeader segmento;
        private System.Windows.Forms.ColumnHeader dirRelativa;
        private System.Windows.Forms.ColumnHeader dirReal;
        private System.Windows.Forms.ColumnHeader longitud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.ListView listViewGraphic;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

