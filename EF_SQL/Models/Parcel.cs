using System;
using System.Collections.Generic;

namespace EF_SQL.Models;

public partial class Parcel
{
    public Guid? Parcelid { get; set; }

    public string? Parcelname { get; set; }

    public string? Other { get; set; }
}
