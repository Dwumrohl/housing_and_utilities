using System;
using System.Collections.Generic;

namespace testBlazor.Data;

/// <summary>
/// Таблица Клиент - ТСЖ
/// </summary>
public partial class HaClient
{
    #region Поля

    /// <summary>
    /// ID ТСЖ
    /// </summary>
    public long? HaId { get; set; }

    /// <summary>
    /// ID клиента.
    /// </summary>
    public long? ClientId { get; set; }

    /// <summary>
    /// ID записи в таблице.
    /// </summary>
    public long HaClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual HomeownersAssociation? Ha { get; set; }

    #endregion
}
