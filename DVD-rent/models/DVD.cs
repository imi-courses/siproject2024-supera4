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

        //Foreign key
        public int RentId { get; set; }

        //Navigation properties
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
        public Rent Rent { get; set; }
    }
}
