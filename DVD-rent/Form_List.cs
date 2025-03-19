using System;
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

    public partial class Form_List : Form
    {
        public Form_List()
        {
            InitializeComponent();
        }

        private void Form_List_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PledgeController.GetAllPledges();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PledgeController.AddPledge(PledgeType.passport, 522, 21512, 25125);
            PledgeController.AddPledge(PledgeType.passport, 1662, 215423512, 25125);
            PledgeController.AddPledge(PledgeType.passport, 312, 21512, 25534125);
            PledgeController.AddPledge(PledgeType.passport, 2522, 21515232, 25534125);
        }
    }
}
