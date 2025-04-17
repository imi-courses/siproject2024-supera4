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

namespace DVD_rent
{
    public partial class DVDList : Form
    {
        public DVDList()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Names", "Names");
        }

        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (DVD dvd in DVDController.GetAllDVDs())
            {
                // Сформировать строку с именами
                //string namesString = dvd.Movies != null ? string.Join(", ", dvd.Movies.Select(o => o.Name)) : "";
                string namesString = string.Join(", ", dvd.Movies.Select(o => o.Name));
                dataGridView1.Rows.Add(dvd.Id, dvd.Quantity, dvd.Price, namesString);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DVDList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddDVD addDVD = new AddDVD();
            addDVD.ShowDialog();
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

        private void edit_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                AddDVD addDVD = new AddDVD(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                addDVD.ShowDialog();
                ReloadGridView();
            }
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

                List<DVD> filteredDVDs = DVDController.GetAllDVDs()
                    .Where(dvd =>
                        dvd.Quantity.ToString().Contains(searchText) ||
                        dvd.Price.ToString().Contains(searchText) || 
                        string.Join(", ", dvd.Movies.Select(o => o.Name)).Contains(searchText)
                    )
                    .ToList();

                dataGridView1.Rows.Clear();
                foreach (DVD dvd in filteredDVDs)
                {
                    // Сформировать строку с именами
                    //string namesString = dvd.Movies != null ? string.Join(", ", dvd.Movies.Select(o => o.Name)) : "";
                    string namesString = string.Join(", ", dvd.Movies.Select(o => o.Name));
                    dataGridView1.Rows.Add(dvd.Id, dvd.Quantity, dvd.Price, namesString);
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
    }
}
