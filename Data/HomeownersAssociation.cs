using System;
using System.Collections.Generic;

namespace testBlazor.Data;

/// <summary>
/// ТСЖ
/// </summary>
public partial class HomeownersAssociation
{
    #region 

    /// <summary>
    /// ID ТСЖ.
    /// </summary>
    public long HaId { get; set; }

    #warning а что это здесь делает?
    public long? ClientId { get; set; }

    /// <summary>
    /// Юридический адрес.
    /// </summary>
    public string? LegalAddress { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public char? PhoneNumber { get; set; }

    /// <summary>
    /// Навзвание.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Лист клиентов.
    /// </summary>
    public virtual ICollection<HaClient> HaClients { get; } = new List<HaClient>();

    #endregion
}
