using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        enum TipoFigura  {Rectangulo, Circulo, Recta, Poligono};
        private Color relleno, contorno;
        private TipoFigura figura_actual; 
        private List<Figura> rectangulos;
        

        public Form1()
        {
            figura_actual = TipoFigura.Circulo;
            relleno = Color.AliceBlue;
            contorno = Color.Black;
            rectangulos = new List<Figura>();
            InitializeComponent();
           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if (figura_actual == TipoFigura.Circulo)
            {
                Circulo c = new Circulo(e.X, e.Y, relleno, contorno);
                c.Draw(this);
                rectangulos.Add(c);
            }
            else if (figura_actual == TipoFigura.Rectangulo)
            {
                Rectangulo r = new Rectangulo(e.X, e.Y, relleno, contorno);
                r.Draw(this);
                rectangulos.Add(r);
            }
            else if (figura_actual == TipoFigura.Recta)
            {
                Recta rt = new Recta(e.X, e.Y, relleno, contorno);
                rt.Draw(this);
                rectangulos.Add(rt);
            }
            else if (figura_actual == TipoFigura.Poligono)
            {
                Poligono p = new Poligono(e.X, e.Y, relleno, contorno);
                p.Draw(this);
                rectangulos.Add(p);
            }
            
          

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Polimorfismo
            foreach (Figura r in rectangulos)
                r.Draw(this);
        }

        

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

       
        

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            figura_actual = TipoFigura.Circulo;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            figura_actual = TipoFigura.Rectangulo;
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            figura_actual = TipoFigura.Recta;
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            figura_actual = TipoFigura.Poligono;
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            rectangulos.Clear();
            this.Refresh();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            rectangulos.Sort();
            rectangulos.Reverse();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ColorDialog color1 = new ColorDialog();
            color1.ShowDialog();
            relleno = color1.Color;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ColorDialog color2 = new ColorDialog();
            color2.ShowDialog();
            contorno = color2.Color;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
