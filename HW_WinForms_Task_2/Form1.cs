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
using System.Xml.Serialization;
using System.Xml.Linq;

namespace HW_WinForms_Task_2
{
    public partial class Form1 : Form
    {
        public string data;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //=======================================
            name = new Label();
            surname = new Label();
            tel_number = new Label();
            e_mail = new Label();
            prog_name = new Label();
            data_name = new Label();
            enter_name = new TextBox();
            enter_surname = new TextBox();
            enter_num = new TextBox();
            enter_email = new TextBox();
            edited_str = new TextBox();
            info = new ListBox();
            add_list = new Button();
            del_list = new Button();
            edit_list = new Button();
            save_txt = new Button();
            save_xml = new Button();
            //=======================================
            prog_name.Text = "АНКЕТА";
            prog_name.Width = 100;
            prog_name.ForeColor = Color.White;
            prog_name.Location = new Point(255, 18);
            prog_name.Font = new Font("Times New Roman", 14);
            //=======================================
            data_name.Text = "СОХРАНЁННЫЕ ДАННЫЕ";
            data_name.Width = 350;
            data_name.ForeColor = Color.White;
            data_name.Location = new Point(180, 194);
            data_name.Font = new Font("Times New Roman", 14);
            //=======================================
            name.Text = "Имя:";
            name.Width = 100;
            name.ForeColor = Color.White;
            name.Location = new Point(55, 65);
            name.Font = new Font("Times New Roman", 12);
            //=======================================
            surname.Text = "Фамилия:";
            surname.Width = 100;
            surname.ForeColor = Color.White;
            surname.Location = new Point(55, 95);
            surname.Font = new Font("Times New Roman", 12);
            //=======================================
            tel_number.Text = "Телефон:";
            tel_number.Width = 100;
            tel_number.ForeColor = Color.White;
            tel_number.Location = new Point(55, 125);
            tel_number.Font = new Font("Times New Roman", 12);
            //=======================================
            e_mail.Text = "E-mail:";
            e_mail.Width = 100;
            e_mail.ForeColor = Color.White;
            e_mail.Location = new Point(55, 155);
            e_mail.Font = new Font("Times New Roman", 12);
            //=======================================
            enter_name.Location = new Point(210, 65);
            enter_name.Size = new Size(20, 100);
            enter_name.Width = 300;
            enter_name.BackColor = Color.White;
            //=======================================
            enter_surname.Location = new Point(210, 95);
            enter_surname.Size = new Size(20, 100);
            enter_surname.Width = 300;
            enter_surname.BackColor = Color.White;
            //=======================================
            enter_num.Location = new Point(210, 125);
            enter_num.Size = new Size(20, 100);
            enter_num.Width = 300;
            enter_num.BackColor = Color.White;
            //=======================================
            enter_email.Location = new Point(210, 155);
            enter_email.Size = new Size(20, 100);
            enter_email.Width = 300;
            enter_email.BackColor = Color.White;
            //=======================================
            info.Size = new Size(330, 300);
            info.Location = new Point(55, 237);
            //=======================================
            add_list.Size = new Size(100, 30);
            add_list.Location = new Point(410, 237);
            add_list.BackColor = Color.White;
            add_list.ForeColor = Color.Black;
            add_list.Text = "Add to list";
            add_list.Click += Add_list_Click;
            //=======================================
            del_list.Size = new Size(100, 30);
            del_list.Location = new Point(410, 297);
            del_list.BackColor = Color.White;
            del_list.ForeColor = Color.Black;
            del_list.Text = "Delete item";
            del_list.Click += Del_list_Click;
            //=======================================
            edit_list.Size = new Size(100, 30);
            edit_list.Location = new Point(410, 357);
            edit_list.BackColor = Color.White;
            edit_list.ForeColor = Color.Black;
            edit_list.Text = "Edit item";
            edit_list.Click += Edit_list_Click;
            //=======================================
            edited_str.Size = new Size(20, 100);
            edited_str.Location = new Point(55, 260);
            edited_str.Width = 300;
            edited_str.BackColor = Color.White;
            //=======================================
            save_txt.Size = new Size(100, 30);
            save_txt.Location = new Point(410, 417);
            save_txt.BackColor = Color.White;
            save_txt.ForeColor = Color.Black;
            save_txt.Text = "Save in .txt";
            save_txt.Click += Save_txt_Click;
            //=======================================
            save_xml.Size = new Size(100, 30);
            save_xml.Location = new Point(410, 477);
            save_xml.BackColor = Color.White;
            save_xml.ForeColor = Color.Black;
            save_xml.Text = "Save in .xml";
            save_xml.Click += Save_xml_Click;
            //=======================================
            Controls.Add(prog_name);
            Controls.Add(data_name);
            Controls.Add(name);
            Controls.Add(surname);
            Controls.Add(tel_number);
            Controls.Add(e_mail);
            Controls.Add(enter_name);
            Controls.Add(enter_surname);
            Controls.Add(enter_num);
            Controls.Add(enter_email);
            Controls.Add(info);
            Controls.Add(add_list);
            Controls.Add(del_list);
            Controls.Add(edit_list);
            Controls.Add(save_txt);
            Controls.Add(save_xml);
        }

        private void Save_xml_Click(object sender, EventArgs e)
        {
            XElement element = new XElement("Items");
            foreach (var item in info.Items)
            {
                element.Add(new XElement("Name", item));
            }
            XDocument document = new XDocument();
            document.Add(element);
            document.Save("data.xml", SaveOptions.DisableFormatting);
            MessageBox.Show("all saved!");
        }

        private void Save_txt_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();

            string out_str = "";
            foreach (string line in info.Items)
            {
                out_str = out_str + line + Environment.NewLine;
            }

            out_str = Environment.NewLine + out_str;
            File.WriteAllText(f.FileName = "data.txt", out_str);
            MessageBox.Show("all saved!");
        }

        private void Edit_list_Click(object sender, EventArgs e)
        {
            Controls.Add(edited_str);
            //. . .
        }

        private void Del_list_Click(object sender, EventArgs e)
        {
            info.Items.RemoveAt(info.SelectedIndex);
        }

        private void Add_list_Click(object sender, EventArgs e)
        {
            info.Items.Add("Имя: " + enter_name);
            info.Items.Add("Фамилия: " + enter_surname);
            info.Items.Add("Номер телефона: " + enter_num);
            info.Items.Add("E-mail: " + enter_email);
            
        }

        Label name;
        Label surname;
        Label tel_number;
        Label e_mail;
        Label prog_name;
        Label data_name;
        TextBox enter_name;
        TextBox enter_surname;
        TextBox enter_num;
        TextBox enter_email;
        TextBox edited_str;
        ListBox info;
        Button add_list;
        Button del_list;
        Button edit_list;
        Button save_txt;
        Button save_xml;
    }
}
