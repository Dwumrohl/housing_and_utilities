using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testBlazor.Data;

public partial class Client
{
    [Key]
    public long ClientId { get; set; }

    public char? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public long? ClientAddressId { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime? OtpRequestedTime { get; set; }

    public virtual ICollection<ClientAddress> ClientAddresses { get; } = new List<ClientAddress>();

    public virtual ICollection<ClientMeterReading> ClientMeterReadings { get; } = new List<ClientMeterReading>();

    public virtual ICollection<HaClient> HaClients { get; } = new List<HaClient>();

    public virtual ICollection<RequestClient> RequestClients { get; } = new List<RequestClient>();
}
