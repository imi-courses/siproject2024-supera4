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
        public static void AddClient(string fullName, int phoneNumber, string address, bool inBlackList)
        {
            using (Context db = new Context())
            {
                db.Clients.Add(new Client {
                    FullName = fullName,
                    PhoneNumber = phoneNumber, 
                    Address = address, 
                    InBlackList = inBlackList });
                db.SaveChanges();
            }

        }
        public static void EditClient(string fullName, int id, int phoneNumber, string address, bool inBlackList)
        {
            try
            {
                Client client = GetClientById(id);
                client.FullName = fullName;
                client.PhoneNumber = phoneNumber;
                client.Address = address;
                client.InBlackList = inBlackList;

                Context db = new Context();

                if (phoneNumber < 11)
                {
                    throw new Exception("incorrect phone number");
                }

                db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
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

