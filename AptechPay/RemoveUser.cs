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
    public partial class RemoveUser : Form
    {
        public RemoveUser()
        {
            InitializeComponent();
        }

        private void RemoveUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.Users' table. You can move, or remove it, as needed.
           // this.usersTableAdapter.Fill(this.data.Users);
            this.CenterToScreen();
            this.Top = 40;
            this.usersTableAdapter.FillByOnlyUsers(this.data.Users, "User");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string user = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //MessageBox.Show(user);
                DialogResult res = MessageBox.Show("Are you sure you want to remove user"+" "+user, "Confirmation", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                   // dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    this.usersTableAdapter.DeleteQuery(user);
                    MessageBox.Show("User"+" "+user+" "+"deleted");
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
                else
                {
                    return;
                }
            }
            else {
                MessageBox.Show("No row selected");
            }
        }
    }
}
