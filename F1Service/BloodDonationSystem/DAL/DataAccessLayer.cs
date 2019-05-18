using BloodDonationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationSystem.DAL
{
    public class DataAccessLayer
    {
        public List<BloodDonator> ListOfDonators;
        private string[] csvNames = { "MOCK_DATA1.csv", "MOCK_DATA2.csv", "MOCK_DATA3.csv", "MOCK_DATA4.csv" };

    }
}
