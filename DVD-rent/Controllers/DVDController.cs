using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVD_rent.Models;
using System.Windows.Forms;

namespace DVD_rent.Controllers
{
    class DVDController
    {
        public static void AddDVD(int quantity, float price)
        {
            try
            {
                using (Context db = new Context())
                {
                    if (price <= 0)
                    {
                        throw new Exception("incorrect price");
                    }
                    if (quantity < 1)
                    {
                        throw new Exception("incorrect quantity");
                    }
                    db.DVDs.Add(new DVD { Price = price, Quantity = quantity });
                    db.SaveChanges();
                }
            }catch(Exception ex){
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
        public static void EditDVD(int id, int quantity, float price)
        {
            try
            {
                DVD dvd = GetDVDById(id);
                dvd.Quantity = quantity;
                dvd.Price = price;

                Context db = new Context();
                if (price <= 0)
                {
                    throw new Exception("incorrect price");
                }
                if (quantity < 1)
                {
                    throw new Exception("incorrect quantity");
                }
                db.Entry(dvd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
        public static DVD GetDVDById(int id)
        {
            using (Context db = new Context())
            {
                return db.DVDs.Find(id);
            }
        }
        public static List<DVD> GetAllDVDs()
        {
            using (Context db = new Context())
            {
                return db.DVDs.ToList();
            }
        }
    }
}
