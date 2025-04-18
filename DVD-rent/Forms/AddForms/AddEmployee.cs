using DVD_rent.Controllers;
using DVD_rent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace DVD_rent
{
    public partial class AddEmployee : Form
    {
        Employee employee = new Employee();
        Position ToEmployeeType(string S)
        {
            if (S == "cashier")
                return Position.cashier;
            else return 0;
        }
        public AddEmployee()
        {
            InitializeComponent();
            position.Items.Add("cashier");
        }
        public AddEmployee(int Id)
        {
            InitializeComponent();
            position.Items.Add("cashier");
            employee = EmployeeController.GetEmployeeById(Id);
            fullName.Text = employee.FullName.ToString();
            login.Text = employee.Login.ToString();
            password.Text = employee.Password.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(password.Text);
            EmployeeController.AddEmployee(ToEmployeeType(position.Text), Convert.ToString(login.Text), hashed, Convert.ToString(fullName.Text));
            this.Close();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
