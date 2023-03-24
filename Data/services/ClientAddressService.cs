using Microsoft.EntityFrameworkCore;

namespace testBlazor.Data.services
{
    /// <summary>
    /// Класс для взаимодействия с таблицей адрес клиента.
    /// </summary>
    public class ClientAddressService : IClientAddressService
    {
        /// <summary>
        /// Контекс БД.
        /// </summary>
        private HousingAndUtilitiesAppContext _context;

        #region Методы

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="context"> Констекст базы данных.</param>
        public ClientAddressService(HousingAndUtilitiesAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Удаляет запись из таблицы адрес клиента.
        /// </summary>
        /// <param name="id"> ID записи.</param>
        public bool deleteClientAddress(Guid id)
        {
            try
            {
                ClientAddress clientAddressRecord = _context.ClientAddresses.Find(id);
                _context.ClientAddresses.Remove(clientAddressRecord);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Возвращает все адреса клиента.
        /// </summary>
        /// <param name="id"> ID клиента.</param>
        /// <returns> Лист адресов клиента.</returns>
        public List<ClientAddress> GetClientAddress(Guid id)
        {
            try
            {
                return _context.ClientAddresses.Where(p => p.ClientId == id).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Добавлет запись в таблицу адрес клинета.
        /// </summary>
        /// <param name="address"> Адрес.</param>
        public bool insertClientAddress(ClientAddress address)
        {
            try
            {
                _context.ClientAddresses.Add(address);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Обновляет запись в таблице адрес клиента.
        /// </summary>
        /// <param name="id"> ID клиента.</param>
        /// <param name="address"> Адрес.</param>
        public bool updateClientAddress(Guid id, ClientAddress address)
        {
            try
            {
                var local = _context.Set<ClientAddress>().Local.FirstOrDefault(entry => entry.ClientAddressId.Equals(address.ClientAddressId));

                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(address).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Возвращет запись из таблицы адрес клиента.
        /// </summary>
        /// <param name="id"> ID записи.</param>
        /// <returns> Запись из таблицы Клиент - Адрес.</returns>
        public ClientAddress getSingleClientAddressById(Guid id)
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

        #endregion
    }
}

