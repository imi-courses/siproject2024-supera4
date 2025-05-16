using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Models;
using DVD_rent.Controllers;

namespace DVD_rent.Forms
{
    public partial class CloseRent : Form
    {
        public Rent rent = new Rent();

        public CloseRent(int rentId)
        {
            InitializeComponent();

            this.rent = RentController.GetRentById(rentId);
            returnDate.Value = rent.ReturnDate;
            if (returnDate.Value < DateTime.Now)
            {
                overdue.Text = "Просрочен штраф = " + calculatePrice().ToString() + "руб.";
                overdue.ForeColor = Color.Red;
            }
            txt_Fullname.Text = ClientController.GetClientById(rent.ClientId).FullName;
            Pledge pledge = PledgeController.GetPledgeById(rent.PledgeId);
            txt_pledgeType.Text = pledge.PledgeType.ToString();
            if (pledge.PledgeType == PledgeType.cash)
            {
                txt_PledgeData.Text = pledge.Money.ToString() + "руб.";
            }
            else
            {
                txt_PledgeData.Text = pledge.Series.ToString() + " " + pledge.Number.ToString();
            }

            //Список дисков
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Quantity", "Количество");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("films", "Фильмы");

            dataGridView1.Rows.Clear();
            foreach (DVD dvd in rent.DVDs)
            {
                dataGridView1.Rows.Add(dvd.Id, dvd.Quantity, dvd.Price, dvd.GetStringOfMovies());
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btn_closeRent_Click(object sender, EventArgs e)
        {
            PledgeController.DeletePledgeById(rent.PledgeId);
            foreach (DVD dvd in rent.DVDs)
            {
                DVDController.DeleteDVDById(dvd.Id);
            }
            this.Dispose();
        }

        private float calculatePrice()
        {
            float price = 0;

            foreach (DVD dvd in rent.DVDs)
            {
                price += dvd.Price;
            }

            price *= (int)(DateTime.Now - returnDate.Value).TotalDays;

            return price;
        }
    }
}
