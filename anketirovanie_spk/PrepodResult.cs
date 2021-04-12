using System;
using Word = Microsoft.Office.Interop.Word;
using System.Data;

namespace anketirovanie_spk
{
    class PrepodResult
    {
        public PrepodResult()
        {

        }

        private string Percentage(int spec, int answer, float quantity)
        {
            int i = answer + 1;
            float[] percents = new float[4];
            string select = @"SELECT SUM(result_prepod.result1) as res1, 
                                     SUM(result_prepod.result2) as res2, 
                                     SUM(result_prepod.result3) as res3, 
                                     SUM(result_prepod.result4) as res4
                              FROM result_prepod INNER JOIN
                                   user_anket ON result_prepod.id_user = user_anket.id
                              WHERE (user_anket.id_spec = '" + spec + "' and result_prepod.id_answer=" + i + " and user_anket.type='Препод')";

            DataSet ds1 = Util.FillTable("prepod_result", select);

            if (ds1.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                percents[0] = (float.Parse(ds1.Tables[0].Rows[0].ItemArray[0].ToString())) / quantity * 100;
            if (ds1.Tables[0].Rows[0].ItemArray[1].ToString() != "")
                percents[1] = (float.Parse(ds1.Tables[0].Rows[0].ItemArray[1].ToString())) / quantity * 100;
            if (ds1.Tables[0].Rows[0].ItemArray[2].ToString() != "")
                percents[2] = (float.Parse(ds1.Tables[0].Rows[0].ItemArray[2].ToString())) / quantity * 100;
            if (ds1.Tables[0].Rows[0].ItemArray[3].ToString() != "")
                percents[3] = (float.Parse(ds1.Tables[0].Rows[0].ItemArray[3].ToString())) / quantity * 100;

            return percents[0].ToString("F2") + "\n" + percents[1].ToString("F2") + "\n" + percents[2].ToString("F2") + "\n" + percents[3].ToString("F2");
        }

        public void PrintResult()
        {
            string select2 = @"SELECT answer, otvet1, otvet2, otvet3, otvet4 FROM prep_answer";

            DataSet ds3 = Util.FillTable("prepod_answer", select2);

            string selectCountAll = @"SELECT COUNT(id) FROM user_anket WHERE (type='Препод')";

            DataSet ds5 = Util.FillTable("prepod_count_all", selectCountAll);

            Word.Application wdApp = new Word.Application();
            Word.Document wdDoc = new Word.Document();
            Object wdMiss = System.Reflection.Missing.Value;
            wdDoc = wdApp.Documents.Add(ref wdMiss, ref wdMiss, ref wdMiss, ref wdMiss);
            // wdApp.Visible = true; //сначала формируется документ, показывать потом
            wdDoc.PageSetup.LeftMargin = 40;
            wdDoc.PageSetup.RightMargin = 25;
            wdDoc.PageSetup.TopMargin = 20;
            wdDoc.PageSetup.BottomMargin = 20;
            Word.Table tb;
            int columnsCount = 4;
            int row_col = 1;

            tb = wdDoc.Tables.Add(wdApp.Selection.Range, 140, columnsCount);

            tb.Columns[1].Width = 40;
            tb.Rows[1].Height = 30;
            tb.Columns[2].Width = 280;
            tb.Rows[2].Height = 30;
            tb.Columns[3].Width = 130;
            tb.Rows[3].Height = 40;
            tb.Columns[4].Width = 90;

            for (int spec = 1; spec <= 10; spec++)
            {

                string selectCount = @"SELECT COUNT(id) FROM user_anket WHERE (type='Препод' and id_spec='" + spec + "')";

                DataSet ds2 = Util.FillTable("prepod_count", selectCount);

                string selectSpec = @"SELECT spec FROM spec where id='" + spec + "'";

                DataSet ds4 = Util.FillTable("prepod_spec", selectSpec);

                tb.Select();
                wdApp.Selection.Range.Font.Name = "Times New Roman";
                wdApp.Selection.Range.Font.Size = 10;
                wdApp.Selection.ParagraphFormat.SpaceAfter = 0;

                tb.Cell(row_col, 1).Select();
                tb.Cell(row_col, 1).Range.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString(); //специальность
                tb.Cell(row_col, 2).Range.Text = "Количество, чел";
                tb.Cell(row_col, 3).Range.Text = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
                tb.Rows[row_col].Select();
                wdApp.Selection.Font.Bold = 1;

                tb.Cell(row_col + 1, 1).Range.Text = "№ п/п";
                tb.Cell(row_col + 1, 2).Range.Text = "Вопросы педагогическим работникам аккредитуемой программы";
                tb.Cell(row_col + 1, 3).Range.Text = "Ответы";
                tb.Cell(row_col + 1, 4).Range.Text = "Результаты анкетирования, %";

                int rowCount = row_col + 1;
                int rowNumber = 0;

                for (int answer = 0; answer <= 11; answer++)
                {
                    rowCount++;
                    rowNumber++;
                    tb.Cell(rowCount, 1).Range.Text = rowNumber.ToString() + ".";
                    tb.Cell(rowCount, 2).Range.Text = ds3.Tables[0].Rows[answer].ItemArray[0].ToString();
                    tb.Cell(rowCount, 3).Range.Text = " - " + ds3.Tables[0].Rows[answer].ItemArray[1].ToString() + "\n - " + ds3.Tables[0].Rows[answer].ItemArray[2].ToString() + "\n - " +
                        ds3.Tables[0].Rows[answer].ItemArray[3].ToString() + "\n - " + ds3.Tables[0].Rows[answer].ItemArray[4].ToString();
                    tb.Cell(rowCount, 4).Range.Text = Percentage(spec, answer, (int)ds2.Tables[0].Rows[0].ItemArray[0]);
                }
                row_col += 14;
            }

            wdApp.Visible = true; //показать документ пользователю
        }
    }
}
