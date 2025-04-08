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
    class DVDController
    {
        public static void AddDVD(int quantity, float price, List<Movie> movies)
        {
            using (Context db = new Context())
            {
                List<Movie> movieList = new List<Movie>();
                foreach (var movie in movies)
                {
                    movieList.Add(db.Movies.Find(movie.Id));
                }
                
                db.DVDs.Add(new DVD { Price = price, Quantity = quantity , Movies = movieList});
                db.SaveChanges();
            }

        }
        public static void EditDVD(int id, int quantity, float price, List<Movie> movies)
        {
            try
            {
                using (Context db = new Context())
                {
                    DVD dvd = db.DVDs.Include(d => d.Movies).FirstOrDefault(d => d.Id == id);
                    List<Movie> movieList = new List<Movie>();
                    foreach (var movie in movies)
                    {
                        movieList.Add(db.Movies.Find(movie.Id));
                    }
                    dvd.Movies = movieList;
                    dvd.Quantity = quantity;
                    dvd.Price = price;

                    if (price <= 0)
                    {
                        throw new Exception("incorrect price");
                    }
                    if (quantity < 1)
                    {
                        throw new Exception("incorrect quantity");
                    }
                    db.Entry(dvd).State = EntityState.Modified;
                    db.SaveChanges();
                }
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
        public static void DeleteDVDById(int id)
        {
            using (Context db = new Context())
            {
                DVD dvd = GetDVDById(id);
                db.DVDs.Attach(dvd);
                db.DVDs.Remove(dvd);
                db.SaveChanges();
            }
        }
        public static List<DVD> GetAllDVDs()
        {
            using (Context db = new Context())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.DVDs.Include("Movies").ToList();
            }
        }
        public static List<Movie> GetMoviesByDVDID(int id)
        {
            using (Context db = new Context())
            {
                db.Configuration.LazyLoadingEnabled = false;
                DVD dvd = GetDVDById(id);
                db.DVDs.Attach(dvd);
                db.Entry(dvd).Collection(d => d.Movies).Load();
                return dvd.Movies.ToList();
            }
        }
    }
}
