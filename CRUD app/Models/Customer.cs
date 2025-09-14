using System;
using System.Collections.Generic;

namespace CRUD_app.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? Country { get; set; }

    public int? Score { get; set; }
}
