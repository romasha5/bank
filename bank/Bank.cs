using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace bank
{
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();            
            textBox1.Text = Properties.Settings.Default.PathToFile;
            tabControl1.SelectedIndex = 0;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lisData();
            this.reportViewer1.RefreshReport();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                WorkDBF wd = new WorkDBF();
                DataTable dt = null;

                try {
                    dt = wd.getTable(textBox1.Text, Path.GetFileName(listBox1.SelectedItem.ToString())); }
                catch
                {
                    MessageBox.Show("Список файлів пустий.");
                }

                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                }
            }
        }

        private void Bank_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PathToFile = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                lisData();
            }
        }

        private void lisData()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(WL.itemsTarget(textBox1.Text));
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }
    }
}
