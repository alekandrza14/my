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
            bool exit = false;
            unscript t2 = new unscript();
            t2.ins = "main.uns";
            t2.Start();
            unscript t = new unscript();
            t.ins = t2.outs2[0];
            t.Start();
            while (!exit)
            {


                string s = Console.ReadLine();
                if (s == "GetVar?")
                {

                    t.GetVarMessange();
                }
                if (s == "Clear")
                {

                    Console.Clear();
                }
                if (s == "Reset?!")
                {

                    Console.Clear();
                    unscript r2 = new unscript();
                    r2.ins = "main.uns";
                    r2.Start();
                    
                    t.ins = r2.outs2[0];
                    t.Start();
                }
                if (s == "Exit")
                {

                    exit = true;
                }
            }
            
        }
    }
}
