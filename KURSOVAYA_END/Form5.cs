using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.OData.Edm;
using MySql.Data.MySqlClient;

namespace KURSOVAYA_END
{
    public partial class Form5 : Form
    {
        //------------------
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;
        //------------------
        MySqlConnection sqlConn2 = new MySqlConnection();
        MySqlCommand sqlCmd2 = new MySqlCommand();
        DataTable sqlDt2 = new DataTable();
        MySqlDataAdapter DtA2 = new MySqlDataAdapter();
        MySqlDataReader sqlRd2;
        //------------------
        MySqlConnection sqlConn3 = new MySqlConnection();
        MySqlCommand sqlCmd3 = new MySqlCommand();
        DataTable sqlDt3 = new DataTable();
        MySqlDataAdapter DtA3 = new MySqlDataAdapter();
        MySqlDataReader sqlRd3;
        //------------------
        private void RefreshGrids() //функция обновления датагридов (удалено)
        {

        }
        private void UpLoadData()   //функция загрузки данных для датагрид_1
        {
            sqlDt.Clear();
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT id_schedule, concat (name_employee, ' ', surname_employee) as 'Сотрудник',  day_schedule, begin_time, end_time FROM mydb.employee left join mydb.schedule  on employee.id_employee = schedule.at_work_id_worker;";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView2.DataSource = sqlDt;
        }

        public void get_name() //функция получения имени сотрудника которому назначают смену
        {
            string theDate = dateTimePicker1.Value.ToShortDateString(); //берем дату из эл-та dateTimePicker1
            MySqlConnection con = new MySqlConnection("server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password"); //строка подключения к бд
            string query = "SELECT concat (name_employee, ' ', surname_employee) as 'Сотрудник' FROM mydb.employee left join mydb.schedule  on employee.id_employee = schedule.at_work_id_worker where employee.id_employee = '" + textBox5.Text + "';";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = "Назначено сотруднику: " + dr.GetValue(0).ToString() + " " + theDate + " числа," + " c " + textBox1.Text + " до " + textBox2.Text;
            }
            con.Close();
        }
       public void set_shedule() //функция запроса на назначение смены сотруднику
        {
            string var;
            var = textBox1.Text; //начало смены
            var = textBox2.Text; //конец смены
            var = textBox5.Text; // ИД сотрудника
            string theDate2 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            sqlConn2.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn2.Open();
            sqlCmd.Connection = sqlConn2;
            sqlCmd.CommandText = "INSERT INTO `mydb`.`schedule` (`at_work_id_worker`, `day_schedule`, `begin_time`, `end_time`) VALUES ('" + textBox5.Text + "', '" + theDate2 + "', '" + textBox1.Text + "', '" + textBox2.Text + "');";
            sqlRd = sqlCmd.ExecuteReader();
            sqlConn2.Close();
            //RefreshGrids();
        }
        public void get_shedule()
        {
            string var = textBox5.Text; // ИД сотрудника
            //sqlCmd.CommandText = "SELECT concat (name_employee, ' ', surname_employee) as 'Сотрудник', day_schedule as 'День смены',begin_time as 'Начало смены',end_time as 'Конец смены' FROM mydb.employee left join mydb.schedule  on employee.id_employee = schedule.at_work_id_worker where employee.id_employee = '" + textBox5.Text + "';";
            sqlDt3.Clear();
            sqlConn3.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn3.Open();
            sqlCmd3.Connection = sqlConn3;
            sqlCmd3.CommandText = "SELECT id_schedule as 'ID Смены',concat (name_employee, ' ', surname_employee) as 'Сотрудник', day_schedule as 'День смены',begin_time as 'Начало смены',end_time as 'Конец смены' FROM mydb.employee left join mydb.schedule  on employee.id_employee = schedule.at_work_id_worker where employee.id_employee = '" + textBox5.Text + "';";
            sqlRd3 = sqlCmd3.ExecuteReader();
            sqlDt3.Load(sqlRd3);
            sqlRd3.Close();
            sqlConn3.Close();
            dataGridView1.DataSource = sqlDt3;
        }
        public Form5()
        {
            InitializeComponent();
            UpLoadData();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
        get_name();
        set_shedule();
        UpLoadData(); 
        MessageBox.Show(label4.Text);
        }
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e) //dateTimePicker1
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string var = textBox3.Text; // ИД смены
            sqlConn2.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn2.Open();
            sqlCmd.Connection = sqlConn2;
            sqlCmd.CommandText = "DELETE FROM `mydb`.`schedule` WHERE (`id_schedule` = '" + textBox3.Text + "');";
            sqlRd = sqlCmd.ExecuteReader();
            sqlConn2.Close();
            UpLoadData();
            get_shedule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            get_shedule();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panel7.Controls)
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

        private void button3_Click(object sender, EventArgs e)
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

