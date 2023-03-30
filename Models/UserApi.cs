using System;
using System.Collections.Generic;

namespace ApiReverseEngineering.Models;

public partial class UserApi
{
    public Guid UserId { get; set; }

    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int ClientId { get; set; }
}
