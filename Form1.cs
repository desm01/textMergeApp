using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace textMergeApp
{
    public partial class TextMerger : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect,     // x-coordinate of upper-left corner
    int nTopRect,      // y-coordinate of upper-left corner
    int nRightRect,    // x-coordinate of lower-right corner
    int nBottomRect,   // y-coordinate of lower-right corner
    int nWidthEllipse, // width of ellipse
    int nHeightEllipse // height of ellipse
);

        public string[] fileNames; 

        public TextMerger()
        {
            InitializeComponent();
            CenterToScreen();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.FormBorderStyle = FormBorderStyle.None;
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 fileNames = openFile.FileNames;
                pictureBox2.Visible = true;
            }

            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
   
            StreamWriter sw = new StreamWriter("output.txt");
            try
            {
                foreach (String fileName in fileNames)
                {
                    sw.Write("<|startoftext|>\n" + merge(fileName) + "\n<|endoftext|>\n\n");

                }
                pictureBox1.Visible = true;
                sw.Close();
            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show("You have not selected any files" +"\n" + ex.ToString());
                Application.Restart();
            }
        }

        public String merge(String fileName)
        {
            if (File.Exists(fileName))
            {
                String name = File.ReadAllText(fileName);
                return name;
            }
            else
            {
                return null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("output.txt");
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
