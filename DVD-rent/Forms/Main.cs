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
using DVD_rent.ListForms;

namespace DVD_rent
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void дисковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVDList DVDform = new DVDList();
            DVDform.ShowDialog();
        }

        private void залогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PledgeList PledgeForm = new PledgeList();
            PledgeForm.ShowDialog();
        }

        private void фильмовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieList MovieForm = new MovieList();
            MovieForm.ShowDialog();
        }
        private void кассировToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeList EmployeeForm = new EmployeeList();
            EmployeeForm.ShowDialog();
        }
        private void клиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientList ClientForm = new ClientList();
            ClientForm.ShowDialog();
        }

        private void арендToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentList RentForm = new RentList();
            RentForm.ShowDialog();
        }
    }
}
