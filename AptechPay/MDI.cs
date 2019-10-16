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
    public partial class MDI : Form
    {
        //private int childFormNumber = 0;
        public string userName;

        public MDI()
        {
            InitializeComponent();
        }

        

        private void MDI_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.CenterToScreen();
        }

        private void registerProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProgram program = new NewProgram();
            program.MdiParent = this;
            program.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStudent student = new NewStudent();
            student.userName = userName;
            student.MdiParent = this;
            student.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewStudent student = new NewStudent();
            student.userName = userName;
            student.MdiParent = this;
            student.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            NewProgram program = new NewProgram();
            program.MdiParent = this;
            program.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.username = userName;
            search.MdiParent = this;
            search.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void perPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paymentsPerPeriod ppp = new paymentsPerPeriod();
            ppp.MdiParent = this;
            ppp.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changepwd = new ChangePassword();
            changepwd.userName = userName.Trim();
            changepwd.MdiParent = this;
            changepwd.Show();
        }

        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
