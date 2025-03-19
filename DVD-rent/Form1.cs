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

        private void дисковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVDList DVDform = new DVDList();
            DVDform.ShowDialog();
        }

        private void залогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_List Pledge_form = new Form_List();
            Pledge_form.ShowDialog();
        }
    }
}
