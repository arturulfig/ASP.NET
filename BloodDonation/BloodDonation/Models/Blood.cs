using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDonation.Models
{
    public enum BloodGroup
    {
        A,
        B,
        AB,
        ZERO
    }
    public enum BloodFactor
    {
        Plus,
        Minus
    }
    public class Blood
    {
        [Display(Name = "Blood group")]
        public BloodGroup TypeOfBlood { get; set; }
        [Display(Name = "Blood factor")]
        public BloodFactor FactorBlood { get; set; }
        [Display(Name = "Amount")]
        public int BloodVolume { get; set; }
    }
}