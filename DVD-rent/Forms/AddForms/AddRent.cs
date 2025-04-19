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
            pledge.Text = PledgeForm.ChoosenPledge.Id.ToString();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (rent.Id != 0) RentController.EditRent(
                    rent.Id, 
                    rentDate.Value.Date, 
                    returnDate.Value.Date, 
                    State.active, 
                    float.Parse(money.Text), 
                    Int32.Parse(client.Text), 
                    user.Id, 
                    Int32.Parse(pledge.Text), 
                    5);
                else RentController.AddRent(
                    rentDate.Value.Date, 
                    returnDate.Value.Date, 
                    State.active, 
                    float.Parse(money.Text), 
                    Int32.Parse(client.Text), 
                    user.Id, 
                    Int32.Parse(pledge.Text), 
                    5);
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
