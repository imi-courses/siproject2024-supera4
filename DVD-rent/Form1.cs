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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void execute_Click(object sender, EventArgs e)
        {
            DVDController.EditDVD(1, 99, 9999999);
            foreach (DVD dvd in DVDController.GetAllDVDs()){
                testingBox.Text += dvd.Id + " " + dvd.Quantity + " " + dvd.Price + "\n";
            }
        }
    }
}
