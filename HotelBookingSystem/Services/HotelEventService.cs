using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class HotelEventService
    {
        private readonly List<HotelEvent> events = new();
        private int nextId = 1;

        public HotelEvent Create(HotelEvent hotelEvent)
        {
            hotelEvent.EventId = nextId++;
            events.Add(hotelEvent);
            return hotelEvent;
        }

        public List<HotelEvent> GetAll() => events;

        public HotelEvent? GetById(int id) =>
            events.FirstOrDefault(e => e.EventId == id);

        public bool Update(int id, HotelEvent updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.ClientId = updated.ClientId;
            existing.RoomId = updated.RoomId;
            existing.StartDate = updated.StartDate;
            existing.EndDate = updated.EndDate;
            existing.StartTime = updated.StartTime;
            existing.EndTime = updated.EndTime;
            return true;
        }

        public bool Delete(int id)
        {
            var hotelEvent = GetById(id);
            if (hotelEvent == null) return false;

            events.Remove(hotelEvent);
            return true;
        }
    }
}