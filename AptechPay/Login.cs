﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.data.Users);
            this.CenterToScreen();
           // this.Top = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.usersTableAdapter.GetDataBy(textBox1.Text, textBox2.Text);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }
            else {
                string userName = textBox1.Text.Trim();
                string role = dt.Rows[0][2].ToString();
                MDI mdi = new MDI();
                mdi.role = role;
                mdi.userName = userName;
                mdi.Show();
                this.Hide();
            }
        }
    }
}
