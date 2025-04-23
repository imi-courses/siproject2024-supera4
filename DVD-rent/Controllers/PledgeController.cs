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
                db.Configuration.LazyLoadingEnabled = false;;
                return db.Pledges.Include("Rents").ToList();
            }
        }
        public static void DeletePledgeById(int id)
        {
            using (Context db = new Context())
            {
                Pledge pledge = GetPledgeById(id);
                db.Pledges.Attach(pledge);
                db.Pledges.Remove(pledge);
                db.SaveChanges();
            }
        }
        public static bool PledgeExists(PledgeType pledgeType, int series, int number, int? excludeId = null)
        {
            using (Context db = new Context())
            {
                var query = db.Pledges
                    .Where(p => p.PledgeType == pledgeType && p.Series == series && p.Number == number);

                if (excludeId.HasValue)
                {
                    query = query.Where(p => p.Id != excludeId.Value);
                }

                return query.Any();
            }
        }
    }
}
