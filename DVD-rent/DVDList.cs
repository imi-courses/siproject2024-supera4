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
    public partial class DVDList : Form
    {
        public DVDList()
        {
            InitializeComponent();
        }

        private void DVDList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DVDController.GetAllDVDs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDVD addDVD = new AddDVD();
            addDVD.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
