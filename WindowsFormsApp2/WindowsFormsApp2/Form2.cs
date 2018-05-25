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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static int vidas;
        public static int nivel;
      

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            /* vidas = trackBar1.Value;
             nivel = trackBar2.Value;
             Form1 juego = new Form1();
             juego.Show();
             this.Close();*/
        }

        private void Foo(object sender, EventArgs e)
        {

            vidas = trackBar1.Value;
            nivel = trackBar2.Value;
            Program.OpenDetailFormOnClose = true;

            this.Close();
        }
    }

}


