namespace testBlazor.Data.services
{
    public class MeterReadingsService : IMeterReadingsService
    {

        private HousingAndUtilitiesAppContext _context;

        public MeterReadingsService(HousingAndUtilitiesAppContext context)
        {
            _context = context;
        }

        public MeterReading getMeterWithPreviousDataByClientIdAndMeterType(Guid? clientId, string? meterType, string? address)
        {
            try
            {
                return _context.MeterReadings.Where(p => p.ClientId == clientId).Where(d => d.Name == meterType).Where(a => a.ClientAddress == address).OrderByDescending(k => k.Date).First();
            }
            catch
            {
                return null;
            }
        }

        public bool insertMeters(List<MeterReading>? meters)
        {
            try
            {
                //foreach (MeterReading meter in meters)
                //{
                //    _context.MeterReadings.Add(meter);
                //}

                _context.MeterReadings.AddRange(meters);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        public List<MeterReading> getMeterReadingsByClientId(Guid? id)
        {
            try
            {
                return _context.MeterReadings.Where(p => p.ClientId == id).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
