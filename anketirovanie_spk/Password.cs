using System;
using System.Windows.Forms;

namespace anketirovanie_spk
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123456")
            {
                Prepod prepf = new Prepod();
                Hide();
                prepf.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }
    }
}
