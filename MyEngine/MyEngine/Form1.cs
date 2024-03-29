using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyEngine.Properties;
using SharpGL;
using System.Numerics;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;
using ObjParser;
using SharpGL.SceneGraph.Lighting;

namespace MyEngine
{

    public partial class Form1 : Form
    {

        public List<Enemys> en = new List<Enemys>()
        {
            new Enemys(true),new Enemys(true,new Point(300,64))
        };


        public Point size3 = new Point(30, 20);
        public Quaternion rot;
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
        List<GameObject> g2 = new List<GameObject>();
        List<GameObject> g3 = new List<GameObject>();
        public Point s;
        public bool tr;
        public int e1;
        public int cs;
        public bool phon;
        public List<ObjParser.Types.Vertex> v = new List<ObjParser.Types.Vertex>();
        public List<ObjParser.Types.Face> f = new List<ObjParser.Types.Face>();
        public List<ObjParser.Types.TextureVertex> vt = new List<ObjParser.Types.TextureVertex>();
        public float narst; public float narst2;
        public float oldpos = 400;
        public float oldpos2 = 200;
        public float oldspeed = 0;
        public float oldspeed2 = 0;
        public float bgup = -20; public float bgsizex = 15; public float bgsizey = 8;
        public float frame;
        Camera camera;
        FpsController motionCtrl;
        Physics physics;
        Render render;
        public float delta4;
        public Vector3 wrot = new Vector3(0.12f, 0, 0);

        System.Timers.Timer inputUpdateTimer;

        public void start()
        {
            //JsonReaderWriterFactory.CreateJsonWriter()
            Width = Const.DISPLAY_XGA_W;
            Height = Const.DISPLAY_XGA_H;

            render = new Render();

            camera = new Camera(
                    vip.GetVector3t(),
                    new OpenTK.Vector3(0, 0, 1),
                    new OpenTK.Vector3(0, 1, 0)
                    );

            physics = new Physics();
            motionCtrl = new FpsController();

            inputUpdateTimer = new System.Timers.Timer(Const.INPUT_UPDATE_INTERVAL);
            inputUpdateTimer.Elapsed += UpdateInput;
            lastTicks = DateTime.Now.Ticks;
            inputUpdateTimer.Enabled = true;
        }
        long lastTicks;
        Ray motionStep = new Ray();
        private void UpdateInput(object sender, System.Timers.ElapsedEventArgs e)
        {

            camera.Origin = vip.GetVector3t();
            float delta = (e.SignalTime.Ticks - lastTicks) / 10000000.0f;
            lastTicks = e.SignalTime.Ticks;
            physics.GlobalTime += delta;
            delta4 = delta;

            // update player input (keyboard_wasd+space+shift + mouse-look)
            if (ondrag)
            {


                motionStep = motionCtrl.Update(delta, camera.RayCopy);
            }

            // gravity free fall
            /*
            OpenTK.Vector3 freeFallVector = physics.Gravity(
                delta,
                camera.RayCopy,
                Const.PLAYER_HIT_RADIUS,
              motionStep.Origin.Y > 0
                );*/

            // motionStep.Origin += freeFallVector;

            // wall collide
            /*
            float sd = physics.CastRay(
                camera.Origin,
                OpenTK.Vector3.NormalizeFast(motionStep.Origin)
                );
            */

            // when hit the wall

            camera.Target = motionStep.Target;    // view only
                                                  // smooth wall sliding


        }
        public Vectorinf vi1 = new Vectorinf(new float[4]
        {
            0,0,0,0
        }); public Vectorinf vi2 = new Vectorinf(new float[4]
         {
            0,0,0,0
         }); public Vectorinf vi3 = new Vectorinf(new float[4]
         {
            0,0,0,0
         }); public Vectorinf vip = new Vectorinf(new float[4]
        {
            0,2,-4,8
        });


        public float rtri;
        public float rquad;

        bool norm = false;
        bool ondrag;

        MyLogic.Main m = new MyLogic.Main();
        public Form1()
        {

            start();
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
            g1.Add(new GameObject(
                new Vectorinf(new float[4]
                {
                    0,0,0,8
                }
                )
                , "2")


                );
            g1[g1.Count - 1].typeanim = 1;

            g1.Add(new GameObject(
                new Vectorinf(new float[4]
                {
                    0,-7,0,8
                }
                )
                , "4")


                );
            g1[g1.Count - 1].vis.SetVector4(new Vector4(10, 10, 10, 2));
            m.main();
            for (int i = 0;i<m.gameObjects.Length;i++)
            {


                g3.Add(new GameObject(
                     new Vectorinf(new float[4]
                     {
                    m.gameObjects[i].transform.pos[0]
                    ,m.gameObjects[i].transform.pos[1]
                    ,m.gameObjects[i].transform.pos[2]
                    ,m.gameObjects[i].transform.pos[3]
                     }
                     )
                     , m.gameObjects[i].a.model)


                     );
                g3[g3.Count - 1].vis.SetVector4(new Vector4(1, 1, 1, 1));
                g3[g3.Count - 1].name = m.gameObjects[i].a.name;

            }
        }

        void reset()
        {
            for (int i = 0; i < m.gameObjects.Length; i++)
            {
                g1.Add(g3[i]);
            }
        }

            Graphics g;
        Point click;
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            g = e.Graphics;
            
        }

        

        


        public void randomwindow()
        {
            Random r = new Random();
            SetDesktopLocation(r.Next(-1, 2)+ Location.X, r.Next(-1, 2) + Location.Y);
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
        bool up, down, right, left, forward, backward, kata, ana;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.E)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Q)
            {

                down = true;
            }
            if (e.KeyCode == Keys.D)
            {
                right = true;
            }
            if (e.KeyCode == Keys.A)
            {
                left = true;
            }
            if (e.KeyCode == Keys.W)
            {
                forward = true;
            }
            if (e.KeyCode == Keys.S)
            {
                backward = true;
            }
            if (e.KeyCode == Keys.X)
            {
                kata = true;
            }
            if (e.KeyCode == Keys.Z)
            {
                ana = true;
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

        float speed;

        private void label4_Click(object sender, EventArgs e)
        {
            tr = !tr;
        }

        bool g5 =false;
        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            // m.UPDATE();
            {
                if (!File.Exists("C:/MyEngine/color_Inspector.sig"))
                {
                    if (File.Exists("C:/MyEngine/color.json"))
                    {



                        ц1 = ц1.fromjson(File.ReadAllText("C:/MyEngine/color.json"));

                    }
                }
                if (tr == true)
                {
                    randomwindow();
                }

                if (forward)
                {
                    vip.SetVector3t(vip.GetVector3t() + camera.Target * 3 * speed);

                }
                if (backward)
                {
                    vip.SetVector3t(vip.GetVector3t() - camera.Target * 3 * speed);


                }
                if (right)
                {
                    vip.SetVector3t(vip.GetVector3t() + OpenTK.Vector3.Cross(camera.Target * 3 * speed, new OpenTK.Vector3(0, 1, 0)));

                }
                if (left)
                {
                    vip.SetVector3t(vip.GetVector3t() - OpenTK.Vector3.Cross(camera.Target * 3 * speed, new OpenTK.Vector3(0, 1, 0)));

                }
               
                if (up)
                {
                    vip.pos[1] += 100f * delta4 * 3 * speed;

                }
                if (down)
                {
                    vip.pos[1] -= 100f * delta4 * 3 * speed;

                }
                if (ana)
                {
                    vip.pos[3] += 4 * delta4 * speed;
                }

                if (kata)
                {
                    vip.pos[3] -= 4 * delta4 * speed;
                }

            }
            OpenGL gl = this.openGLControl1.OpenGL;

            speed = ((float)trackBar4.Value) / 50;

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

            gl.LookAt(0,0,0,0,0,-1000,0,1,0);

            
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
                case 6:
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

                    if (f[i].VertexIndexList.Length == 3)
                    {

                        gl.Begin(OpenGL.GL_TRIANGLES);
                    }
                    if (f[i].VertexIndexList.Length == 2)
                    {

                        gl.Begin(OpenGL.GL_LINES);
                    }
                    if (f[i].VertexIndexList.Length == 4)
                    {

                        gl.Begin(OpenGL.GL_QUADS);
                    }




                    gl.TexCoord(vt[f[i].TextureVertexIndexList[i2] - 1].X, vt[f[i].TextureVertexIndexList[i2] - 1].Y);



                    gl.Vertex(v[f[i].VertexIndexList[i2] - 1].X, v[f[i].VertexIndexList[i2] - 1].Y, v[f[i].VertexIndexList[i2] - 1].Z+7);

                }


                //gl.TexCoord(vt[f[i].VertexIndexList[i2] - 1].X, vt[f[i].VertexIndexList[i2] - 1].Y);

            }
        }
        
        private void NewMethod2(OpenGL gl)
        {
            
            int cs1 = cs; if (g2.Count != 0)
            {

                g1.Clear(); if (true)
                {
                    for (int i3 = 0; i3 < g2.Count; i3++)
                    {

                        g1.Add(g2.ToArray()[i3]);
                    }
                        textBox1.Text = g1[0].vi.pos[0].ToString() + g1[0].vi.pos[1].ToString() + g1[0].vi.pos[2].ToString() + g1[0].vi.pos[3].ToString();
                    if (true)
                    {


                        g2.Clear();
                    }
                }
            }


           


                m.UPDATE();
            
            
            frame++;
            for (int i3 = 0; i3 < g1.Count; i3++)
            {
                for (int i = 0; i < m.gameObjects.Length; i++)
                {

                    if (g1[i3].name == m.gameObjects[i].a.name && m.gameObjects[i].up1 == MyLogic.updata.transform)
                    {
                        g1[i3].dvi.pos = m.OutPut().pos;
                    }
                    if (g1[i3].name == m.gameObjects[i].a.name && m.gameObjects[i].up1 == MyLogic.updata.scale)
                    {
                        g1[i3].vis.pos = m.OutPutscale().pos;
                    }
                }



                g1[i3].activeanim(frame,0.1f);
                if (g1.Count != 0)
                {
                    cs1 = int.Parse(g1[i3].model);
                }
                gl.LoadIdentity();
                Vector3 v3 = Vector3.Transform(new Vector3(1,1,1) ,Matrix4x4.CreateFromQuaternion(rot));
                label1.Text = "pos xyzw :" + vip.pos[0] +"/" + vip.pos[1] + "/"+ +vip.pos[2] + "/" + vip.pos[3];
                if (g1.Count != 0)
                    gl.LookAt(vip.pos[0], vip.pos[1], vip.pos[2],
                    camera.Target.X* 6.28f * (Vector3.Distance(Vector3.Zero, vip.GetVector3()) / 1.25f), camera.Target.Y * 6.28f * (Vector3.Distance(Vector3.Zero, vip.GetVector3()) / 1.25f), camera.Target.Z * 6.28f *( Vector3.Distance(Vector3.Zero, vip.GetVector3())/ 1.25f), camera.Up.X, camera.Up.Y, camera.Up.Z);
                if(g1.Count != 0)
                gl.Translate(g1[i3].vi.pos[0]+ g1[i3].dvi.pos[0], g1[i3].vi.pos[1] + g1[i3].dvi.pos[1], g1[i3].vi.pos[2] + g1[i3].dvi.pos[2]);
                gl.Color(1f, 1f, 1f);
                if (cs1 == 3)
                {

                    gl.Color(0f, 1f, 1f);
                }
                /*
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
                if (cs1 == 6)
                {

                    gl.Begin(OpenGL.GL_TRIANGLES);
                }
                */

                if (g1.Count != 0)
                {
                    if (g1[i3].цвет.color1 != 0 || g1[i3].цвет.color2 != 0 || g1[i3].цвет.color3 !=0)
                    {



                        gl.Color(((float)g1[i3].цвет.color1) / 255, ((float)g1[i3].цвет.color2) / 255, ((float)g1[i3].цвет.color3) / 255);

                    }
                }
                    if (g1.Count != 0)
                    for (int i = 0; i < g1[i3].f.Count; i++)
                {

                    for (int i2 = 0; i2 < g1[i3].f[i].VertexIndexList.Length; i2++)
                    {
                            if (g1[i3].f[i].VertexIndexList.Length == 3)
                            {

                                gl.Begin(OpenGL.GL_TRIANGLES);
                            }
                            if (g1[i3].f[i].VertexIndexList.Length == 2)
                            {

                                gl.Begin(OpenGL.GL_LINES);
                            }
                            if (g1[i3].f[i].VertexIndexList.Length == 4)
                            {

                                gl.Begin(OpenGL.GL_QUADS);
                            }
                            if (Vector4.Distance(vip.GetVector4(), g1[i3].vi.GetVector4())<100+ Vector4.Distance( g1[i3].vis.GetVector4(),Vector4.Zero))
                        {
                                Vector4 v4 = Vector4.One;
                                Vector2 lep = new Vector2(1, 0);
                                Vector2 leb = new Vector2(0, 1);
                                Vector2 lerp1 = Vector2.Lerp(lep, leb, wrot.X);
                                v4.X += lerp1.X - lerp1.Y;
                                v4.W += lerp1.Y - lerp1.X;
                                v4.W += 0.5f;
                                float wpos = vip.pos[3] - g1[i3].vi.pos[3];
                                float wz = (wpos/ g1[i3].vis.pos[3]);
                                if (wpos / g1[i3].vis.pos[3] > 0)
                                {
                                    wz = -(vip.pos[3] - g1[i3].vi.pos[3]) / g1[i3].vis.pos[3];
                                }

                                if (wz < -1)
                                {
                                    wz = -1;
                                }
                                Vector3 v35 = new Vector3(v4.X-v4.W, v4.Y, v4.Z);


                                Vector3 v32 = new Vector3(((float)g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].X * wz),
                                ((float)g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].Y * wz),
                                ((float)g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].Z * wz));
                            Vector3 v33 = new Vector3((float)g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].X,
                                 (float)g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].Y,
                                 (float)g1[i3].v[g1[i3].f[i].VertexIndexList[i2] - 1].Z);



                            gl.TexCoord(g1[i3].vt[g1[i3].f[i].TextureVertexIndexList[i2] - 1].X, g1[i3].vt[g1[i3].f[i].TextureVertexIndexList[i2] - 1].Y);
                                
                                v32 += v33;
                                v32 *= v35;
                            gl.Vertex(v32.X * g1[i3].vis.GetVector4().X,
                                    v32.Y * g1[i3].vis.GetVector4().Y,
                                    v32.Z * g1[i3].vis.GetVector4().Z);
                            /*
                            if ((int)(vip.pos[3]-2)/2 != (int)(g1[i3].vi.pos[3] -2)/ 2)
                            {


                                gl.Vertex(v32.X * g1[i3].vis.GetVector4().X,
                                    v32.Y * g1[i3].vis.GetVector4().Y,
                                    v32.Z * g1[i3].vis.GetVector4().Z);
                            }
                            if ((int)(vip.pos[3] - 2) / 2 == (int)(g1[i3].vi.pos[3] - 2) / 2)
                            {


                                gl.Vertex(v33.X * g1[i3].vis.GetVector4().X,
                                    v33.Y * g1[i3].vis.GetVector4().Y,
                                    v33.Z * g1[i3].vis.GetVector4().Z);
                            }
                            */
                        }
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

              //  gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 2)
            {

             //   gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 3)
            {

              //  gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 4)
            {

              //  gl.Begin(OpenGL.GL_QUADS);
            }
            if (cs == 1)
            {

              //  gl.Begin(OpenGL.GL_TRIANGLES);
            }
            if (cs == 5)
            {

              //  gl.Begin(OpenGL.GL_TRIANGLES);
            }
            if (cs == 6)
            {

              //  gl.Begin(OpenGL.GL_TRIANGLES);
            }
        }
        string s5 = "";
        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {

            /*
             File.Delete("C:/MyEngine/input_back.sig");
                File.Delete("C:/MyEngine/input_nsig1.sig");
             File.Delete("C:/MyEngine/input_right.sig");
                File.Delete("C:/MyEngine/input_nsig2.sig");
            
                File.Delete("C:/MyEngine/input_left.sig");

                File.Delete("C:/MyEngine/input_nsig3.sig");
           
                File.Delete("C:/MyEngine/input_up.sig");
                File.Delete("C:/MyEngine/input_nsig4.sig");
            
                File.Delete("C:/MyEngine/input_down.sig");
                File.Delete("C:/MyEngine/input_nsig5.sig");
           
                File.Delete("C:/MyEngine/input_forward.sig");

                File.Delete("C:/MyEngine/input_nsig.sig");
           
                File.Delete("C:/MyEngine/input_forward1.sig");


          
                File.Delete("C:/MyEngine/input_back1.sig");
            
                File.Delete("C:/MyEngine/input_right1.sig");
            
                File.Delete("C:/MyEngine/input_left1.sig");
            */
            if (e.KeyCode == Keys.D)
            {
                vip.SetVector3t(vip.GetVector3t() + OpenTK.Vector3.Cross(camera.Target * speed, new OpenTK.Vector3(0, 1, 0)));

            }

            if (e.KeyCode == Keys.Escape)
            {
                File.Delete("C:/MyEngine/input_back.sig");
                File.Delete("C:/MyEngine/input_nsig1.sig");
                File.Delete("C:/MyEngine/input_right.sig");
                File.Delete("C:/MyEngine/input_nsig2.sig");

                File.Delete("C:/MyEngine/input_left.sig");

                File.Delete("C:/MyEngine/input_nsig3.sig");

                File.Delete("C:/MyEngine/input_up.sig");
                File.Delete("C:/MyEngine/input_nsig4.sig");

                File.Delete("C:/MyEngine/input_down.sig");
                File.Delete("C:/MyEngine/input_nsig5.sig");

                File.Delete("C:/MyEngine/input_forward.sig");

                File.Delete("C:/MyEngine/input_nsig.sig");

                File.Delete("C:/MyEngine/input_forward1.sig");



                File.Delete("C:/MyEngine/input_back1.sig");

                File.Delete("C:/MyEngine/input_right1.sig");

                File.Delete("C:/MyEngine/input_left1.sig");
                vip = new Vectorinf(new float[4]
        {
            0,2,-4,8
        });
            }
            if (e.KeyCode == Keys.E)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Q)
            {

                down = true;
            }
            if (e.KeyCode == Keys.D)
            {
                right = true;
            }
            if (e.KeyCode == Keys.A)
            {
                left = true;
            }
            if (e.KeyCode == Keys.W)
            {
                forward = true;
            }
            if (e.KeyCode == Keys.S)
            {
                backward = true;
            }
            if (e.KeyCode == Keys.X)
            {
                kata = true;
            }
            if (e.KeyCode == Keys.Z)
            {
                ana = true;
            }

            if (e.KeyCode == Keys.A)
            {
                vip.SetVector3t(vip.GetVector3t() - OpenTK.Vector3.Cross(camera.Target * speed, new OpenTK.Vector3(0, 1, 0)));
                
            }
           
            if (e.KeyCode == Keys.F1)
            {
                tr=!tr;
            }
            if (e.KeyCode == Keys.F2)
            {
                reset();
            }

            if (e.KeyCode == Keys.W)
            {
                //  vip.pos[2] += 0.3f;
               vip.SetVector3t(vip.GetVector3t()+camera.Target * speed);
                
            }
            if (e.KeyCode == Keys.S)
            {
                vip.SetVector3t(vip.GetVector3t() - camera.Target * speed);

               
            }
            if (e.KeyCode == Keys.E)
            {
                vip.pos[1] += 100f*delta4 * speed;
            }
            if (e.KeyCode == Keys.Q)
            {
                vip.pos[1] -= 100f * delta4 * speed;
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
                    
                    var Obj = new Obj();
                    Obj.LoadObj("ресурсы/cat.obj1");
                    Console.WriteLine(Obj.VertexList.Count.ToString());
                    v = Obj.VertexList;
                    f = Obj.FaceList;
                    vt = Obj.TextureList;
                }
                if (cs == 7)
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
                if (s5.Length != 0)
                {
                    s5 = "";
                }
            }
            
           
            if (e.KeyCode == Keys.Space)
            {
                
                g1.Add(new GameObject(new Vectorinf(new float[4] 
                {
                    (camera.Target.X *7) +  vip.pos[0],
                    ( camera.Target.Y *7) +  vip.pos[1],
                     (camera.Target.Z *7) + vip.pos[2],
                    0 + vip.pos[3]
                })
                    ,cs.ToString()));
                g1[g1.Count - 1].цвет = new Цвет((byte)ц1.color1,(byte)ц1.color2, (byte)ц1.color3);
                if (File.Exists("ресурсы/"+Path.GetFileName(s5))) {
                    g1[g1.Count - 1] = g1[g1.Count - 1].resset(g1[g1.Count - 1].vi, Path.GetFileName(s5));
                    Console.WriteLine("0");
                }
                Console.WriteLine(ц1.color1);
            }
            

            
        }
        Цвет ц1 = new Цвет(0, 0, 0);
        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            float speed = oldpos - e.X;
            speed /= 200;
            


                    narst += speed * 2;
            oldspeed = speed;
            float speed2 = oldpos2 - e.Y;
            speed2 /= 200;


            


                narst2 += speed2 * 2;
            
                oldspeed2 = speed2;



            rot = Quaternion.CreateFromAxisAngle(new Vector3(0,1,0),narst);

            rot = Quaternion.Concatenate(Quaternion.CreateFromAxisAngle(new Vector3(-1, 0, 0), narst2),rot);




            oldpos = e.X - (oldspeed*11);




            oldpos2 = e.Y - (oldspeed2 * 11);
            */
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
           
            

            JsonSerializerOptions n = new JsonSerializerOptions();
            n.MaxDepth = 40; n.WriteIndented = true;

            string s = new jsonUtillity().gameobjectstojson(g1.ToArray());
            Directory.CreateDirectory("demosave");
            File.WriteAllText("demosave/save.json",s);
            textBox1.Text = s;

        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            ondrag = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Q)
            {

                down = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.W)
            {
                forward = false;
            }
            if (e.KeyCode == Keys.S)
            {
                backward = false;
            }
            if (e.KeyCode == Keys.X)
            {
                kata = false;
            }
            if (e.KeyCode == Keys.Z)
            {
                ana = false;
            }

        }

        private void openGLControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Q)
            {

                down = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.W)
            {
                forward = false;
            }
            if (e.KeyCode == Keys.S)
            {
                backward = false;
            }
            if (e.KeyCode == Keys.X)
            {
                kata = false;
            }
            if (e.KeyCode == Keys.Z)
            {
                ana = false;
            }
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            ondrag = false;
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        { 
          //  OpenGL gl = this.openGLControl1.OpenGL;



          //  gl.Clear(OpenGL.GL_DEPTH_TEST);



            
           // List<float> f = new List<float>();
            
          //  gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, new float[] {(float)Math.Sin( vip.GetVector4().X), (float)Math.Sin(vip.GetVector4().Y), (float)Math.Sin(vip.GetVector4().Z),0f,1f,0f,0f,1f,0f});
          //  gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, new float[] { 1f, 1f, 1f, 1f });
          //  gl.Enable(OpenGL.GL_LIGHTING);
          //  gl.Enable(OpenGL.GL_AMBIENT);
          //  gl.Enable(OpenGL.GL_LIGHT0);
          //  gl.Flush();




            // gl.Enable(OpenGL.GL_DIFFUSE);
            // gl.ShadeModel(OpenGL.GL_SMOOTH);

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            
            
            g2.Clear();
            DubObject[] n = JsonSerializer.Deserialize<DubObject[]>(File.ReadAllText("demosave/save.json")).ToArray();
            GameObject[] g6 = new GameObject[n.Length];
            for (int i = 0; i < n.Length; i++)
            {
              g6[i] =  n[i].load();


            }
            
            for (int i = 0;i<n.Length;i++)
            {


                g2.Add(g6[i]);
            }

        }
       

        private void openGLControl1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                s5 = file;
            }
        }

        private void openGLControl1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                s5 = file; if (File.Exists("ресурсы/" + Path.GetFileName(s5)))
                {


                    if (s5.Length != 0)
                    {
                        var Obj = new Obj();
                        Obj.LoadObj("ресурсы/" + Path.GetFileName(s5));
                        Console.WriteLine(Obj.VertexList.Count.ToString());
                        v = Obj.VertexList;
                        f = Obj.FaceList;
                        vt = Obj.TextureList;
                    }
                }
                else
                {
                    File.Copy(s5, "ресурсы/" + Path.GetFileName(s5));
                    if (s5.Length != 0)
                    {
                        var Obj = new Obj();
                        Obj.LoadObj("ресурсы/" + Path.GetFileName(s5));
                        Console.WriteLine(Obj.VertexList.Count.ToString());
                        v = Obj.VertexList;
                        f = Obj.FaceList;
                        vt = Obj.TextureList;
                    }
                }
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }
    }
    public class onclear
    {
        public static bool clear;
    }
} 