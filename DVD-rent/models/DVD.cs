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
    public class DVD
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
