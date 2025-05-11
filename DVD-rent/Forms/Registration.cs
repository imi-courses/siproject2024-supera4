using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Controllers;
using BCrypt.Net;

namespace DVD_rent.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            if (pwd1.Text == pwd2.Text)
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(pwd1.Text);
                EmployeeController.AddEmployee(Models.Position.director, login.Text, hashed, fullName.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else
                MessageBox.Show("Пароль не совпадает!");
        }
    }
}
