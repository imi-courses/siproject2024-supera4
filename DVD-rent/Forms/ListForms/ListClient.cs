using DVD_rent.AddForms;
using DVD_rent.Controllers;
using DVD_rent.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVD_rent
{
    public partial class ClientList : Form
    {
        public string ChoosenClientId;

        public ClientList(ListFormStatus status)
        {
            InitializeComponent();
            string[] types = { "ID", "ФИО", "Телефон", "Адрес", "Черный список" };

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("FullName", "ФИО");
            dataGridView1.Columns.Add("PhoneNumber", "Телефон");
            dataGridView1.Columns.Add("Address", "Адрес");
            dataGridView1.Columns.Add("InBlackList", "Чёрный список");

            type.Items.AddRange(types);
            type.SelectedIndex = 0;
            type.DropDownStyle = ComboBoxStyle.DropDownList;

            if (status == ListFormStatus.NotChoose) btnChoose.Visible = false;
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
                List<Client> filteredClients = new List<Client>();

                if(string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView();
                    return;
                }


                if (type.SelectedItem.ToString() == "ID")
                {
                    filteredClients = ClientController.GetAllClients()
                    .Where(client =>
                        client.Id.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "ФИО")
                {
                    filteredClients = ClientController.GetAllClients()
                    .Where(client =>
                        client.FullName.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Телефон")
                {
                    filteredClients = ClientController.GetAllClients()
                    .Where(client =>
                        client.PhoneNumber.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Адрес")
                {
                    filteredClients = ClientController.GetAllClients()
                    .Where(client =>
                        client.Address.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Черный список")
                {
                    filteredClients = ClientController.GetAllClients()
                    .Where(client =>
                        client.InBlackList.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }

                dataGridView1.Rows.Clear();
                foreach (Client client in filteredClients)
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
                MessageBox.Show("Выберите для редактирования");
                return;
            }

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
                            ClientController.DeleteClientById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
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