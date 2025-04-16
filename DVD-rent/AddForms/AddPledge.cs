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

            int series = 0;
            int number = 0;
            int money = 0;

            if (selectedPledgeType != "cash")
            {
                string seriesText = textBox1.Text;
                string numberText = textBox2.Text;

                if (string.IsNullOrEmpty(seriesText) || string.IsNullOrEmpty(numberText))
                {
                    MessageBox.Show("Введите серию и номер документа!");
                    return;
                }

                if (selectedPledgeType == "passport")
                {
                    if (seriesText.Length != 4 || numberText.Length != 6)
                    {
                        MessageBox.Show("Для паспорта серия должна состоять из 4 цифр, а номер из 6.");
                        return;
                    }
                }

                if (selectedPledgeType == "internationalPassport")
                {
                    if (seriesText.Length != 2 || numberText.Length != 7)
                    {
                        MessageBox.Show("Для иностранного паспорта серия должна состоять из 2 цифр, а номер из 7.");
                        return;
                    }
                }

                if (selectedPledgeType == "driverLicense")
                {
                    if (seriesText.Length != 4 || numberText.Length != 6)
                    {
                        MessageBox.Show("Для водительского удостоверения серия должна состоять из 4 цифр, а номер из 6.");
                        return;
                    }
                }

                if (!int.TryParse(seriesText, out series))
                {
                    MessageBox.Show("Серия должна быть числом!");
                    return;
                }

                if (!int.TryParse(numberText, out number))
                {
                    MessageBox.Show("Номер должен быть числом!");
                    return;
                }
            }

            if (selectedPledgeType == "cash")
            {
                if (!int.TryParse(textBox3.Text, out money))
                {
                    MessageBox.Show("Введите сумму залога!");
                    return;
                }
                if (money <= 0)
                {
                    MessageBox.Show("Сумма залога должна быть не меньше 0 рублей!");
                    return;
                }
            }

            PledgeController.AddPledge(ToPledgeType(comboBox1.Text), series, number, money);
            this.Close();
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

        private void AddPledge_Load(object sender, EventArgs e)
        {

        }
    }
}
