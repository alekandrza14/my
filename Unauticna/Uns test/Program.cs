using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unauticna;

namespace Uns_test
{
    class Program
    {
        static public void Main(string[] args)
        {
            unscript t2 = new unscript();
            t2.ins = "main.uns";
            t2.Start();
            unscript t = new unscript();
            t.ins = t2.outs2[0];
            t.Start();
          string s = Console.ReadLine();
            if (s == "GetVar?")
            {

                t.GetVarMessange();
            }
            Console.ReadLine();
        }
    }
}
