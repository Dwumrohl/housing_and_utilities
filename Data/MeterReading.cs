using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class MeterReading
{
    public long MeterReadingsId { get; set; }

    public char? Name { get; set; }

    public long? Data { get; set; }

    public virtual ICollection<ClientMeterReading> ClientMeterReadings { get; } = new List<ClientMeterReading>();
}
