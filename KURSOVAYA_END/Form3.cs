using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KURSOVAYA_END
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //открыть сотрудники
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) //открыть должности
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //открыть расписания
        {
            Form5 f = new Form5();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e) //открыть инвентарь
        {
            Form6 f = new Form6();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e) //открыть Услуги и цены
        {
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e) //закрыть
        {
            DialogResult iExit;
            try
            {
                iExit = MessageBox.Show("Подтвердите выход из программы. Вы перейдёте в окно авторизации.", "MySQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
