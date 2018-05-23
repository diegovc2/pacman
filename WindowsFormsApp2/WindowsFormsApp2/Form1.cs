using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        int timer = 0;
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        private bool parado;
        int speed = 5;

        int ghost1 = 6;
        int ghost2 = 8;

        int ghost3x = 8;
        int ghost3y = 8;

        int score = 0;
        private bool azul;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                goright = false;
                goup = false;
                godown = false;
                pacman.Image = Properties.Resources.Right;

            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;

                goleft = false;
                goup = false;
                godown = false;
                pacman.Image = Properties.Resources.Left;
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                goleft = false;
                goright = false;
                godown = false;
                pacman.Image = Properties.Resources.Up;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                goleft = false;
                goright = false;
                goup = false;
                pacman.Image = Properties.Resources.down;
            }
        }



        /* private void Form1_KeyUp(object sender, KeyEventArgs e)
         {
             if(e.KeyCode== Keys.Left)
             {
                 goleft = false;
             }

             if (e.KeyCode == Keys.Right)
             {
                 goright = false;
             }

             if (e.KeyCode == Keys.Up)
             {
                 goup = false;
             }

             if (e.KeyCode == Keys.Down)
             {
                 godown = false;
             }
         }
         */



        private void timer1_Tick(object sender, EventArgs e)
        {
            //LEYES FANTASMAS AZULES
            if (azul)
            {
                timer++;
                label1.Text = timer.ToString();
                if (timer == 100)
                {
                    foreach (Control c in Controls)
                    {
                        //CAMBIA A FLASH
                        if (c is PictureBox && c.Tag == "ghost")
                        {
                            PictureBox p = c as PictureBox;
                            p.Image = WindowsFormsApp2.Properties.Resources.ezgif_5_55e31f897e;
                        }

                    }

                }
                //CAMBIA A NORMAL
                if(timer>=250)
                {
                    foreach (Control c in Controls)
                    {
                        if (c is PictureBox && c.Tag == "ghost")
                        {
                            PictureBox p = c as PictureBox;
                            if (p.Name=="pinkGhost")
                            {
                                p.Image= WindowsFormsApp2.Properties.Resources.pink_guy;
                            }
                            if (p.Name == "redGhost")
                            {
                                p.Image = WindowsFormsApp2.Properties.Resources.red_guy;
                            }
                            if (p.Name == "yellowGhost")
                            {
                                p.Image = WindowsFormsApp2.Properties.Resources.yellow_guy;
                            }
                            if (p.Name == "blueGhost")
                            {
                                p.Image = WindowsFormsApp2.Properties.Resources.Pacman_light_blue_inky_sh_600x600;
                            }
                        }

                    }
                    timer = 0;
                    azul = false;
                }

                


            }


            //Para reaparecer por los bordes

            if (pacman.Right > ClientSize.Width)
            {
                pacman.Left = 0;
            }


            if (pacman.Right <= 0)
            {
                pacman.Left = ClientSize.Width - pacman.Bounds.Width;
            }

            if (pacman.Bottom < 0)
            {
                pacman.Top = ClientSize.Height - pacman.Height;
            }

            if (pacman.Top > ClientSize.Height)
            {
                pacman.Top = 0;
            }

            if (pinkGhost.Bottom < 0)
            {
                pinkGhost.Top = ClientSize.Height - pinkGhost.Height;
            }

            if (pinkGhost.Top > ClientSize.Height)
            {
                pinkGhost.Top = 0;
            }

            if (pinkGhost.Right > ClientSize.Width)
            {
                pinkGhost.Left = 0;
            }


            if (pinkGhost.Right <= 0)
            {
                pinkGhost.Left = ClientSize.Width - pinkGhost.Bounds.Width;
            }


            if (redGhost.Right > ClientSize.Width)
            {
                redGhost.Left = 0;
            }


            if (redGhost.Right <= 0)
            {
                redGhost.Left = ClientSize.Width - redGhost.Bounds.Width;
            }


            if (yellowGhost.Right > ClientSize.Width)
            {
                yellowGhost.Left = 0;
            }


            if (yellowGhost.Right <= 0)
            {
                yellowGhost.Left = ClientSize.Width - yellowGhost.Bounds.Width;
            }

            if (blueGhost.Right > ClientSize.Width)
            {
                blueGhost.Left = 0;
            }


            if (blueGhost.Right <= 0)
            {
                blueGhost.Left = ClientSize.Width - blueGhost.Bounds.Width;
            }



            //PUNTAJE

            // label1.Text = "Score: " + score;


            //CONTROL PACMAN

            colisionpac.Left = pacman.Left - 10;
            colisionpac.Top = pacman.Top - 10;

            if (goleft || goup || godown || goright)
            {
                parado = false;

            }

            if (goleft)
            {
                pacman.Left -= speed;
            }

            if (goright)
            {
                pacman.Left += speed;
            }

            if (goup)
            {
                pacman.Top -= speed;
            }

            if (godown)
            {
                pacman.Top += speed;
            }

            foreach (Control x in Controls)
                if (x is PictureBox)
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds)
                        && (x.Tag == "wallhor" || x.Tag == "wallvert") && !parado)
                    {
                        parado = true;
                        if (goright && pacman.Right >= (x.Left))
                        {
                            pacman.Left = x.Left - pacman.Width;
                            goright = false;
                        }

                        if (goleft && pacman.Left <= (x.Right))
                        {
                            pacman.Left = x.Left + pacman.Width;
                            goleft = false;
                        }

                        if (goup && pacman.Top <= x.Bottom)
                        {
                            pacman.Top = x.Top + pacman.Height;
                        }

                        if (godown && pacman.Bottom >= x.Top)
                        {
                            pacman.Top = x.Top - pacman.Height;
                        }







                    }
                }

            //Moneda Grande



            redGhost.Left += ghost1;
            yellowGhost.Left += ghost2;
            blueGhost.Left += ghost2;

            if (redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) ||
                redGhost.Bounds.IntersectsWith(pictureBox4.Bounds) ||
                redGhost.Bounds.IntersectsWith(pictureBox5.Bounds) ||
                redGhost.Bounds.IntersectsWith(pictureBox6.Bounds)
                )
            {
                ghost1 = -ghost1;
            }

            if (yellowGhost.Bounds.IntersectsWith(pictureBox1.Bounds) ||
                yellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds) ||
                yellowGhost.Bounds.IntersectsWith(pictureBox5.Bounds) ||
                yellowGhost.Bounds.IntersectsWith(pictureBox6.Bounds) ||
                blueGhost.Bounds.IntersectsWith(pictureBox1.Bounds) ||
                blueGhost.Bounds.IntersectsWith(pictureBox4.Bounds) ||
                blueGhost.Bounds.IntersectsWith(pictureBox5.Bounds) ||
                blueGhost.Bounds.IntersectsWith(pictureBox6.Bounds)
                )
            {
                ghost2 = -ghost2;
            }

            foreach (Control x in this.Controls)
            {
                //MUERTE POR FANTASMA


                if (x is PictureBox && x.Tag == "ghost")
                {
                    /*if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                        {
                        pacman.Left = 0;
                        pacman.Top = 25;
                        label2.Text = "Game Over";
                        label2.Visible = true;
                        timer1.Stop();
                    }
                    */


                }

                //Recogida Monedas

                if (x is PictureBox && x.Tag == "coin")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        score++;

                    }

                }

                //CHEQUEAR POWERPELLET
                if (x is PictureBox && x.Tag == "monGrande")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        score++;
                        azul = true;

                        foreach (Control c in Controls)
                        {
                            if (c is PictureBox)
                            {


                                PictureBox o = c as PictureBox;
                                if (c.Tag == "ghost")
                                {

                                    o.Image = WindowsFormsApp2.Properties.Resources.fantasma;
                                }
                            }
                        }


                    }

                }




            }

            pinkGhost.Left += ghost3x;
            pinkGhost.Top += ghost3y;

            if (pinkGhost.Left < 1 ||
                pinkGhost.Left + pinkGhost.Width > ClientSize.Width - 2 ||
                pinkGhost.Bounds.IntersectsWith(pictureBox1.Bounds) ||
                pinkGhost.Bounds.IntersectsWith(pictureBox4.Bounds) ||
                pinkGhost.Bounds.IntersectsWith(pictureBox5.Bounds) ||
                pinkGhost.Bounds.IntersectsWith(pictureBox6.Bounds)
                )
            {
                ghost3x = -ghost3x;
            }

            if (pinkGhost.Top < 1 ||
                pinkGhost.Top + pinkGhost.Height > ClientSize.Height - 2
                )
            {
                ghost3x = -ghost3x;
            }
        }


    }
}
