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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace DVD_rent
{
    public partial class Main : Form
    {
        public Employee user = new Employee();

        public Main(Employee user)
        {
            InitializeComponent();
            string position;
            switch (user.Position)
            {
                case Position.cashier:
                    position = "Кассир";
                    break;
                case Position.director:
                    position = "Директор";
                    break;
                default:
                    position = user.Position.ToString();
                    break;
            }
            this.user = user;
            if (user.Position == Position.cashier) кассирыToolStripMenuItem.Enabled = false;
            AddUsernameToRight(position + " | " + user.FullName);
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
            Report.Text = "";

            ExcelPackage.License.SetNonCommercialPersonal("Dmitriev Arkady");

            List<Rent> rentedDVDs = new List<Rent>();
            List<Rent> expiredRents = new List<Rent>();
            foreach (Rent rent in RentController.GetAllRents())
            {
                if (rent.RentDate == dateTimePicker.Value.Date)
                {
                    rentedDVDs.Add(rent);
                }
                else if ((rent.ReturnDate < dateTimePicker.Value.Date)&&(rent.State == State.active))
                {
                    expiredRents.Add(rent);
                }
            }
            Report.Text += dateTimePicker.Value.ToString("yyyy-MM-dd") + "\n";
            Report.Text += "Количество одолженных за день дисков: " + rentedDVDs.Count.ToString() + "\n";
            foreach (Rent rent in rentedDVDs)
            {
                Report.Text += "ФИО: " + rent.Client.FullName.ToString() + "\n";
            }
            Report.Text += "Количество не вернувшихся дисков: " + expiredRents.Count.ToString() + "\n";
            foreach (Rent rent in expiredRents)
            {
                Report.Text += "ФИО: " + rent.Client.FullName.ToString() + "\n";
            }
            Report.Text += "Отчёт от: " + user.FullName + "\n";

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Данные");

                //Кто сделал отчёт
                worksheet.Cells["B1"].Value = "Отчёт от: ";
                worksheet.Cells["C1"].Value = user.FullName;
                worksheet.Cells["B1:C1"].Style.Font.Bold = true;

                //Заголовки
                worksheet.Cells["B2:F2"].Merge = true;
                worksheet.Cells["B2:F3"].Style.Font.Bold = true;
                worksheet.Cells["B2"].Value = "Об одолженных за день дисках";
                var range = worksheet.Cells["B2:F" + (3 + rentedDVDs.Count).ToString()];

                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells["B3"].Value = "ID аренды";
                worksheet.Cells["C3"].Value = "ФИО клиента";
                worksheet.Cells["D3"].Value = "Ном. тел.";
                worksheet.Cells["E3"].Value = "Адрес";
                worksheet.Cells["F3"].Value = "Кол-во одолженных дисков";


                worksheet.Cells["H2:L2"].Merge = true;
                worksheet.Cells["H2:L3"].Style.Font.Bold = true;
                worksheet.Cells["H2"].Value = "Клиенты, которые не вернули";
                range = worksheet.Cells["H2:L" + (3 + expiredRents.Count).ToString()];

                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells["H3"].Value = "ID аренды";
                worksheet.Cells["I3"].Value = "ФИО клиента";
                worksheet.Cells["J3"].Value = "Ном. тел.";
                worksheet.Cells["K3"].Value = "Адрес";
                worksheet.Cells["L3"].Value = "Кол-во одолженных дисков";


                // Данные
                for (int i = 0; i < rentedDVDs.Count; i++)
                {
                    worksheet.Cells["B" + (i + 4).ToString()].Value = rentedDVDs[i].Id;
                    worksheet.Cells["C" + (i + 4).ToString()].Value = rentedDVDs[i].Client.FullName;
                    worksheet.Cells["D" + (i + 4).ToString()].Value = rentedDVDs[i].Client.PhoneNumber;
                    worksheet.Cells["E" + (i + 4).ToString()].Value = rentedDVDs[i].Client.Address;
                    worksheet.Cells["F" + (i + 4).ToString()].Value = rentedDVDs[i].DVDs.Count;
                }

                for (int i = 0; i < expiredRents.Count;i++)
                {
                    worksheet.Cells["H" + (i + 4).ToString()].Value = expiredRents[i].Id;
                    worksheet.Cells["I" + (i + 4).ToString()].Value = expiredRents[i].Client.FullName;
                    worksheet.Cells["J" + (i + 4).ToString()].Value = expiredRents[i].Client.PhoneNumber;
                    worksheet.Cells["K" + (i + 4).ToString()].Value = expiredRents[i].Client.Address;
                    worksheet.Cells["L" + (i + 4).ToString()].Value = expiredRents[i].DVDs.Count;
                }



                // Создаем SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
                saveFileDialog.Title = "Сохранить отчёт";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.AddExtension = true;

                // Устанавливаем начальную директорию из Settings
                if (!string.IsNullOrEmpty(Properties.Settings.Default.FilePath))
                {
                    saveFileDialog.InitialDirectory = Properties.Settings.Default.FilePath;
                }
                else
                {
                    // Если в Settings нет пути, устанавливаем папку "Мои документы" по умолчанию
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
                // Устанавливаем имя файла по умолчанию
                saveFileDialog.FileName = "Отчёт " + dateTimePicker.Value.ToString("yyyy-MM-dd") + ".xlsx";


                // Отображаем диалог сохранения файла
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получаем выбранный путь и имя файла
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Сохраняем файл
                        var file = new FileInfo(filePath);
                        package.SaveAs(file);

                        // Обновляем SavePath в Settings
                        Properties.Settings.Default.FilePath = Path.GetDirectoryName(filePath);
                        Properties.Settings.Default.Save();

                        MessageBox.Show("Отчёт успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
