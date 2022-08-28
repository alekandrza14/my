using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ObjParser;


namespace MyEngine
{
    public class GameObject
    {
       public Component c = new Component();
       public Vectorinf vi = new Vectorinf(new float[0]{
        });
        public GameObject(Vectorinf vi)
        {
            this.vi = vi;

        }
       
        
       
        public GameObject(Vectorinf vi, string model)
        {


            this.vi = vi;
            this.model = model;
            if (model == "0")
            {
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/cube.obj");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "1")
            {
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/sphere.obj");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "2")
            {
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/quad-sphere.obj");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "5")
            {
                
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/cube.obj");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "3")
            {

                var Obj = new Obj();
                Obj.LoadObj("ресурсы/pipiis.obj");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "4")
            {

                var Obj = new Obj();
                Obj.LoadObj("ресурсы/terrain.obj");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
        }



        public List<ObjParser.Types.Vertex> v = new List<ObjParser.Types.Vertex>();
        public List<ObjParser.Types.Face> f = new List<ObjParser.Types.Face>();
        public List<ObjParser.Types.TextureVertex> vt = new List<ObjParser.Types.TextureVertex>();
        public object type;
        public string model;
        public bool init;
    }
    public class EditorObject
    {
        public Vectorinf vi = new Vectorinf(new float[0]{
        });
        public EditorObject(Vectorinf vi)
        {
            this.vi = vi;
        }
        public EditorObject(Vectorinf vi, object type)
        {
            this.vi = vi;
            this.type = type;
        }
        public object type;
        public string name;
        public bool init;
    }
    public class DebugObject
    {
        public Vectorinf vi = new Vectorinf(new float[0]{
        });
        public DebugObject(Vectorinf vi)
        {
            this.vi = vi;
        }
        public DebugObject(Vectorinf vi, object type)
        {
            this.vi = vi;
            this.type = type;
        }
        public object type;
        public string name;
        public bool init;
    }
    public class CameraObj
    {
        public Vectorinf vi = new Vectorinf(new float[0]{
        });
        public CameraObj(Vectorinf vi)
        {
            this.vi = vi;
        }
        public CameraObj(Vectorinf vi, object type)
        {
            this.vi = vi;
            this.type = type;
        }
        public object type;
        public string name;
        public bool init;
    }
}
