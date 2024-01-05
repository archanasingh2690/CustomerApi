using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApi.Models;

public partial class Customer
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte[]? MiddleName { get; set; }

    public decimal? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }
}
