using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class MeterReading
{
    public Guid MeterReadingsId { get; set; }

    public string? Name { get; set; }

    public long? Data { get; set; }

    public DateTime? Date { get; set; }

    public Guid? ClientId { get; set; }

    public virtual Client? Client { get; set; }
}
