using ProEvents.Domain.Identity;

namespace ProEvents.Domain
{
    public class Party
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime PartyDate { get; set; }
        public string Theme { get; set; }
        public int AmountOfPeople { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Part>? Parts { get; set; }
        public IEnumerable<SocialNetwork>? SocialNetworks { get; set; }
        public IEnumerable<SpeakerParty>? SpeakerParties { get; set; }
    }
}
