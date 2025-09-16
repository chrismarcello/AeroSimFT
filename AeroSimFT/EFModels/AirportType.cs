using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AirportType
{
    public int TypeId { get; set; }

    public string AirportTypeTitle { get; set; } = null!;

    public string? OrigTypeName { get; set; }

    public virtual ICollection<Airport> Airports { get; set; } = new List<Airport>();
}
