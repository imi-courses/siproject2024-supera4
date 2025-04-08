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
    public enum Position
    {
        director,
        cashier
    }
    public class Employee : Person
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        [MaxLength(100)]
        public string Login { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }

        //Navigation properties
        public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    }
}