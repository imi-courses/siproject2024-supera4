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

            comboBox1.SelectedIndex = 0;

            comboBox1_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedPledgeType = comboBox1.SelectedItem?.ToString();

            try
            {
                int series = 0;
                int number = 0;
                int money = 0;

                if (selectedPledgeType != "cash")
                {
                    if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Series and Number are required unless 'cash' is selected.");
                        return;
                    }

                    if (!int.TryParse(textBox1.Text, out series))
                    {
                        MessageBox.Show("Invalid Series. Please enter a number.");
                        return;
                    }
                    if (!int.TryParse(textBox2.Text, out number))
                    {
                        MessageBox.Show("Invalid Number. Please enter a number.");
                        return;
                    }
                }
                if (selectedPledgeType == "cash")
                {
                    if (string.IsNullOrEmpty(textBox3.Text))
                    {
                        MessageBox.Show("Money is required.");
                        return;
                    }

                    if (!int.TryParse(textBox3.Text, out money))
                    {
                        MessageBox.Show("Invalid Money value. Please enter a number.");
                        return;
                    }
                }

                PledgeController.AddPledge(ToPledgeType(comboBox1.Text), series, number, money);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPledgeType = comboBox1.SelectedItem?.ToString();

            if (selectedPledgeType == "cash")
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox3.Text = "";
            }
        }
    }
}
