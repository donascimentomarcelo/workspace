﻿namespace ProEvents.Application.Dtos
{
    public class SocialNetworkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? PartyId { get; set; }
        public PartyDto Party { get; set; }
        public int? SpeakerId { get; set; }
        public SpeakerDto Speaker { get; set; }
    }
}
