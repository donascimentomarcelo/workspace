using ProEvents.Domain.Identity;

namespace ProEvents.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? MiniCV { get; set; }
        public string? ImageURL { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<SocialNetwork>? SocialNetworks { get; set; }
        public IEnumerable<SpeakerParty> SpeakerParties { get; set; }
    }
}
