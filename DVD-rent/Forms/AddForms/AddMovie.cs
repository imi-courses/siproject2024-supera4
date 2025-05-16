using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Models;
using DVD_rent.Controllers;

namespace DVD_rent
{
    public partial class AddMovie : Form
    {
        Movie movie = new Movie();
        public AddMovie()
        {
            InitializeComponent();
        }

        public AddMovie(int id)
        {
            InitializeComponent();

            this.Text = "Редактировать фильм";
            movie = MovieController.GetMovieById(id);
            name.Text = movie.Name;
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                if (movie.Id != 0) MovieController.EditMovie(movie.Id, name.Text);
                else MovieController.AddMovie(name.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {

        }
    }
}
