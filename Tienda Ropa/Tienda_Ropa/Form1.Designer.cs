namespace Tienda_Ropa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.rbRemera = new System.Windows.Forms.RadioButton();
            this.rbPantalon = new System.Windows.Forms.RadioButton();
            this.dtFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btNuevo = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.Lista_Ropa = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(56, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Marca";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(116, 60);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(100, 23);
            this.tbCodigo.TabIndex = 4;
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(116, 108);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(100, 23);
            this.tbPrecio.TabIndex = 5;
            // 
            // cbMarca
            // 
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(116, 159);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(121, 23);
            this.cbMarca.TabIndex = 6;
            // 
            // rbRemera
            // 
            this.rbRemera.AutoSize = true;
            this.rbRemera.Location = new System.Drawing.Point(116, 215);
            this.rbRemera.Name = "rbRemera";
            this.rbRemera.Size = new System.Drawing.Size(65, 19);
            this.rbRemera.TabIndex = 7;
            this.rbRemera.TabStop = true;
            this.rbRemera.Text = "Remera";
            this.rbRemera.UseVisualStyleBackColor = true;
            // 
            // rbPantalon
            // 
            this.rbPantalon.AutoSize = true;
            this.rbPantalon.Location = new System.Drawing.Point(219, 215);
            this.rbPantalon.Name = "rbPantalon";
            this.rbPantalon.Size = new System.Drawing.Size(72, 19);
            this.rbPantalon.TabIndex = 8;
            this.rbPantalon.TabStop = true;
            this.rbPantalon.Text = "Pantalon";
            this.rbPantalon.UseVisualStyleBackColor = true;
            // 
            // dtFechaIngreso
            // 
            this.dtFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIngreso.Location = new System.Drawing.Point(116, 269);
            this.dtFechaIngreso.Name = "dtFechaIngreso";
            this.dtFechaIngreso.Size = new System.Drawing.Size(100, 23);
            this.dtFechaIngreso.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Ingreso";
            // 
            // btNuevo
            // 
            this.btNuevo.Location = new System.Drawing.Point(171, 353);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 11;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(394, 353);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(75, 23);
            this.btGuardar.TabIndex = 12;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(620, 353);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(75, 23);
            this.btSalir.TabIndex = 13;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            // 
            // Lista_Ropa
            // 
            this.Lista_Ropa.FormattingEnabled = true;
            this.Lista_Ropa.ItemHeight = 15;
            this.Lista_Ropa.Location = new System.Drawing.Point(372, 108);
            this.Lista_Ropa.Name = "Lista_Ropa";
            this.Lista_Ropa.Size = new System.Drawing.Size(371, 109);
            this.Lista_Ropa.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(782, 418);
            this.Controls.Add(this.Lista_Ropa);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFechaIngreso);
            this.Controls.Add(this.rbPantalon);
            this.Controls.Add(this.rbRemera);
            this.Controls.Add(this.cbMarca);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.tbCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbCodigo;
        private TextBox tbPrecio;
        private ComboBox cbMarca;
        private RadioButton rbRemera;
        private RadioButton rbPantalon;
        private DateTimePicker dtFechaIngreso;
        private Label label5;
        private Button btNuevo;
        private Button btGuardar;
        private Button btSalir;
        private ListBox Lista_Ropa;
    }
}