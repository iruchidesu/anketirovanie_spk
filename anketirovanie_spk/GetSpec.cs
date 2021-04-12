using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace anketirovanie_spk
{
    public partial class GetSpec : Form
    {
        public GetSpec()
        {
            InitializeComponent();
        }

        private void GetSpec_Load(object sender, EventArgs e)
        {
            
            string select = @"SELECT spec FROM spec";
            
            DataSet ds2 = new DataSet();

            try
            {
                ds2 = Util.FillTable("spec", select);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                comboBox1.Items.Add(row.ItemArray[0]);
            }
            comboBox1.SelectedIndex = 0;
        }

        public string ReadSpecName()
        {
            string spec = comboBox1.SelectedItem.ToString();
            return spec;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
