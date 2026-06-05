using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
   public class fall
    {
        public void Update(object type)
        {
            object ob = new Enemys();
            if (type.GetType() == ob.GetType())
            {

                var en = (Enemys)type;
                en.ellipsepos1.Y += 3;
            }
        }
    }
}
