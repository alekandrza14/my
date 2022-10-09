using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using System.Diagnostics;

namespace MyEngine
{
    static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OpenTK.Vector2 t = OpenTK.Vector2.Zero;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process t5 = new Process();
            t5.StartInfo.FileName = Application.StartupPath+ "/app/color_inspector/Color_inspector.exe";
            t5.Start();
            Application.Run(new Form1());
            t5.Kill();


        }
    }
}
