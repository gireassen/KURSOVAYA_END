using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KURSOVAYA_END
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password"); //строка подключения к бд
            textBox2.PasswordChar = '*'; //спрятать строку ввода пароля
        }

        private void button1_Click(object sender, EventArgs e) //кнопка авторизоваться
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM auth_login where login='" + textBox1.Text + "' AND pass='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read()) //логин\пасс верны
            {
                textBox2.Clear(); //очистить поле с паролем
                MessageBox.Show("Авторизация прошла успешно!");
                Form3 f = new Form3(); //открыть меню
                f.ShowDialog();
            }
            else //логин\пасс не верны
            {
                textBox1.Clear(); //очистить поле с логином
                textBox2.Clear();//очистить поле с паролем
                MessageBox.Show("Неверное сочетание логина и пароля!");
            }
            con.Close();
        }

        private void информацияПоРаботеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.ShowDialog();
        }

        private void выходИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            try
            {
                iExit = MessageBox.Show("Подтвердите выход из программы. Вы перейдёте в окно выбора управления.", "MySQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}