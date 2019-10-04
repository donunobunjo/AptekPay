using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptechPay
{
    public partial class Payment : Form
    {
        public string studid;
        public string fulname;
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.Payments' table. You can move, or remove it, as needed.
           // this.paymentsTableAdapter.Fill(this.data.Payments);
            //label1.Text = studid;
            label4.Text = fulname;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.paymentsTableAdapter.InsertQuery(Convert.ToInt32(studid.Trim()), fulname.Trim(), 0, Convert.ToDecimal(textBox1.Text), dateTimePicker1.Value.Date.ToString(), textBox2.Text);
            MessageBox.Show("The payment has been made, thankyou");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
