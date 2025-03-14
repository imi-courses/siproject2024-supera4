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

        public void ReloadGridView()
        {
            dataGridView1.DataSource = DVDController.GetAllDVDs();
        }

        private void DVDList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDVD addDVD = new AddDVD();
            addDVD.ShowDialog();
            ReloadGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    DVDController.DeleteDVDById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                }
            }
            ReloadGridView();
        }
    }
}
