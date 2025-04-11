using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class RoomBookingService
    {
        private readonly List<RoomBooking> bookings = new();
        private int nextId = 1;

        public RoomBooking Create(RoomBooking booking)
        {
            booking.BookingId = nextId++;
            bookings.Add(booking);
            return booking;
        }

        public List<RoomBooking> GetAll() => bookings;

        public RoomBooking? GetById(int id) =>
            bookings.FirstOrDefault(b => b.BookingId == id);

        public List<RoomBooking> GetByClientId(int clientId) =>
            bookings.Where(b => b.ClientId == clientId).ToList();

        public List<RoomBooking> GetByRoomId(int roomId) =>
            bookings.Where(b => b.RoomId == roomId).ToList();

        public bool Update(int id, RoomBooking updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.RoomId = updated.RoomId;
            existing.GuestId = updated.GuestId;
            existing.ClientId = updated.ClientId;
            existing.StartDate = updated.StartDate;
            existing.EndDate = updated.EndDate;
            return true;
        }

        public bool Delete(int id)
        {
            var booking = GetById(id);
            if (booking == null) return false;

            bookings.Remove(booking);
            return true;
        }

        public bool IsRoomAvailable(int roomId, DateTime start, DateTime end)
        {
            return bookings.All(b =>
                b.RoomId != roomId || end <= b.StartDate || start >= b.EndDate);
        }
    }
}