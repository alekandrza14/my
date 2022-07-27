using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;


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
        public GameObject(Vectorinf vi, object type)
        {
            this.vi = vi;
            this.type = type;
        }
        public GameObject(object type)
        {

            this.type = type;
        }
        public GameObject(object type, List<object> components)
        {

            this.type = type;
        }
        public GameObject(Vectorinf vi, object type, List<object> components)
        {

            this.type = type;
            this.vi = vi;
        }
        
        
        
       
        public object type;
        public string name;
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
