using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonation.Models
{
    public class BloodDonator : Blood
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DonationDate { get; set; }
        public float VolumeOfBlood { get; set; }
        public string Address { get; set; }
        public string PersonalNumber { get; set; }
    }
}
