using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class ClientService
    {
        private readonly List<Client> clients = new();
        private int nextId = 1;

        public Client Create(Client client)
        {
            client.Id = nextId++;
            clients.Add(client);
            return client;
        }

        public List<Client> GetAll() => clients;

        public Client? GetById(int id) => clients.FirstOrDefault(c => c.Id == id);

        public bool Update(int id, Client updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.BillingAddress = updated.BillingAddress;
            existing.ContactPerson = updated.ContactPerson;
            existing.ContactNumber = updated.ContactNumber;
            return true;
        }

        public bool Delete(int id)
        {
            var client = GetById(id);
            if (client == null) return false;

            clients.Remove(client);
            return true;
        }
    }
}