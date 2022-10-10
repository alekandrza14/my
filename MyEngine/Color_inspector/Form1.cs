using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Color_inspector
{
    
    public partial class Form1 : Form
    {
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
        }
        public float bgup = -20; public float bgsizex = 15; public float bgsizey = 8;

        Цвет ц;
        private void openGLControl1_OpenGLDraw_1(object sender, RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);
            gl.LookAt(0, 0, 0, 0, 0, 1000, 0, 1, 0);

            
            gl.LoadIdentity();


             ц = new Цвет((byte)trackBar1.Value, (byte)trackBar2.Value, (byte)trackBar3.Value);


            gl.Translate(0f, 0f, bgup);
            gl.Begin(OpenGL.GL_QUADS);
            //
            gl.Color(((float)ц.color1) / 255, ((float)ц.color2) / 255, ((float)ц.color3) / 255);


            gl.Vertex(-bgsizex, bgsizey, 0f);
            gl.Vertex(bgsizex, bgsizey, 0f);
            gl.Vertex(bgsizex, -bgsizey, 0f);
            gl.Vertex(-bgsizex, -bgsizey, 0f);



            gl.End();

            gl.Flush();
        }
        public void gen()
        {
            


                ц = new Цвет((byte)trackBar1.Value, (byte)trackBar2.Value, (byte)trackBar3.Value);
                ц.tojson();
                Directory.CreateDirectory("C:/MyEngine");
                File.WriteAllText("C:/MyEngine/color.json", ц.json);
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void trackBar1_KeyDown(object sender, KeyEventArgs e)
        {
            gen();
        }

        private void trackBar2_KeyDown(object sender, KeyEventArgs e)
        {
            gen();
        }

        private void trackBar3_KeyDown(object sender, KeyEventArgs e)
        {
            gen();
        }

        private void trackBar3_MouseDown(object sender, MouseEventArgs e)
        {
            gen();
        }

        private void trackBar2_MouseDown(object sender, MouseEventArgs e)
        {
            gen();
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            gen();
        }
    }
    public class Цвет
    {
        public string json;
        public string tojson()
        {
            json = System.Text.Json.JsonSerializer.Serialize<Цвет>(this);
            return json;
        }
        public Цвет(byte c1, byte c2, byte c3)
        {
            color1 = c1;
            color2 = c2;
            color3 = c3;
        }
        [JsonPropertyName("color1")]
        public byte color1 { get; set; }
        [JsonPropertyName("color2")]
        public byte color2 { get; set; }
        [JsonPropertyName("color3")]
        public byte color3 { get; set; }
    }
}
