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
        public static void AddRent(DateTime RentDate, DateTime ReturnDate, State state, float money, int clientId, int employeeId, int pledgeId, List<int> dvdIds)
        {
            using (Context db = new Context())
            {
                DVD dvd = new DVD();
                List<DVD> dvdList = new List<DVD>();
                foreach (int dvdId in dvdIds)
                {
                    dvd = db.DVDs.Find(dvdId);
                    dvd.Quantity--;
                    dvdList.Add(dvd);
                }

                db.Rents.Add(new Rent { 
                    RentDate = RentDate, 
                    ReturnDate = ReturnDate , 
                    State = state, 
                    Money = money , 
                    ClientId = clientId,
                    EmployeeId = employeeId,
                    PledgeId = pledgeId,
                    DVDs = dvdList
                });
                db.SaveChanges();
            }

        }
        public static void EditRent(int id, DateTime RentDate, DateTime ReturnDate, State state, float money, int clientId, int employeeId, int pledgeId, List<int> dvdIds)
        {
            try
            {
                using (Context db = new Context())
                {
                    List<DVD> dvdList = new List<DVD>();
                    DVD dvd = new DVD();

                    Rent rent = db.Rents
                        .Include(r => r.DVDs)
                        .FirstOrDefault(r => r.Id == id); // rent которая находиться в базе данных

                    //обратно возвращаем значения количество дисков
                    foreach (DVD d in rent.DVDs)
                    {
                        dvd = db.DVDs.Find(d.Id);
                        dvd.Quantity++;
                    }

                    //меняем rent из базы данных данными из нового renta
                    rent.RentDate = RentDate;
                    rent.ReturnDate = ReturnDate;
                    rent.State = state;
                    rent.Money = money;
                    rent.Client = db.Clients.Find(clientId);
                    rent.Employee = db.Employees.Find(employeeId);
                    rent.Pledge = db.Pledges.Find(pledgeId);

                    foreach (int dvdId in dvdIds)
                    {
                        db.DVDs.Find(dvdId).Quantity--;
                        dvdList.Add(db.DVDs.Find(dvdId));
                    }
                    rent.DVDs = dvdList;
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
                db.Configuration.LazyLoadingEnabled = false;
                return db.Rents
                    .Include(r => r.Client)
                    .Include(r => r.Pledge)
                    .Include(r => r.Employee)
                    .Include(r => r.DVDs)
                    .FirstOrDefault(r => r.Id == id);
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
                return db.Rents.Include("Client").Include("Pledge").Include("Employee").Include("DVDs").ToList();
            }
        }
    }
}
