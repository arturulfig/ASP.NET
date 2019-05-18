using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonation.Models
{
    public class Stats
    {
        public float TotalAmount { get; set; }
        // group A
        public float TotalA_Plus { get; set; }
        public float TotalA_Minus { get; set; }
        // group B
        public float TotalB_Plus { get; set; }
        public float TotalB_Minus { get; set; }
        // group AB
        public float TotalAB_Plus { get; set; }
        public float TotalAB_Minus { get; set; }
        // group Zero
        public float TotalZero_Plus { get; set; }
        public float TotalZero_Minus { get; set; }
    }
}
