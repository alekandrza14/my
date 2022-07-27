using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyEngine
{

    public class Component1
    {

       
        public GameObject init(object obj)
        {
            GameObject g = new GameObject(obj);
            g.init = true;
            return g;
            
        }
        public GameObject[] initAllEnemyes(List<Enemys> obj)
        {
            GameObject[] g = new GameObject[obj.Count];
            for (int i = 0; i < obj.Count; i++)
            {
                g[i] = init(obj[i]);
            }
            return g;
        }
        



    }
}
