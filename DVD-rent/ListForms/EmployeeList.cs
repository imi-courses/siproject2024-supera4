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
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "Поиск" && textBox1.ForeColor != Color.Gray) ;
            {
                string searchText = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(searchText) )
                {
                    ReloadGridView();
                    return;
                }
                List<Employee> filteredEmployees = EmployeeController.GetAllEmployees().Where(p=> p.FullName.ToString().Contains(searchText) || p.Login.ToString().Contains(searchText)|| p.Password.ToString().Contains(searchText)).ToList();
                
                dataGridView1.DataSource = filteredEmployees;
            }
        }
        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Поиск";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void search_Enter(object sender, EventArgs e)
        {
            if (textBox1.ForeColor != Color.Gray)
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }

       


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void ReloadGridView()
        {
            dataGridView1.DataSource = EmployeeController.GetAllEmployees();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void EmployeeList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
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
                    DVDController.DeleteDVDById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                }
            }
            ReloadGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
