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
            string[] types = { "ID", "Название" };
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Name", "Название");
            type.Items.AddRange(types);
            type.SelectedIndex = 0;
            type.DropDownStyle = ComboBoxStyle.DropDownList;
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите для редактирования");
                return;
            }

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
                            MovieController.DeleteMovieById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
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

        private void MovieList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text != "Поиск" && search.ForeColor != Color.Gray)
            {

                string searchText = search.Text.Trim();
                List<Movie> filteredMovies = new List<Movie>();

                if (string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView();
                    return;
                }

                if (type.SelectedItem.ToString() == "ID")
                {
                    filteredMovies = MovieController.GetAllMovies()
                    .Where(movie =>
                        movie.Id.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Название")
                {
                    filteredMovies = MovieController.GetAllMovies()
                    .Where(movie =>
                        movie.Name.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();
                }

                dataGridView1.Rows.Clear();
                foreach (Movie movie in filteredMovies)
                {
                    dataGridView1.Rows.Add(movie.Id, movie.Name);
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
