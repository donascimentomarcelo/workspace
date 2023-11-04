namespace ProEvents.Domain
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? PartyId { get; set; }
        public Party? Party { get; set; }
        public int? SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
    }
}
