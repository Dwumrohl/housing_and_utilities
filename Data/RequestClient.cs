using System;
using System.Collections.Generic;

namespace testBlazor.Data;

/// <summary>
/// Таблица Заявка - Клиент.
/// </summary>
public partial class RequestClient
{
    #region Поля

    /// <summary>
    /// Id записи в таблице Заявка - Клиент.
    /// </summary>
    public long RequestClientId { get; set; }

    /// <summary>
    /// ID заявки.
    /// </summary>
    public long? RequestId { get; set; }

    /// <summary>
    /// ID клиента.
    /// </summary>
    public long? ClientId { get; set; }

    /// <summary>
    /// Клиент.
    /// </summary>
    public virtual Client? Client { get; set; }

    /// <summary>
    /// Заявка.
    /// </summary>
    public virtual Request? Request { get; set; }

    #endregion
}
