using System;
using System.Collections.Generic;

namespace testBlazor.Data;

/// <summary>
/// Заявки.
/// </summary>
public partial class Request
{
    #region Поля

    /// <summary>
    /// ID заявки.
    /// </summary>
    public Guid RequestId { get; set; }

    /// <summary>
    /// Тип заявки.
    /// </summary>
    public int? RequestNumber { get; set; }

    /// <summary>
    /// Название заявки.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Дата заявки.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Адрес.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Комментарий.
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Статус.
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// Колекция записей таблицы Клиент - Заявка.
    /// </summary>
    public Guid? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    #endregion
}
