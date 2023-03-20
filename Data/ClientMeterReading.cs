using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class ClientMeterReading
{
    public long ClientMeterReadingsId { get; set; }

    public long? MeterReadingsId { get; set; }

    public long? ClientId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Client? Client { get; set; }

    public virtual MeterReading? MeterReadings { get; set; }
}
