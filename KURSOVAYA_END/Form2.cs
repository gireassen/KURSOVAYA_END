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
    public partial class Form2 : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;
        private void RefreshGrids() //функция обновления датагридов
        {
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
        private void UpLoadData()   //функция загрузки данных для датагрид_1
        {
            sqlDt.Clear();
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "select id_employee as 'id сотрудника',concat (name_employee, ' ', surname_employee) as 'Сотрудник' from mydb.employee;";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView1.DataSource = sqlDt;
        }
        public Form2()
        {
            InitializeComponent();
            UpLoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e) //кнопка Выход
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

        private void button8_Click(object sender, EventArgs e)//кнопка "очистки" от текста
        {
            try
            {
                foreach (Control c in panel3.Controls)
                {
                    if (c is TextBox box)
                    {
                        box.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e) 
        {

        }

        private void button5_Click(object sender, EventArgs e)//кнопка "добавить сотрудника"
        {
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";

            try
            {
                sqlConn.Open();
                string var;
                var = textBox1.Text;
                var = textBox3.Text;
                sqlCmd.CommandText = "INSERT INTO mydb.employee (name_employee, surname_employee)" + "VALUES ('" + textBox3.Text + "' , '" + textBox1.Text + "')";
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();
                UpLoadData();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpLoadData();
                RefreshGrids();
            }
        }

        private void button7_Click(object sender, EventArgs e)//кнопка "удалить сотрудника"
        {
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";

            try
            {
                sqlConn.Open();
                string var;
                var = textBox2.Text;
                sqlCmd.CommandText = "DELETE FROM mydb.employee WHERE (id_employee = '" + textBox2.Text + "')";
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();
                UpLoadData();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpLoadData();
                RefreshGrids();
            }
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

        private void информацияПоРаботеToolStripMenuItem_Click(object sender, EventArgs e) //открыть справку
        {
            Form8 f = new Form8();
            f.ShowDialog();
        }
    }
}
