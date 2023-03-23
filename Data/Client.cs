using System.ComponentModel.DataAnnotations;

namespace testBlazor.Data;

/// <summary>
/// Клиент.
/// </summary>
public partial class Client
{
    #region Поля
    /// <summary>
    /// ID клиента.
    /// </summary>
    [Key]
    public long ClientId { get; set; }

    /// <summary>
    /// Номер телефона клиента.
    /// </summary>
    public char? PhoneNumber { get; set; }

    /// <summary>
    /// Электронная почта клиента.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Имя клиента.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Фамилия клиента.
    /// </summary>
    public string? Surname { get; set; }

    /// <summary>
    /// Отчество клиента.
    /// </summary>
    public string? Patronymic { get; set; }

    #warning Что это за залупа? Нахуй она нужна, если у клиента может быть несколько адресов?
    /// <summary>
    /// Id адреса клиента.
    /// </summary>
    public long? ClientAddressId { get; set; }

    /// <summary>
    /// Пароль клиента.
    /// </summary>
    public string? Password { get; set; }

    #warning Может удалить эту хуйню? Это же обрубок спринга
    public string? Role { get; set; }

    /// <summary>
    /// Дата последнего запроса пароля.
    /// </summary>
    public DateTime? OtpRequestedTime { get; set; }
    #endregion

    public virtual ICollection<ClientAddress> ClientAddresses { get; } = new List<ClientAddress>();

    public virtual ICollection<ClientMeterReading> ClientMeterReadings { get; } = new List<ClientMeterReading>();

    public virtual ICollection<HaClient> HaClients { get; } = new List<HaClient>();

    public virtual ICollection<RequestClient> RequestClients { get; } = new List<RequestClient>();

    #region Методы

    /// <summary>
    /// Проверяет заполненность данных клиента.
    /// </summary>
    /// <returns></returns>
    public bool isEmpty()
    {
        if(Name == null &&  Surname == null && Patronymic == null)
        {
            return true;
        }
        return false;
    }
    #endregion
}
