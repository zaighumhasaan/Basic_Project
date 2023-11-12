using System;
using System.Collections.Generic;

namespace Basic_Project.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public double Price { get; set; }

    public int ProductQnty { get; set; }

    public DateTime? MfgDate { get; set; }

    public DateTime? ExpDate { get; set; }

    public static implicit operator Product?(int? v)
    {
        throw new NotImplementedException();
    }
}
