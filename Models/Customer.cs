using System;
using System.Collections.Generic;

namespace CustomerApi.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte[]? MiddleName { get; set; }

    public decimal? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
