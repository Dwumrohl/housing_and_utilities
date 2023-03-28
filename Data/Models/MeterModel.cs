namespace testBlazor.Data.Models
{
    /// <summary>
    /// Класс для отправки показаний
    /// </summary>
    public class MeterModel
    {
        List<MeterReading>? meterReading { get; set; }
        public string? street { get; set; }
        public string? building { get; set; }
        public string? house { get; set; }
        public string? apartment { get; set; }
    }
}
