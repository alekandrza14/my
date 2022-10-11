using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.IO;
using System.Windows.Forms;

namespace MyEngine
{
    public class init
    {
        public Process input;
        public init(string a)
        {
            
            if (File.Exists("app/input_ahk/Input.exe"))
            {
                input = new Process();
                input.StartInfo.FileName = a + "/app/input_ahk/Input.exe";
                input.Start();
            }
            
        }
        public void exit()
        {
            
            input.Kill();
            
        }
    }
}
