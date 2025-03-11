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
            DVDController.AddDVD(Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text));
            this.Close();
        }
    }
}
