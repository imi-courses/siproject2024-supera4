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

namespace DVD_rent.AddForms
{
    public partial class AddRent : Form
    {
        public Employee user = new Employee();
        public Rent rent = new Rent();
        private int clientId = -1;
        private int pledgeId = -1;

        public AddRent(Employee user)
        {
            InitializeComponent();
            this.user = user;
        }

        public AddRent(Employee user, int rentId)
        {
            InitializeComponent();
            this.Text = "Редактировать аренду";
            this.user = user;
            this.rent = RentController.GetRentById(rentId);
            rentDate.Value = rent.RentDate;
            returnDate.Value = rent.ReturnDate;
            money.Text = calculatePrice().ToString();
            client.Text = rent.ClientId.ToString();
            pledge.Text = rent.PledgeId.ToString();
            foreach (DVD dvd in this.rent.DVDs)
            {
                dvds.Text += dvd.Id.ToString() + " ";
            }
        }

        private void chooseClient_Click(object sender, EventArgs e)
        {
            ClientList ClientForm = new ClientList(ListFormStatus.choose);
            ClientForm.ShowDialog();
            clientId = int.Parse(ClientForm.ChoosenClientId);
            client.Text = ClientController.GetClientById(clientId).FullName;
            
        }

        private void chooseDisks_Click(object sender, EventArgs e)
        {
            DVDList DVDform = new DVDList(ListFormStatus.choose);
            DVDform.ShowDialog();
            dvds.Text = DVDform.ChoosenDVDsId;
            money.Text = calculatePrice().ToString();
        }

        private void choosePledge_Click(object sender, EventArgs e)
        {
            AddPledge addPledge = new AddPledge();
            addPledge.ShowDialog();
            pledgeId = PledgeController.GetAllPledges().Last().Id;
            Pledge pledge1 = PledgeController.GetAllPledges().Last();
            if (pledge1.PledgeType == PledgeType.cash)
            {
                pledge.Text = pledge1.Money.ToString() + "руб.";
            }
            else
            {
                pledge.Text = pledge1.Series.ToString() + " " + pledge1.Number.ToString();
            }
            
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> dvdIds = dvds.Text
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                foreach (int dvdId in dvdIds)
                {
                    if (DVDController.GetDVDById(dvdId).Quantity == 0)
                        throw new Exception("Диск с таким ID=" + dvdId.ToString() + " нет в наличии");
                }

                if (returnDate.Value <= rentDate.Value)
                {
                    throw new Exception("Дата аренды не может быть равен или быть больше чем дата возвращения");
                }

                if (rent.Id != 0) RentController.EditRent(
                    rent.Id,
                    rentDate.Value.Date,
                    returnDate.Value.Date,
                    State.active,
                    calculatePrice(),
                    clientId,
                    user.Id,
                    pledgeId,
                    dvdIds);
                else RentController.AddRent(
                    rentDate.Value.Date,
                    returnDate.Value.Date,
                    State.active,
                    calculatePrice(),
                    clientId,
                    user.Id,
                    pledgeId,
                    dvdIds);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
                // Проверка на внутреннее исключение
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Подробности: " + ex.InnerException.Message);

                    // Иногда бывает ещё один уровень вложенности:
                    if (ex.InnerException.InnerException != null)
                    {
                        MessageBox.Show("Глубже: " + ex.InnerException.InnerException.Message);
                    }
                }
            }
        }

        private float calculatePrice()
        {
            float price = 0;
            List<int> dvdIds = dvds.Text
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            foreach (int dvdId in dvdIds)
            {
                price += DVDController.GetDVDById(dvdId).Price;
            }

            price *= (int)(returnDate.Value - rentDate.Value).TotalDays;

            return price;
        }

        private void returnDate_ValueChanged(object sender, EventArgs e)
        {
            money.Text = calculatePrice().ToString();
        }

        private void rentDate_ValueChanged(object sender, EventArgs e)
        {
            money.Text = calculatePrice().ToString();
        }
    }
}

