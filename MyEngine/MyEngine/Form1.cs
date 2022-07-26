using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyEngine
{
    public partial class Form1 : Form
    {
        public Point ellipsepos = new Point(100, 100);
        public Point startpos = new Point(100, 100);
        public Enemys[] en = new Enemys[]
        {
            new Enemys(),
            new Enemys(new Point(10,300),new Point(200,300)),
            new Enemys(new Point(100,200),new Point(100,250),true),
            new Enemys(new Point(50,250),new Point(150,300))
        };
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Point click;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            g.Clear(Color.Black);

            // g.DrawRectangle(Pens.Red, 100, 100, 300, 200);

            allDraws(sender);



        }
       
        public void drawpp2(object sender,Point newpos)
        {
            g.DrawEllipse(Pens.Red, newpos.X, newpos.Y, 30, 20);
            g.FillEllipse(Brushes.Aqua, newpos.X, newpos.Y, 30, 20);
        }
        public void allDraws(object sender)
        {
            for (int i = 0;i<en.Length;i++) {
                if (ellipsepos.X > en[i].ellipsepos1.X - 30 && ellipsepos.Y > en[i].ellipsepos1.Y - 30 && ellipsepos.X < en[i].ellipsepos1.X + 30 && ellipsepos.Y < en[i].ellipsepos1.Y + 30)
                {
                    ellipsepos = startpos;
                }
                if (en[i].ellipsepos1.X > en[i].endstene.X)
                {
                    en[i].ellipsepos1.X = 1;
                }
                if (en[i].ellipsepos1.X < 1)
                {
                    en[i].ellipsepos1.X = en[i].endstene.X;
                }
                if (en[i].ellipsepos1.Y > en[i].endstene1.Y)
                {
                    en[i].p3 = false;
                }
                if (en[i].ellipsepos1.Y < en[i].endstene1.X)
                {
                    en[i].p3 = true;
                }
                if (!en[i].rot)
                {


                    en[i].ellipsepos1.X += 1;
                }
                if (en[i].rot)
                {


                    en[i].ellipsepos1.X -= 1;
                }
                if (en[i].p3)
                       
                {


                    en[i].ellipsepos1.Y += 1;
                }
                if (!en[i].p3)
                {


                    en[i].ellipsepos1.Y -= 1;
                }
                drawpp2(sender, en[i].ellipsepos1);
            }
            if (ellipsepos.X > 815)
            {
                ellipsepos.X = 1;
            }
            if (ellipsepos.X < 1)
            {
                ellipsepos.X = 815;
            }
            if (ellipsepos.Y > 488)
            {
                ellipsepos.Y = 1;
            }
            if (ellipsepos.Y < 1)
            {
                ellipsepos.Y = 488;
            }
            drawpp2(sender, ellipsepos);
           
            

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;
            
            g.Clear(Color.Black);

            ellipsepos = click;
            allDraws(sender);


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            g = CreateGraphics();
            g.Clear(Color.Black);
            switch (e.KeyCode)
            {
                case Keys.A:
                    ellipsepos.X -= 2;
                    break;
                case Keys.D:

                    ellipsepos.X += 2;
                    break;
                case Keys.W:

                    ellipsepos.Y -= 2;
                    break;
                case Keys.S:

                    ellipsepos.Y += 2;
                    break;
            }

            allDraws(sender);
        }

        
    }
    public class onclear
    {
        public static bool clear;
    }
}
