using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class HomeownersAssociation
{
    public long HaId { get; set; }

    public long? ClientId { get; set; }

    public string? LegalAddress { get; set; }

    public char? PhoneNumber { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<HaClient> HaClients { get; } = new List<HaClient>();
}
