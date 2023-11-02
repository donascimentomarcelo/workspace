using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Domain
{
    internal class Party
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public DateTime? PartyDate { get; set; }
        public string? Theme { get; set; }
        public int? AmountOfPeople { get; set; }
        public string? ImageUrl { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public IEnumerable<Part>? Part { get; set; }
        public IEnumerable<SocialNetwork>? SocialNetwork { get; set; }
        public IEnumerable<SpeakerParty> SpeakerParties { get; set; }
    }
}
