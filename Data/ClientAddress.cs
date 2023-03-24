using System;
using System.Collections.Generic;

namespace testBlazor.Data;

/// <summary>
/// Адрес клиента.
/// </summary>
public partial class ClientAddress
{
    #region Поля

    /// <summary>
    /// ID записи в таблице.
    /// </summary>
    public Guid ClientAddressId { get; set; }

    /// <summary>
    /// ID клиента.
    /// </summary>
    public Guid? ClientId { get; set; }

    /// <summary>
    /// Город.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Улица.
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Дом.
    /// </summary>
    public string? House { get; set; }

    /// <summary>
    /// Подъезд.
    /// </summary>
    public int Building { get; set; }

    /// <summary>
    /// Квартира.
    /// </summary>
    public int? Apartment { get; set; }

    public virtual Client? Client { get; set; }

    #endregion
}
