using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using DVD_rent.Controllers;
using DVD_rent.Models;
using DVD_rent.AddForms;

namespace DVD_rent.ListForms
{
    public partial class RentList : Form
    {
        public RentList()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("RentDate", "RentDate");
            dataGridView1.Columns.Add("ReturnDate", "ReturnDate");
            dataGridView1.Columns.Add("State", "State");
            dataGridView1.Columns.Add("Money", "Money");
            dataGridView1.Columns.Add("Client", "Client");
            dataGridView1.Columns.Add("Employee", "Employee");
            dataGridView1.Columns.Add("Pledge", "Pledge");
            dataGridView1.Columns.Add("DVDs", "DVDs");
        }

        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (Rent rent in RentController.GetAllRents())
            {
                //string namesString = string.Join(", ", rent.Movies.Select(o => o.Name));
                dataGridView1.Rows.Add(rent.Id, rent.RentDate, rent.ReturnDate, rent.State, rent.Money, rent.Client, rent.Employee, rent.Pledge, rent.DVDs);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RentList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddRent addRent = new AddRent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
