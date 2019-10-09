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
    public partial class paymentsPerPeriod : Form
    {
        public paymentsPerPeriod()
        {
            InitializeComponent();
        }

        private void paymentsPerPeriod_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = 10;
        }

        private void button1_Click(object sender, EventArgs e){

            this.paymentsPerPeriodTableAdapter.Fill(this.data.PaymentsPerPeriod, dateTimePicker1.Value.Date.ToString(), dateTimePicker2.Value.Date.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
