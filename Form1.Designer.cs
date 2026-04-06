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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel_der = new Panel();
            labelBreadcrumb = new Label();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            panel_izq = new Panel();
            hora = new Label();
            iconoHora = new ReaLTaiizor.Controls.ParrotPictureBox();
            iconoLimpiar = new ReaLTaiizor.Controls.ParrotPictureBox();
            panelContenedor = new Panel();
            iconoBuscar = new PictureBox();
            txtBusqueda = new TextBox();
            panelFiltros = new FlowLayoutPanel();
            border_panelFiltros = new ReaLTaiizor.Controls.AloneTextBox();
            border_txtBusqueda = new ReaLTaiizor.Controls.AloneTextBox();
            limpiarFiltros = new LinkLabel();
            border_panelContenedor = new ReaLTaiizor.Controls.HopeRoundButton();
            btn_Volver = new Button();
            verdeOscuro = new Panel();
            verdeClaro = new Panel();
            Rojo = new Panel();
            Blanco = new Panel();
            btn_Cerrar = new Button();
            aloneTextBox1 = new ReaLTaiizor.Controls.AloneTextBox();
            aloneTextBox2 = new ReaLTaiizor.Controls.AloneTextBox();
            timerHora = new System.Windows.Forms.Timer(components);
            panel_der.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_izq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconoBuscar).BeginInit();
            SuspendLayout();
            // 
            // panel_der
            // 
            panel_der.Controls.Add(labelBreadcrumb);
            panel_der.Controls.Add(dataGridView1);
            panel_der.Location = new Point(515, 60);
            panel_der.Name = "panel_der";
            panel_der.Size = new Size(473, 569);
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
            dataGridView1.BackgroundColor = Color.FromArgb(239, 248, 244);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(426, 499);
            dataGridView1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(948, 606);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel_izq
            // 
            panel_izq.Controls.Add(hora);
            panel_izq.Controls.Add(iconoHora);
            panel_izq.Controls.Add(iconoLimpiar);
            panel_izq.Controls.Add(panelContenedor);
            panel_izq.Controls.Add(iconoBuscar);
            panel_izq.Controls.Add(txtBusqueda);
            panel_izq.Controls.Add(panelFiltros);
            panel_izq.Controls.Add(border_panelFiltros);
            panel_izq.Controls.Add(border_txtBusqueda);
            panel_izq.Controls.Add(limpiarFiltros);
            panel_izq.Controls.Add(border_panelContenedor);
            panel_izq.Location = new Point(53, 60);
            panel_izq.Name = "panel_izq";
            panel_izq.Size = new Size(428, 571);
            panel_izq.TabIndex = 1;
            // 
            // hora
            // 
            hora.AutoSize = true;
            hora.Font = new Font("Nexa Heavy", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hora.ForeColor = Color.FromArgb(175, 175, 175);
            hora.Location = new Point(46, 16);
            hora.Name = "hora";
            hora.Size = new Size(57, 19);
            hora.TabIndex = 6;
            hora.Text = "00:00";
            // 
            // iconoHora
            // 
            iconoHora.BackgroundImage = (Image)resources.GetObject("iconoHora.BackgroundImage");
            iconoHora.BackgroundImageLayout = ImageLayout.Zoom;
            iconoHora.ColorLeft = Color.DodgerBlue;
            iconoHora.ColorRight = Color.DodgerBlue;
            iconoHora.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            iconoHora.FilterAlpha = 200;
            iconoHora.FilterEnabled = true;
            iconoHora.Image = null;
            iconoHora.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            iconoHora.IsElipse = false;
            iconoHora.IsParallax = false;
            iconoHora.Location = new Point(19, 13);
            iconoHora.Name = "iconoHora";
            iconoHora.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            iconoHora.Size = new Size(28, 25);
            iconoHora.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            iconoHora.TabIndex = 10;
            iconoHora.Text = "parrotPictureBox2";
            iconoHora.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // iconoLimpiar
            // 
            iconoLimpiar.BackgroundImage = (Image)resources.GetObject("iconoLimpiar.BackgroundImage");
            iconoLimpiar.BackgroundImageLayout = ImageLayout.Zoom;
            iconoLimpiar.ColorLeft = Color.DodgerBlue;
            iconoLimpiar.ColorRight = Color.DodgerBlue;
            iconoLimpiar.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            iconoLimpiar.FilterAlpha = 200;
            iconoLimpiar.FilterEnabled = true;
            iconoLimpiar.Image = null;
            iconoLimpiar.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            iconoLimpiar.IsElipse = false;
            iconoLimpiar.IsParallax = false;
            iconoLimpiar.Location = new Point(308, 10);
            iconoLimpiar.Name = "iconoLimpiar";
            iconoLimpiar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            iconoLimpiar.Size = new Size(28, 25);
            iconoLimpiar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            iconoLimpiar.TabIndex = 9;
            iconoLimpiar.Text = "parrotPictureBox1";
            iconoLimpiar.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // panelContenedor
            // 
            panelContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelContenedor.AutoScroll = true;
            panelContenedor.Location = new Point(19, 241);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(383, 302);
            panelContenedor.TabIndex = 6;
            // 
            // iconoBuscar
            // 
            iconoBuscar.Image = (Image)resources.GetObject("iconoBuscar.Image");
            iconoBuscar.Location = new Point(360, 155);
            iconoBuscar.Name = "iconoBuscar";
            iconoBuscar.Size = new Size(36, 36);
            iconoBuscar.SizeMode = PictureBoxSizeMode.Zoom;
            iconoBuscar.TabIndex = 8;
            iconoBuscar.TabStop = false;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(239, 248, 244);
            txtBusqueda.BorderStyle = BorderStyle.None;
            txtBusqueda.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBusqueda.ForeColor = Color.DarkGray;
            txtBusqueda.Location = new Point(28, 163);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(332, 20);
            txtBusqueda.TabIndex = 7;
            txtBusqueda.Text = "Escribí el nombre de un producto...";
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            txtBusqueda.Enter += txtBusqueda_Enter;
            txtBusqueda.Leave += txtBusqueda_Leave;
            // 
            // panelFiltros
            // 
            panelFiltros.Location = new Point(30, 54);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(367, 60);
            panelFiltros.TabIndex = 0;
            // 
            // border_panelFiltros
            // 
            border_panelFiltros.BackColor = Color.Transparent;
            border_panelFiltros.EnabledCalc = false;
            border_panelFiltros.Font = new Font("Segoe UI", 9F);
            border_panelFiltros.ForeColor = Color.FromArgb(124, 133, 142);
            border_panelFiltros.Location = new Point(19, 44);
            border_panelFiltros.MaxLength = 32767;
            border_panelFiltros.MultiLine = false;
            border_panelFiltros.Name = "border_panelFiltros";
            border_panelFiltros.ReadOnly = false;
            border_panelFiltros.Size = new Size(384, 78);
            border_panelFiltros.TabIndex = 6;
            border_panelFiltros.TextAlign = HorizontalAlignment.Left;
            border_panelFiltros.UseSystemPasswordChar = false;
            // 
            // border_txtBusqueda
            // 
            border_txtBusqueda.BackColor = Color.Transparent;
            border_txtBusqueda.Enabled = false;
            border_txtBusqueda.EnabledCalc = false;
            border_txtBusqueda.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            border_txtBusqueda.ForeColor = Color.FromArgb(64, 64, 64);
            border_txtBusqueda.Location = new Point(19, 149);
            border_txtBusqueda.MaxLength = 32767;
            border_txtBusqueda.MultiLine = false;
            border_txtBusqueda.Name = "border_txtBusqueda";
            border_txtBusqueda.ReadOnly = false;
            border_txtBusqueda.Size = new Size(384, 47);
            border_txtBusqueda.TabIndex = 5;
            border_txtBusqueda.TextAlign = HorizontalAlignment.Left;
            border_txtBusqueda.UseSystemPasswordChar = false;
            // 
            // limpiarFiltros
            // 
            limpiarFiltros.ActiveLinkColor = Color.FromArgb(119, 216, 158);
            limpiarFiltros.AutoSize = true;
            limpiarFiltros.Font = new Font("Nexa Heavy", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            limpiarFiltros.ForeColor = SystemColors.ControlText;
            limpiarFiltros.LinkColor = Color.FromArgb(15, 30, 19);
            limpiarFiltros.Location = new Point(335, 13);
            limpiarFiltros.Name = "limpiarFiltros";
            limpiarFiltros.Size = new Size(67, 19);
            limpiarFiltros.TabIndex = 3;
            limpiarFiltros.TabStop = true;
            limpiarFiltros.Text = "Limpiar";
            limpiarFiltros.LinkClicked += limpiarFiltros_LinkClicked;
            // 
            // border_panelContenedor
            // 
            border_panelContenedor.BackColor = Color.FromArgb(119, 216, 158);
            border_panelContenedor.BorderColor = Color.FromArgb(119, 216, 158);
            border_panelContenedor.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            border_panelContenedor.DangerColor = Color.FromArgb(119, 216, 158);
            border_panelContenedor.DefaultColor = Color.FromArgb(119, 216, 158);
            border_panelContenedor.Font = new Font("Segoe UI", 12F);
            border_panelContenedor.HoverTextColor = Color.FromArgb(48, 49, 51);
            border_panelContenedor.InfoColor = Color.FromArgb(144, 147, 153);
            border_panelContenedor.Location = new Point(19, 225);
            border_panelContenedor.Name = "border_panelContenedor";
            border_panelContenedor.PrimaryColor = Color.FromArgb(119, 216, 158);
            border_panelContenedor.Size = new Size(383, 34);
            border_panelContenedor.SuccessColor = Color.FromArgb(119, 216, 158);
            border_panelContenedor.TabIndex = 9;
            border_panelContenedor.TextColor = Color.White;
            border_panelContenedor.WarningColor = Color.FromArgb(119, 216, 158);
            // 
            // btn_Volver
            // 
            btn_Volver.BackColor = Color.FromArgb(248, 110, 113);
            btn_Volver.BackgroundImage = (Image)resources.GetObject("btn_Volver.BackgroundImage");
            btn_Volver.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Volver.FlatStyle = FlatStyle.Flat;
            btn_Volver.Font = new Font("Nexa Heavy", 8.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Volver.ForeColor = Color.FromArgb(241, 254, 247);
            btn_Volver.Location = new Point(-1, -1);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(66, 33);
            btn_Volver.TabIndex = 0;
            btn_Volver.UseVisualStyleBackColor = false;
            btn_Volver.Click += btn_Volver_Click;
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
            btn_Cerrar.Location = new Point(965, -1);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.Size = new Size(68, 33);
            btn_Cerrar.TabIndex = 5;
            btn_Cerrar.Text = "X";
            btn_Cerrar.UseVisualStyleBackColor = false;
            btn_Cerrar.Click += btn_Cerrar_Click;
            // 
            // aloneTextBox1
            // 
            aloneTextBox1.BackColor = Color.Transparent;
            aloneTextBox1.Enabled = false;
            aloneTextBox1.EnabledCalc = false;
            aloneTextBox1.Font = new Font("Segoe UI", 9F);
            aloneTextBox1.ForeColor = Color.FromArgb(124, 133, 142);
            aloneTextBox1.Location = new Point(49, 50);
            aloneTextBox1.MaxLength = 32767;
            aloneTextBox1.MultiLine = false;
            aloneTextBox1.Name = "aloneTextBox1";
            aloneTextBox1.ReadOnly = false;
            aloneTextBox1.Size = new Size(436, 587);
            aloneTextBox1.TabIndex = 7;
            aloneTextBox1.TextAlign = HorizontalAlignment.Left;
            aloneTextBox1.UseSystemPasswordChar = false;
            // 
            // aloneTextBox2
            // 
            aloneTextBox2.BackColor = Color.Transparent;
            aloneTextBox2.Enabled = false;
            aloneTextBox2.EnabledCalc = false;
            aloneTextBox2.Font = new Font("Segoe UI", 9F);
            aloneTextBox2.ForeColor = Color.FromArgb(124, 133, 142);
            aloneTextBox2.Location = new Point(513, 52);
            aloneTextBox2.MaxLength = 32767;
            aloneTextBox2.MultiLine = false;
            aloneTextBox2.Name = "aloneTextBox2";
            aloneTextBox2.ReadOnly = false;
            aloneTextBox2.Size = new Size(477, 587);
            aloneTextBox2.TabIndex = 8;
            aloneTextBox2.TextAlign = HorizontalAlignment.Left;
            aloneTextBox2.UseSystemPasswordChar = false;
            // 
            // timerHora
            // 
            timerHora.Interval = 1000;
            timerHora.Tick += timerHora_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 248, 244);
            ClientSize = new Size(1032, 651);
            Controls.Add(pictureBox1);
            Controls.Add(btn_Cerrar);
            Controls.Add(panel_izq);
            Controls.Add(Blanco);
            Controls.Add(Rojo);
            Controls.Add(verdeClaro);
            Controls.Add(verdeOscuro);
            Controls.Add(btn_Volver);
            Controls.Add(panel_der);
            Controls.Add(aloneTextBox1);
            Controls.Add(aloneTextBox2);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel_der.ResumeLayout(false);
            panel_der.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_izq.ResumeLayout(false);
            panel_izq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconoBuscar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_der;
        private Panel panel_izq;
        private FlowLayoutPanel panelFiltros;
        private Button btn_Volver;
        private Button button2;
        private TextBox txtBusqueda;
        private LinkLabel limpiarFiltros;
        private Label labelBreadcrumb;
        private DataGridView dataGridView1;
        private Panel verdeOscuro;
        private Panel verdeClaro;
        private Panel Rojo;
        private Panel Blanco;
        private Button btn_Cerrar;
        private ReaLTaiizor.Controls.AloneTextBox border_txtBusqueda;
        private Panel panelContenedor;
        private ReaLTaiizor.Controls.AloneTextBox border_panelFiltros;
        private PictureBox iconoBuscar;
        private ReaLTaiizor.Controls.HopeRoundButton border_panelContenedor;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.AloneTextBox aloneTextBox1;
        private ReaLTaiizor.Controls.AloneTextBox aloneTextBox2;
        private Label hora;
        private ReaLTaiizor.Controls.ParrotPictureBox iconoHora;
        private ReaLTaiizor.Controls.ParrotPictureBox iconoLimpiar;
        private System.Windows.Forms.Timer timerHora;
    }
}
