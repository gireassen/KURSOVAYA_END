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
    public partial class Form4 : Form
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

        private void RefreshGrids() //функция обновления датагридов
        {
            dataGridView2.Update();
            dataGridView2.Refresh();
            dataGridView3.Update();
            dataGridView3.Refresh();
        }
        private void UpLoadData2()   //функция загрузки данных для датагрид_2 вывести список сотрудников
        {
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "select id_employee as 'id сотрудника',concat (name_employee, ' ', surname_employee) as 'Сотрудник',name_position as 'Должность сотрудника' from mydb.employee left join mydb.position on employee.id_employee = position.id_worker;";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView2.DataSource = sqlDt;
        }
        private void UpLoadData3()   //функция загрузки данных для датагрид_3 вывести список должностей
        {

            sqlConn2.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn2.Open();
            sqlCmd2.Connection = sqlConn2;
            sqlCmd2.CommandText = "SELECT id_position as 'ID дожности', name_position as 'Название должности',id_worker as 'ID сотрудника на этой должности' FROM mydb.position;";
            sqlRd2 = sqlCmd2.ExecuteReader();
            sqlDt2.Load(sqlRd2);
            sqlRd2.Close();
            sqlConn2.Close();
            dataGridView3.DataSource = sqlDt2;
        }
        public Form4()
        {   
            InitializeComponent();
            UpLoadData2();
            UpLoadData3();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            try
            {
                iExit = MessageBox.Show("Подтвердите выход из программы.", "MySQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e) //кнопка назначить должность
        {
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            try
            {
                sqlConn.Open();
                string var;
                var = textBox5.Text;
                var = textBox4.Text;
                sqlCmd.CommandText = "UPDATE `mydb`.`position` SET `id_worker` = '" + textBox5.Text + "' WHERE(`id_position` = '" + textBox4.Text + "')";
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();
                UpLoadData2();
                UpLoadData3();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpLoadData2();
                UpLoadData3();
                RefreshGrids();
            }
        }
        
        private void button2_Click(object sender, EventArgs e) //кнопка удалена по ненадобности
        {
            try
            {
               // UpLoadData4();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RefreshGrids();
            }
        }

        private void button4_Click(object sender, EventArgs e) // Сместить с должности
        {
            //UPDATE `mydb`.`position` SET `id_worker` = NULL WHERE (`id_position` = '9');
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            try
            {
                sqlConn.Open();
                string var;
                var = textBox5.Text;
                var = textBox4.Text;
                sqlCmd.CommandText = "UPDATE `mydb`.`position` SET `id_worker` = NULL WHERE(`id_position` = '" + textBox4.Text + "')";
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();
                UpLoadData2();
                UpLoadData3();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpLoadData2();
                UpLoadData3();
                RefreshGrids();
            }
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
