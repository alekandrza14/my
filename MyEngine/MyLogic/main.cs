using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogic
{
    public class Atribute
    {
        public object[] atr;
        public string name;
        public string model;
        public Atribute(object[] atr, string name)
        {
            this.atr = atr;
            this.name = name;
        }
    }
    public class Vector4
    {
        public float[] pos;

        public Vector4(float[] pos)
        {
            this.pos = pos;
        }
    }
    public class GameObject
    {
        public Atribute a;
        public Vector4 transform;
        public updata up1; 
        public updata up2;
        public updata up3;
        public updata up4;
        public GameObject(Vector4 v4, Atribute a)
        {
            transform = v4;
            object b = a.atr[0];
            object a2 = new rand();
            if (b.GetType() == a2.GetType())
            {
                up1 = updata.transform;
            }
            object a3 = new randscale();
            if (b.GetType() == a3.GetType())
            {
                up1 = updata.scale;
            }
            this.a = a;
        }
    }
    public enum updata
    {
       none, transform, model,scale
    }
    

    public class Main
    {
        public object[] log = new object[] { new rand() }; 
        public object[] log1 = new object[] { new randscale() };
        public GameObject[] gameObjects;
        public string level = "1";
       public void main()
        {
            Atribute a1 = new Atribute(log, "cube");
            Atribute a2 = new Atribute(log1, "cube1");
            gameObjects = new GameObject[]
            {
               new  GameObject(new Vector4(new float[4]{0,5,0,8
               }),a1), new  GameObject(new Vector4(new float[4]{2,5,7,8
               }),a2)
            };
            object b = gameObjects[0].a.atr[0];
            object a = new rand();
            if (b.GetType() == a.GetType())
            {
                rand r = (rand)b;
                r.start(gameObjects[0].transform, gameObjects[0]);
                r.Update();
            }
            object b2 = gameObjects[1].a.atr[0];
            object a3 = new randscale();
            if (b2.GetType() == a3.GetType())
            {
                randscale r = (randscale)b2;
                r.start(new Vector4(new float[] { 1, 1, 1, 1 }), gameObjects[1]);
                r.Update();
            }
            gameObjects[0].a.model = "0";
            gameObjects[1].a.model = "0";

        }
        public void UPDATE()
        {
            object b = gameObjects[0].a.atr[0];
            object a = new rand();
            if (b.GetType() == a.GetType())
            {
                rand r = (rand)b;
                r.Update();
            }
            object b2 = gameObjects[1].a.atr[0];
            object a2 = new randscale();
            if (b2.GetType() == a2.GetType())
            {
                randscale r = (randscale)b2;
                r.Update();
            }
        }
        public Vector4 OutPut()
        {
            Vector4 v4 = new Vector4(new float[] { 0, 0, 0, 0 });
            object b = gameObjects[0].a.atr[0];
            object a = new rand();
            if (b.GetType() == a.GetType())
            {
                rand r = (rand)b;
                v4 = r.transform;
            }
            return v4;
        }
        public Vector4 OutPutscale()
        {
            Vector4 v4 = new Vector4(new float[] { 1, 1, 1, 1 });
            object b = gameObjects[1].a.atr[0];
            object a = new randscale();
            if (b.GetType() == a.GetType())
            {
                randscale r = (randscale)b;
                v4 = r.transform;
            }
            return v4;
        }
    }
}
