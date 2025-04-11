using System;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using HotelBookingSystem.Utilities;

namespace HotelBookingSystem
{
    public class MainMenu
    {
        private readonly ClientService clientService = new();
        private readonly GuestService guestService = new();
        private readonly RoomService roomService = new();
        private readonly RoomBookingService bookingService = new();
        private readonly HotelEventService eventService = new();
        private readonly MealService mealService = new();

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== HOTELLSYSTEM ===");
                Console.WriteLine("1. Registrer kunde");
                Console.WriteLine("2. Vis alle kunder");
                Console.WriteLine("3. Registrer gjest");
                Console.WriteLine("4. Vis alle gjester");
                Console.WriteLine("5. Legg til rom");
                Console.WriteLine("6. Vis alle rom");
                Console.WriteLine("7. Vis ledige rom");
                Console.WriteLine("8. Registrer booking");
                Console.WriteLine("9. Vis alle bookinger");
                Console.WriteLine("10. Opprett arrangement (event)");
                Console.WriteLine("11. Vis alle arrangementer");
                Console.WriteLine("12. Opprett måltid");
                Console.WriteLine("13. Vis alle måltider");
                Console.WriteLine("14. Rapport: Mest brukte rom");
                Console.WriteLine("15. Rapport: Mest lønnsomme kunde");
                Console.WriteLine("16. Fyll inn eksempeldata");
                Console.WriteLine("17. Sikkerhetskopier alle data");
                Console.WriteLine("18. Gjenopprett alle data");
                Console.WriteLine("0. Avslutt");
                Console.Write("\nDitt valg: ");
                string? choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        RegisterClient();
                        break;
                    case "2":
                        ListClients();
                        break;
                    case "3":
                        RegisterGuest();
                        break;
                    case "4":
                        ListGuests();
                        break;
                    case "5":
                        AddRoom();
                        break;
                    case "6":
                        ListAllRooms();
                        break;
                    case "7":
                        ListAvailableRooms();
                        break;
                    case "8":
                        RegisterBooking();
                        break;
                    case "9":
                        ListAllBookings();
                        break;
                    case "10":
                        RegisterEvent();
                        break;
                    case "11":
                        ListAllEvents();
                        break;
                    case "12":
                        RegisterMeal();
                        break;
                    case "13":
                        ListAllMeals();
                        break;
                    case "14":
                        ShowMostBookedRoom();
                        break;
                    case "15":
                        ShowTopPayingClient();
                        break;
                    case "16":
                        SeedDebugData();
                        break;
                    case "17":
                        BackupAll();
                        break;
                    case "18":
                        RestoreAll();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("❌ Ugyldig valg");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nTrykk en tast for å fortsette...");
                    Console.ReadKey();
                }
            }
        }

        private void RegisterClient()
        {
            Console.Write("Navn: ");
            var name = Console.ReadLine();

            Console.Write("Fakturaadresse: ");
            var address = Console.ReadLine();

            Console.Write("Kontaktperson: ");
            var contact = Console.ReadLine();

            Console.Write("Telefonnummer: ");
            var phone = Console.ReadLine();

            var client = new Client
            {
                Name = name ?? "",
                BillingAddress = address ?? "",
                ContactPerson = contact ?? "",
                ContactNumber = phone ?? ""
            };

            clientService.Create(client);
            Console.WriteLine("✅ Kunde registrert!");
        }

        private void ListClients()
        {
            var clients = clientService.GetAll();
            Console.WriteLine("--- REGISTRERTE KUNDER ---");

            if (clients.Count == 0)
            {
                Console.WriteLine("📭 Ingen kunder registrert ennå.");
            }
            else
            {
                foreach (var client in clients)
                {
                    Console.WriteLine(client);
                }
            }
        }
        
        private void RegisterGuest()
        {
            Console.Write("Navn: ");
            var name = Console.ReadLine();

            Console.Write("Telefonnummer: ");
            var phone = Console.ReadLine();

            Console.Write("Foretrukket rom: ");
            var preferredRoom = Console.ReadLine();

            var guest = new Guest
            {
                Name = name ?? "",
                ContactNumber = phone ?? "",
                PreferredRoom = preferredRoom ?? ""
            };

            guestService.Create(guest);
            Console.WriteLine("✅ Gjest registrert!");
        }

        private void ListGuests()
        {
            var guests = guestService.GetAll();

            Console.WriteLine("--- GJESTER ---");
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
        
        private void AddRoom()
        {
            Console.Write("Romnummer: ");
            var number = Console.ReadLine();

            Console.Write("Type (enkeltrom, dobbeltrom, suite osv.): ");
            var type = Console.ReadLine();

            var room = new Room
            {
                RoomNumber = number ?? "",
                Type = type ?? "",
                IsAvailable = true
            };

            roomService.Create(room);
            Console.WriteLine("✅ Rom lagt til.");
        }

        private void ListAllRooms()
        {
            var rooms = roomService.GetAll();
            Console.WriteLine("--- ALLE ROM ---");
            foreach (var room in rooms)
            {
                Console.WriteLine(room);
            }
        }

        private void ListAvailableRooms()
        {
            var available = roomService.GetAvailableRooms();
            Console.WriteLine("--- LEDIGE ROM ---");
            foreach (var room in available)
            {
                Console.WriteLine(room);
            }
        }
        
        private void RegisterBooking()
        {
            Console.Write("Kunde-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int clientId))
            {
                Console.WriteLine("❌ Ugyldig ID.");
                return;
            }

            Console.Write("Gjest-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int guestId))
            {
                Console.WriteLine("❌ Ugyldig ID.");
                return;
            }

            Console.Write("Rom-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roomId))
            {
                Console.WriteLine("❌ Ugyldig ID.");
                return;
            }

            Console.Write("Startdato (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                Console.WriteLine("❌ Ugyldig dato.");
                return;
            }

            Console.Write("Sluttdato (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                Console.WriteLine("❌ Ugyldig dato.");
                return;
            }

            var booking = new RoomBooking(0, clientId, roomId, guestId, startDate, endDate);
            bookingService.Create(booking);
            Console.WriteLine("✅ Booking registrert!");
        }
        
        private void ListAllBookings()
        {
            var bookings = bookingService.GetAll();

            if (bookings.Count == 0)
            {
                Console.WriteLine("📭 Ingen bookinger registrert.");
                return;
            }

            Console.WriteLine("--- BOOKINGER ---");
            foreach (var booking in bookings)
            {
                Console.WriteLine($"[{booking.BookingId}] Rom: {booking.RoomId}, Kunde-ID: {booking.ClientId}, Fra: {booking.StartDate:yyyy-MM-dd} Til: {booking.EndDate:yyyy-MM-dd}");
            }
        }
        
        private void RegisterEvent()
        {
            Console.Write("Kunde-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int clientId)) return;

            Console.Write("Rom-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roomId)) return;

            Console.Write("Startdato (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate)) return;

            Console.Write("Sluttdato (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate)) return;

            Console.Write("Starttid (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan startTime)) return;

            Console.Write("Sluttid (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan endTime)) return;

            var newEvent = new HotelEvent(0, clientId, roomId, startDate, endDate, startTime, endTime);
            eventService.Create(newEvent);
            Console.WriteLine("✅ Arrangement opprettet.");
        }

        private void ListAllEvents()
        {
            var events = eventService.GetAll();

            if (events.Count == 0)
            {
                Console.WriteLine("📭 Ingen arrangementer funnet.");
                return;
            }

            Console.WriteLine("--- ARRANGEMENTER ---");
            foreach (var e in events)
            {
                Console.WriteLine(e);
            }
        }
        
        private void RegisterMeal()
        {
            Console.Write("Navn på måltid: ");
            var name = Console.ReadLine();

            Console.Write("Kunde-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int clientId)) return;

            Console.Write("Rom-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roomId)) return;

            Console.Write("Antall deltakere: ");
            if (!int.TryParse(Console.ReadLine(), out int attendees)) return;

            Console.Write("Dato (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date)) return;

            Console.Write("Starttid (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan startTime)) return;

            Console.Write("Sluttid (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan endTime)) return;

            Console.Write("Kostholdsnotater: ");
            var notes = Console.ReadLine();

            var meal = new Meal(0, name ?? "", clientId, roomId, attendees, date, startTime, endTime, notes ?? "");
            mealService.Create(meal);
            Console.WriteLine("✅ Måltid opprettet.");
        }

        private void ListAllMeals()
        {
            var meals = mealService.GetAll();

            if (meals.Count == 0)
            {
                Console.WriteLine("📭 Ingen måltider registrert.");
                return;
            }

            Console.WriteLine("--- MÅLTIDER ---");
            foreach (var m in meals)
            {
                Console.WriteLine(m);
            }
        }
        
        private void SeedDebugData()
        {
            clientService.Create(new Client
            {
                Name = "Wayne Enterprises",
                BillingAddress = "Gotham City",
                ContactPerson = "Lucius Fox",
                ContactNumber = "555-0198"
            });

            guestService.Create(new Guest
            {
                Name = "Clark Kent",
                ContactNumber = "555-0001",
                PreferredRoom = "201"
            });

            roomService.Create(new Room
            {
                RoomNumber = "101",
                Type = "Standard",
                IsAvailable = true
            });

            bookingService.Create(new RoomBooking(0, 1, 1, 1, DateTime.Today, DateTime.Today.AddDays(2)));

            eventService.Create(new HotelEvent(0, 1, 1, DateTime.Today, DateTime.Today.AddDays(1), TimeSpan.FromHours(9), TimeSpan.FromHours(15)));

            mealService.Create(new Meal(0, "Frokost", 1, 1, 15, DateTime.Today, TimeSpan.FromHours(8), TimeSpan.FromHours(9), "Vegetar"));

            Console.WriteLine("✅ Eksempeldata fylt inn.");
        }
        
        private void BackupAll()
        {
            BackupManager.Backup(clientService.GetAll(), "clients.json");
            BackupManager.Backup(guestService.GetAll(), "guests.json");
            BackupManager.Backup(roomService.GetAll(), "rooms.json");
            BackupManager.Backup(bookingService.GetAll(), "bookings.json");
            BackupManager.Backup(eventService.GetAll(), "events.json");
            BackupManager.Backup(mealService.GetAll(), "meals.json");

            Console.WriteLine("✅ Alle data er sikkerhetskopiert.");
        }

        private void RestoreAll()
        {
            foreach (var client in BackupManager.Restore<Client>("clients.json"))
                clientService.Create(client);

            foreach (var guest in BackupManager.Restore<Guest>("guests.json"))
                guestService.Create(guest);

            foreach (var room in BackupManager.Restore<Room>("rooms.json"))
                roomService.Create(room);

            foreach (var booking in BackupManager.Restore<RoomBooking>("bookings.json"))
                bookingService.Create(booking);

            foreach (var evt in BackupManager.Restore<HotelEvent>("events.json"))
                eventService.Create(evt);

            foreach (var meal in BackupManager.Restore<Meal>("meals.json"))
                mealService.Create(meal);

            Console.WriteLine("✅ Alle data er gjenopprettet.");
        }
        
        private void ShowMostBookedRoom()
        {
            var bookings = bookingService.GetAll();
    
            if (!bookings.Any())
            {
                Console.WriteLine("📭 Ingen bookinger funnet.");
                return;
            }

            var mostUsedRoom = bookings
                .GroupBy(b => b.RoomId)
                .OrderByDescending(g => g.Count())
                .Select(g => new { RoomId = g.Key, Count = g.Count() })
                .First();

            Console.WriteLine($"🏨 Mest brukte rom: {mostUsedRoom.RoomId} ({mostUsedRoom.Count} bookinger)");
        }

        private void ShowTopPayingClient()
        {
            var bookings = bookingService.GetAll();
            const int pricePerNight = 1000;

            if (!bookings.Any())
            {
                Console.WriteLine("📭 Ingen bookinger funnet.");
                return;
            }

            var revenueByClient = bookings
                .GroupBy(b => b.ClientId)
                .Select(g => new
                {
                    ClientId = g.Key,
                    TotalNights = g.Sum(b => (b.EndDate - b.StartDate).Days),
                    Revenue = g.Sum(b => (b.EndDate - b.StartDate).Days * pricePerNight)
                })
                .OrderByDescending(c => c.Revenue)
                .First();

            Console.WriteLine($"💰 Mest lønnsomme kunde: ID {revenueByClient.ClientId} – {revenueByClient.TotalNights} netter – {revenueByClient.Revenue} kr i inntekt");
        }










    }
}
