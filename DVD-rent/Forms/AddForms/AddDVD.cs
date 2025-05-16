using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Controllers;
using DVD_rent.Models;

namespace DVD_rent
{
    public partial class AddDVD : Form
    {
        DVD dvd = new DVD();
        List<Movie> allMovieList = new List<Movie>();
        List<Movie> checkedMovieList = new List<Movie>();
        public AddDVD()
        {
            InitializeComponent();
            allMovieList = MovieController.GetAllMovies();
            checkedListBox1.Items.AddRange(allMovieList.ToArray());
            checkedListBox1.CheckOnClick = true;
        }

        public AddDVD(int Id)
        {
            InitializeComponent();

            this.Text = "Редактировать диск";
            allMovieList = MovieController.GetAllMovies();
            checkedListBox1.Items.AddRange(allMovieList.ToArray());
            dvd = DVDController.GetDVDById(Id);
            quantity.Text = dvd.Quantity.ToString();
            price.Text = dvd.Price.ToString();
            checkedMovieList = DVDController.GetMoviesByDVDID(Id);
            for (int i = 0; i < checkedMovieList.Count; i++)
            {
                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    if (checkedMovieList[i].Id == allMovieList[j].Id)
                    {
                        checkedListBox1.SetItemCheckState(j, CheckState.Checked);
                        break;
                    }
                }
            };
            checkedListBox1.CheckOnClick = true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(price.Text) <= 0)
                {
                    throw new Exception("incorrect price");
                }
                if (Convert.ToInt32(quantity.Text) < 1)
                {
                    throw new Exception("incorrect quantity");
                }
                checkedMovieList = new List<Movie>();
                for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
                {
                    checkedMovieList.Add(allMovieList[checkedListBox1.CheckedIndices[i]]);
                }
                if (dvd.Id != 0) DVDController.EditDVD(dvd.Id, Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text), checkedMovieList);
                else DVDController.AddDVD(Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text), checkedMovieList);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
    }
}
