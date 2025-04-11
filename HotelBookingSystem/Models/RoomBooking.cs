namespace HotelBookingSystem.Models
{
    public class RoomBooking
    {
        public int BookingId { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RoomBooking(int bookingId, int clientId, int roomId, int guestId, DateTime startDate, DateTime endDate)
        {
            BookingId = bookingId;
            ClientId = clientId;
            RoomId = roomId;
            GuestId = guestId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return $"[{BookingId}] Kunde-ID: {ClientId}, Gjest-ID: {GuestId}, Rom: {RoomId}, Fra: {StartDate:yyyy-MM-dd} Til: {EndDate:yyyy-MM-dd}";
        }
    }
}