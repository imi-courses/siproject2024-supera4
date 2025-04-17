using DVD_rent.Controllers;
using DVD_rent.Models;
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
    public partial class AddEmployee : Form
    {
        Position ToEmployeeType(string S)
        {
            if (S == "cashier")
                return Position.cashier;
            else return 0;
        }
        public AddEmployee()
        {
            InitializeComponent();
            comboBox1.Items.Add("cashier");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            EmployeeController.AddEmployee(ToEmployeeType(comboBox1.Text), Convert.ToString(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text));
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
