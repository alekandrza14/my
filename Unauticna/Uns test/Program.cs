using System;
using System.Collections.Generic;
using System.IO;
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
            MainCore.newfile = "main.uns";
            if (File.Exists(MainCore.newfile))
            {


                MainCore.newfile = "main.uns";
                 while (MainCore.Run() != 0)
                  {
                
                  }
                
                //  core2 c = new core2();
                //  c.code = File.ReadAllText(MainCore.newfile);
                //
                //  Console.ReadLine();
                //  c.get();
                //  Console.WriteLine(MainCore.newfile);
                //  Console.WriteLine(c.words.ToArray().Length);
                //  Console.WriteLine(c.code.Length);
                //  Console.ReadLine();
                //  c.end();
                //  c.get();
                //  
                //  Console.WriteLine(MainCore.newfile);
                //  Console.WriteLine(c.words.ToArray().Length);
                //  Console.WriteLine(c.code.Length);
                //  Console.ReadLine();
            }
            else
            {
                Console.WriteLine("file not find");
                Console.ReadLine();
            }

            /*
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
            */

        }
    }
}
