namespace WinFormsApp6
{
    partial class SplashScreen
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            parrotFlatProgressBar1 = new ReaLTaiizor.Controls.ParrotFlatProgressBar();
            progressIndicator1 = new ReaLTaiizor.Controls.ProgressIndicator();
            pictureBox1 = new PictureBox();
            dungeonHeaderLabel1 = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // parrotFlatProgressBar1
            // 
            parrotFlatProgressBar1.BarStyle = ReaLTaiizor.Controls.ParrotFlatProgressBar.Style.Flat;
            parrotFlatProgressBar1.BorderColor = Color.Transparent;
            parrotFlatProgressBar1.Colors = (List<Color>)resources.GetObject("parrotFlatProgressBar1.Colors");
            parrotFlatProgressBar1.CompleteBackColor = Color.FromArgb(248, 110, 113);
            parrotFlatProgressBar1.CompleteColor = Color.FromArgb(248, 110, 113);
            parrotFlatProgressBar1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotFlatProgressBar1.IncompletedBackColor = Color.Transparent;
            parrotFlatProgressBar1.InocmpletedColor = Color.Transparent;
            parrotFlatProgressBar1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotFlatProgressBar1.Location = new Point(-1, 431);
            parrotFlatProgressBar1.MaxValue = 100;
            parrotFlatProgressBar1.Name = "parrotFlatProgressBar1";
            parrotFlatProgressBar1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotFlatProgressBar1.Positions = (List<float>)resources.GetObject("parrotFlatProgressBar1.Positions");
            parrotFlatProgressBar1.ShowBorder = true;
            parrotFlatProgressBar1.Size = new Size(802, 19);
            parrotFlatProgressBar1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            parrotFlatProgressBar1.TabIndex = 11;
            parrotFlatProgressBar1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotFlatProgressBar1.Value = 0;
            // 
            // progressIndicator1
            // 
            progressIndicator1.Location = new Point(386, 299);
            progressIndicator1.MinimumSize = new Size(50, 50);
            progressIndicator1.Name = "progressIndicator1";
            progressIndicator1.P_AnimationColor = Color.FromArgb(119, 216, 158);
            progressIndicator1.P_AnimationSpeed = 90;
            progressIndicator1.P_BaseColor = Color.LightGray;
            progressIndicator1.Size = new Size(74, 74);
            progressIndicator1.TabIndex = 13;
            progressIndicator1.Text = "progressIndicator1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-4, 103);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(802, 201);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // dungeonHeaderLabel1
            // 
            dungeonHeaderLabel1.AutoSize = true;
            dungeonHeaderLabel1.BackColor = Color.Transparent;
            dungeonHeaderLabel1.Font = new Font("Nexa Heavy", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonHeaderLabel1.ForeColor = Color.DarkGray;
            dungeonHeaderLabel1.Location = new Point(182, 410);
            dungeonHeaderLabel1.Name = "dungeonHeaderLabel1";
            dungeonHeaderLabel1.Size = new Size(436, 17);
            dungeonHeaderLabel1.TabIndex = 15;
            dungeonHeaderLabel1.Text = "© 2026 | Este programa fue desarrollado por Joaquín Altamirano ";
            // 
            // timer1
            // 
            timer1.Interval = 86;
            timer1.Tick += timer1_Tick;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 248, 244);
            ClientSize = new Size(800, 450);
            Controls.Add(dungeonHeaderLabel1);
            Controls.Add(pictureBox1);
            Controls.Add(progressIndicator1);
            Controls.Add(parrotFlatProgressBar1);
            Cursor = Cursors.AppStarting;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashScreen";
            Text = "SplashScreen";
            Load += SplashScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.ParrotFlatProgressBar parrotFlatProgressBar1;
        private ReaLTaiizor.Controls.ProgressIndicator progressIndicator1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.DungeonHeaderLabel dungeonHeaderLabel1;
        private System.Windows.Forms.Timer timer1;
    }
}