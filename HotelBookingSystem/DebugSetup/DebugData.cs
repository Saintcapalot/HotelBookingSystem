using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.DebugSetup
{
    public static class DebugData
    {
        public static void SeedAll(
            ClientService clientService,
            GuestService guestService,
            RoomService roomService,
            RoomBookingService bookingService,
            HotelEventService eventService,
            MealService mealService)
        {
            foreach (var client in GetClients())
                clientService.Create(client);

            foreach (var guest in GetGuests())
                guestService.Create(guest);

            foreach (var room in GetRooms())
                roomService.Create(room);

            foreach (var booking in GetBookings())
                bookingService.Create(booking);

            foreach (var ev in GetEvents())
                eventService.Create(ev);

            foreach (var meal in GetMeals())
                mealService.Create(meal);

            Console.WriteLine("✅ Eksempeldata lagt til.");
        }

        public static List<Client> GetClients() => new()
        {
            new Client { Name = "Wayne Enterprises", BillingAddress = "Gotham", ContactPerson = "Lucius Fox", ContactNumber = "555-0198" },
            new Client { Name = "Daily Planet", BillingAddress = "Metropolis", ContactPerson = "Lois Lane", ContactNumber = "555-0123" }
        };

        public static List<Guest> GetGuests() => new()
        {
            new Guest { Name = "Clark Kent", ContactNumber = "555-0001", PreferredRoom = "201" },
            new Guest { Name = "Diana Prince", ContactNumber = "555-0002", PreferredRoom = "Suite 1" }
        };

        public static List<Room> GetRooms() => new()
        {
            new Room { RoomNumber = "101", Type = "Standard", IsAvailable = true },
            new Room { RoomNumber = "201", Type = "Deluxe", IsAvailable = true },
            new Room { RoomNumber = "301", Type = "Suite", IsAvailable = true }
        };

        public static List<RoomBooking> GetBookings() => new()
        {
            new RoomBooking(1, 1, 101, 1, DateTime.Today, DateTime.Today.AddDays(2)),
            new RoomBooking(2, 2, 201, 2, DateTime.Today.AddDays(1), DateTime.Today.AddDays(3))
        };

        public static List<HotelEvent> GetEvents() => new()
        {
            new HotelEvent(1, 1, 101, DateTime.Today, DateTime.Today.AddDays(1), TimeSpan.FromHours(10), TimeSpan.FromHours(16)),
            new HotelEvent(2, 2, 201, DateTime.Today, DateTime.Today.AddDays(2), TimeSpan.FromHours(9), TimeSpan.FromHours(12))
        };

        public static List<Meal> GetMeals() => new()
        {
            new Meal(1, "Frokost", 1, 101, 20, DateTime.Today, TimeSpan.FromHours(7), TimeSpan.FromHours(9), "Vegetar"),
            new Meal(2, "Lunsj", 2, 201, 30, DateTime.Today, TimeSpan.FromHours(12), TimeSpan.FromHours(13), "")
        };
    }
}
