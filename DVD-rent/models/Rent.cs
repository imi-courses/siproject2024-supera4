using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DVD_rent.models;

namespace DVD_rent.models
{
    public class Rent
    {
        public DateTime rentDate { get; set; }
        public DateTime returnDate { get; set; }
        [MaxLength(100)]
        public string state { get; set; }
        [MaxLength(100)]
        public string pledge { get; set; }
        public float money { get; set; }

    }
}
