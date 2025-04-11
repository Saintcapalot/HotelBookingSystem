using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class RoomService
    {
        private readonly List<Room> rooms = new();
        private int nextId = 1;

        public Room Create(Room room)
        {
            room.Id = nextId++;
            rooms.Add(room);
            return room;
        }

        public List<Room> GetAll() => rooms;

        public Room? GetById(int id) => rooms.FirstOrDefault(r => r.Id == id);

        public bool Update(int id, Room updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.RoomNumber = updated.RoomNumber;
            existing.Type = updated.Type;
            existing.IsAvailable = updated.IsAvailable;
            return true;
        }

        public bool Delete(int id)
        {
            var room = GetById(id);
            if (room == null) return false;

            rooms.Remove(room);
            return true;
        }

        public List<Room> GetAvailableRooms() =>
            rooms.Where(r => r.IsAvailable).ToList();
    }
}