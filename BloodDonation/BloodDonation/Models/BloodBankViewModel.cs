using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonation.Models
{

    public class BloodBankViewModel
    {
        public BloodDonator donator;
        public PagedList.IPagedList<BloodDonator> PagedDonators { get; set; }
        public Stats Statistics { get; set; }
        public List<BloodDonator> ListOfDonators { get; set; }
        public BloodBankViewModel()
        {
            ListOfDonators = new List<BloodDonator>();
            Statistics = new Stats();
        }
        public void addStats()
        {
            if (ListOfDonators != null)
            {
                foreach (var item in ListOfDonators)
                {
                    Statistics.TotalAmount += item.BloodVolume;
                    switch (item.FactorBlood)
                    {
                        case BloodFactor.Plus:
                            switch (item.TypeOfBlood)
                            {
                                case BloodGroup.A:
                                    Statistics.TotalA_Plus += item.BloodVolume;
                                    break;
                                case BloodGroup.B:
                                    Statistics.TotalB_Plus += item.BloodVolume;
                                    break;
                                case BloodGroup.AB:
                                    Statistics.TotalAB_Plus += item.BloodVolume;
                                    break;
                                case BloodGroup.ZERO:
                                    Statistics.TotalZero_Plus += item.BloodVolume;
                                    break;
                            }
                            break;
                        case BloodFactor.Minus:
                            switch (item.TypeOfBlood)
                            {
                                case BloodGroup.A:
                                    Statistics.TotalA_Minus += item.BloodVolume;
                                    break;
                                case BloodGroup.B:
                                    Statistics.TotalB_Minus += item.BloodVolume;
                                    break;
                                case BloodGroup.AB:
                                    Statistics.TotalAB_Minus += item.BloodVolume;
                                    break;
                                case BloodGroup.ZERO:
                                    Statistics.TotalZero_Minus += item.BloodVolume;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}