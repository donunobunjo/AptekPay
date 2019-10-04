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
            /*if (dataGridView1.SelectedRows.Count == 1)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete this record", "Confirmation", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to select a row, by clicking the row marker, before you hit the delete button");
            }*/
            if (dataGridView1.SelectedRows.Count == 1)
            {
                //dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                string iden = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string fulname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //MessageBox.Show(fulname);
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
    }
}
