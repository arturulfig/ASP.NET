using System;
using System.Collections.Generic;
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
        public BloodGroup TypeOfBlood { get; set; }
        public BloodFactor FactorBlood { get; set; }
        public float BloodVolume { get; set; }
    }
}