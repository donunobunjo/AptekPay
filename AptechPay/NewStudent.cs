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
    public partial class NewStudent : Form
    {
        public NewStudent()
        {
            InitializeComponent();
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.StudID' table. You can move, or remove it, as needed.
            //this.studIDTableAdapter.Fill(this.data.StudID);
            // TODO: This line of code loads data into the 'data.Payments' table. You can move, or remove it, as needed.
            //this.paymentsTableAdapter.Fill(this.data.Payments);
            // TODO: This line of code loads data into the 'data.Students' table. You can move, or remove it, as needed.
            //this.studentsTableAdapter.Fill(this.data.Students);
            // TODO: This line of code loads data into the 'data.Programs' table. You can move, or remove it, as needed.
            //this.programsTableAdapter.Fill(this.data.Programs);
            // TODO: This line of code loads data into the 'data.ProgramNames' table. You can move, or remove it, as needed.
            this.programNamesTableAdapter.Fill(this.data.ProgramNames);
            this.CenterToScreen();
            this.Top = 50;
            comboBox1.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rollnum, middlename;
           // int duration;
            //double cost;
            DateTime enddate;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter student name");
                textBox2.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter student surname");
                textBox4.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select a program");
                comboBox1.Focus();
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Please enter the duration of the program");
                textBox5.Focus();
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Please enter the cost of the program");
                textBox6.Focus();
                return;
            }
            if (textBox7.Text == "")
            {
                MessageBox.Show("Please enter initial payment");
                textBox7.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                middlename = ".";
            }
            else{
                middlename=textBox3.Text;
            }
            if (textBox1.Text == "")
            {
                rollnum = "404";
            }
            else{
                rollnum=textBox1.Text;
            }
            string fullname = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
            enddate= dateTimePicker1.Value.Date.AddMonths(Convert.ToInt32(textBox5.Text));
            // this.studentsTableAdapter.InsertQuery(rollnum, textBox2.Text, textBox3.Text, textBox4.Text, fullname, comboBox1.Text, Convert.ToInt32(textBox5.Text), Convert.ToDecimal(textBox6.Text), dateTimePicker1.Value, enddate, textBox8.Text, true);
            this.studentsTableAdapter.InsertQuery(rollnum, textBox2.Text, textBox3.Text, textBox4.Text, fullname, comboBox1.Text, Convert.ToInt32(textBox5.Text), Convert.ToDecimal(textBox6.Text), dateTimePicker1.Value.ToString(), enddate.ToString(), textBox8.Text, true);
            DataTable dtable = new DataTable();
            dtable=this.studIDTableAdapter.GetData();
            Int32 stdid = Convert.ToInt32(dtable.Rows[0][0].ToString());
            this.paymentsTableAdapter.InsertQuery(stdid, fullname, Convert.ToDecimal(textBox6.Text), Convert.ToDecimal(textBox7.Text), dateTimePicker1.Value.Date.ToString(), textBox8.Text);
            //MessageBox.Show(Convert.ToString(stdid));
            MessageBox.Show("Student's Information has been registered");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //duration = System.Convert.ToInt32(dttable.Rows[0][2].ToString());
            if (comboBox1.Text == "")
            {
                return;
            }
            else
            {
                DataTable dttable = new DataTable();
                dttable = this.programsTableAdapter.GetDataByProgram(comboBox1.Text);
                textBox5.Text = dttable.Rows[0][2].ToString();
                textBox6.Text = dttable.Rows[0][3].ToString();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }
       private void textBox5_Enter(object sender, EventArgs e)
        {
            
        }

       private void textBox6_TextChanged(object sender, EventArgs e)
       {

       }

       
    }
}
