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
    public partial class Form1 : Form
    {
        int rei = 0;
        bool ganador = false;
        //bool goUp;
        //bool goDown;
        bool derecha = true;
        bool izquierda = false;
        bool final = false;
        int cantidad = 50;
        List<Control> lista;
        string playerName = "";
        int puntoY = 12;
        int puntoX = 622;
        bool goLeft;
        bool goRight;
        int speed = 6;
        int vida = 5;
        int playerSpeed = 6;
        int score = 0;
        bool isPressed;
        int totalEnemies = 12;
        int vecesJugado = 0;
        int scoreAnterior = 0;
        Image fondo;
        PictureBox background;

        public Form1()
        {
            InitializeComponent();
            lblLevel.Text = "Level = 1";
            NaveFinal.Visible = false;
            NaveFinal.Tag = null;
            fondo = Properties.Resources.fondo1;
            //CrearFondo(fondo);
            player.BringToFront();

        }

        private void CrearFondo(Image fondo)
        {
            background = new PictureBox();
            background.Image = fondo;
            //this.BackgroundImage = fondo;
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            background.Size = new Size(700, 500);
            background.Location = new Point(0, 0);
            Controls.Add(background);
            background.BringToFront();

        }

        private void ContarEnemigos()
        {
            lista = new List<Control>();
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "invader")
                {
                    lista.Add(x);
                }
            }
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Up)
            //{
            //    goUp = true;
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    goDown = true;
            //}


            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && player.Left < 650)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                makeBullet();
            }
        }

        internal int GetReinicio()
        {
            return rei;
        }

        internal Image GetFondo()
        {
            return fondo;
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    goUp = false;
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    goDown = false;
            //}

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (isPressed)
            {
                isPressed = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (goUp)
            //{
            //    player.Top -= playerSpeed;
            //}
            //else if (goDown)
            //{
            //    player.Top += playerSpeed;
            //}


            //player movimiento izquierda y derecha
            if (goLeft)
            {
                player.Left -= playerSpeed;
            }
            else if (goRight)
            {
                player.Left += playerSpeed;
            }
            if (player.Left < 0)
            {
                goLeft = false;
            }
            if (player.Left > 650)
            {
                goRight = false;
            }
            //movimiento de los enemigos
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "invader")
                {
                    x.BringToFront();
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        gameOver();
                        MessageBox.Show("Has perdido, la Tierra fue destruida");
                        MessageBox.Show($"Victorias : {vecesJugado}");
                        this.Close();
                    }
                    ((PictureBox)x).Left += speed;
                    if (((PictureBox)x).Left > 720)
                    {
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;
                        ((PictureBox)x).Left = -50;
                    }
                }
                if (x is PictureBox && x.Tag == "Final")
                {

                    x.BringToFront();
                    if (((PictureBox)x).Left < 0)
                    {
                        ((PictureBox)x).Left += speed;
                        derecha = true;
                        izquierda = false;
                    }
                    if (((PictureBox)x).Left + ((PictureBox)x).Width > 700)
                    {
                        ((PictureBox)x).Left -= speed;
                        derecha = false;
                        izquierda = true;
                    }
                    if (derecha)
                    {
                        ((PictureBox)x).Left += speed;
                    }
                    if (izquierda)
                    {
                        ((PictureBox)x).Left -= speed;

                    }
                }

            }

            //movimiento de las balas
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "Bullet")
                {
                    y.Top -= 20;
                    if (((PictureBox)y).Top < this.Height - 490)
                    {
                        this.Controls.Remove(y);
                    }
                }
            }
            if (final)
            {
                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && y.Tag == "Ataque")
                    {
                        if (y.Bounds.IntersectsWith(player.Bounds))
                        {
                            gameOver();
                            MessageBox.Show("Tu has muerto, la Tierra fue destruida");
                        }

                    }
                    if (y is PictureBox && y.Tag == "Ataque")
                    {
                        y.Top += 10;
                        if (((PictureBox)y).Top < this.Height - 490)
                        {
                            this.Controls.Remove(y);
                        }
                    }
                }
            }


            //colision de balas con el enemigo
            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "invader")
                    {
                        if (j is PictureBox && j.Tag == "Bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                this.Controls.Remove(i);
                                this.Controls.Remove(j);

                            }
                        }
                    }
                    if (i is PictureBox && i.Tag == "Ataque")
                    {
                        if (j is PictureBox && j.Tag == "Bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                this.Controls.Remove(i);
                                this.Controls.Remove(j);

                            }
                        }
                    }
                    if (i is PictureBox && i.Tag == "Final")
                    {
                        if (j is PictureBox && j.Tag == "Bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                this.Controls.Remove(j);
                                vida--;
                                if (vida == 0)
                                {
                                    this.Controls.Remove(i);
                                    gameOver();
                                    MessageBox.Show("Tu salvaste la Tierra");
                                    fondo = Properties.Resources.fondo3;
                                    ganador = true;
                                    timer2.Start();

                                }
                            }
                        }
                    }

                }
            }

            //generar score
            label1.Text = $"Score : {score}";
            if (totalEnemies == 12)
            {
                if (score > totalEnemies - 1)
                {
                    gameOver();
                    MessageBox.Show("Tu salvaste la Tierra");
                    DialogResult dr = MessageBox.Show("Desea reiniciar el juego?", "Game Over", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ReiniciarJuego();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            else
            {
                if (score == cantidad + scoreAnterior)
                {
                    gameOver();
                    MessageBox.Show($"{playerName} ¡Tu salvaste la Tierra!");
                    DialogResult dr = MessageBox.Show("Desea reiniciar el juego?", "Game Over", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ReiniciarJuego();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }

        private void ReiniciarJuego()
        {
            vecesJugado++;
            lblLevel.Text = $"Level = {vecesJugado + 1}";
            timer1.Start();
            player.Location = new Point(271, 411);
            speed += 5;
            scoreAnterior = score;
            totalEnemies += 3;
            if (vecesJugado < 5)
            {
                CrearEnemigos();
                ContarEnemigos();
                cantidad = lista.Count();
            }
            else
            {
                JefeFinal();
                MessageBox.Show("Preparate, la Nave Final ha llegado!!!", "FINAL");
            }

        }

        private void JefeFinal()
        {
            fondo = Properties.Resources.fondo2;
            //CrearFondo(fondo);
            player.BringToFront();
            NaveFinal.Tag = "Final";
            final = true;
            timer2.Start();
            NaveFinal.Visible = true;
            NaveFinal.BringToFront();
        }

        private void CrearEnemigos()
        {
            puntoY = 12;
            puntoX = 622;
            for (int i = 0; i < totalEnemies; i++)
            {
                PictureBox enemigo = new PictureBox();
                enemigo.Image = Properties.Resources.enemies;
                enemigo.SizeMode = PictureBoxSizeMode.Zoom;
                enemigo.BackColor = Color.Transparent;
                enemigo.Size = new Size(50, 50);
                enemigo.Tag = "invader";
                if (puntoX >= 6)
                {
                    Point enemigoposicion = new Point(puntoX, puntoY);
                    enemigo.Location = enemigoposicion;
                }
                else
                {
                    puntoY += 50;
                    puntoX = 622;
                    Point enemigoposicion = new Point(puntoX, puntoY);
                    enemigo.Location = enemigoposicion;
                }
                puntoX -= 50;
                enemigo.BringToFront();
                this.Controls.Add(enemigo);
                enemigo.BringToFront();

            }
        }

        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet21;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.BackColor = Color.Red;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "Bullet";
            bullet.Left = player.Left + player.Width / 2;
            bullet.Top = player.Top - 20;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        public void AtaqueFinal()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet21;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.BackColor = Color.Blue;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "Ataque";
            bullet.Left = NaveFinal.Left;
            bullet.Top = NaveFinal.Top + 100;
            this.Controls.Add(bullet);
            bullet.BringToFront();

            PictureBox bala = new PictureBox();
            bala.Image = Properties.Resources.bullet21;
            bala.SizeMode = PictureBoxSizeMode.StretchImage;
            bala.BackColor = Color.Blue;
            bala.Size = new Size(5, 20);
            bala.Tag = "Ataque";
            bala.Left = NaveFinal.Left + NaveFinal.Width;
            bala.Top = NaveFinal.Top + 100;
            this.Controls.Add(bala);
            bala.BringToFront();

            PictureBox medio = new PictureBox();
            medio.Image = Properties.Resources.bullet21;
            medio.SizeMode = PictureBoxSizeMode.StretchImage;
            medio.BackColor = Color.Blue;
            medio.Size = new Size(5, 20);
            medio.Tag = "Ataque";
            medio.Left = NaveFinal.Left + NaveFinal.Width / 2;
            medio.Top = NaveFinal.Top + 100;
            this.Controls.Add(medio);
            medio.BringToFront();
        }

        private void gameOver()
        {
            timer1.Stop();
            timer2.Stop();
            label1.Text += " Game Over";
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ganador)
            {
                player.Location = new Point(320, 180);
                foreach (Control item in this.Controls)
                {
                    if (item is PictureBox && item.Tag == "Ataque")
                    {
                        this.Controls.Remove(item);
                    }
                }
                rei = 5;
                GetReinicio();
                this.Close();


            }

            if (!ganador)
            {
                if (final)
                {
                    AtaqueFinal();
                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && y.Tag == "Ataque")
                        {
                            y.Top += 10;
                            if (((PictureBox)y).Top < this.Height - 490)
                            {
                                this.Controls.Remove(y);
                            }
                        }
                        if (y is PictureBox && y.Tag == "Ataque")
                        {
                            if (y.Bounds.IntersectsWith(player.Bounds))
                            {
                                gameOver();
                                MessageBox.Show("Tu has muerto, la Tierra fue destruida");
                            }

                        }
                    }
                }
            }

        }
    }
}
