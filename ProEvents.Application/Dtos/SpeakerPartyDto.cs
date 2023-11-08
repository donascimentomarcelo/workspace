namespace ProEvents.Application.Dtos
{
    public class SpeakerPartyDto
    {
        public int SpeakerId { get; set; }
        public SpeakerDto Speaker { get; set; }
        public int PartyId { get; set; }
        public PartyDto Party { get; set; }
    }
}
