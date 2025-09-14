using System;
using System.Collections.Generic;

namespace CRUD_app.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? Sales { get; set; }
}
