using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogic
{
    public class logic
    {
       public Vector4 transform;
        public void start(Vector4 v4,GameObject g)
        {
            transform = v4;
        }
    }
    public class rand : logic
    {
        bool min;
        public void Update()
        {
            if (!min)
            {


                transform.pos[0] += 0.1f;
            }
            if (min)
            {


                transform.pos[0] -= 0.1f;
            }
            if (transform.pos[0] > 10)
            {
                min = true;
            }
            if (transform.pos[0] < -10)
            {
                min = false;
            }
        }
    }
    public class randscale : logic
    {
        bool min;
        public void Update()
        {
            if (!min)
            {


                transform.pos[0] += 0.1f;
            }
            if (min)
            {


                transform.pos[0] -= 0.1f;
            }
            if (transform.pos[0] > 10)
            {
                min = true;
            }
            if (transform.pos[0] < -10)
            {
                min = false;
            }
        }
    }
}
