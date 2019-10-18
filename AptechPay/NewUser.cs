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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.Users' table. You can move, or remove it, as needed.
           // this.usersTableAdapter.Fill(this.data.Users);
            this.CenterToScreen();
            this.Top = 40;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("You need to enter User name");
                textBox1.Focus();
                return;
            }

            DataTable dt = new DataTable();
            dt = this.checkUserTableAdapter.GetData(textBox1.Text);
            if (dt.Rows.Count != 0) {
                MessageBox.Show("This user already exist");
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("You need to enter password");
                textBox2.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("You need to confirm password");
                textBox3.Focus();
                return;
            }

            if (textBox2.Text != textBox3.Text) {
                MessageBox.Show("The password and confirm password don't match");
                textBox3.Focus();
                return;
            }
            this.usersTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, "User");
            MessageBox.Show("The user has been created");
            this.Close();
        }
    }
}
