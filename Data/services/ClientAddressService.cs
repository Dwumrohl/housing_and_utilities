using Microsoft.EntityFrameworkCore;

namespace testBlazor.Data.services
{
    public class ClientAddressService : IClientAddressService
    {
        private HousingAndUtilitiesAppContext _context;

        public ClientAddressService(HousingAndUtilitiesAppContext context)
        {
            _context = context;
        }

        public void deleteClientAddress(long id)
        {
            try
            {
                ClientAddress ord = _context.ClientAddresses.Find(id);
                _context.ClientAddresses.Remove(ord);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ClientAddress> GetClientAddress()
        {
            try
            {
                return _context.ClientAddresses.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void insertClientAddress(ClientAddress address)
        {
            try
            {
                _context.ClientAddresses.Add(address);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void updateClientAddress(long id, ClientAddress address)
        {
            try
            {
                var local = _context.Set<ClientAddress>().Local.FirstOrDefault(entry => entry.ClientAddressId.Equals(address.ClientAddressId));
                // check if local is not null
                if (local != null)
                {
                    // detach
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(address).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public ClientAddress getSingleClientAddressById(long id)
        {
            try
            {
                var local = _context.ClientAddresses.First(entry => entry.ClientAddressId.Equals(id));
                return local;
            }
            catch
            {
                return null;
            }
        }
    }
}

