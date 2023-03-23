using Microsoft.EntityFrameworkCore;

namespace testBlazor.Data.services
{
    /// <summary>
    /// Класс для взаимодействия с таблицей Клиент.
    /// </summary>
    public class ClientService : IClientService
    {
        /// <summary>
        /// Контекст БД.
        /// </summary>
        private HousingAndUtilitiesAppContext _context;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="context"> Контекст БД.</param>
        public ClientService(HousingAndUtilitiesAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Удаление клиента из таблицы.
        /// </summary>
        /// <param name="id"> ID клиента.</param>
        public bool deleteClient(long id)
        {
            try
            {
                Client client = _context.Clients.Find(id);
                _context.Clients.Remove(client);
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
        /// Возвращает лист клиентов.
        /// </summary>
        /// <returns> Лист клиентов.</returns>
        public List<Client> GetClients()
        {
            try
            {
                return _context.Clients.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return new List<Client>();
            }
        }

        /// <summary>
        /// Добавлет клиента в базы данных.
        /// </summary>
        /// <param name="client"> Клиент.</param>
        public bool insertClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
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
        /// Получает асинхронно клиента по email.
        /// </summary>
        /// <param name="email"> Электронная почта.</param>
        /// <returns>Клиента.</returns>
        public async Task<Client> SingleClient(string email)
        {
            try
            {
                Client client = await _context.Clients.FirstOrDefaultAsync(c => c.Email.Equals(email));
                return client;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Обновляет клиента.
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <param name="client">Клиент</param>
        public bool updateClient(long id, Client client)
        {
            try
            {
                var local = _context.Set<Client>().Local.FirstOrDefault(entry => entry.ClientId.Equals(client.ClientId));

                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(client).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Обновляет клиента по email.
        /// </summary>
        /// <param name="email"> Электронная почта.</param>
        /// <param name="client">Клиент.</param>
		public bool updateClientByEmail(string email, Client client)
		{
			try
			{
				var local = _context.Clients.First(entry => entry.Email.Equals(email));

				if (local != null)
				{
                    _context.Clients.Update(client);
                }
                else 
                {
                    _context.Clients.Add(client);
                }
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
        /// Получает клиента по email.
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns> Клиента.</returns>
        public Client getSingleClientByEmail(string email)
        {
            try
            {
                var local = _context.Clients.First(entry => entry.Email.Equals(email));
                return local;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }

        //Блять, что это 
        public async Task<bool> UpdateTest(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
