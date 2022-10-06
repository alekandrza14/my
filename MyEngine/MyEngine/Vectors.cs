using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine
{
    public class Vectorinf
    {
        public float[] pos;
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
