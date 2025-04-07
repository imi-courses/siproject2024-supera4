using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVD_rent.Models;
using System.Windows.Forms;

namespace DVD_rent.Controllers
{
    class MovieController
    {
        public static void AddMovie(string name)
        {
            using (Context db = new Context())
            {
                db.Movies.Add(new Movie { Name = name });
                db.SaveChanges();
            }

        }
        public static void EditMovie(int id, string name)
        {
            try
            {
                Movie movie = GetMovieById(id);
                movie.Name = name;

                Context db = new Context();
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }
        public static Movie GetMovieById(int id)
        {
            using (Context db = new Context())
            {
                return db.Movies.Find(id);
            }
        }
        public static void DeleteMovieById(int id)
        {
            using (Context db = new Context())
            {
                Movie movie = GetMovieById(id);
                db.Movies.Attach(movie);
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }
        public static List<Movie> GetAllMovies()
        {
            using (Context db = new Context())
            {
                //foreach (var movie in db.Movies)
                //{

                //}
                return db.Movies.ToList();
            }
        }
    }
}
