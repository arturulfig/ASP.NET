using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{
    public enum ConferenceType
    {
        Lecture,
        Workshop
    }

    public enum ConferenceTypeText
    {
        Lektorat,
        Warsztaty
    }

    public class ConferenceUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string AvatarUrl { get; set; }

        public ConferenceType? ConferenceType { get; set; }

    }
}
