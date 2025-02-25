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
using DVD_rent.Services;

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
            DVDService.Add(100, 2);
            DVDService.Add(10, 129);
            DVDService.Add(200, 29);
            DVDService.Add(134, 9);
            testingBox.Text = DVDService.ShowAll();
        }
    }
}
