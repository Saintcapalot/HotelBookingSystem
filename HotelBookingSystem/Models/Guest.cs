namespace HotelBookingSystem.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string PreferredRoom { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[{Id}] {Name} – Tlf: {ContactNumber}, Foretrukket rom: {PreferredRoom}";
        }
    }
}