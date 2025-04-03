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
        PledgeType ToPledgeType(string S)
        {
            if (S == "passport")
                return PledgeType.passport;
            else if (S == "internationalPassport")
                return PledgeType.internationalPassport;
            else if (S == "driverLicense")
                return PledgeType.driverLicense;
            else if (S == "cash")
                return PledgeType.cash;
            else return 0;
        }

        public AddPledge()
        {
            InitializeComponent();

            comboBox1.Items.Add("passport");
            comboBox1.Items.Add("internationalPassport");
            comboBox1.Items.Add("driverLicense");
            comboBox1.Items.Add("cash");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PledgeController.AddPledge(ToPledgeType(comboBox1.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPledge_Load(object sender, EventArgs e)
        {

        }
    }
}
