namespace HotelBookingSystem.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public int ExpectedAttendees { get; set; }
        public DateTime MealDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string DietaryNotes { get; set; }

        public Meal(int mealId, string mealName, int clientId, int roomId, int expectedAttendees, DateTime mealDate, TimeSpan startTime, TimeSpan endTime, string dietaryNotes)
        {
            MealId = mealId;
            MealName = mealName;
            ClientId = clientId;
            RoomId = roomId;
            ExpectedAttendees = expectedAttendees;
            MealDate = mealDate;
            StartTime = startTime;
            EndTime = endTime;
            DietaryNotes = dietaryNotes;
        }

        public override string ToString()
        {
            return $"[{MealId}] {MealName} – {MealDate:yyyy-MM-dd} {StartTime}-{EndTime}, Rom: {RoomId}, Kunde: {ClientId}, Antall: {ExpectedAttendees}, Notater: {DietaryNotes}";
        }
    }
}