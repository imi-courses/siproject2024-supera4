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
using DVD_rent.Forms;

namespace DVD_rent.ListForms
{
    public partial class RentList : Form
    {
        public Employee user = new Employee();

        public RentList(Employee user)
        {
            InitializeComponent();
            string[] types = { "ID", "Дата аренды", "Дата возвращения", "Состояние", "Цена", "ФИО клиента", "ФИО кассира", "Залог", "DVDs" };
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("RentDate", "Дата аренды");
            dataGridView1.Columns.Add("ReturnDate", "Дата возвращения");
            dataGridView1.Columns.Add("State", "Состояние");
            dataGridView1.Columns.Add("Money", "Цена");
            dataGridView1.Columns.Add("Client", "ФИО клиента");
            dataGridView1.Columns.Add("Employee", "ФИО кассира");
            dataGridView1.Columns.Add("Pledge", "Залог");
            dataGridView1.Columns.Add("DVDs", "DVDs");
            type.Items.AddRange(types);
            type.SelectedIndex = 0;
            type.DropDownStyle = ComboBoxStyle.DropDownList;
            this.user = user;
            ReloadGridView(RentController.GetAllRents());
        }

        public void ReloadGridView(List<Rent> rents)
        {
            dataGridView1.Rows.Clear();
            foreach (Rent rent in rents)
            {
                string dvds="";
                foreach (DVD dvd in rent.DVDs)
                {
                    dvds += dvd.Id.ToString() + " ";
                }
                dataGridView1.Rows.Add(
                    rent.Id, 
                    rent.RentDate, 
                    rent.ReturnDate, 
                    rent.State, 
                    rent.Money, 
                    rent.Client.FullName, 
                    rent.Employee.FullName, 
                    rent.Pledge.Id, 
                    dvds);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RentList_Load(object sender, EventArgs e)
        {
            ReloadGridView(RentController.GetAllRents());
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddRent addRent = new AddRent(user);
            addRent.ShowDialog();
            ReloadGridView(RentController.GetAllRents());
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadGridView(RentController.GetAllRents());
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
            ReloadGridView(RentController.GetAllRents());
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text != "Поиск" && search.ForeColor != Color.Gray)
            {

                string searchText = search.Text.Trim().ToLower();
                List<Rent> filteredRents = new List<Rent>();

                if (string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView(RentController.GetAllRents());
                    return;
                }

                if (type.SelectedItem.ToString() == "ID")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(rent =>
                        rent.Id.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Дата аренды")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(rent =>
                        rent.RentDate.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Дата возвращения")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(rent =>
                        rent.ReturnDate.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Состояние")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(rent =>
                        rent.State.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Цена")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(rent =>
                        rent.Money.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "ФИО клиента")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(rent =>
                        rent.Client.FullName.ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "ФИО кассира")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(rent =>
                        rent.Employee.FullName.ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Залог")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(dvd =>
                        dvd.Pledge.Id.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "DVDs")
                {
                    filteredRents = RentController.GetAllRents()
                    .Where(dvd =>
                        dvd.DVDs.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                ReloadGridView(filteredRents);
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

        private void edit_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                AddRent addRent = new AddRent(user, int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                addRent.ShowDialog();
                ReloadGridView(RentController.GetAllRents());
            }
        }

        private void btn_closeRent_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                CloseRent closeRent = new CloseRent(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                closeRent.ShowDialog();
                ReloadGridView(RentController.GetAllRents());
            }
        }
    }
}
