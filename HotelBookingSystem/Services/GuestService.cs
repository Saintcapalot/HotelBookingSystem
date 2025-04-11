using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class GuestService
    {
        private readonly List<Guest> guests = new();
        private int nextId = 1;

        public Guest Create(Guest guest)
        {
            guest.Id = nextId++;
            guests.Add(guest);
            return guest;
        }

        public List<Guest> GetAll() => guests;

        public Guest? GetById(int id) => guests.FirstOrDefault(g => g.Id == id);

        public bool Update(int id, Guest updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.ContactNumber = updated.ContactNumber;
            existing.PreferredRoom = updated.PreferredRoom;
            return true;
        }

        public bool Delete(int id)
        {
            var guest = GetById(id);
            if (guest == null) return false;

            guests.Remove(guest);
            return true;
        }
    }
}