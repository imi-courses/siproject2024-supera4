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
    public partial class AddDVD : Form
    {
        DVD dvd = new DVD();
        public AddDVD()
        {
            InitializeComponent();
            checkedListBox1.Items.AddRange(MovieController.GetAllMovies().ToArray());
        }

        public AddDVD(int Id)
        {
            InitializeComponent();
            dvd = DVDController.GetDVDById(Id);
            quantity.Text = dvd.Quantity.ToString();
            price.Text = dvd.Price.ToString();
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
                if (dvd.Id != 0) DVDController.EditDVD(dvd.Id, Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text), checkedListBox1.CheckedItems.Cast<Movie>().ToList());
                else DVDController.AddDVD(Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text), checkedListBox1.CheckedItems.Cast<Movie>().ToList());
                string namesString = checkedListBox1.CheckedItems.Cast<Movie>().ToList() != null ? string.Join(", ", checkedListBox1.CheckedItems.Cast<Movie>().ToList().Select(o => o.Name)) : "";
                MessageBox.Show(namesString);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
    }
}
