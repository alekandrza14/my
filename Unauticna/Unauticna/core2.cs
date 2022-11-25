using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unauticna
{
    public class core2
    {
        string sigdata = "";
        int t = 0;
        public string code;
        public List<string> words = new List<string>();
        string word;

        public void clear()
        {
            sigdata = "";
            t = 0;
        }
        public void end()
        {

            words.Clear();

        }
        public void get()
        {





            for (int i = 0; i < code.Length; i++)
            {
              //  Console.WriteLine(code[i]);
                if (code[i] == ' ')
                {
                    words.Add(word);
                    word = "";

                }
                else if (code[i] == '_')
                {


                    word += " ";
                }
                else if (code[i] == '(')
                {


                    words.Add("start");
                }
                else if (code[i] == ')')
                {


                    words.Add("unstart");
                }
                else if (code[i] == '.' && sigdata != "end?")
                {
                    sigdata = "end?";
                    word += code[i];
                }
                else if (code[i] == '.' && sigdata == "end?")
                {

                    words.Add("exit");
                  //  Console.WriteLine("exit");


                }
                else if (code[i] != '.' && sigdata == "end?")
                {



                    word += code[i];
                    clear();

                }

                else if (code[i] == '\n')
                {
                    words.Add(word);
                    word = "";
                }
                else if (code[i] == ';')
                {
                    words.Add(word);
                    words.Add("end");
                    word = "";


                }
                else
                {

                    word += code[i];
                }
            }

            string typedata = ""; string vardata = ""; int varindex = -1; float numdata = 0; bool scobe = false;
            for (int i = 0; i < words.Count; i++)
            {

              //  Console.WriteLine(words[i]);
                if (words[i] == "num")
                {
                    typedata = "number data";
                  //  Console.WriteLine("number data");
                }
                else if (words[i] == "start")
                {
                    scobe = true;
                 //   Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else if (words[i] == "unstart" && scobe)
                {
                   // Console.ForegroundColor = ConsoleColor.White;
                    scobe = false;
                }
                else if (words[i] == ".sig")
                {

                    Console.ReadLine();
                }
                else if (words[i] == "return")
                {
                    typedata = "run new script";
                }
                else if (typedata == "number data")
                {
                    unscript u = new unscript();
                    u.pre = words[i];
                    u.Start();
                    data_var.numsdata.Add(u.outsv[0].x);
                    data_var.numsname.Add(u.outs2[0]);
                    MainCore.datas.Add(u);
                    //  Console.WriteLine("number var");
                    typedata = "end";
                }
                else if (words[i] == "write")
                {
                    
                    typedata = "write";
                }
                else if (typedata == "write" && words[i] != "end")
                {
                    Console.Write(words[i]);



                }
                else if (typedata == "write" && words[i] == "end")
                {
                   // Console.Write(words[i]);
                    Console.Write("\n");
                    typedata = "end";

                }
                else if (typedata == "run new script")
                {
                    unscript u = new unscript();
                    u.pre = words[i];
                    u.Start();
                    MainCore.newfile = u.link[0];
                    MainCore.datas.Add(u);

                    typedata = "end";

                }
                else if (words[i] == "end" && typedata == "end")
                {
                    typedata = "";
                }
                else if (words[i] == "exit")
                {
                    MainCore.newfile = "death";


                    typedata = "";

                }
                else if (words[i] == "+" && typedata == "var")
                {



                    typedata = "plus";

                }
                else if (typedata == "plus" && vardata != "" && varindex != -1)
                {

                    for (int ie = 0; ie < data_var.numsname.Count; ie++)
                    {
                        string t = data_var.numsname[ie];
                        if (words[i] == t)
                        {

                            //     Console.WriteLine(t + " is found");
                            typedata = "end";
                            data_var.numsdata[varindex] = (float)(data_var.numsdata[ie] + numdata);
                            //   Console.WriteLine("a + b = " + (int)(data_var.numsdata[ie] + numdata));
                            vardata = "";
                            varindex = -1;
                            numdata = 0;

                        }
                    }

                    typedata = "end";

                }
                else if (typedata == "plus" && vardata == "")
                {

                    for (int ie = 0; ie < data_var.numsname.Count; ie++)
                    {
                        string t = data_var.numsname[ie];
                        if (words[i] == t)
                        {

                            //  Console.WriteLine(t + " is found");
                            typedata = "end";

                            //   Console.WriteLine("? + b = ?");
                            vardata = "";
                            numdata = 0;

                        }
                    }

                    typedata = "end";

                }
                else if (words[i] == "-" && typedata == "var")
                {



                    typedata = "minu";

                }
                else if (typedata == "minu" && vardata != "" && varindex != -1)
                {

                    for (int ie = 0; ie < data_var.numsname.Count; ie++)
                    {
                        string t = data_var.numsname[ie];
                        if (words[i] == t)
                        {

                            //     Console.WriteLine(t + " is found");
                            typedata = "end";
                            data_var.numsdata[varindex] = (float)(numdata - data_var.numsdata[ie]);
                            //   Console.WriteLine("a + b = " + (int)(data_var.numsdata[ie] + numdata));
                            vardata = "";
                            varindex = -1;
                            numdata = 0;

                        }
                    }

                    typedata = "end";

                }
                else if (typedata == "minu" && vardata == "")
                {

                    for (int ie = 0; ie < data_var.numsname.Count; ie++)
                    {
                        string t = data_var.numsname[ie];
                        if (words[i] == t)
                        {

                            //  Console.WriteLine(t + " is found");
                            typedata = "end";

                            //   Console.WriteLine("? + b = ?");
                            vardata = "";
                            numdata = 0;

                        }
                    }

                    typedata = "end";

                }
                else if (typedata != "write" && words[i] == "chek var")
                {

                    for (int ie = 0; ie < data_var.numsname.Count; ie++)
                    {
                        string t = data_var.numsname[ie]; 
                        float t2 = data_var.numsdata[ie];
                        Console.WriteLine(t2 + ": < nuber varible > :" + t);
                    }

                    typedata = "end";

                }
                else
                {
                    
                    for (int ie =0;ie< data_var.numsname.Count;ie++)
                    {
                        string t = data_var.numsname[ie];
                        if (words[i] == t)
                        {

                          //  Console.WriteLine(t + " is found");
                            typedata = "var";
                            vardata = t;
                            varindex = ie;
                            numdata = data_var.numsdata[ie];


                        }
                    }

                }


            }


        }

    }
}
