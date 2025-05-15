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

namespace DVD_rent.AddForms
{
    public partial class AddClient : Form
    {
        private int _clientId = -1;

        public AddClient()
        {
            InitializeComponent();
            button1.Text = "Сохранить";
            button3.Text = "Отмена";
        }

        public void SetClientData(int id, string fullName, string phoneNumber, string address, bool inBlackList)
        {
            _clientId = id;
            this.fullName.Text = fullName ?? "";
            this.phoneNumber.Text = phoneNumber; // Форматирование до 11 цифр
            this.address.Text = address ?? "";
            this.checkBoxBlackList.Checked = inBlackList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fullName.Text))
                {
                    MessageBox.Show("Введите ФИО клиента");
                    return;
                }

                string phone = phoneNumber.Text.Trim();
                if (phone.Length != 11 || !phone.All(char.IsDigit))
                {
                    MessageBox.Show("Номер телефона должен содержать ровно 11 цифр");
                    return;
                }

                if (_clientId == -1)
                {
                    ClientController.AddClient(
                        fullName.Text,
                        phone,
                        address.Text,
                        checkBoxBlackList.Checked);
                }
                else
                {
                    ClientController.EditClient(
                        _clientId,
                        fullName.Text,
                        phone,
                        address.Text,
                        checkBoxBlackList.Checked);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }
    }
}