namespace ProEvents.Application.Dtos
{
    public class PartDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Amount { get; set; }
        public int PartyId { get; set; }
        public PartyDto Party { get; set; }
    }
}
