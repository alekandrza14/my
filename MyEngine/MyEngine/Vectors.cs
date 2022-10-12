using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace MyEngine
{
    public class fallcolor
    {
        [JsonPropertyName("color1")]
        public byte color1 { get; set; }
        [JsonPropertyName("color2")]
        public byte color2 { get; set; }
        [JsonPropertyName("color3")]
        public byte color3 { get; set; }
    }

    public class Цвет
    {
        public string json;
        public string tojson()
        {
            json = System.Text.Json.JsonSerializer.Serialize<Цвет>(this);
            return json;
        }
        public Цвет fromjson(string json)
        {
            fallcolor f = System.Text.Json.JsonSerializer.Deserialize<fallcolor>(json);
            return new Цвет(f.color1, f.color2, f.color3);
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
    public class Vectorinf
    {
        public string json;
        public Vectorinf fromjson(string json)
        {
            Vectorinf f = System.Text.Json.JsonSerializer.Deserialize<Vectorinf>(json);
            return f;
        }
        public string tojson()
        {
            json = System.Text.Json.JsonSerializer.Serialize<Vectorinf>(this);
            return json;
        }
        [JsonPropertyName("position")]
        public float[] pos { get; set; }
        public Vector2 GetVector2()
        {
            Vector2 v2 = new Vector2(pos[0], pos[1]);
            return v2;
        }
        public Vector3 GetVector3()
        {
            Vector3 v3 = new Vector3(pos[0], pos[1], pos[2]);
            return v3;
        }
        public Vector4 GetVector4()
        {
            Vector4 v4 = new Vector4(pos[0], pos[1], pos[2], pos[3]);
            return v4;
        }
        public OpenTK.Vector2 GetVector2t()
        {
            OpenTK.Vector2 v2 = new OpenTK.Vector2(pos[0], pos[1]);
            return v2;
        }
        public OpenTK.Vector3 GetVector3t()
        {
            OpenTK.Vector3 v3 = new OpenTK.Vector3(pos[0], pos[1], pos[2]);
            return v3;
        }
        public OpenTK.Vector4 GetVector4t()
        {
            OpenTK.Vector4 v4 = new OpenTK.Vector4(pos[0], pos[1], pos[2], pos[3]);
            return v4;
        }
        public void SetVector2(Vector2 xy)
        {
            pos[0] = xy.X;
            pos[1] = xy.Y;
        }
        public void SetVector3(Vector3 xyz)
        {
            pos[0] = xyz.X;
            pos[1] = xyz.Y;
            pos[2] = xyz.Z;
        }
        public void SetVector4(Vector4 xyzw)
        {
            pos[0] = xyzw.X;
            pos[1] = xyzw.Y;
            pos[2] = xyzw.Z;
            pos[3] = xyzw.W;
        }
        public void SetVector2t(OpenTK.Vector2 xy)
        {
            pos[0] = xy.X;
            pos[1] = xy.Y;
        }
        public void SetVector3t(OpenTK.Vector3 xyz)
        {
            pos[0] = xyz.X;
            pos[1] = xyz.Y;
            pos[2] = xyz.Z;
        }
        public void SetVector4t(OpenTK.Vector4 xyzw)
        {
            pos[0] = xyzw.X;
            pos[1] = xyzw.Y;
            pos[2] = xyzw.Z;
            pos[3] = xyzw.W;
        }


        public Vectorinf(float[] pos)
        {
            this.pos = pos;
        }
    }
    public class Vectorinfint
    {
        public int[] pos;
        public Vector2 GetVector2()
        {
            Vector2 v2 = new Vector2(pos[0], pos[1]);
            return v2;
        }
        public Vector3 GetVector3()
        {
            Vector3 v3 = new Vector3(pos[0], pos[1], pos[2]);
            return v3;
        }
        public Vector4 GetVector4()
        {
            Vector4 v4 = new Vector4(pos[0], pos[1], pos[2], pos[3]);
            return v4;
        }
        public Vectorinfint(int[] pos)
        {
            this.pos = pos;
        }
    }
    public class Vectorinfdouble
    {
        public double[] pos;
        public Vector2 GetVector2()
        {
            Vector2 v2 = new Vector2((float)pos[0], (float)pos[1]);
            return v2;
        }
        public Vector3 GetVector3()
        {
            Vector3 v3 = new Vector3((float)pos[0], (float)pos[1], (float)pos[2]);
            return v3;
        }
        public Vector4 GetVector4()
        {
            Vector4 v4 = new Vector4((float)pos[0], (float)pos[1], (float)pos[2], (float)pos[3]);
            return v4;
        }
        public Vectorinfdouble(double[] pos)
        {
            this.pos = pos;
        }
    }
    public class Vectorinfdecimal
    {
        public decimal[] pos;
        public Vector2 GetVector2()
        {
            Vector2 v2 = new Vector2((float)pos[0], (float)pos[1]);
            return v2;
        }
        public Vector3 GetVector3()
        {
            Vector3 v3 = new Vector3((float)pos[0], (float)pos[1], (float)pos[2]);
            return v3;
        }
        public Vector4 GetVector4()
        {
            Vector4 v4 = new Vector4((float)pos[0], (float)pos[1], (float)pos[2], (float)pos[3]);
            return v4;
        }
        public Vectorinfdecimal(decimal[] pos)
        {
            this.pos = pos;
        }
    }

}
