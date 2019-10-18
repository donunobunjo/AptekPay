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
    public partial class PaymentsPerPeriod1 : Form
    {
        public PaymentsPerPeriod1()
        {
            InitializeComponent();
        }

        private void PaymentsPerPeriod1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Data.Payments' table. You can move, or remove it, as needed.
            this.PaymentsTableAdapter.Fill(this.Data.Payments);

            this.reportViewer1.RefreshReport();
        }
    }
}
