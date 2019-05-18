using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationSystem.Models
{
    public class BloodDonator : Blood
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DonationDate { get; set; }
        public float VolumeOfBlood { get; set; }
        public string Address { get; set; }
        public int PersonalNumber { get; set; }
    }
}
