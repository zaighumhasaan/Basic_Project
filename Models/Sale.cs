using System;
using System.Collections.Generic;

namespace Basic_Project.Models;

public partial class Sale
{
    public int Id { get; set; }

    public string? SaleProduct { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public int? SaleQnty { get; set; }

    public double? Total { get; set; }
}
