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

        public AddRent(Employee user)
        {
            InitializeComponent();
            this.user = user;
        }

        public AddRent(Employee user, int rentId)
        {
            InitializeComponent();
            this.user = user;
            this.rent = RentController.GetRentById(rentId);
            rentDate.Value = rent.RentDate;
            returnDate.Value = rent.ReturnDate;
            money.Text = rent.Money.ToString();
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
            client.Text = ClientForm.ChoosenClientId;
        }

        private void chooseDisks_Click(object sender, EventArgs e)
        {
            DVDList DVDform = new DVDList(ListFormStatus.choose);
            DVDform.ShowDialog();
            dvds.Text = DVDform.ChoosenDVDsId;
        }

        private void choosePledge_Click(object sender, EventArgs e)
        {
            PledgeList PledgeForm = new PledgeList();
            PledgeForm.ShowDialog();
            pledge.Text = PledgeForm.ChoosenPledgeId;
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

                if (rent.Id != 0) RentController.EditRent(
                    rent.Id, 
                    rentDate.Value.Date, 
                    returnDate.Value.Date, 
                    State.active, 
                    float.Parse(money.Text), 
                    Int32.Parse(client.Text), 
                    user.Id, 
                    Int32.Parse(pledge.Text),
                    dvdIds);
                else RentController.AddRent(
                    rentDate.Value.Date, 
                    returnDate.Value.Date, 
                    State.active, 
                    float.Parse(money.Text), 
                    Int32.Parse(client.Text), 
                    user.Id, 
                    Int32.Parse(pledge.Text),
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
    }
}
