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
            panel1 = new Panel();
            labelBreadcrumb = new Label();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            panel3 = new FlowLayoutPanel();
            limpiarFiltros = new LinkLabel();
            button2 = new Button();
            textBox1 = new TextBox();
            panelFiltros = new FlowLayoutPanel();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelBreadcrumb);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(422, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 495);
            panel1.TabIndex = 0;
            // 
            // labelBreadcrumb
            // 
            labelBreadcrumb.AutoSize = true;
            labelBreadcrumb.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBreadcrumb.Location = new Point(22, 12);
            labelBreadcrumb.Name = "labelBreadcrumb";
            labelBreadcrumb.Size = new Size(93, 20);
            labelBreadcrumb.TabIndex = 5;
            labelBreadcrumb.Text = "Breadcrumb";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(293, 423);
            dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(limpiarFiltros);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(panelFiltros);
            panel2.Location = new Point(60, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(336, 495);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.FlowDirection = FlowDirection.TopDown;
            panel3.Location = new Point(19, 176);
            panel3.Name = "panel3";
            panel3.Size = new Size(293, 288);
            panel3.TabIndex = 4;
            panel3.WrapContents = false;
            // 
            // limpiarFiltros
            // 
            limpiarFiltros.AutoSize = true;
            limpiarFiltros.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            limpiarFiltros.ForeColor = SystemColors.ControlText;
            limpiarFiltros.Location = new Point(252, 13);
            limpiarFiltros.Name = "limpiarFiltros";
            limpiarFiltros.Size = new Size(60, 20);
            limpiarFiltros.TabIndex = 3;
            limpiarFiltros.TabStop = true;
            limpiarFiltros.Text = "Limpiar";
            limpiarFiltros.LinkClicked += limpiarFiltros_LinkClicked;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(262, 128);
            button2.Name = "button2";
            button2.Size = new Size(50, 27);
            button2.TabIndex = 2;
            button2.Text = "Buscar";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(19, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(293, 27);
            textBox1.TabIndex = 1;
            // 
            // panelFiltros
            // 
            panelFiltros.BorderStyle = BorderStyle.FixedSingle;
            panelFiltros.Location = new Point(19, 44);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(293, 67);
            panelFiltros.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(50, 44);
            button1.TabIndex = 0;
            button1.Text = "←";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 521);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private FlowLayoutPanel panelFiltros;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private LinkLabel limpiarFiltros;
        private Label labelBreadcrumb;
        private DataGridView dataGridView1;
        private FlowLayoutPanel panel3;
    }
}
