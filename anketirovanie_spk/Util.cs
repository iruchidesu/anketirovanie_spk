using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace anketirovanie_spk
{
    class Util
    {
        private static readonly string source = Properties.Resources.connectionstring;

        public static DataSet FillTable(string dtable, string query)
        {
            DataSet ds1 = new DataSet();
            try
            {
                SqlConnection connectionstring = new SqlConnection(source);
                SqlDataAdapter da = new SqlDataAdapter(query, connectionstring);
                da.Fill(ds1, dtable);
                return ds1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return ds1;
            }
        }

        public static string GenerateUserUid()
        {
            TimeSpan dt = DateTime.Now.TimeOfDay;
            return Math.Round(dt.TotalMilliseconds).ToString(); ;
        }

        public static string ConvertAnswer(int d)
        {
            switch (d)
            {
                case 1:
                    return "result1";
                case 2:
                    return "result2";
                case 3:
                    return "result3";
                case 4:
                    return "result4";
                case 5:
                    return "result5";
            }
            return "0";
        }

        public static int ConvertUserUidToIdUser(string userUid)
        {
            DataSet ds;
            try
            {
                ds = FillTable("student", "SELECT id FROM user_anket WHERE ( uid = '" + userUid + "')");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            return (int)ds.Tables[0].Rows[0].ItemArray[0];
        }

        public static int ConvertSpecNameToIdSpec(string specName)
        {
            DataSet ds;
            try
            {
                ds = FillTable("spec", "SELECT id FROM spec WHERE ( spec = '" + specName + "')");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
}
