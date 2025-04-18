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
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Position", "Position");
            dataGridView1.Columns.Add("Login", "Login");
            dataGridView1.Columns.Add("Password", "Password");
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text != "Поиск" && search.ForeColor != Color.Gray) ;
            {
                string searchText = search.Text.Trim();

                if (string.IsNullOrEmpty(searchText) )
                {
                    ReloadGridView();
                    return;
                }
                List<Employee> filteredEmployees = EmployeeController.GetAllEmployees().Where(p=> 
                p.FullName.ToString().Contains(searchText) || 
                p.Login.ToString().Contains(searchText)|| 
                p.Password.ToString().Contains(searchText)).ToList();
                
                dataGridView1.DataSource = filteredEmployees;
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
                dataGridView1.Rows.Add(employee.Id, employee.Position, employee.Login, employee.Password);
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
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    EmployeeController.DeleteEmployeeById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                }
            }
            ReloadGridView();
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

        private void button1_Click(object sender, EventArgs e)
        {
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
