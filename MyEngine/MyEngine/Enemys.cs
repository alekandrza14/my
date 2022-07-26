using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MyEngine
{
    public class Enemys
    {
        public Point ellipsepos1 = new Point(200, 200);
        public Point endstene = new Point(800, 0);
        public Point endstene1 = new Point(1, 488);
        public bool p3; public bool rot; public bool isdie;
        public Enemys(Point pos, Point posup)
        {
            ellipsepos1 = pos;
            endstene1 = posup;
        }
        public Enemys(Point pos, Point posup,bool rot2)
        {
            ellipsepos1 = pos;
            endstene1 = posup;
            rot = rot2;
        }
        public Enemys()
        {
            
        }
    }
}
