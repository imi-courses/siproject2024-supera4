using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_rent
{
    public enum PledgeType
    {
        passport,
        internationalPassport,
        driverLicense,
        cash
    }
    public class Pledge
    {
        public int Id { get; set; }
        public PledgeType PledgeType { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public float Money { get; set; }
    }
}
