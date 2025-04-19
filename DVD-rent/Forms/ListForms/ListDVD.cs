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
    public enum ListFormStatus
    {
        choose,
        NotChoose
    }

    public partial class DVDList : Form
    {
        public string ChoosenDVDsId;
        public DVDList(ListFormStatus status)
        {
            string[] types = { "ID", "Количество", "Цена", "Фильмы" };
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Quantity", "Количество");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("films", "Фильмы");
            type.Items.AddRange(types);
            type.SelectedIndex = 0;
            type.DropDownStyle = ComboBoxStyle.DropDownList;
            if (status == ListFormStatus.NotChoose) btnChoose.Visible = false;
        }

        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (DVD dvd in DVDController.GetAllDVDs())
            {
                dataGridView1.Rows.Add(dvd.Id, dvd.Quantity, dvd.Price, dvd.GetStringOfMovies());
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

                string searchText = search.Text.Trim().ToLower();
                List<DVD> filteredDVDs = new List<DVD>();
                
                
                if (string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView();
                    return;
                }

                if (type.SelectedItem.ToString() == "ID")
                {
                    filteredDVDs = DVDController.GetAllDVDs()
                    .Where(dvd =>
                        dvd.Id.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Количество")
                {
                    filteredDVDs = DVDController.GetAllDVDs()
                    .Where(dvd =>
                        dvd.Quantity.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                } 
                else if (type.SelectedItem.ToString() == "Цена")
                {
                    filteredDVDs = DVDController.GetAllDVDs()
                    .Where(dvd =>
                        dvd.Price.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Фильмы")
                {
                    filteredDVDs = DVDController.GetAllDVDs()
                    .Where(dvd =>
                        dvd.GetStringOfMovies().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                

                dataGridView1.Rows.Clear();
                foreach (DVD dvd in filteredDVDs)
                {
                    dataGridView1.Rows.Add(dvd.Id, dvd.Quantity, dvd.Price, dvd.GetStringOfMovies());
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

        private void btnChoose_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            for (int i=0; i< selectedRowCount;i++)
            {
                ChoosenDVDsId += dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString() + " ";
                this.Close();
            }
        }
    }
}
