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
    public partial class MovieList : Form
    {
        public MovieList()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
        }

        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (Movie movie in MovieController.GetAllMovies())
            {
                dataGridView1.Rows.Add(movie.Id, movie.Name);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddMovie addMovie = new AddMovie();
            addMovie.ShowDialog();
            ReloadGridView();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                AddMovie addMovie = new AddMovie(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                addMovie.ShowDialog();
                ReloadGridView();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    MovieController.DeleteMovieById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                }
            }
            ReloadGridView();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void MovieList_Load(object sender, EventArgs e)
        {
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

    }
}
