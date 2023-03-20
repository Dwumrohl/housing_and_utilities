using System;
using System.Collections.Generic;

namespace testBlazor.Data;

public partial class HaClient
{
    public long? HaId { get; set; }

    public long? ClientId { get; set; }

    public long HaClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual HomeownersAssociation? Ha { get; set; }
}
