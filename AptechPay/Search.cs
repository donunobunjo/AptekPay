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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = 10;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //this.studentInfoTableAdapter.FillBy1(this.reportManDataSet.StudentInfo, textBox1.Text, textBox1.Text, textBox1.Text);
            this.searchTableAdapter.Fill(this.data.Search, textBox1.Text, textBox1.Text, textBox1.Text, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (dataGridView1.SelectedRows.Count == 1)
            {
                string iden = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string fulname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Payment payment = new Payment();
                payment.studid = iden;
                payment.fulname = fulname;
                payment.ShowDialog();
            }
            else
            {
                MessageBox.Show("No row selected");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string iden = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string fulname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string program = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                PaymentHistory payHist = new PaymentHistory();
                payHist.studid = iden;
                payHist.fulname = fulname;
                payHist.program = program;
                payHist.ShowDialog();

            }
            else
            {
                MessageBox.Show("No row selected");
            }

        }
    }
}
