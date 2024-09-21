using System;
using System.Collections.Generic;

namespace DatabaseFirst;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Photo { get; set; }
}
