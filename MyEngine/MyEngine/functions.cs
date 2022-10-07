using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MyEngine
{
    public class jsonUtillity
    {
        public jsonUtillity()
        {

        }
        public string gameobjectstojson(GameObject[] g)
        {
            for (int i = 0; i < g.Length; i++)
            {
                g[i].Save();
            }
                return System.Text.Json.JsonSerializer.Serialize<GameObject[]>(g);
        }
    }
}
