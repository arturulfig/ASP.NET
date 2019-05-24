using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodDonation.Models;
using System.IO;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Resources;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace BloodDonation.DAL
{
    public class DataAccessLayer
    {
        public List<BloodDonator> ListOfDonators;
        private string csvName = "MOCK_DATA4.csv";
        private string csvPath;
        private TextFieldParser parser;
        private string fullPath;
        private string[] fields;
        private bool validator;
        private bool permission;
        string[] delimiters = { ";", "," };
        public DataAccessLayer(string filePath)
        {
            csvPath = filePath;
            fullPath = Path.Combine(csvPath, csvName);
            ListOfDonators = new List<BloodDonator>();
            LoadFromFile(fullPath);
        }

        public void CheckInputData(string[] fields)
        {
            //validator = true;
            //if (fields.Length != 8)
            //{
            //    //AddDataToAnotherFile();
            //}
            //else
           // {
                if (true)
                {
                   // permission = false;
                    //isDataValid();

                    if (true)
                    {
                        BloodDonator donator = new BloodDonator()
                        {
                            FirstName = fields[0],
                            LastName = fields[1],
                            PersonalNumber = fields[2],
                            TypeOfBlood = (BloodGroup)Enum.Parse(typeof(BloodGroup), fields[3]),
                            FactorBlood = (BloodFactor)Enum.Parse(typeof(BloodFactor), fields[4]),
                            BloodVolume = float.Parse(fields[5]),
                            DonationDate = fields[6],
                            Address = fields[7],
                        };
                        ListOfDonators.Add(donator);
                    }
                }
            //}
        }

        private void isDataValid()
        {
            checkName(fields[1]);
            checkName(fields[2]);
            checkDate(fields[3]);
            checkAmount(fields[4]);
            CheckBloodGroup(fields[5]);
            checkBloodFactor(fields[6]);
            checkAddress(fields[7]);
            checkPersonalNumber(fields[8]);
            if (validator)
                permission = true;
        }

        public void checkDate(string date)
        {
            try
            {
                var parseDate = DateTime.Parse(date).ToShortDateString();
                fields[6] = parseDate;
            }
            catch
            {
                validator = false;
            }
        }

        public void checkName(string firstName)
        {
            bool letterInput = Regex.IsMatch(firstName, @"[a-zA-Z]");
            if (!letterInput)
            {
                validator = false;
            }
        }

        public void checkPersonalNumber(string pesel)
        {
            try
            {
                Convert.ToInt64(pesel);
                if (pesel.Length != 11)
                {
                    validator = false;
                }
            }
            catch
            {
                validator = false;
            }
        }
        public void checkAddress(string place)
        {
            bool placeInput = Regex.IsMatch(place, @"[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ-]*");
            if (!placeInput)
            {
                validator = false;
            }

        }

        public void checkAmount(string amount)
        {
            try
            {
                if (Convert.ToInt32(amount) < 0)
                {
                    validator = false;
                }
            }
            catch
            {
                validator = false;
            }
        }

        protected bool checkStringIsNum(string letters)
        {
            return letters.All(char.IsDigit);
        }

        public List<BloodDonator> LoadFromFile(string fullPath)

        {
            using (TextFieldParser parser = FileSystem.OpenTextFieldParser(fullPath, delimiters))
            {
                while (!parser.EndOfData)
                {
                    try
                    {
                        fields = parser.ReadFields();
                        CheckInputData(fields);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }


            return ListOfDonators;
        }
        public void CheckBloodGroup(string group)
        {
            if (group == "0")
            {
                group = "ZERO";
            }


            if (!(Enum.IsDefined(typeof(BloodGroup), group)))
            {
                validator = false;
            }

            fields[3] = group;
        }
        public void checkBloodFactor(string factor)
        {
            string factorPlus = "+";
            string factorMinus = "-";
            string bloodFactor = null;

            if (factor.Contains(factorPlus))
                bloodFactor = BloodFactor.Plus.ToString();
            if (factor.Contains(factorMinus))
                bloodFactor = BloodFactor.Minus.ToString();
            if (bloodFactor != null)
                fields[4] = Convert.ToString(bloodFactor);
        }
    }
}   
