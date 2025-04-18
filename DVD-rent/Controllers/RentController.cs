using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DVD_rent.Models;
using System.Windows.Forms;

namespace DVD_rent.Controllers
{
    class RentController
    {
        public static void AddRent(DateTime RentDate, DateTime ReturnDate, State state, float money, int clientId, int employeeId, int pledgeId, int DVDs)
        {
            using (Context db = new Context())
            {

                db.Rents.Add(new Rent { 
                    RentDate = RentDate, 
                    ReturnDate = ReturnDate , 
                    State = state, 
                    Money = money , 
                    ClientId = clientId,
                    EmployeeId = employeeId,
                    PledgeId = pledgeId,
                    DVDs = new List<DVD>() });
                db.SaveChanges();
            }

        }
        public static void EditRent(int id, DateTime RentDate, DateTime ReturnDate, State state, float money, int clientId, int employeeId, int pledgeId, int DVDs)
        {
            try
            {
                using (Context db = new Context())
                {
                    Rent rent = RentController.GetRentById(id);
                    rent.RentDate = RentDate;
                    rent.ReturnDate = ReturnDate;
                    rent.State = state;
                    rent.Money = money;
                    rent.Client = ClientController.GetClientById(clientId);
                    rent.Employee = EmployeeController.GetEmployeeById(employeeId);
                    rent.Pledge = PledgeController.GetPledgeById(pledgeId);
                    rent.DVDs = new List<DVD>();

                    //if (price <= 0)
                    //{
                    //    throw new Exception("incorrect price");
                    //}
                    //if (quantity < 1)
                    //{
                    //    throw new Exception("incorrect quantity");
                    //}
                    db.Entry(rent).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
        public static Rent GetRentById(int id)
        {
            using (Context db = new Context())
            {
                return db.Rents.Find(id);
            }
        }
        public static void DeleteRentById(int id)
        {
            using (Context db = new Context())
            {
                Rent rent = GetRentById(id);
                db.Rents.Attach(rent);
                db.Rents.Remove(rent);
                db.SaveChanges();
            }
        }
        public static List<Rent> GetAllRents()
        {
            using (Context db = new Context())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Rents.ToList();
            }
        }
    }
}
