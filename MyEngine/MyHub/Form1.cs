using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MyHub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:/MyProjects/" + textBox1.Text);
           if(!File.Exists("C:/MyProjects/" + textBox1.Text + "/Unpack me.zip")) File.Copy(textBox2.Text +".zip", "C:/MyProjects/" + textBox1.Text+"/Unpack me.zip");
            else
            {
                File.Delete("C:/MyProjects/" + textBox1.Text + "/Unpack me.zip");
                File.Copy(textBox2.Text+".zip", "C:/MyProjects/" + textBox1.Text + "/Unpack me.zip");
            }
            Process t5 = new Process();
            t5.StartInfo.FileName = "C:/Windows/explorer.exe";
            t5.StartInfo.WorkingDirectory = "C:/MyProjects/" + textBox1.Text;
            t5.StartInfo.Arguments = "C:\\MyProjects\\" + textBox1.Text+"";
            t5.Start();
            Process t6 = new Process();
            t6.StartInfo.FileName = "MyEngine.exe";
            t6.Start();

        }
    }
}
