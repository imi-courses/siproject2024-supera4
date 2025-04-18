using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVD_rent.AddForms
{
    public partial class AddRent : Form
    {
        public AddRent()
        {
            InitializeComponent();
        }

        private void chooseClient_Click(object sender, EventArgs e)
        {
            ClientList ClientForm = new ClientList();
            ClientForm.ShowDialog();
        }

        private void chooseDisks_Click(object sender, EventArgs e)
        {
            DVDList DVDform = new DVDList();
            DVDform.ShowDialog();
        }

        private void choosePledge_Click(object sender, EventArgs e)
        {
            PledgeList PledgeForm = new PledgeList();
            PledgeForm.ShowDialog();
        }
    }
}
