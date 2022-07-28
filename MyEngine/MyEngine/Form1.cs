using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyEngine.Properties;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;

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
        public Texture текстура = new Texture();
        public bool playerisdye;
        Component1 c = new Component1();
        GameObject[] g1;
        public Point s;
        public bool tr;
        public int e1;
        public Vectorinf vi = new Vectorinf(new float[3]
        {
            0,0,0
        }); public Vectorinf vip = new Vectorinf(new float[3]
        {
            0,0,0
        });
        

        public float rtri;
        public float rquad;
        
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

            OpenGL gl = this.openGLControl1.OpenGL;

            gl.Enable(OpenGL.GL_TEXTURE_2D);

            текстура.Create(gl, Resources.песок_42_3);
            


        }


        Graphics g;
        Point click;
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            g = e.Graphics;
            g1 = c.initAllEnemyes(en);
            // g.DrawRectangle(Pens.Red, 100, 100, 300, 200);


            /*
            for (int i = 0; i < en.Count; i++)
            {
                drawpp2(sender, en[i].ellipsepos1, false, i);
            }*/
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
        {/*
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


            */



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

        

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            {
                /*
                gl.LoadIdentity();

                gl.Translate(1.5f,0f,-6.0f);

                gl.Rotate(rtri,0f,1f,0f);

                gl.Begin(OpenGL.GL_TRIANGLES);

                gl.Color(1f, 0f, 0f);//1
                gl.Vertex(0f, 1f, 0f);
                gl.Color(0f, 1f, 0f);//2
                gl.Vertex(-1f, -1f, 1f);
                gl.Color(0f, 0f, 1f);//3
                gl.Vertex(1f, -1f, 1f);

                gl.Color(1f, 0f, 0f);//1
                gl.Vertex(0f, 1f, 0f);
                gl.Color(0f, 1f, 0f);//2
                gl.Vertex(1f, -1f, 1f);
                gl.Color(0f, 0f, 1f);//3
                gl.Vertex(1f, -1f, -1f);

                gl.Color(1f, 0f, 0f);//1
                gl.Vertex(0f, 1f, 0f);
                gl.Color(0f, 1f, 0f);//2
                gl.Vertex(1f, -1f, -1f);
                gl.Color(0f, 0f, 1f);//3
                gl.Vertex(-1f, -1f, -1f);

                gl.Color(1f, 0f, 0f);//1
                gl.Vertex(0f, 1f, 0f);
                gl.Color(0f, 1f, 0f);//2
                gl.Vertex(-1f, -1f, -1f);
                gl.Color(0f, 0f, 1f);//3
                gl.Vertex(-1f, -1f, 1f);

                gl.End();
                */
            }
            gl.LoadIdentity();

            

            gl.Translate(0f+vip.pos[0], 0f + vip.pos[1], -7.0f + vip.pos[2]);

            gl.Rotate(vi.pos[1], 0, 1, 0);
            gl.Rotate(vi.pos[0], 1, 0, 0);
            gl.Rotate(vi.pos[2], 0, 0, 1);
            текстура.Bind(gl);
            gl.Begin(OpenGL.GL_QUADS);


            gl.Color(1f, 1f, 1f);
            gl.TexCoord(0, 0); gl.Vertex(1, 1, -1);//1
            gl.TexCoord(0, 1); gl.Vertex(-1, 1, -1);
            gl.TexCoord(1, 0); gl.Vertex(-1, 1, 1);
            gl.TexCoord(1, 1); gl.Vertex(1, 1, 1);



            gl.TexCoord(0, 1); gl.Vertex(1, -1, 1);//2
         gl.TexCoord(1, 0);   gl.Vertex(-1, -1, 1);
         gl.TexCoord(1, 1);   gl.Vertex(-1, -1, -1);
         gl.TexCoord(0, 0);   gl.Vertex(1, -1, -1);



            gl.TexCoord(0, 0); gl.Vertex(1, 1, 1);//3
          gl.TexCoord(1, 1);  gl.Vertex(-1, 1, 1);
          gl.TexCoord(1, 0);  gl.Vertex(-1, -1, 1);
          gl.TexCoord(0, 1);  gl.Vertex(1, -1, 1);



            gl.TexCoord(0, 0); gl.Vertex(1, -1, -1);//4
          gl.TexCoord(1, 1);  gl.Vertex(-1, -1, -1);
          gl.TexCoord(1, 0);  gl.Vertex(-1, 1, -1);
          gl.TexCoord(0, 1);  gl.Vertex(1, 1, -1);



            gl.TexCoord(0, 0); gl.Vertex(-1, 1, 1);//5
          gl.TexCoord(1, 1);  gl.Vertex(-1, 1, -1);
          gl.TexCoord(1, 0);  gl.Vertex(-1, -1, -1);
          gl.TexCoord(0, 1);  gl.Vertex(-1,-1, 1);


            
          gl.TexCoord(1, 0);  gl.Vertex(1, 1, -1);//6
          gl.TexCoord(0, 0);  gl.Vertex(1, 1, 1);
          gl.TexCoord(1, 1);  gl.Vertex(1, -1, 1);
          gl.TexCoord(0, 1);  gl.Vertex(1, -1, -1);

            gl.End();

            gl.Flush();

            rtri += 3.0f;
            rquad += 3.0f;
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                vi.pos[1] += 3;
            }
            
            if (e.KeyCode == Keys.D)
            {
                vi.pos[1] -= 3;
            }
            if (e.KeyCode == Keys.X)
            {
                vi.pos[0] += 3;
            }
            if (e.KeyCode == Keys.Z)
            {
                vi.pos[0] -= 3;
            }
            if (e.KeyCode == Keys.Q)
            {
                vi.pos[2] += 3;
            }
            if (e.KeyCode == Keys.E)
            {
                vi.pos[2] -= 3;
            }
            if (e.KeyCode == Keys.W)
            {
                vip.pos[2] += 0.1f;
            }
            if (e.KeyCode == Keys.S)
            {
                vip.pos[2] -=  0.1f;
            }
            switch (e.KeyCode)
            {



                case Keys.Escape:


                    Application.Exit();

                    break;





                case Keys.W:


                    vip.pos[2] += 0.1f;

                    break;
                case Keys.S:
                    vip.pos[2] -= 0.1f;



                    break;
               


            }
        }

       

        
    }
    public class onclear
    {
        public static bool clear;
    }
}
