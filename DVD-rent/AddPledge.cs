using DVD_rent.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVD_rent
{
    public partial class AddPledge : Form
    {
        public AddPledge()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PledgeController.AddPledge((PledgeType)Convert.ToInt32(comboBox1.Text),Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
        }
    }
}
