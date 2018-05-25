using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class FormInicio: Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }
        public int nivel;
        public int vidas;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            nivel = trackBar1.Value;
            vidas = trackBar2.Value;
            

        }
    }
}
