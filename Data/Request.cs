using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class Request
{
    public long RequestId { get; set; }

    public int? Type { get; set; }

    public string? Name { get; set; }

    public DateOnly? Date { get; set; }

    public string? Address { get; set; }

    public string? Comment { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<RequestClient> RequestClients { get; } = new List<RequestClient>();
}
