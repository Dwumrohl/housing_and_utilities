using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testBlazor.Data.services
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

        public async Task<Client> SingleClient(string email)
        {
            try
            {
                Client client = await _context.Clients.FirstOrDefaultAsync(c => c.Email.Equals(email));
                return client;
            }
            catch
            {
                return null;
            }
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

		public void updateClientByEmail(string email, Client client)
		{
			try
			{
				var local = _context.Clients.First(entry => entry.Email.Equals(email));
				// check if local is not null
				if (local != null)
				{
                    // detach
                    //_context.Entry(local).State = EntityState.Detached;
                    local.Password = client.Password;
                }
                else { _context.Clients.Add(client); }
                //local.Password = client.Password;
                //_context.Clients.Update(client);
                //_context.Entry(client).State = EntityState.Modified;
                _context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}

        public Client getSingleClientByEmail(string email)
        {
            try
            {
                var local = _context.Clients.First(entry => entry.Email.Equals(email));
                return local;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateTest(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
