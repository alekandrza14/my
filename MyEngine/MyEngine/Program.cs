using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;

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
            settings s = new settings();
            init i = new init(Application.StartupPath);
            s.start();
            s = s.s;
            if (!s.spp_color_inpector_or_sch_color_inpector)
            {
                t5.StartInfo.FileName = Application.StartupPath + "/app/color_inspector/Color_inspector.exe";
            }
            else
            {
                t5.StartInfo.FileName = Application.StartupPath + "/app/color_inspector_cpp/Color_inspector_cpp.exe";
            }
            t5.Start();
            Application.Run(new Form1());
            t5.Kill();
            i.exit();

            

        }
    }
    public class settings
    {
        [JsonPropertyName("spp_color_inpector_or_sch_color_inpector")]
        public bool spp_color_inpector_or_sch_color_inpector { get; set; }
        public settings s;
        public settings Load()
        {
            return JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.ini"));
        }
        public void start()
        {
            if (File.Exists("settings.ini"))
            {
                s = Load();
            }
            else
            {
                spp_color_inpector_or_sch_color_inpector = false;
                File.WriteAllText("settings.ini", JsonSerializer.Serialize<settings>(this));
                start();
            }
        }
    }
}
