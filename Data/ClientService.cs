using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testBlazor.Data
{
    public class ClientService : IClientService
    {
        private HousingAndUtilitiesAppContext _context;

        public ClientService(HousingAndUtilitiesAppContext context)
        {
            _context = context;
        }

        public void deleteClient(long id)
        {
            try
            {
                Client ord = _context.Clients.Find(id);
                _context.Clients.Remove(ord);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Client> GetClients()
        {
            try
            {
                return _context.Clients.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void insertClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Client SingleClient(long id)
        {
            throw new NotImplementedException();
        }

        public void updateClient(long id, Client client)
        {
            try
            {
                var local = _context.Set<Client>().Local.FirstOrDefault(entry => entry.ClientId.Equals(client.ClientId));
                // check if local is not null
                if (local != null)
                {
                    // detach
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(client).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
