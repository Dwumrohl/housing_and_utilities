namespace testBlazor.Data.services
{
    /// <summary>
    /// Сервис для работы с заявкой
    /// </summary>
    public class RequestService : IRequestService
    {
        /// <summary>
        /// Контекст БД.
        /// </summary>
        private HousingAndUtilitiesAppContext _context;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="context"> Контекст БД.</param>
        public RequestService(HousingAndUtilitiesAppContext context)
        {
            _context = context;
        }

        public bool deleteRequestById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Request> getRequestsByClientId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Request getSingleRequestById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool insertRequest(Request request)
        {
            try
            {
                _context.Requests.Add(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        public bool updateRequestById(Guid id, ClientAddress request)
        {
            throw new NotImplementedException();
        }
    }
}
