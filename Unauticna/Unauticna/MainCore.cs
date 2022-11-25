using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unauticna
{
    public static class MainCore
    {
      static  public string newfile;
        static public List<unscript> datas = new List<unscript>();
        public static data_var_get get() {
          return  data_var.get();
        }
        public static int Run()
        {
            if (File.Exists(newfile) && newfile != "death")
            {
                core2 c = new core2();
                c.code = File.ReadAllText(newfile);
                c.get();
                return 1;
            }
           else if (newfile == "death")
            {
                
                return 0;
            }
            return 1;
        }
    }
}
