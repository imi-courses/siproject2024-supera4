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
using DVD_rent.ListForms;

namespace DVD_rent
{
    public partial class Main : Form
    {
        public Employee user = new Employee();

        public Main(Employee user)
        {
            InitializeComponent();
            this.user = user;
            //if (user.Position == Position.cashier) кассировToolStripMenuItem.Enabled = false;
            AddUsernameToRight(user.Position.ToString() + " | " + user.FullName);
        }

        private void дисковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVDList DVDform = new DVDList(ListFormStatus.NotChoose);
            DVDform.ShowDialog();
        }

        private void залогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PledgeList PledgeForm = new PledgeList();
            PledgeForm.ShowDialog();
        }

        private void фильмовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieList MovieForm = new MovieList();
            MovieForm.ShowDialog();
        }
        private void кассировToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeList EmployeeForm = new EmployeeList();
            EmployeeForm.ShowDialog();
        }
        private void клиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientList ClientForm = new ClientList(ListFormStatus.NotChoose);
            ClientForm.ShowDialog();
        }

        private void арендToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentList RentForm = new RentList(user);
            RentForm.ShowDialog();
        }

        private void AddUsernameToRight(string username)
        {
            ToolStripLabel userLabel = new ToolStripLabel()
            {
                Text = username,
                Alignment = ToolStripItemAlignment.Right,
                Margin = new Padding(0, 0, 10, 0),
                Font = new Font(menuStrip1.Font, FontStyle.Bold)
            };

            menuStrip1.Items.Add(userLabel);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            int rentedDVDs = 0;
            int expiredRents = 0;
            foreach (Rent rent in RentController.GetAllRents())
            {
                if (rent.RentDate == dateTimePicker.Value.Date)
                {
                    rentedDVDs++;
                }
                else if ((rent.ReturnDate < dateTimePicker.Value.Date)&&(rent.State == State.active))
                {
                    expiredRents++;
                }
            }
            Report.Text += dateTimePicker.Value.Date.ToString() + "\n";
            Report.Text += "Количество одолженных за день дисков: " + rentedDVDs.ToString() + "\n";
            Report.Text += "Количество не вернувшихся дисков: " + rentedDVDs.ToString() + "\n";
            Report.Text += "Отчёт от: " + user.FullName + "\n";
        }
    }
}
