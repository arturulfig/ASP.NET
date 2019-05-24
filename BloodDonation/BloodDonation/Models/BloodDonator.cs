using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDonation.Models
{
    public class BloodDonator : Blood
    {
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Donation date")]
        public string DonationDate { get; set; }
        [Display(Name = "Amount")]
        public int VolumeOfBlood { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Personal number")]
        public string PersonalNumber { get; set; }
    }
}
