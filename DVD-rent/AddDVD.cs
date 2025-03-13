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
    public partial class AddDVD : Form
    {
        public AddDVD()
        {
            InitializeComponent();
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
    }
}
