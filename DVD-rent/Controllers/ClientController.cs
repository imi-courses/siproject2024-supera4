using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVD_rent.Models;
using System.Windows.Forms;

namespace DVD_rent.Controllers
{
    internal class ClientController
    {
        public static void AddClient(string fullName, string phoneNumber, string address, bool inBlackList)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fullName))
                    throw new Exception("ФИО не может быть пустым");

                if (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
                    throw new Exception("Номер телефона должен содержать ровно 11 цифр");

                using (Context db = new Context())
                {
                    db.Clients.Add(new Client
                    {
                        FullName = fullName,
                        PhoneNumber = phoneNumber,
                        Address = address,
                        InBlackList = inBlackList
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}");
                throw;
            }
        }

        public static void EditClient(int id, string fullName, string phoneNumber, string address, bool inBlackList)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fullName))
                    throw new Exception("ФИО не может быть пустым");

                if (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
                    throw new Exception("Номер телефона должен содержать ровно 11 цифр");

                using (Context db = new Context())
                {
                    Client client = db.Clients.Find(id);
                    if (client == null)
                        throw new Exception("Клиент не найден");

                    client.FullName = fullName;
                    client.PhoneNumber = phoneNumber;
                    client.Address = address;
                    client.InBlackList = inBlackList;

                    db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании клиента: {ex.Message}");
                throw;
            }
        }

        public static Client GetClientById(int id)
        {
            using (Context db = new Context())
            {
                return db.Clients.Find(id);
            }
        }

        public static void DeleteClientById(int id)
        {
            using (Context db = new Context())
            {
                Client client = GetClientById(id);
                db.Clients.Attach(client);
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        public static List<Client> GetAllClients()
        {
            using (Context db = new Context())
            {
                return db.Clients.ToList();
            }
        }
    }
}