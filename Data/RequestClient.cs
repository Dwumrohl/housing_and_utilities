using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class RequestClient
{
    public long RequestClientId { get; set; }

    public long? RequestId { get; set; }

    public long? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Request? Request { get; set; }
}
