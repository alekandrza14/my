using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unauticna
{
    public class data_var
    {
        public static List<float> numsdata = new List<float>();
        public static List<string> numsname = new List<string>();
        public static data_var_get get()
        {
            data_var_get dvg = new data_var_get();
            dvg.numsdata = numsdata; 
            dvg.numsname = numsname;
            return dvg;
        }
    }
    public class data_var_get
    {
        public List<float> numsdata;
        public List<string> numsname;
    }
}
