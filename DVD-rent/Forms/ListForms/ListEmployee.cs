using DVD_rent.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Models;

namespace DVD_rent
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();
            string[] types = { "Позиция", "ФИО", "Логин", "Пароль" };
            type.Items.AddRange(types);
            type.SelectedIndex = 0;
            type.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Position", "Позиция");
            dataGridView1.Columns.Add("FullName", "ФИО");
            dataGridView1.Columns.Add("Login", "Логин");
            dataGridView1.Columns.Add("Password", "Пароль");
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text != "Поиск" && search.ForeColor != Color.Gray)
            {

                string searchText = search.Text.Trim();
                List<Employee> filteredEmployeed = new List<Employee>();

                if (string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView();
                    return;
                }

                if (type.SelectedItem.ToString() == "Позиция")
                {
                    filteredEmployeed = EmployeeController.GetAllEmployees()
                    .Where(p =>
                        p.Position.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "ФИО")
                {
                    filteredEmployeed = EmployeeController.GetAllEmployees()
                    .Where(p =>
                        p.FullName.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
            
                else if (type.SelectedItem.ToString() == "Логин")
                {
                    filteredEmployeed = EmployeeController.GetAllEmployees()
                    .Where(p =>
                        p.Login.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Пароль")
                {
                    filteredEmployeed = EmployeeController.GetAllEmployees()
                    .Where(p =>
                        p.Password.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }

                dataGridView1.Rows.Clear();
                foreach (Employee employee in filteredEmployeed)
                {
                    dataGridView1.Rows.Add(employee.Id, employee.Position, employee.FullName, employee.Login, employee.Password);
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }





        private void Form2_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();

            foreach (Employee employee in EmployeeController.GetAllEmployees())
            {
                dataGridView1.Rows.Add(employee.Id, employee.Position, employee.FullName, employee.Login, employee.Password);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
            ReloadGridView();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите для удаления");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить?",
                "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount > 0)
                    {
                        for (int i = 0; i < selectedRowCount; i++)
                        {
                            if (EmployeeController.GetEmployeeById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString())).Position != Position.director)
                                EmployeeController.DeleteEmployeeById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                            else
                                MessageBox.Show("Невозможно удалить директора!");
                        }
                    }
                    ReloadGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_TextChanged_1(object sender, EventArgs e)
        {
            if (search.Text != "Поиск" && search.ForeColor != Color.Gray)
            {
                string searchText = search.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView();
                    return;
                }
                List<Employee> filteredEmployees = EmployeeController.GetAllEmployees()
                    .Where(p =>
                        p.FullName.ToString().Contains(searchText) ||
                        p.Login.ToString().Contains(searchText) ||
                        p.Password.ToString().Contains(searchText))
                    .ToList();

                dataGridView1.DataSource = filteredEmployees;
            }
        }

        private void search_Enter(object sender, EventArgs e)
        {
            if (search.ForeColor == Color.Gray)
            {
                search.Text = "";
                search.ForeColor = SystemColors.WindowText;
            }


        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                search.Text = "Поиск";
                search.ForeColor = Color.Gray;
            }
        }

        //редактировать
        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите для редактирования");
                return;
            }

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                AddEmployee addEmployee = new AddEmployee(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                addEmployee.ShowDialog();
                ReloadGridView();
            }
        }
    }
}