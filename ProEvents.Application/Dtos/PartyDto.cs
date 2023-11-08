namespace ProEvents.Application.Dtos
{
    public class PartyDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PartyDate { get; set; }
        public string Theme { get; set; }
        public int AmountOfPeople { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<PartDto>? Parts { get; set; }
        public IEnumerable<SocialNetworkDto>? SocialNetworks { get; set; }
        public IEnumerable<SpeakerPartyDto>? SpeakerParties { get; set; }
    }
}
