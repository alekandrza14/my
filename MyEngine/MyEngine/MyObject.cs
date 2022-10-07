using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ObjParser;
using System.Text.Json.Serialization;

namespace MyEngine
{
    
    public class GameObject
    {
        [JsonPropertyName("vector")]
        public Vectorinf vi = new Vectorinf(new float[0]{
        });
        [JsonPropertyName("vector2")]
        public Vectorinf vis = new Vectorinf(new float[4]{1,1,1,1
        });
        [JsonPropertyName("vector3")]
        public Vectorinf dvi = new Vectorinf(new float[5]{0,0,0,0,0
        });
        [JsonPropertyName("dop")]
        public string[] json { get; set; }
        public List<string> jsons = new List<string>();
        public void Save()
        {
            jsons.Add(цвет.tojson());
            jsons.Add(vi.tojson());
            jsons.Add(vis.tojson());
            jsons.Add(dvi.tojson());
            json = jsons.ToArray();
        }


        public GameObject(Vectorinf vi)
        {
            this.vi = vi;

        }
       
        public void activeanim(float t,float speed)
        {
            if (this.typeanim == 1)
            {
                anim.play(dvi,t,speed);
            }
        }
        public void setцвет(Цвет ргб)
        {
            цвет = ргб;


        }
       
        public GameObject(Vectorinf vi, string model)
        {


            this.vi = vi;
            this.model = model;
            if (model == "0")
            {
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/cube.obj1");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "1")
            {
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/sphere.obj1");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "2")
            {
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/quad-sphere.obj1");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "5")
            {
                
                var Obj = new Obj();
                Obj.LoadObj("ресурсы/arua.obj1");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "3")
            {

                var Obj = new Obj();
                Obj.LoadObj("ресурсы/pipiis.obj1");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "4")
            {

                var Obj = new Obj();
                Obj.LoadObj("ресурсы/terrain.obj1");
                Console.WriteLine(Obj.VertexList.Count.ToString());
                v = Obj.VertexList;
                f = Obj.FaceList;
                vt = Obj.TextureList;
            }
            if (model == "6")
            {

                var Obj = new Obj();
                Obj.LoadObj("ресурсы/cat.obj1");
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
        [JsonPropertyName("model_id")]
        public string model { get; set; }
        [JsonPropertyName("color")]
        public Цвет цвет = new Цвет(0, 0, 0);
        public bool init;
        [JsonPropertyName("anim_id")]
        public int typeanim { get; set; }
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
