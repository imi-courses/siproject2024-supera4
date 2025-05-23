﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Models;
using DVD_rent.Controllers;

namespace DVD_rent
{
    public partial class Authorization : Form
    {
        public Employee user = new Employee();

        public Authorization()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var employee = EmployeeController.GetAllEmployees()
                .FirstOrDefault(emp => emp.Login == login.Text);

            if (employee != null && BCrypt.Net.BCrypt.Verify(password.Text, employee.Password))
            {
                user = employee;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            password.Text = "";
            MessageBox.Show("Неправильный логин или пароль");
        }
    }
}
