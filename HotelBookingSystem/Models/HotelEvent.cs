namespace HotelBookingSystem.Models
{
    public class HotelEvent
    {
        public int EventId { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public HotelEvent(int eventId, int clientId, int roomId, DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime)
        {
            EventId = eventId;
            ClientId = clientId;
            RoomId = roomId;
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"[{EventId}] Kunde-ID: {ClientId}, Rom: {RoomId}, Fra: {StartDate:yyyy-MM-dd} {StartTime} Til: {EndDate:yyyy-MM-dd} {EndTime}";
        }
    }
}