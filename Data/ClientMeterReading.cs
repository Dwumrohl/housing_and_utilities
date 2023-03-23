using System;
using System.Collections.Generic;

namespace testBlazor.Data;

    #warning а нахуя это в принципе существует?
/// <summary>
/// Показания счетчика клиента.
/// </summary>
public partial class ClientMeterReading
{
    #region Поля
    public long ClientMeterReadingsId { get; set; }

    public long? MeterReadingsId { get; set; }

    public long? ClientId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Client? Client { get; set; }

    public virtual MeterReading? MeterReadings { get; set; }

    #endregion
}
