using System;
using System.Collections;
using System.IO;
using System.Runtime;

namespace Unauticna.lib
{
    public class lib
    {
        public static void set(string assetfolder)
        {
            Directory.CreateDirectory(assetfolder);
        }
    }
}
