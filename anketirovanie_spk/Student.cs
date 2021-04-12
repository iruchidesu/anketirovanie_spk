using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace anketirovanie_spk
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        int cnt = 0;
        DataSet dataset1 = new DataSet();
        int[] answers = new int[16];
        GetSpec specf = new GetSpec();

        private void Student_Load(object sender, EventArgs e)
        {
            specf.ShowDialog();

            cnt++;
            label2.Text = cnt.ToString();
            string select = @"SELECT answer, otvet1, otvet2, otvet3, otvet4, otvet5, kol FROM student_answer";

            try
            {
                dataset1 = Util.FillTable("student", select);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBox1.Text = dataset1.Tables[0].Rows[0].ItemArray[0].ToString();
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton1.Text = dataset1.Tables[0].Rows[0].ItemArray[1].ToString();
            radioButton2.Text = dataset1.Tables[0].Rows[0].ItemArray[2].ToString();
            radioButton3.Text = dataset1.Tables[0].Rows[0].ItemArray[3].ToString();
            radioButton4.Text = dataset1.Tables[0].Rows[0].ItemArray[4].ToString();
        }

        private int CheckAnswer()
        {
            if (radioButton1.Checked == true)
                return 1;
            if (radioButton2.Checked == true)
                return 2;
            if (radioButton3.Checked == true)
                return 3;
            if (radioButton4.Checked == true)
                return 4;
            if (radioButton5.Checked == true)
                return 5;
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckAnswer() == 0)
            {
                MessageBox.Show("Требуется ответ");
                return;
            }
            else
            {
                answers[cnt - 1] = CheckAnswer();
            }

            if (cnt < dataset1.Tables[0].Rows.Count)
            {
                cnt++;
                label2.Text = cnt.ToString();
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                textBox1.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[0].ToString();

                int s = int.Parse(dataset1.Tables[0].Rows[cnt - 1].ItemArray[6].ToString());
                switch (s)
                {
                    case 2:
                        radioButton1.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[1].ToString();
                        radioButton2.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[2].ToString();
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        break;
                    case 3:
                        radioButton1.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[1].ToString();
                        radioButton2.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[2].ToString();
                        radioButton3.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[3].ToString();
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton3.Visible = true;
                        break;
                    case 4:
                        radioButton1.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[1].ToString();
                        radioButton2.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[2].ToString();
                        radioButton3.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[3].ToString();
                        radioButton4.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[4].ToString();
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton3.Visible = true;
                        radioButton4.Visible = true;
                        break;
                    case 5:
                        radioButton1.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[1].ToString();
                        radioButton2.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[2].ToString();
                        radioButton3.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[3].ToString();
                        radioButton4.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[4].ToString();
                        radioButton5.Text = dataset1.Tables[0].Rows[cnt - 1].ItemArray[5].ToString();
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton3.Visible = true;
                        radioButton4.Visible = true;
                        radioButton5.Visible = true;
                        break;
                }
            }
            else
            {
                button2.Visible = true;
                button1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //здесь создается пользователь и записываются результаты
            int p = 0;
            string userUid = Util.GenerateUserUid();
            string select = @"INSERT user_anket(uid,type,id_spec) VALUES (" + userUid + ",'Студент'," + Util.ConvertSpecNameToIdSpec(specf.ReadSpecName()) + ")";
            try
            {
                Util.FillTable("add_user", select);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int idUser = Util.ConvertUserUidToIdUser(userUid);

            foreach (int i in answers)
            {
                p++;
                string select1 = @"INSERT result_stud(id_user," + Util.ConvertAnswer(i) + ", id_answer) VALUES (" + idUser + ",1," + p + ")";
                try
                {
                    Util.FillTable("add_result_stud", select1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            MessageBox.Show("Анкетирование завершено. Спасибо за внимание!");
            Close();
        }
    }
}
