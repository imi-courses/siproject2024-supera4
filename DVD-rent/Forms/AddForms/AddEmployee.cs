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
using System.Xml.Linq;

namespace DVD_rent
{
    public partial class AddEmployee : Form
    {
        Employee employee = new Employee();
        public AddEmployee()
        {
            InitializeComponent();
        }
        public AddEmployee(int Id)
        {
            InitializeComponent();

            this.Text = "Редактировать сотрудника";
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

            // Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(fullName.Text) ||
                string.IsNullOrWhiteSpace(login.Text) ||
                string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return; // Прекратить сохранение, если поля не заполнены
            }

            try
            {
                // Добавление проверки на уникальность логина
                if (IsLoginExists(login.Text) && login.Text != employee.Login)
                {
                    MessageBox.Show("Логин уже занят. Пожалуйста, выберите другой.");
                    return; // Прекратить сохранение, если логин не уникален
                }

                if (employee.Id != 0)
                {
                    EmployeeController.EditEmployee(employee.Id, employee.Position, Convert.ToString(login.Text), hashed, Convert.ToString(fullName.Text));
                }
                else
                {
                    EmployeeController.AddEmployee(Position.cashier, Convert.ToString(login.Text), hashed, Convert.ToString(fullName.Text));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form listEmployee = new Form();
            listEmployee.ShowDialog();
        }

        // Метод для проверки существования логина
        private bool IsLoginExists(string loginToCheck)
        {
            return EmployeeController.GetAllEmployees().Any(e => e.Login == loginToCheck);
        }
    }
}