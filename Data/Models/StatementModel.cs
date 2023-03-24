namespace testBlazor.Data.Models
{
    /// <summary>
    /// Модель для формы отправки заявки
    /// </summary>
    public class StatementModel
    {
        public string? street { get; set; }
        public string? building { get; set; }
        public string? house { get; set; }
        public string? apartment { get; set; }
        public string? surname { get; set; }
        public string? name { get; set; }
        public string? patronymic { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? comment { get; set; }

    }
}
