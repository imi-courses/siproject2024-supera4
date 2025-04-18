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
    public enum State
    {
        closed,
        active
    }
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public State State { get; set; }
        public float Money { get; set; }

        //Foreign key
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int PledgeId { get; set; }

        //Navigation properties
        public virtual ICollection<DVD> DVDs { get; set; } = new List<DVD>();
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Pledge Pledge { get; set; }
    }
}
