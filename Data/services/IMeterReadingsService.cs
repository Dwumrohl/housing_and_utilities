namespace testBlazor.Data.services
{
    public interface IMeterReadingsService
    {
        MeterReading getMeterWithPreviousDataByClientIdAndMeterType(Guid? clientId, string? meterType);

        public bool insertMeters(List<MeterReading> meters);

        public List<MeterReading> getMeterReadingsByClientId(Guid? id);
    }
}
