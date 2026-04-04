namespace WinFormsApp6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel_der = new Panel();
            labelBreadcrumb = new Label();
            dataGridView1 = new DataGridView();
            panel_izq = new Panel();
            panelContenedor = new Panel();
            txtBusqueda = new ReaLTaiizor.Controls.AloneTextBox();
            limpiarFiltros = new LinkLabel();
            panelFiltros = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            btn_Volver = new Button();
            verdeOscuro = new Panel();
            verdeClaro = new Panel();
            Rojo = new Panel();
            Blanco = new Panel();
            btn_Cerrar = new Button();
            panel_der.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel_izq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel_der
            // 
            panel_der.BorderStyle = BorderStyle.Fixed3D;
            panel_der.Controls.Add(labelBreadcrumb);
            panel_der.Controls.Add(dataGridView1);
            panel_der.Location = new Point(515, 45);
            panel_der.Name = "panel_der";
            panel_der.Size = new Size(473, 495);
            panel_der.TabIndex = 0;
            // 
            // labelBreadcrumb
            // 
            labelBreadcrumb.AutoSize = true;
            labelBreadcrumb.Font = new Font("Nexa Heavy", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBreadcrumb.ForeColor = Color.FromArgb(175, 175, 175);
            labelBreadcrumb.Location = new Point(22, 13);
            labelBreadcrumb.Name = "labelBreadcrumb";
            labelBreadcrumb.Size = new Size(104, 19);
            labelBreadcrumb.TabIndex = 5;
            labelBreadcrumb.Text = "Breadcrumb";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(426, 420);
            dataGridView1.TabIndex = 0;
            // 
            // panel_izq
            // 
            panel_izq.BorderStyle = BorderStyle.Fixed3D;
            panel_izq.Controls.Add(panelContenedor);
            panel_izq.Controls.Add(txtBusqueda);
            panel_izq.Controls.Add(limpiarFiltros);
            panel_izq.Controls.Add(panelFiltros);
            panel_izq.Location = new Point(53, 45);
            panel_izq.Name = "panel_izq";
            panel_izq.Size = new Size(428, 497);
            panel_izq.TabIndex = 1;
            // 
            // panelContenedor
            // 
            panelContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelContenedor.AutoScroll = true;
            panelContenedor.Location = new Point(19, 190);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(382, 274);
            panelContenedor.TabIndex = 6;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.Transparent;
            txtBusqueda.EnabledCalc = true;
            txtBusqueda.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBusqueda.ForeColor = Color.FromArgb(64, 64, 64);
            txtBusqueda.Location = new Point(19, 128);
            txtBusqueda.MaxLength = 32767;
            txtBusqueda.MultiLine = false;
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.ReadOnly = false;
            txtBusqueda.Size = new Size(384, 41);
            txtBusqueda.TabIndex = 5;
            txtBusqueda.Text = "Escribí el nombre de un producto...";
            txtBusqueda.TextAlign = HorizontalAlignment.Left;
            txtBusqueda.UseSystemPasswordChar = false;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // limpiarFiltros
            // 
            limpiarFiltros.ActiveLinkColor = Color.FromArgb(119, 216, 158);
            limpiarFiltros.AutoSize = true;
            limpiarFiltros.Font = new Font("Nexa Heavy", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            limpiarFiltros.ForeColor = SystemColors.ControlText;
            limpiarFiltros.LinkColor = Color.FromArgb(15, 30, 19);
            limpiarFiltros.Location = new Point(336, 13);
            limpiarFiltros.Name = "limpiarFiltros";
            limpiarFiltros.Size = new Size(67, 19);
            limpiarFiltros.TabIndex = 3;
            limpiarFiltros.TabStop = true;
            limpiarFiltros.Text = "Limpiar";
            // 
            // panelFiltros
            // 
            panelFiltros.BorderStyle = BorderStyle.Fixed3D;
            panelFiltros.Location = new Point(19, 44);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(384, 67);
            panelFiltros.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(471, 548);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btn_Volver
            // 
            btn_Volver.BackColor = Color.FromArgb(248, 110, 113);
            btn_Volver.FlatStyle = FlatStyle.Flat;
            btn_Volver.Font = new Font("Nexa Heavy", 8.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Volver.ForeColor = Color.FromArgb(241, 254, 247);
            btn_Volver.Location = new Point(1, 44);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(54, 34);
            btn_Volver.TabIndex = 0;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = false;
            // 
            // verdeOscuro
            // 
            verdeOscuro.BackColor = Color.FromArgb(15, 30, 19);
            verdeOscuro.Location = new Point(8, 151);
            verdeOscuro.Name = "verdeOscuro";
            verdeOscuro.Size = new Size(16, 19);
            verdeOscuro.TabIndex = 2;
            verdeOscuro.Visible = false;
            // 
            // verdeClaro
            // 
            verdeClaro.BackColor = Color.FromArgb(119, 216, 158);
            verdeClaro.Location = new Point(24, 151);
            verdeClaro.Name = "verdeClaro";
            verdeClaro.Size = new Size(16, 19);
            verdeClaro.TabIndex = 3;
            verdeClaro.Visible = false;
            // 
            // Rojo
            // 
            Rojo.BackColor = Color.FromArgb(248, 110, 113);
            Rojo.Location = new Point(8, 170);
            Rojo.Name = "Rojo";
            Rojo.Size = new Size(16, 19);
            Rojo.TabIndex = 3;
            Rojo.Visible = false;
            // 
            // Blanco
            // 
            Blanco.BackColor = Color.FromArgb(241, 254, 247);
            Blanco.ForeColor = SystemColors.ControlLight;
            Blanco.Location = new Point(24, 170);
            Blanco.Name = "Blanco";
            Blanco.Size = new Size(16, 19);
            Blanco.TabIndex = 4;
            Blanco.Visible = false;
            // 
            // btn_Cerrar
            // 
            btn_Cerrar.BackColor = Color.FromArgb(248, 110, 113);
            btn_Cerrar.FlatStyle = FlatStyle.Flat;
            btn_Cerrar.Font = new Font("Nexa Heavy", 8.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Cerrar.ForeColor = Color.FromArgb(241, 254, 247);
            btn_Cerrar.Location = new Point(995, -1);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.Size = new Size(38, 30);
            btn_Cerrar.TabIndex = 5;
            btn_Cerrar.Text = "X";
            btn_Cerrar.UseVisualStyleBackColor = false;
            btn_Cerrar.Click += btn_Cerrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 248, 244);
            ClientSize = new Size(1032, 581);
            Controls.Add(btn_Cerrar);
            Controls.Add(panel_izq);
            Controls.Add(pictureBox1);
            Controls.Add(Blanco);
            Controls.Add(Rojo);
            Controls.Add(verdeClaro);
            Controls.Add(verdeOscuro);
            Controls.Add(btn_Volver);
            Controls.Add(panel_der);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel_der.ResumeLayout(false);
            panel_der.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel_izq.ResumeLayout(false);
            panel_izq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_der;
        private Panel panel_izq;
        private FlowLayoutPanel panelFiltros;
        private Button btn_Volver;
        private Button button2;
        private TextBox textBox1;
        private LinkLabel limpiarFiltros;
        private Label labelBreadcrumb;
        private DataGridView dataGridView1;
        private Panel verdeOscuro;
        private Panel verdeClaro;
        private Panel Rojo;
        private Panel Blanco;
        private PictureBox pictureBox1;
        private Button btn_Cerrar;
        private ReaLTaiizor.Controls.AloneTextBox txtBusqueda;
        private Panel panelContenedor;
    }
}
