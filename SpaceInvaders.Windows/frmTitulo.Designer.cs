namespace SpaceInvaders.Windows
{
    partial class frmTitulo
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
            this.components = new System.ComponentModel.Container();
            this.pbxStart = new System.Windows.Forms.PictureBox();
            this.pbxCerrar = new System.Windows.Forms.PictureBox();
            this.timerFondo = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxStart
            // 
            this.pbxStart.Image = global::SpaceInvaders.Windows.Properties.Resources.boton_start;
            this.pbxStart.Location = new System.Drawing.Point(211, 196);
            this.pbxStart.Name = "pbxStart";
            this.pbxStart.Size = new System.Drawing.Size(276, 166);
            this.pbxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxStart.TabIndex = 0;
            this.pbxStart.TabStop = false;
            this.pbxStart.Tag = "";
            this.pbxStart.Click += new System.EventHandler(this.pbxStart_Click);
            this.pbxStart.MouseLeave += new System.EventHandler(this.Efecto2);
            this.pbxStart.MouseHover += new System.EventHandler(this.Efecto);
            // 
            // pbxCerrar
            // 
            this.pbxCerrar.Image = global::SpaceInvaders.Windows.Properties.Resources.Cerrar;
            this.pbxCerrar.Location = new System.Drawing.Point(620, 12);
            this.pbxCerrar.Name = "pbxCerrar";
            this.pbxCerrar.Size = new System.Drawing.Size(52, 50);
            this.pbxCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCerrar.TabIndex = 1;
            this.pbxCerrar.TabStop = false;
            this.pbxCerrar.Tag = "Boton";
            this.pbxCerrar.Click += new System.EventHandler(this.pbxCerrar_Click);
            this.pbxCerrar.MouseLeave += new System.EventHandler(this.CambioCursor2);
            this.pbxCerrar.MouseHover += new System.EventHandler(this.CambioCursor);
            // 
            // timerFondo
            // 
            this.timerFondo.Enabled = true;
            this.timerFondo.Interval = 20;
            this.timerFondo.Tick += new System.EventHandler(this.timerFondo_Tick);
            // 
            // frmTitulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpaceInvaders.Windows.Properties.Resources.titulo___copia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.ControlBox = false;
            this.Controls.Add(this.pbxCerrar);
            this.Controls.Add(this.pbxStart);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "frmTitulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTitulo";
            ((System.ComponentModel.ISupportInitialize)(this.pbxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxStart;
        private System.Windows.Forms.PictureBox pbxCerrar;
        private System.Windows.Forms.Timer timerFondo;
    }
}