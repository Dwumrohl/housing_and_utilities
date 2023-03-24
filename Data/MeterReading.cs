using System;
using System.Collections.Generic;

namespace testBlazor.Data;
/// <summary>
/// Entity показания
/// </summary>
public partial class MeterReading
{
    #region Поля

    /// <summary>
    /// Id показания
    /// </summary>
    public Guid MeterReadingsId { get; set; }

    /// <summary>
    /// наименование показания
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Данные показателя
    /// </summary>
    public long? Data { get; set; }

    /// <summary>
    /// Дата подачи показания
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// внешний ключ id клиента
    /// </summary>
    public Guid? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    #endregion
}
