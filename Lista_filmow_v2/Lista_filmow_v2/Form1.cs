using static System.Windows.Forms.LinkLabel;
using System.IO;

namespace Lista_filmow_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
/*        string path = @"S:\Filip Trzmiel\Lista_filmow_v2\Lista_filmow_v2\text.txt";
*/
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Nie podano danych");

            }
            else
            {
                string[] row = { textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Czy zapisaæ dane?", "Okno", btns);
            string[] linie = new string[listView1.Items.Count];
            int i = 0;

            if (result == DialogResult.Yes)
                foreach (ListViewItem item in listView1.Items)
                {
                    linie[i] = "";
                    for (int k = 0; k < item.SubItems.Count; k++)
                        linie[i] += item.SubItems[k].Text + "^";

                    i++;
                    File.WriteAllLines("text.txt", linie);
                    Application.Exit();
                }
            else
            {
                Application.Exit();
            }
        

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void usunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string[] linie = new string[listView1.Items.Count];
            int i = 0;
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Nie podano danych");
            }
            else {
                foreach (ListViewItem item in listView1.Items)
                {
                    linie[i] = "";
                    for (int k = 0; k < item.SubItems.Count; k++)
                        linie[i] += item.SubItems[k].Text + "^";

                    i++;
                
                }
/*                string path = @"S:\Filip Trzmiel\Lista_filmow_v2\Lista_filmow_v2\text.txt";
*/                

                File.WriteAllLines("text.txt", linie);
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] linie = File.ReadAllLines("text.txt");

            string[] row = { textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text };
            var listViewItem = new ListViewItem(row);


            if (!File.Exists("text.txt"))
                return;


            foreach (string linia in linie)
            {
                string[] temp = linia.Split('^');

                Convert.ToString(temp);
                listView1.Items.Add(new ListViewItem(temp));

            }
        }

        private void zmieñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == "")
            {
                MessageBox.Show("Nie podano danych");
            }
            else
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
                listView1.SelectedItems[0].SubItems[2].Text = textBox3.Text;
                listView1.SelectedItems[0].SubItems[3].Text = dateTimePicker1.Text;
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}