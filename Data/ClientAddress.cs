using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class ClientAddress
{
    public long ClientAddressId { get; set; }

    public long? ClientId { get; set; }

    public char? City { get; set; }

    public char? Street { get; set; }

    public char? House { get; set; }

    public int? Building { get; set; }

    public int? Apartment { get; set; }

    public virtual Client? Client { get; set; }
}
