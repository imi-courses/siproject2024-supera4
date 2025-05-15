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
    public class Client : Person
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public bool InBlackList { get; set; }

        //Navigation properties
        public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
    }
}
