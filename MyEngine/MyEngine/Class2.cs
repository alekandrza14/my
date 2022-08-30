using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toe;
using System.Runtime;

namespace MyEngine
{
    public static class anim
    {
        public static void play(Vectorinf vi,float time, float speed)
        {

            float f = (float)Math.Cos(time*speed);
            vi.pos[1] = f;

        }

       
    }
}
