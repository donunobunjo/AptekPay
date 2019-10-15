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
    public partial class ChangePassword : Form
    {
        public string userName;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.data.Users);
            this.CenterToScreen();
             this.Top = 30;
            // MessageBox.Show(Convert.ToString(this.userName));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text==""){
                MessageBox.Show("Please enter old password");
                textBox1.Focus();
                return;
            }
            DataTable dt = new DataTable();
           // dt = this.usersTableAdapter.GetDataByChangePassword(userName);
            dt = this.validatePasswordTableAdapter.GetData(userName);
            string pwd = dt.Rows[0][0].ToString();
            if (textBox1.Text.Trim() == pwd)
            {
                //MessageBox.Show("corectttt");
                if (textBox2.Text=="")
                {
                    MessageBox.Show("You need to enter new password");
                    textBox2.Focus();
                    return;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("You need to confirm new password");
                    textBox3.Focus();
                    return;
                }
                if (textBox2.Text.Trim()!=textBox3.Text.Trim())
                {
                    MessageBox.Show("Your new password don't match with the confirm password");
                    textBox2.Focus();
                    return;

                }
                this.usersTableAdapter.UpdateQuery(textBox2.Text.Trim(), userName);
                MessageBox.Show("Password change successfull");
                this.Close();

            }
            else
            {
                MessageBox.Show("Old password you entered is incorrect");
                return;
            }

        }
    }
}
