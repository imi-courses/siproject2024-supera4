﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DVD_rent.Controllers;

namespace DVD_rent
{

    public partial class PledgeList : Form
    {
        public PledgeList()
        {
            InitializeComponent();
        }

        private void Form_List_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PledgeController.GetAllPledges();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddPledge addPledge = new AddPledge();
            addPledge.ShowDialog();
            ReloadGridView();
        }
        public void ReloadGridView()
        {
            dataGridView1.DataSource = PledgeController.GetAllPledges();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    PledgeController.DeletePledgeById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                }
            }
            ReloadGridView();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void edit_Click(object sender, EventArgs e)
        {

        }
    }
}
