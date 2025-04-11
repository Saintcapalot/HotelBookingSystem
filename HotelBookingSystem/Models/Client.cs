namespace HotelBookingSystem.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BillingAddress { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[{Id}] {Name} – Kontakt: {ContactPerson}, {ContactNumber}";
        }
    }
}