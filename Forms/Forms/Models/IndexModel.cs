using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{
    public class IndexModel
    {
        public List<Forms.Models.ConferenceUser> GetUsers { get; set; }
        public Forms.Models.ConferenceUser ConferenceUser { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPageCount { get; set; }
    }
}
