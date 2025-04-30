using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.AddForms;
using DVD_rent.Controllers;
using DVD_rent.Models;

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
            dataGridView1.Columns.Add("PhoneNumber", "к.т.");
            dataGridView1.Columns.Add("Address", "Адрес");
            dataGridView1.Columns.Add("InBlackList", "Чёрный список");

            delete.Text = "Удалить";
            edit.Text = "Редактировать";
            add.Text = "Добавить";
            close.Text = "Закрыть";
            reload.Text = "Обновить";
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

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования");
                return;
            }

            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                string fullName = row.Cells["FullName"].Value.ToString();
                int phoneNumber = Convert.ToInt32(row.Cells["PhoneNumber"].Value);
                string address = row.Cells["Address"].Value.ToString();
                bool inBlackList = row.Cells["InBlackList"].Value.ToString() == "Да";

                AddClient editForm = new AddClient();
                editForm.Text = "Редактирование клиента";
                editForm.SetClientData(id, fullName, phoneNumber, address, inBlackList);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    ReloadGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}");
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