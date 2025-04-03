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

namespace DVD_rent
{
    public partial class MovieList : Form
    {
        public MovieList()
        {
            InitializeComponent();
        }

        public void ReloadGridView()
        {
            dataGridView1.DataSource = MovieController.GetAllMovies();
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
    }
}
