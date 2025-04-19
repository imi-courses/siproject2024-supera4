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
using DVD_rent.Models;
using DVD_rent.AddForms;

namespace DVD_rent.ListForms
{
    public partial class RentList : Form
    {
        public Employee user = new Employee();

        public RentList(Employee user)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("RentDate", "Дата аренды");
            dataGridView1.Columns.Add("ReturnDate", "Дата возвращения");
            dataGridView1.Columns.Add("State", "Состояние");
            dataGridView1.Columns.Add("Money", "Цена");
            dataGridView1.Columns.Add("Client", "ФИО клиента");
            dataGridView1.Columns.Add("Employee", "ФИО кассира");
            dataGridView1.Columns.Add("Pledge", "Залог");
            dataGridView1.Columns.Add("DVDs", "DVDs");
            this.user = user;
            ReloadGridView();
        }

        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (Rent rent in RentController.GetAllRents())
            {
                dataGridView1.Rows.Add(
                    rent.Id, 
                    rent.RentDate, 
                    rent.ReturnDate, 
                    rent.State, 
                    rent.Money, 
                    rent.Client.FullName, 
                    rent.Employee.FullName, 
                    rent.Pledge.Id, 
                    rent.DVDs);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RentList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddRent addRent = new AddRent(user);
            addRent.ShowDialog();
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
                    RentController.DeleteRentById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                }
            }
            ReloadGridView();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text != "Поиск" && search.ForeColor != Color.Gray)
            {

                string searchText = search.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView();
                    return;
                }

                List<Pledge> filteredPledges = PledgeController.GetAllPledges()
                    .Where(p =>
                        p.PledgeType.ToString().Contains(searchText) ||
                        p.Series.ToString().Contains(searchText) ||
                        p.Number.ToString().Contains(searchText) ||
                        p.Money.ToString().Contains(searchText)
                    )
                    .ToList();

                dataGridView1.DataSource = filteredPledges;
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

        //private void edit_Click(object sender, EventArgs e)
        //{
        //    Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
        //    if (selectedRowCount == 1)
        //    {
        //        AddRent addRent = new AddRent(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
        //        addRent.ShowDialog();
        //        ReloadGridView();
        //    }
        //}
    }
}
