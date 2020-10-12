using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders.Windows
{
    public partial class frmTitulo : Form
    {
        PictureBox background;
        bool jugando;
        Form1 Juego = new Form1();
        Image fondo;

        public frmTitulo()
        {
            InitializeComponent();

            timerFondo.Stop();
        }
        private void CrearFondo(Image fondo)
        {
            background = new PictureBox();
            background.Image = fondo;
            //this.BackgroundImage = fondo;
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            background.Size = new Size(700, 500);
            background.Tag = "FONDO";
            background.Location = new Point(0, 0);
            Controls.Add(background);
            background.BringToFront();
            if (reiniciar==5)
            {
                Controls.Remove(background);
                jugando = false;
                fondo = null;
            }
        }
        private void Efecto(object sender, EventArgs e)
        {
            pbxStart.BorderStyle = BorderStyle.Fixed3D;
            this.Cursor = Cursors.Hand;
        }

        private void Efecto2(object sender, EventArgs e)
        {
            pbxStart.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void pbxStart_Click(object sender, EventArgs e)
        {
            jugando = true;
            timerFondo.Start();
            DialogResult dr = Juego.ShowDialog(this);

        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CambioCursor(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;

        }

        private void CambioCursor2(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }
        int reiniciar = 0;
        private void timerFondo_Tick(object sender, EventArgs e)
        {
            reiniciar = Juego.GetReinicio();

            if (jugando)
            {
                fondo = Juego.GetFondo();
                CrearFondo(fondo);
                this.Location = Juego.Location;
            }
            if (!jugando)
            {
                foreach (Control x in this.Controls)
                {
                    if (x.Tag!="Boton")
                    {
                        this.Controls.Remove(x);

                    }
                }
            }
        }
    }
}
