using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace HW_Task_1
{
    public partial class Form1 : Form
    {
        public string line = " ";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1 = new ProgressBar();
            text = new ListBox();
            btn = new Button();
            counter_min = new Label();
            counter_max = new Label();
            str_counter = new Label();
            text.Location = new Point(30, 30);
            text.Size = new Size(420, 250);
            text.Font = new Font("Times New Roman", 14);
            progressBar1.Location = new Point(30, 300);
            progressBar1.Size = new Size(420, 30);
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            btn.Location = new Point(190, 350);
            btn.Size = new Size(100, 50);
            btn.Text = "Read";
            btn.Font = new Font("Times New Roman", 10);
            btn.BackColor = Color.White;
            counter_min.Width = 100;
            counter_min.Location = new Point(30, 335);
            counter_min.ForeColor = Color.White;
            counter_min.Text = "0";
            counter_max.Width = 100;
            counter_max.Location = new Point(427, 335);
            counter_max.ForeColor = Color.White;
            counter_max.Text = "100";
            str_counter.Location = new Point(35, 410);
            str_counter.ForeColor = Color.White;
            str_counter.Width = 500;
            str_counter.Font = new Font("Times New Roman", 12);
            text.SelectedValueChanged += listBox1_SelectedValueChanged;
            btn.Click += button1_Click;
            Controls.Add(progressBar1);
            Controls.Add(text);
            Controls.Add(btn);
            Controls.Add(counter_min);
            Controls.Add(counter_max);
            Controls.Add(str_counter);
        }

        StreamReader inStream = new StreamReader("D:\\readfile.txt");
        int i = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string line = "";
            while ((line = inStream.ReadLine()) != null)
            {
                text.Items.Add(inStream.ReadLine());
                i++;
            }
            progressBar1.Maximum = i;
            text.SelectedIndex = 0;
            str_counter.Text = i.ToString() + " - counter of strings. Click on string to input value on Progress Bar!";
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (text.SelectedIndex != -1)
            {
                progressBar1.Value = text.SelectedIndex;
            }
        }
        
        ProgressBar progressBar1;
        ListBox text;
        Button btn;
        Label counter_min;
        Label counter_max;
        Label str_counter;
    }
}
