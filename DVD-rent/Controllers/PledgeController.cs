using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVD_rent.Models;
using System.Windows.Forms;
using System.Data.Entity;

namespace DVD_rent.Controllers
{
    class PledgeController
    {
        public static void AddPledge(PledgeType pledgetype, int series, int number, float money)
        {
            try
            {
                using (Context db = new Context())
                {
                    if (money <= 0)
                    {
                        throw new Exception("incorrect price");
                    }
                    db.Pledges.Add(new Pledge { PledgeType = pledgetype, Series = series, Number = number, Money = money });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
        public static void EditPledge(int id, PledgeType pledgetype, int series, int number, float money)
        {
            try
            {
                Pledge pledge = GetPledgeById(id);
                pledge.PledgeType = pledgetype;
                pledge.Series = series;
                pledge.Number = number;
                pledge.Money = money;

                Context db = new Context();
                if (money <= 0)
                {
                    throw new Exception("incorrect price");
                }
                db.Entry(pledge).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
        public static Pledge GetPledgeById(int id)
        {
            using (Context db = new Context())
            {
                return db.Pledges.Find(id);
            }
        }
        public static List<Pledge> GetAllPledges()
        {
            using (Context db = new Context())
            {
                return db.Pledges.ToList();
            }
        }
    }
}
