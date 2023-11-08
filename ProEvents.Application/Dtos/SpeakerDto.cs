namespace ProEvents.Application.Dtos
{
    public class SpeakerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCV { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialNetworkDto> SocialNetworks { get; set; }
        public IEnumerable<SpeakerPartyDto> SpeakerParties { get; set; }
    }
}
