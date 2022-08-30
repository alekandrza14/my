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
using ObjParser;

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
        public Texture hah = new Texture();
        public bool playerisdye;
        Component1 c = new Component1();
        List<GameObject> g1 = new List<GameObject>();
        public Point s;
        public bool tr;
        public int e1;
        public int cs;
        public bool phon;
        public List<ObjParser.Types.Vertex> v = new List<ObjParser.Types.Vertex>();
        public List<ObjParser.Types.Face> f = new List<ObjParser.Types.Face>();
        public List<ObjParser.Types.TextureVertex> vt = new List<ObjParser.Types.TextureVertex>();
        public float oldpos;
        public float bgup = -20; public float bgsizex = 15; public float bgsizey = 8;

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

            текстура.Create(gl, "ресурсы/texurecube.png");
            hah.Create(gl, "ресурсы/hah.png");


            var Obj = new Obj();
            Obj.LoadObj("ресурсы/cube.obj1");
            Console.WriteLine(Obj.VertexList.Count.ToString());
            v = Obj.VertexList;
            f = Obj.FaceList;
            vt = Obj.TextureList;
            bgup *= 5;
            bgsizey *= 5;
            bgsizex *= 5;
        }


        Graphics g;
        Point click;
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            g = e.Graphics;
            
        }

        




        
       

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;

            timer3.Enabled = true;

            if (!playerisdye)
            {
                for (int i = 0; i < en.Count; i++)
                {
                    
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

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Enable(OpenGL.GL_BLEND); 

            gl.Translate(-5f, -3.5f, -16f);
            
            
            текстура.Bind(gl);
            NewMethod(gl);

            gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);


            gl.Color(1f, 1f, 1f);

            if (cs == 3)
            {

                gl.Color(0f, 1f, 1f);
            }
            switch (cs)
            {
                case 0:
                    NewMethod1(gl);
                    break;
                case 1:
                    NewMethod1(gl);
                    break;
                case 2:
                    NewMethod1(gl);
                    break;
                case 3:
                    NewMethod1(gl);
                    break;
                case 4:
                    NewMethod1(gl);
                    break;
                case 5:
                    NewMethod1(gl);
                    break;
            }

            gl.End();

            
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Enable(OpenGL.GL_BLEND);
            

            NewMethod2(gl);


            
           

            gl.LoadIdentity();
            gl.Translate(0f, 0f, bgup);
            hah.Bind(gl);


            if (!phon) {
                gl.Begin(OpenGL.GL_QUADS);

                



                gl.Color(1f, 1f, 1f);


                gl.TexCoord(0.5f + 0.5f, -0.5f + 0.5f); gl.Vertex(-bgsizex, bgsizey, 0f);
                gl.TexCoord(-0.5f + 0.5f, -0.5f + 0.5f); gl.Vertex(bgsizex, bgsizey, 0f);
                gl.TexCoord(-0.5f + 0.5f, 0.5f + 0.5f); gl.Vertex(bgsizex, -bgsizey, 0f);
                gl.TexCoord(0.5f + 0.5f, 0.5f + 0.5f); gl.Vertex(-bgsizex, -bgsizey, 0f);



                gl.End();
            }
           
            gl.Flush();

            rtri += 3.0f;
            rquad += 3.0f;
        }

        private void NewMethod1(OpenGL gl)
        {
            for (int i = 0; i < f.Count; i++)
            {

                for (int i2 = 0; i2 < f[i].VertexIndexList.Length; i2++)
                {






                    gl.TexCoord(vt[f[i].TextureVertexIndexList[i2] - 1].X, vt[f[i].TextureVertexIndexList[i2] - 1].Y);



                    gl.Vertex(v[f[i].VertexIndexList[i2] - 1].X, v[f[i].VertexIndexList[i2] - 1].Y, v[f[i].VertexIndexList[i2] - 1].Z+7);

                }


                //gl.TexCoord(vt[f[i].VertexIndexList[i2] - 1].X, vt[f[i].VertexIndexList[i2] - 1].Y);

            }
        }
        
        private void NewMethod2(OpenGL gl)
        {
            int cs1 = cs;
            for (int i3 = 0; i3 < g1.Count; i3++)
            {
                
                cs1 = int.Parse(g1[i3].model);
                gl.LoadIdentity();
                gl.Rotate(vi.pos[1], 0, 1, 0);
                gl.Rotate(vi.pos[0], 1, 0, 0);
                gl.Rotate(vi.pos[2], 0, 0, 1);
                gl.Color(1f, 1f, 1f);
                if (cs1 == 3)
                {

                    gl.Color(0f, 1f, 1f);
                }
                if (cs1 == 0)
                {

                    gl.Begin(OpenGL.GL_QUADS);
                }
                if (cs1 == 2)
                {

                    gl.Begin(OpenGL.GL_QUADS);
                }
                if (cs1 == 3)
                {

                    gl.Begin(OpenGL.GL_QUADS);
                }
                if (cs1 == 4)
                {

                    gl.Begin(OpenGL.GL_QUADS);
                }
                if (cs1 == 1)
                {

                    gl.Begin(OpenGL.GL_TRIANGLES);
                }
                if (cs1 == 5)
                {

                    gl.Begin(OpenGL.GL_TRIANGLES);
                }

                for (int i = 0; i < g1[i3].f.Count; i++)
                {

                    for (int i2 = 0; i2 < g1[i3].f[i].VertexIndexList.Length; i2++)
                    {






                        gl.TexCoord(g1[i3].vt[g1[i3].f[i].TextureVertexIndexList[i2] - 1].X, g1[i3].vt[g1[i3].f[i].TextureVertexIndexList[i2] - 1].Y);



                        gl.Vertex(g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].X - g1[i3].vi.pos[0] + vip.pos[0], g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].Y - g1[i3].vi.pos[1] + vip.pos[1], g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].Z+7 - g1[i3].vi.pos[2]+vip.pos[2]);

                    }


                    //gl.TexCoord(vt[f[i].VertexIndexList[i2] - 1].X, vt[f[i].VertexIndexList[i2] - 1].Y);

                }
                gl.End();
            }
        }
        
        private void NewMethod(OpenGL gl)
        {
            if (cs == 0)
            {

                gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 2)
            {

                gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 3)
            {

                gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 4)
            {

                gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 1)
            {

                gl.Begin(OpenGL.GL_TRIANGLES);
            }
            if (cs == 5)
            {

                gl.Begin(OpenGL.GL_TRIANGLES);
            }
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                vip.pos[0] += 0.3f;
            }
            
            if (e.KeyCode == Keys.D)
            {
                vip.pos[0] -= 0.3f;
            }
            
            
            if (e.KeyCode == Keys.W)
            {
                vip.pos[2] += 0.3f;
            }
            if (e.KeyCode == Keys.S)
            {
                vip.pos[2] -= 0.3f;
            }
            if (e.KeyCode == Keys.E)
            {
                vip.pos[1] += 0.3f;
            }
            if (e.KeyCode == Keys.Q)
            {
                vip.pos[1] -= 0.3f;
            }
            if (e.KeyCode == Keys.U)
            {
                phon = !phon;
            }
            if (e.KeyCode == Keys.C)
            {
                
                cs ++;
                if (cs ==0)
                {
                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/cube.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
                if (cs == 1)
                {
                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/sphere.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
                if (cs == 2)
                {
                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/quad-sphere.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
                if (cs == 5)
                {
                    
                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/arua.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
                if (cs == 6)
                {
                    cs = 0;
                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/cube.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
                if (cs == 3)
                {

                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/pipiis.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
                if (cs == 4)
                {

                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/terrain.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
            }
            
            if (e.KeyCode == Keys.Space)
            {
                g1.Add(new GameObject(new Vectorinf(new float[3] 
                { 
                    0 + vip.pos[0],
                    0 + vip.pos[1],
                    7 + vip.pos[2]
                })
                    ,cs.ToString()));
            }
            

            
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            float speed = oldpos -e.X;
            vi.pos[1] -= speed;

            oldpos = e.X;
        }
    }
    public class onclear
    {
        public static bool clear;
    }
}
