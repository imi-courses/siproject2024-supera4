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

            pledgeType.Items.Add("passport");
            pledgeType.Items.Add("internationalPassport");
            pledgeType.Items.Add("driverLicense");
            pledgeType.Items.Add("cash");

            pledgeType.SelectedIndex = 0;

            comboBox1_SelectedIndexChanged(this, EventArgs.Empty);
        }

        Pledge pledge = new Pledge();

        public AddPledge(int Id)
        {
            InitializeComponent();
            pledge = PledgeController.GetPledgeById(Id);
            pledgeType.Text = pledge.PledgeType.ToString();
            series.Text = pledge.Series.ToString();
            numbers.Text = pledge.Number.ToString();
            price.Text = pledge.Money.ToString();

            comboBox1_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedPledgeType = pledgeType.Text;

            int series = 0;
            int number = 0;
            float money = 0;

            if (selectedPledgeType != "cash")
            {
                string seriesText = this.series.Text;
                string numberText = numbers.Text;

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

            else
            {
                if (!float.TryParse(price.Text, out money))
                {
                    MessageBox.Show("Сумма залога должна быть числом!");
                    return;
                }

                if (money < 0)
                {
                    MessageBox.Show("Сумма залога не может быть отрицательной!");
                    return;
                }
            }

            if (selectedPledgeType != "cash")
            {
                if (PledgeController.PledgeExists(ToPledgeType(selectedPledgeType), series, number, pledge.Id > 0 ? pledge.Id : (int?)null))
                {
                    MessageBox.Show("Залог с таким типом, серией и номером уже существует!");
                    return;
                }
            }

            if (pledge.Id != 0) PledgeController.EditPledge(pledge.Id, ToPledgeType(pledgeType.Text), series, number, money);
            else PledgeController.AddPledge(ToPledgeType(pledgeType.Text), series, number, money);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPledgeType = pledgeType.Text;

            if (selectedPledgeType == "cash")
            {
                series.Enabled = false;
                numbers.Enabled = false;
                price.Enabled = true;
                series.Text = "";
                numbers.Text = "";
            }
            else
            {
                series.Enabled = true;
                numbers.Enabled = true;
                price.Enabled = false;
                price.Text = "";
            }
        }

        private void AddPledge_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
