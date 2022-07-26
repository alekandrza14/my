using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyEngine.Properties;

namespace MyEngine
{
    public partial class Form1 : Form
    {
        public Point ellipsepos = new Point(100, 100);
        public Point startpos = new Point(100, 100);
        public List<Enemys> en = new List<Enemys>()
        {
            new Enemys(),
            new Enemys(new Point(10,300),new Point(1, 488)),
            new Enemys(new Point(100,200),new Point(100,250),true,3),
            new Enemys(new Point(200,300),new Point(1, 488),true),
            new Enemys(new Point(50,250),new Point(1, 488),3)
        }; public List<Enemys> starten = new List<Enemys>()
        {
            new Enemys(),
            new Enemys(new Point(10,300),new Point(1, 488)),
            new Enemys(new Point(100,200),new Point(100,250),true,3),
            new Enemys(new Point(200,300),new Point(1, 488),true),
            new Enemys(new Point(50,250),new Point(1, 488),3)
        };

        public Point size3 = new Point(30,20);
        public int xp; public int bestxp;
        public Bitmap pipis = Resources.pipis;
        public Bitmap pipis1 = Resources.pipis1;
        public Bitmap pipis2 = Resources.pipis2;
        public Bitmap pipis3 = Resources.pipis3;
        public bool playerisdye;


        public Form1()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint|
                ControlStyles.UserPaint | 
                ControlStyles.ResizeRedraw | 
                ControlStyles.UserMouse | 
                ControlStyles.FixedHeight | 
                ControlStyles.FixedWidth, true);
            UpdateStyles();
            
            if (File.Exists("bestxp"))
            {
                bestxp = int.Parse(File.ReadAllText("bestxp"));
            }
        }
        Graphics g;
        Point click;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            // g.DrawRectangle(Pens.Red, 100, 100, 300, 200);

            

            drawpp2(sender, ellipsepos,true,0); for (int i = 0; i < en.Count; i++)
            {
                drawpp2(sender, en[i].ellipsepos1, false,i);
            }
        }

        public void drawpp2(object sender,Point newpos,bool isp,int pp)
        {

            Rectangle r = new Rectangle(newpos.X, newpos.Y, 30, 20);
            
                if (!en[pp].isdie)
                {


                    g.DrawImage(pipis, r);
                }
                if (en[pp].isdie)
                {


                    g.DrawImage(pipis1, r);
                }
            
            if (isp)
            {
                if (!playerisdye)
                {

                    g.DrawImage(pipis2, r);
                }
                if (playerisdye)
                {

                    g.DrawImage(pipis3, r);
                }
            }
           
        }
        public void allDraws(object sender)
        {

            starten = new List<Enemys>()
        {
            new Enemys(),
            new Enemys(new Point(10,300),new Point(1, 488)),
            new Enemys(new Point(100,200),new Point(100,250),true,3),
            new Enemys(new Point(200,300),new Point(1, 488),true),
            new Enemys(new Point(50,250),new Point(1, 488),3)
        };

            for (int i = 0;i<en.Count; i++) {
                if (ellipsepos.X > en[i].ellipsepos1.X - size3.X && ellipsepos.Y > en[i].ellipsepos1.Y - size3.Y && ellipsepos.X < en[i].ellipsepos1.X + size3.X && ellipsepos.Y < en[i].ellipsepos1.Y + size3.Y)
                {
                    playerisdye = true;
                    
                    return;
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
                if (!en[i].isdie)
                {

                
                if (!en[i].rot)
                {


                    en[i].ellipsepos1.X += en[i].speed;
                }
                if (en[i].rot)
                {


                    en[i].ellipsepos1.X -= en[i].speed;
                    }
                if (en[i].p3)
                       
                {


                    en[i].ellipsepos1.Y += en[i].speed;
                    }
                    if (!en[i].p3)
                    {


                        en[i].ellipsepos1.Y -= en[i].speed;
                    }
                }
                
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
            

            
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;

            timer3.Enabled = true;
            bool norm = true;
            if (!playerisdye)
            {
                for (int i = 0; i < en.Count; i++)
                {
                    if (click.X > en[i].ellipsepos1.X - size3.X && click.Y > en[i].ellipsepos1.Y - size3.Y && click.X < en[i].ellipsepos1.X + size3.X && click.Y < en[i].ellipsepos1.Y + size3.Y)
                    {
                        en[i].isdie = true;
                        norm = false;
                        xp += 500;
                    }



                }
                if (norm)
                {
                    ellipsepos = center(click);
                }
            }

        }
        public Point center(Point click)
        {
            click.X -= size3.X / 2;
            click.Y -= size3.Y / 2;
            return click;
        }
            private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!playerisdye)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        ellipsepos.X -= 6;
                        break;
                    case Keys.D:

                        ellipsepos.X += 6;
                        break;
                    case Keys.W:

                        ellipsepos.Y -= 6;
                        break;
                    case Keys.S:

                        ellipsepos.Y += 6;
                        break;
                    case Keys.Left:
                        ellipsepos.X -= 6;
                        break;
                    case Keys.Right:

                        ellipsepos.X += 6;
                        break;
                    case Keys.Up:

                        ellipsepos.Y -= 6;
                        break;
                    case Keys.Down:

                        ellipsepos.Y += 6;
                        break;


                    case Keys.Escape:


                        Application.Exit();

                        break;
                }
            }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!playerisdye)
            {
                xp++;
            }
            if (bestxp < xp)
            {
                bestxp = xp;
                File.WriteAllText("bestxp",bestxp.ToString());
            }
            label1.Text = "[xp] " + xp.ToString(); 
            label2.Text = "[bestxp] " + bestxp.ToString();
            allDraws(sender);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

           Location =new Point(r.Next(-1, 2) + Location.X, r.Next(-1, 2) + Location.Y);
            Refresh();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < en.Count; i++)
            {
                Enemys s;
                if (en[i].isdie)
                {
                    s = en[i];
                    en.RemoveAt(i);
                    en.Add(new Enemys(s.ellipsepos1, s.endstene1,r.Next(1,3)));
                    en.Add(new Enemys(s.ellipsepos1, s.endstene1,true, r.Next(1, 3)));
                }
            }
            if (playerisdye == true)
            {
                en = starten;
                ellipsepos = startpos;
                xp = 0;
                playerisdye = false;
            }
            timer3.Enabled = false;
            
        }

       
    }
    public class onclear
    {
        public static bool clear;
    }
}
