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

    public partial class Form7 : Form
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
        private void UpLoadData()   //функция загрузки данных для датагрид_1
        {
            sqlDt.Clear();
            sqlConn.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT id_product as 'ID Услуги', name_product as 'Наименование',description_product as 'Описание', price_product as 'Цена' FROM mydb.product_list;";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView2.DataSource = sqlDt;
        }
        public Form7()
        {
            InitializeComponent();
            UpLoadData();
        }

        private void Form7_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConn2.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn2.Open();
            sqlCmd.Connection = sqlConn2;
            sqlCmd.CommandText = "DELETE FROM `mydb`.`product_list` WHERE (`id_product` = '" + textBox5.Text + "');";
            sqlRd = sqlCmd.ExecuteReader();
            sqlConn2.Close();
            UpLoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConn2.ConnectionString = "server=localhost; user id = root; persistsecurityinfo = True; database = mydb; sslmode = None; password=password";
            sqlConn2.Open();
            sqlCmd.Connection = sqlConn2;
            sqlCmd.CommandText = "INSERT INTO `mydb`.`product_list` (`name_product`, `description_product`, `price_product`) VALUES ('" + textBox4.Text + "', '" + textBox3.Text + "', '" + textBox1.Text + "');";
            sqlRd = sqlCmd.ExecuteReader();
            sqlConn2.Close();
            UpLoadData();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void информацияПоРаботеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.ShowDialog();
        }
    }
}
