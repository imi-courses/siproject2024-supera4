using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVD_rent.Models;

namespace DVD_rent.Controllers
{
    class DVDController
    {
        public static void Add(int quantity, float price)
        {
            using (Context db = new Context())
            {
                db.DVDs.Add(new DVD { Price = price, Quantity = quantity });
                db.SaveChanges();
            }
        }
        public static string ShowAll()
        {
            using (Context db = new Context())
            {
                string text = "";
                var dvds = (from b in db.DVDs
                           select b).ToList();

                foreach (var dvd in dvds)
                {
                    text += dvd.Id + " " + dvd.Quantity + " " + dvd.Price + "\n";
                }
                return text;
            }
        }
    }
}
