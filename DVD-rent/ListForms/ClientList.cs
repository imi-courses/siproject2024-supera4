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
        public ClientList()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("PhoneNumber", "PhoneNumber");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("InBlackList", "InBlackList");
        }

        //private void Form_List_Load(object sender, EventArgs e)
        //{
        //    dataGridView1.DataSource = ClientController.GetAllClients();
        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //}

        //private void add_Click(object sender, EventArgs e)
        //{
        //    AddClient addClient = new AddClient();
        //    addClient.ShowDialog();
        //    ReloadGridView();
        //}
        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (Client client in ClientController.GetAllClients())
            {
                dataGridView1.Rows.Add(client.Id, client.PhoneNumber, client.InBlackList, client.Address);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void delete_Click(object sender, EventArgs e)
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

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.ShowDialog();
            ReloadGridView();
        }
    }
}

