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

        public List<Enemys> en = new List<Enemys>()
        {
            new Enemys(true),new Enemys(true,new Point(300,64))
        };


        public Point size3 = new Point(30, 20);
        public int x; public int y;
        public Bitmap pipis = Resources.pipis;
        public Bitmap pipis1 = Resources.pipis1;
        public Bitmap pipis2 = Resources.pipis2;
        public Bitmap pipis3 = Resources.pipis3;
        public bool playerisdye;
        GameObject[] g1;
        public Point s;
        public bool tr;
        Component1 c = new Component1();
        public int e1;
        
        bool norm = false;
        List<Enemys> eny(GameObject[] g3)
        {
            List<Enemys> t = new List<Enemys>();
            for (int i = 0; i < g3.Length; i++)
            {
                t.Add((Enemys)g3[i].type);
            }
            return t;
        }

        public Form1()
        {



            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserMouse |
                ControlStyles.FixedHeight |
                ControlStyles.FixedWidth, true);
            UpdateStyles();



        }


        Graphics g;
        Point click;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g1 = c.initAllEnemyes(en);
            // g.DrawRectangle(Pens.Red, 100, 100, 300, 200);



            for (int i = 0; i < en.Count; i++)
            {
                drawpp2(sender, en[i].ellipsepos1, false, i);
            }
        }

        public void drawpp2(object sender, Point newpos, bool isp, int pp)
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



        }
        public void allDraws(object sender)
        {
            g1 = c.initAllEnemyes(en);

            s = new Point(Size.Width, Size.Height);

            for (int i = 0; i < en.Count; i++) {

                if (en[i].ellipsepos1.X > s.X-1)
                {
                    en[i].ellipsepos1.X = 1;
                }
                if (en[i].ellipsepos1.X < 1)
                {
                    en[i].ellipsepos1.X = s.X-1;
                }
                if (en[i].ellipsepos1.Y > s.Y-3)
                {
                    en[i].p3 = false;
                }
                if (en[i].ellipsepos1.Y < en[i].endstene1.X)
                {
                    en[i].p3 = true;
                }
                if (!en[i].isdie && !en[i].isnoai)
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






        }
        public void createpipis()
        {
            Enemys e9 = new Enemys(true, new Point(x, y));
            en.Add(e9);
            norm = true;
            e1 = en.Count - 1;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;

            timer3.Enabled = true;

            if (!playerisdye)
            {
                for (int i = 0; i < en.Count; i++)
                {
                    g1 = c.initAllEnemyes(en);
                    if (click.X > en[i].ellipsepos1.X - size3.X && click.Y > en[i].ellipsepos1.Y - size3.Y && click.X < en[i].ellipsepos1.X + size3.X && click.Y < en[i].ellipsepos1.Y + size3.Y)
                    {
                        norm = !norm;
                        if (norm)
                        {
                            e1 = i;


                        }
                    }




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



                    case Keys.Escape:


                        Application.Exit();

                        break;
                    case Keys.C:


                        createpipis();

                        break;
                    case Keys.X:


                        tr = !tr;

                        break;
                    case Keys.Delete:


                        if (norm)
                        {
                            en[e1].isdie = true;
                            norm = false;
                        }

                        break;
                    case Keys.Back:


                        if (norm)
                        {
                            en[e1].isdel = true;

                            norm = false;
                        }

                        break;
                    case Keys.F1:
                        Enemys s2;
                        Random r = new Random();
                        if (norm)
                        {
                            s2 = en[e1];
                            en[e1] = new Enemys(s2.ellipsepos1, s2.endstene1, r.Next(1, 3));

                            norm = false;
                        }

                        break;
                    case Keys.F2:

                        Random r2 = new Random();
                        if (norm)
                        {
                            s2 = en[e1];
                            en[e1] = new Enemys(s2.ellipsepos1, s2.endstene1,true, r2.Next(1, 3));

                            norm = false;
                        }

                        break;
                    case Keys.Up:


                        killall();

                        break;
                    case Keys.Down:


                        Delall();

                        break;

                }
            }


        }
        public void killall()
        {
            for (int i = 0; i < en.Count; i++)
            {
                en[i].isdie = true;
            }
            norm = false;
        }
        public void Delall()
        {
            for (int i = 0; i < en.Count; i++)
            {
                en[i].isdel = true;
            }
            norm = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           var p = PointToClient(Cursor.Position);
            x = p.X - size3.X/2; y = p.Y - size3.Y / 2;
            label1.Text = "[x] " + x.ToString(); 
            label2.Text = "[y] " + y.ToString();
            allDraws(sender);
            s = new Point(Size.Width, Size.Height);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random(); if (norm) {
                en[e1].ellipsepos1.X = x;
                en[e1].ellipsepos1.Y = y;
            }
            if (tr)
            {
                Location = new Point(r.Next(-1, 2) + Location.X, r.Next(-1, 2) + Location.Y);
            }
            for (int i = 0; i < en.Count; i++)
            {
                g1 = c.initAllEnemyes(en);
                Enemys s;
                if (en[i].isdel)
                {
                    s = en[i];
                    en.RemoveAt(i);
                }
            }
            Refresh();
            label3.Location = new Point(s.X - 70, s.Y - 70);
            label4.Location = new Point(s.X - 70, s.Y - 90);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < en.Count; i++)
            {
                g1 = c.initAllEnemyes(en);
                Enemys s;
                if (en[i].isdie)
                {
                    s = en[i];
                    en.RemoveAt(i);
                    en.Add(new Enemys(s.ellipsepos1, s.endstene1,r.Next(1,3)));
                    en.Add(new Enemys(s.ellipsepos1, s.endstene1,true, r.Next(1, 3)));
                }
            }
            
            timer3.Enabled = false;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            createpipis();
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            tr = !tr;
        }
    }
    public class onclear
    {
        public static bool clear;
    }
}
