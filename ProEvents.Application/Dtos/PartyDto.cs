using System.ComponentModel.DataAnnotations;

namespace ProEvents.Application.Dtos
{
    public class PartyDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PartyDate { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        public string Theme { get; set; }
        [Range(1, 200, ErrorMessage = "It's out of the range - between 1 and 120")]
        public int AmountOfPeople { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "The {0} field needs to be a valid address")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<PartDto>? Parts { get; set; }
        public IEnumerable<SocialNetworkDto>? SocialNetworks { get; set; }
        public IEnumerable<SpeakerPartyDto>? SpeakerParties { get; set; }
    }
}
