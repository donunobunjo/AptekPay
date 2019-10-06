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
    public partial class PaymentHistory : Form
    {
        public string studid;
        public string fulname;
        public string program;
        public PaymentHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentHistory_Load(object sender, EventArgs e)
        {
            label1.Text = fulname;
            label2.Text = program;
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
            label4.Text = bal.ToString();
        }
    }
}
