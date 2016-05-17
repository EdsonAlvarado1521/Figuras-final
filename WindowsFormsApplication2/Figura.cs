using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    abstract class Figura:IComparable
    {
        protected int X;
        protected int Y;
       
        protected int R1, R2, R3, R4;     //coordenadas de las rectas
        protected int P1, P2, P3, P4, P5;  //coordenadas para un poligono
        protected Pen pluma;
        protected int ancho;
        protected int largo;
        protected Color color1,color2;
        protected SolidBrush brocha;

        public Figura(int x, int y, Color c1, Color c2 ) {
            X = x;
            Y = y;
            color1 = c1;
            color2 = c2;
            brocha = new SolidBrush(color1);
            pluma = new Pen(color2, 4);
                
            Random rnd = new Random();
            ancho = rnd.Next(10,60);
            largo = ancho;
            R1 = rnd.Next(20, 300);
            R2 = rnd.Next(20, 300);
            R3 = rnd.Next(20, 300);
            R4 = rnd.Next(20, 300);
            P1 = rnd.Next(20, 500);
            P2 = rnd.Next(20, 500);
            P3 = rnd.Next(20, 500);
            P4 = rnd.Next(20, 500);
            P5 = rnd.Next(20, 500);
        }

        public abstract void Draw(Form f);

        public int CompareTo(object obj)
        {

            return this.largo.CompareTo(((Figura)obj).largo);
        }
    }


    class Rectangulo:Figura
    {
        public Rectangulo(int x, int y, Color c1, Color c2 ):base(x,y, c1, c2)
    	{
        } 

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawRectangle(pluma, this.X, this.Y, ancho, largo);
            g.FillRectangle(brocha, this.X, this.Y, ancho, largo);
        }

    }

    class Circulo : Figura
    {
        public Circulo(int x, int y, Color c1, Color c2) : base(x, y, c1, c2)
        {

        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawEllipse(pluma, this.X, this.Y, ancho, largo);
            g.FillEllipse(brocha, this.X, this.Y, ancho, largo);
        }

    }

    class Recta  : Figura
    {
        public Recta(int x, int y, Color c1, Color c2) : base(x, y, c1, c2)
        {

        }
        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();

            Point coordenada1 = new Point(this.R1, this.R2);
            Point coordenada2 = new Point(this.R3, this.R4);

            GraphicsPath linea = new GraphicsPath();
            linea.AddLine(coordenada1, coordenada2);
            g.DrawPath(pluma, linea);
        }
    }

    class Poligono : Figura
    {
        public Poligono(int x, int y, Color c1, Color c2) : base(x, y, c1, c2)
        {

        }
        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();

            Point punto1 = new Point(this.P1, 100);
            Point punto2 = new Point(this.P2, 50);
            Point punto3 = new Point(this.P3, 200);
            Point punto4 = new Point(this.P4, 350);
            Point punto5 = new Point(this.P5, 300);
            GraphicsPath trazar = new GraphicsPath();
            trazar.AddLine(punto1, punto2);
            trazar.AddLine(punto2, punto3);
            trazar.AddLine(punto3, punto4);
            trazar.AddLine(punto4, punto5);
            trazar.AddLine(punto5, punto1);
            g.DrawPath(pluma, trazar);
            g.FillPath(brocha, trazar);
        }
    }
}
