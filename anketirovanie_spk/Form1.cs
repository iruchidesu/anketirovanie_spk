using System;
using System.Windows.Forms;

namespace anketirovanie_spk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StudentResult studResultForm = new StudentResult();
        PrepodResult prepResultForm = new PrepodResult();

        private void button1_Click(object sender, EventArgs e)
        {
            Student stud = new Student();
            Hide();
            stud.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Password passf = new Password();
            Hide();
            passf.ShowDialog();
            Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сброситьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string select1 = @"DELETE result_prepod";
            Util.FillTable("result_prepod", select1);
            
            string select2 = @"DELETE result_stud";
            Util.FillTable("result_stud", select2);
            
            string select = @"DELETE user_anket";
            Util.FillTable("user", select);

            MessageBox.Show("Результаты удалены");
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void студентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            файлToolStripMenuItem.Enabled = false;
            выходToolStripMenuItem1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //процесс формирования
           studResultForm.PrintResult();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            файлToolStripMenuItem.Enabled = true;
            выходToolStripMenuItem1.Enabled = true;
            MessageBox.Show("Отчет по студентам сформирован");
        }

        private void преподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            файлToolStripMenuItem.Enabled = false;
            выходToolStripMenuItem1.Enabled = false;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            prepResultForm.PrintResult();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            файлToolStripMenuItem.Enabled = true;
            выходToolStripMenuItem1.Enabled = true;
            MessageBox.Show("Отчет по преподавателям сформирован");
        }
    }
}
