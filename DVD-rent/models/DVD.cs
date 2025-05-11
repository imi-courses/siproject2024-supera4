using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DVD_rent.Models;

namespace DVD_rent.Models
{
    public class DVD
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        //Navigation properties
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
        public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

        public string GetStringOfMovies()
        {
            return string.Join(", ", Movies.Select(o => o.Name));
        }
    }
}
