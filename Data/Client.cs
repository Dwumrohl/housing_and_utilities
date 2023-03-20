using System.ComponentModel.DataAnnotations;

namespace testBlazor.Data
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }
        public int phone_number { get; set; }
        public string? name { get; set; }
        [Required]
        public string? email { get; set; }
        public string? surname { get; set;}
        public string? patronymic { get; set; }
        public string? password { get; set; }
        public string? role { get; set; }
        public DateTime otp_requested_time { get; set; }


    }
}
