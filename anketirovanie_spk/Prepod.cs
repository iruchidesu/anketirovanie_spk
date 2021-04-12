using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace anketirovanie_spk
{
    public partial class Prepod : Form
    {
        public Prepod()
        {
            InitializeComponent();
        }

        int cnt = 0;
        DataSet ds1 = new DataSet();
        int[] answers = new int[12];
        GetSpec specf = new GetSpec();

        private void Prepod_Load(object sender, EventArgs e)
        {
            specf.ShowDialog();

            cnt++;
            label2.Text = cnt.ToString();
            string select = @"SELECT answer, otvet1, otvet2, otvet3, otvet4, kol FROM prep_answer";
  
            try
            {
                ds1 = Util.FillTable("prepod", select);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            textBox1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            radioButton2.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            radioButton3.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
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
                answers[cnt-1] = CheckAnswer();
            }

            if (cnt < ds1.Tables[0].Rows.Count)
            {
                cnt++;
                label2.Text = cnt.ToString();
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                textBox1.Text = ds1.Tables[0].Rows[cnt - 1].ItemArray[0].ToString();

                int s = int.Parse(ds1.Tables[0].Rows[cnt-1].ItemArray[5].ToString());
                switch (s)
                {
                    case 2:
                        radioButton1.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[1].ToString();
                        radioButton2.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[2].ToString();
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        break;
                    case 3:
                        radioButton1.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[1].ToString();
                        radioButton2.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[2].ToString();
                        radioButton3.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[3].ToString();
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton3.Visible = true;
                        break;
                    case 4:
                        radioButton1.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[1].ToString();
                        radioButton2.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[2].ToString();
                        radioButton3.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[3].ToString();
                        radioButton4.Text = ds1.Tables[0].Rows[cnt-1].ItemArray[4].ToString();
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton3.Visible = true;
                        radioButton4.Visible = true;
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
            string select = @"INSERT user_anket(uid,type,id_spec) VALUES (" + userUid + ",'Препод'," + Util.ConvertSpecNameToIdSpec(specf.ReadSpecName()) + ")";
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
                string select1 = @"INSERT result_prepod(id_user," + Util.ConvertAnswer(i) + ", id_answer) VALUES (" + idUser + ",1," + p + ")";
                try
                {
                    Util.FillTable("add_result_prepod", select1);
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
