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
        public AddDVD()
        {
            InitializeComponent();

        }

        public AddDVD(int Id)
        {
            InitializeComponent();
            DVD dvd = DVDController.GetDVDById(Id);
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
                DVDController.AddDVD(Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }

        private void AddDVD_Load(object sender, EventArgs e)
        {

        }
    }
}
