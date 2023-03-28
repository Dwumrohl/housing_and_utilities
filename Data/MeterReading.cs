using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace testBlazor.Data;
/// <summary>
/// Entity показания
/// </summary>
public partial class MeterReading
{
    public MeterReading()
    {

    }

    public MeterReading(string? name, long? data, DateTime? date, Guid? clientId, string? clientAddress, string? beforeData, Client? client)
    {
        Name = name;
        Data = data;
        Date = date;
        ClientId = clientId;
        ClientAddress = clientAddress;
        BeforeData = beforeData;
        Client = client;
    }



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

    public string? ClientAddress { get; set; }

    [NotMapped]
    public string? BeforeData { get; set; }

    public virtual Client? Client { get; set; }

    #endregion
}
