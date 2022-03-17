using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public partial class TrustyBank : Form
    {
        mySql Que = new mySql();
        public TrustyBank()
        {
            InitializeComponent();
        }

        private void TrustyBank_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Que.IdentifierUser(textBox1.Text, textBox2.Text);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    WelcomePage startMain = new WelcomePage(dt.Rows[0][0].ToString(), dt.Rows[0][3].ToString());
                    startMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
