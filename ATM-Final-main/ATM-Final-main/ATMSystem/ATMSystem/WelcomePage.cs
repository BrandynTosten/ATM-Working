using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public partial class WelcomePage : Form
    {
        public WelcomePage(string UserId, string UserName)
        {
            InitializeComponent();
            label2.Text = UserName;

        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Withdraw newWithdraw = new Withdraw();
            newWithdraw.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Deposit newDeposit = new Deposit();
            newDeposit.ShowDialog();
        }
    }
}
