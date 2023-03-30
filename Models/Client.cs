using System;
using System.Collections.Generic;

namespace ApiReverseEngineering.Models;

public partial class Client
{
    public Guid ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
