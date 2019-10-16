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
        public string userName;
        public string enroltype;
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
            int stdID = Convert.ToInt32(studid);
            this.paymentsHistoryTableAdapter.Fill(this.data.PaymentsHistory, stdID);
            DataTable paydt = new DataTable();
            DataTable billdt = new DataTable();
            //dttable = this.programsTableAdapter.GetDataByProgram(comboBox1.Text);
            paydt = this.sumPaymentTableAdapter.GetData(stdID);
            billdt = this.sumBillTableAdapter.GetData(stdID);
            decimal billTotal = Convert.ToDecimal(billdt.Rows[0][0].ToString());
            decimal payTotal = Convert.ToDecimal(paydt.Rows[0][0].ToString());
            decimal bal = billTotal - payTotal;
            //MessageBox.Show(bal.ToString());
            label6.Text = bal.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("You need to enter the amount");
                textBox1.Focus();
                return;
            }
            DateTime today = DateTime.Today;
            this.paymentsTableAdapter.InsertQuery(Convert.ToInt32(studid.Trim()), fulname.Trim(), 0, Convert.ToDecimal(textBox1.Text), dateTimePicker1.Value.Date.ToString(), textBox2.Text,userName,today.ToString(),enroltype);
            MessageBox.Show("The payment has been made, thank you");
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
