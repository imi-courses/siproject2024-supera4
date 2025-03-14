using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVD_rent
{
    public partial class authorization : Form
    {
        public bool UserSuccessfullyAuthenticated { get; private set; } = false;

        public authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (login.Text == "admin" && password.Text == "admin")
            if (true)
            {
                UserSuccessfullyAuthenticated = true;
                this.Close();
            }
            else
            {
                password.Text = "";
                MessageBox.Show("Incorrect password or login");
            }
        }
    }
}
