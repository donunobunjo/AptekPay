using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AptechPay
{
    public partial class NewStudent : Form
    {
        Int32 ctr;
        public string userName;
        public NewStudent()
        {
            InitializeComponent();
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            DataTable stddt = new DataTable();
            stddt = this.studentsTableAdapter.GetData();
            if (stddt.Rows.Count == 0)
            {
                ctr = 1;
            }
            else
            {
                dt = this.checkstudentIDTableAdapter.GetData();
                ctr = Convert.ToInt32(dt.Rows[0][0].ToString());
                ctr = ctr + 1;
            }
            textBox12.Text = ctr.ToString();
            this.programNamesTableAdapter.Fill(this.data.ProgramNames);
            this.CenterToScreen();
            this.Top = 10;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Focus();
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
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rollnum, middlename, email,alternativePhoneNumber;
           // int duration;
            //double cost;
            DateTime enddate;
            /*if (textBox12.Text == "")
            {
                MessageBox.Show("Please enter IdentificationID ");
                textBox12.Focus();
                return;
            }*/
            Int32 iden = Convert.ToInt32(textBox12.Text);
            DataTable dt = new DataTable();
            dt = this.checkIdenIDTableAdapter.GetData(iden);
            if (dt.Rows.Count!=0)
            {
                MessageBox.Show("This Identification ID has been used");
                textBox12.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter student first name");
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
             if (textBox9.Text == "")
            {
                MessageBox.Show("Please enter student phone number");
                textBox9.Focus();
                return;
            }
             if (comboBox2.Text == "")
             {
                 MessageBox.Show("Please select an enrollment type");
                 comboBox2.Focus();
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
            if (textBox10.Text == "")
            {
                alternativePhoneNumber = "Nill";
            }
            else
            {
                alternativePhoneNumber = textBox1.Text;
            }
            if (textBox11.Text == "")
            {
                email = "Nill";
            }
            else
            {
                email = textBox11.Text;
                Regex expr = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (expr.IsMatch(email))
                {
                    email = textBox11.Text;
                }
                else
                {
                    MessageBox.Show("Invalid email");
                    textBox11.Focus();
                    return;
                }
            }
            DateTime today = DateTime.Today;
            string fullname = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
            enddate= dateTimePicker1.Value.Date.AddMonths(Convert.ToInt32(textBox5.Text));
            // this.studentsTableAdapter.InsertQuery(rollnum, textBox2.Text, textBox3.Text, textBox4.Text, fullname, comboBox1.Text, Convert.ToInt32(textBox5.Text), Convert.ToDecimal(textBox6.Text), dateTimePicker1.Value, enddate, textBox8.Text, true);
            this.studentsTableAdapter.InsertQuery(rollnum, textBox2.Text, textBox3.Text, textBox4.Text, fullname, comboBox1.Text, Convert.ToInt32(textBox5.Text), Convert.ToDecimal(textBox6.Text), dateTimePicker1.Value.ToString(), enddate.ToString(), textBox8.Text, true,Convert.ToInt32(textBox12.Text),textBox9.Text,alternativePhoneNumber,email,userName,dateTimePicker1.Value.ToString(),comboBox2.Text);
            DataTable dtable = new DataTable();
            dtable=this.studIDTableAdapter.GetData();
            Int32 stdid = Convert.ToInt32(dtable.Rows[0][0].ToString());
            this.paymentsTableAdapter.InsertQuery(stdid, fullname, Convert.ToDecimal(textBox6.Text), Convert.ToDecimal(textBox7.Text), dateTimePicker1.Value.Date.ToString(), textBox8.Text,userName,today.ToString(),comboBox2.Text);
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
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            ctr = ctr + 1;
            textBox12.Text = ctr.ToString();
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

       private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
       {
           e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
       }

       private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
       {
           e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
       }

       private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
       {
           e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
       }

       
    }
}
