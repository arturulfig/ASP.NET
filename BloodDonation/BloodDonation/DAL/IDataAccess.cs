using BloodDonation.Models;
using System.Collections.Generic;

namespace BloodDonation
{
    interface IDataAccess
    {
        List<BloodDonator> LoadFromFile(string fullPath);
        //void SaveToFile(BloodDonator donator);
        void CheckInputData(string[] input);

    }
}