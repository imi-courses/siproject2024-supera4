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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVD_rent.AddForms
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClientController.AddClient(Convert.ToInt32(textBox1.Text), Convert.ToString(textBox2.Text), false);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
