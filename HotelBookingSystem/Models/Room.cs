namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // F.eks. Enkeltrom, Dobbeltrom, Suite
        public bool IsAvailable { get; set; } = true;

        public override string ToString()
        {
            var status = IsAvailable ? "Ledig" : "Opptatt";
            return $"[{Id}] Rom {RoomNumber} – {Type} ({status})";
        }
    }
}