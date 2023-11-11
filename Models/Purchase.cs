using System;
using System.Collections.Generic;

namespace Basic_Project.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public string PurchaseProduct { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public int? PurchaseQnty { get; set; }

    public DateTime? ProductMdfDate { get; set; }

    public DateTime? ProductExpDate { get; set; }

    public double? Price { get; set; }
}
