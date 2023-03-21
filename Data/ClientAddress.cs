using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class ClientAddress
{
    public long ClientAddressId { get; set; }

    public long? ClientId { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public int Building { get; set; }

    public int? Apartment { get; set; }

    public virtual Client? Client { get; set; }
}
