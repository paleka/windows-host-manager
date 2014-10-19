using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DirectoryInfo dinfo = new DirectoryInfo(@"assets\hosts\");

            FileInfo[] Files = dinfo.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                String withoutTxt = file.Name.Substring(0, file.Name.Length - 4);
                listBox1.Items.Add(withoutTxt);
            }


        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                this.Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string curItem = listBox1.SelectedItem.ToString();
                textBox1.Text = curItem;
                loadText(curItem);
            }
            else
            {
                tempbox.Text = "empty click";
            }
            //saveText(); change host file instantly
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                saveText();
            }
            else
            {
                tempbox.Text = "empty click";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //loadText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string curItem = listBox1.SelectedItem.ToString();
                saveToSource(curItem);
            }
            else
            {
                tempbox.Text = "empty click";
            }
        }

        public void saveToSource(string curItem)
        {
            
            string path = @"assets\hosts\" + curItem + ".txt";
            File.WriteAllLines(path, textBox1.Lines);
            saveText();
        }



        public void loadText(string curItem)
        {
            textBox1.Text = File.ReadAllText(@"assets\hosts\"+curItem+".txt");
        }

        public void saveText()
        {
            string path = @"C:\Windows\System32\drivers\etc\hosts";
            File.WriteAllLines(path, textBox1.Lines);

            string curItem = listBox1.SelectedItem.ToString();
            string str = curItem.Substring(2);

            tempbox.Text = str;
        }


        //@todo before clsing application and restore host file on exit
        public void ExitApplication()
        {
            //textBox1.Text = "Hello World";
            //textBox1.Select(6, 5);

            //MessageBox.Show(textBox1.SelectedText);

            // Display a message box asking users if they
            // want to exit the application.
            /*if (MessageBox.Show("Do you want to exit?", "My Application",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
                Application.Exit();
            }
            */
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            /*Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
            textBox1.Width = size.Width;
            textBox1.Height = size.Height;*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
