using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Unauticna
{
    public class Vector2
    {
        public float x, y;
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2()
        {
            this.x = 0f;
            this.y = 0f;
        }
    }
    public class byte2
    {
        public byte x, y;
        public byte2(byte x, byte y)
        {
            this.x = x;
            this.y = y;
        }
        public byte2()
        {
            this.x = 0;
            this.y = 0;
        }
    }
    public class double2
    {
        public double x, y;
        public double2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double2()
        {
            this.x = 0d;
            this.y = 0d;
        }
    }
    public class link__
    {
        public string path;
        public string app;
        public string info;
        public link__(unscript u, string command)
        {
            u.lin = false;
            u.lin2 = false;
            if (command == "1")
            {


                load(u);
            }
            if (command == "2")
            {


                create(u);
            }
        }
        public void load(unscript u)
        {
            path = u.link[u.link.Count - 1];
            app = u.linkname[u.linkname.Count - 1];
            if (File.Exists(path))
            {
                int i2 = path.Length - app.Length;
                int i3 = 0; int i4 = 0;
                for (int i = path.Length - 1; i > i2 - 1 && i4 == 0; i--)
                {
                    if (path[i] != '/' && i4 == 0)
                    {


                        if (path[i] == app[i - i2])
                        {
                            i3++;
                        }
                    }
                    if (path[i] == '/' && i4 == 0)
                    {

                        i4 = 1;


                    }
                }
                if (true)
                {
                    if (true)
                    {


                        if (app.Length == i3)
                        {
                            char[] c = path.ToCharArray();
                            string newpath = "";
                            for (int i = 0; i < c.Length - app.Length; i++)
                            {
                                newpath += c[i];
                            }

                            Console.WriteLine("совпадает" + "|" + newpath);

                            Process p = new Process();
                            p.StartInfo.FileName = path;
                            p.StartInfo.WorkingDirectory = newpath;
                            p.Start();

                        }
                        if (app.Length != i3)
                        {
                            Console.WriteLine("не совпадает" + path + "|" + i3 + "'" + app.Length);
                        }
                    }
                }
            }
        }

        public void create(unscript u)
        {
            
            path = u.link[u.link.Count - 1];
            info = u.linkname[u.linkname.Count - 1];
            File.WriteAllText(path,info);
            
        }

    }
    public class unscript
    {
       public unscript()
        {

        }
       public static void load(string uns)
        {
            unscript unsl = new unscript();
                unsl.ins = uns;
            unsl.Start();

        }
        public void GetVarMessange()
        {
            for (int i = 0; i < outs.Count; i++)
            {
                Console.ForegroundColor=ConsoleColor.DarkGray;
                Console.WriteLine(outs[i]);
            }
            for (int i = 0; i < outs2.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(outs2[i]);
            }
            for (int i = 0; i < outs3.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(outs3[i]);
            }
            for (int i = 0; i < outsv.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(outsv[i]);
            }
            for (int i = 0; i < outsd.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(outsd[i]);
            }
            for (int i = 0; i < link.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(link[i]);
            }
            for (int i = 0; i < linkname.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(linkname[i]);
            }
        }
        public string ins;

        public string pre;
        string pre1;
        string pre2;
        public List<string> outs = new List<string>();
        public List<string> outs2 = new List<string>();
        List<string> outs3 = new List<string>();
        public List<Vector2> outsv = new List<Vector2>();
        public List<double2> outsd = new List<double2>();
        public List<string> link = new List<string>();
        public List<string> linkname = new List<string>();
        public bool lin,lin2;
        // Start is called before the first frame update
        public void Start()
        {
            if (File.Exists(ins))
            {
                pre = File.ReadAllText(ins);
            }
            for (int i = 0; i < pre.Length; i++)
            {
                pre1 += pre[i];
                if (pre[i] == '+')
                {
                    outs.Add(pre1);

                    pre1 = "";
                    for (int x = 0; x < outs.Count; x++)
                    {
                        if (outs[x] == "/stop/+")
                        {
                            Console.WriteLine("остановлено"); 
                            i = pre.Length;
                        }
                        if (outs[x] == "/done/+")
                        {
                            Console.WriteLine("остановлено и готово");
                            i = pre.Length;
                        }
                        if (outs[x] == "/debug/+")
                        {
                            Console.WriteLine("остановлено иза доступа");
                            i = pre.Length;
                        }
                    }
                }
            }
            for (int x = 0; x < outs.Count; x++)
            {

                if (outs[x][0] == '/' && outs[x][1] == 'v' && outs[x][2] == 'a' && outs[x][3] == 'r' && outs[x][4] == ' ')
                {
                    for (int y = 5; y < outs[x].Length - 2; y++)
                    {
                        pre2 += outs[x][y];

                    }
                    outs2.Add(pre2);
                    pre2 = "";

                }
                if (outs[x][0] == '/' && outs[x][1] == 'l' && outs[x][2] == 'i' && outs[x][3] == 'n' && outs[x][4] == 'k' && outs[x][5] == '|' && outs[x][6] == ':')
                {
                    for (int y = 7; y < outs[x].Length - 2; y++)
                    {
                        if (outs[x][y] != '=')
                        {


                            pre2 += outs[x][y];
                        }
                        if (outs[x][y] == '=')
                        {


                            pre2 += "/";
                        }

                    }
                    link.Add(pre2);
                    lin = true;
                    pre2 = "";

                }
                if (lin)
                {
                    if (outs[x][0] == '/' && outs[x][1] == 'v' && outs[x][2] == 'a' && outs[x][3] == 'r' && outs[x][4] == ' ')
                    {
                        for (int y = 5; y < outs[x].Length - 2; y++)
                        {
                            pre2 += outs[x][y];

                        }
                        linkname.Add(pre2);
                        Console.WriteLine(linkname[linkname.Count-1]);
                        lin2 = true;
                        pre2 = "";
                        
                    }
                }

                if (outs[x] == "/start/+" && lin && lin2)
                {

                    new link__(this,"1");


                }
                if (outs[x] == "/create/+" && lin && lin2)
                {

                    new link__(this,"2");


                }



                if (outs[x][0] == '/' && outs[x][1] == 'v' && outs[x][2] == 'e' && outs[x][3] == 'l' && outs[x][4] == ' ')
                {
                    int x1 = 0;
                    Vector2 v2 = new Vector2();
                    for (int y = 5; y < outs[x].Length - 2; y++)
                    {
                        if (outs[x][y] != '|' && x1 == 0)
                        {

                            pre2 += outs[x][y];
                        }


                        if (outs[x][y] == '|')
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }
                        if (y == outs[x].Length - 3)
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }


                    }

                    if (x1 == 0)
                    {
                        v2 = new Vector2(float.Parse(outs3[0]), float.Parse(outs3[1]));

                      //  Console.WriteLine("vector=" + v2.x + "|" + v2.y);
                    }
                    outsv.Add(v2);
                    outs3 = new List<string>();
                    pre2 = "";

                }
                if (outs[x][0] == '/' && outs[x][1] == 't' && outs[x][2] == 'e' && outs[x][3] == 'p' && outs[x][4] == ' ')
                {
                    int x1 = 0;
                    double2 v2 = new double2();
                    for (int y = 5; y < outs[x].Length - 2; y++)
                    {
                        if (outs[x][y] != '|' && x1 == 0)
                        {

                            pre2 += outs[x][y];
                        }


                        if (outs[x][y] == '|')
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }
                        if (y == outs[x].Length - 3)
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }


                    }

                    if (x1 == 0)
                    {
                        v2 = new double2(double.Parse(outs3[0]), double.Parse(outs3[1]));

                        Console.WriteLine("^vector=" + v2.x + "|" + v2.y);
                    }
                    outsd.Add(v2);
                    outs3 = new List<string>();
                    pre2 = "";

                }
            }

        }
    }
}
