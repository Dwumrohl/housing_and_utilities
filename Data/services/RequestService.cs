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

        /// <summary>
        /// удаление заявки по id
        /// </summary>      
        public bool deleteRequestById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Поиск заявок по id клиента
        /// </summary>  
        public List<Request> getRequestsByClientId(Guid id)
        {
            try
            {
                return _context.Requests.Where(p => p.ClientId == id).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Получение заявки по ее id
        /// </summary>  
        public Request getSingleRequestById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  добавление заявки
        /// </summary>  
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

        /// <summary>
        /// Обновление заявки по id
        /// </summary>  
        public bool updateRequestById(Guid id, Request request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// получение номера последней созданной заявки ( не id)
        /// </summary>  
        public int? getHighestRequestNumber()
        {
            int? highestNumber = 0;
            try
            {
                highestNumber = _context.Requests.Max(r => r.RequestNumber);
            }catch (Exception ex) { Console.WriteLine($"{ex.Message}"); }
            return highestNumber;
        }
    }
}
