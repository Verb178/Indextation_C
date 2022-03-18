using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indextation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
                listBox1.Items.Clear();
                string partialName = textBox2.Text;
                string[] files = Directory.GetFiles(textBox1.Text, "*" + partialName + "*.*", SearchOption.AllDirectories);
                System.Windows.Forms.MessageBox.Show("Files trouvé: " + files.Length.ToString(), "Message");

            int i;
            for (i = 0; i < files.Length; i++)
            {
                listBox1.Items.Add(Path.GetFileName(files[i]) + ";" + Path.GetDirectoryName(files[i]) + ";" + Path.GetFileName(Path.GetDirectoryName(files[i])));
            }

        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("dd-MM-yyyy-HH-mm");
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != null && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                String timeStamp = GetTimestamp(DateTime.Now);
                const string sPath = "info";

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(textBox3.Text + "\\" + sPath + "-" + timeStamp + ".csv");
                foreach (var item in listBox1.Items)
                {
                    SaveFile.WriteLine(item);
                }

                SaveFile.Close();

                MessageBox.Show("Information sauvegardé!");
            } else
            {
                MessageBox.Show("Veuillez indiquer un dossier ou enregistrer.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
