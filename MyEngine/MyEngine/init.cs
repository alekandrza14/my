using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.IO;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MyEngine
{
    public class init
    {
        public Process input;

        /*
        public GameObject[] Load(string json)
        {
            GameObject[] n = JsonSerializer.Deserialize<GameObject[]>(json);
            for (int i =0;i<n.Length;i++)
            {
                n[i].load();

            }
            return n;
        }
        */
        public init(string a)
        {
           
                File.Delete("C:/MyEngine/input_back.sig");
                File.Delete("C:/MyEngine/input_nsig1.sig");
             File.Delete("C:/MyEngine/input_right.sig");
                File.Delete("C:/MyEngine/input_nsig2.sig");
            
                File.Delete("C:/MyEngine/input_left.sig");

                File.Delete("C:/MyEngine/input_nsig3.sig");
           
                File.Delete("C:/MyEngine/input_up.sig");
                File.Delete("C:/MyEngine/input_nsig4.sig");
            
                File.Delete("C:/MyEngine/input_down.sig");
                File.Delete("C:/MyEngine/input_nsig5.sig");
           
                File.Delete("C:/MyEngine/input_forward.sig");

                File.Delete("C:/MyEngine/input_nsig.sig");
           
                File.Delete("C:/MyEngine/input_forward1.sig");


          
                File.Delete("C:/MyEngine/input_back1.sig");
            
                File.Delete("C:/MyEngine/input_right1.sig");
            
                File.Delete("C:/MyEngine/input_left1.sig");

            
            if (File.Exists("app/input_ahk/Input.exe"))
            {
             //   input = new Process();
              //  input.StartInfo.FileName = a + "/app/input_ahk/Input.exe";
              //  input.Start();
            }
            
        }
        public void exit()
        {
            
            
        }
    }
}
