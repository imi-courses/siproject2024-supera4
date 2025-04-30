using DVD_rent.AddForms;
using DVD_rent.Controllers;
using DVD_rent.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVD_rent
{
    public partial class ClientList : Form
    {
        public string ChoosenClientId;

        public ClientList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("FullName", "ФИО");
            dataGridView1.Columns.Add("PhoneNumber", "Телефон");
            dataGridView1.Columns.Add("Address", "Адрес");
            dataGridView1.Columns.Add("InBlackList", "Чёрный список");
        }

        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (Client client in ClientController.GetAllClients())
            {
                dataGridView1.Rows.Add(
                    client.Id,
                    client.FullName,
                    client.PhoneNumber,
                    client.Address,
                    client.InBlackList ? "Да" : "Нет");
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                List<Client> filteredClients = ClientController.GetAllClients()
                    .Where(c =>
                        c.FullName.Contains(searchText) ||
                        c.PhoneNumber.Contains(searchText) ||
                        c.Address.Contains(searchText))
                    .ToList();

                dataGridView1.Rows.Clear();
                foreach (Client client in filteredClients)
                {
                    dataGridView1.Rows.Add(client.Id, client.FullName, client.PhoneNumber,
                                         client.Address, client.InBlackList ? "Да" : "Нет");
                }
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

        private void add_Click(object sender, EventArgs e)
        {
            AddClient addForm = new AddClient();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                ReloadGridView();
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string fullName = row.Cells["FullName"].Value.ToString();
            string phone = row.Cells["PhoneNumber"].Value.ToString();
            string address = row.Cells["Address"].Value.ToString();
            bool inBlackList = row.Cells["InBlackList"].Value.ToString() == "Да";

            AddClient editForm = new AddClient();
            editForm.Text = "Редактирование клиента";
            editForm.SetClientData(id, fullName, phone, address, inBlackList);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                ReloadGridView();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для удаления");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить выбранного клиента?",
                "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    ClientController.DeleteClientById(id);
                    ReloadGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ChoosenClientId = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}