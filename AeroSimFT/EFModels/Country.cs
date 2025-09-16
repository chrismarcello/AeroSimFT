using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class Country
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Continent { get; set; }

    public string? WikipediaLink { get; set; }

    public string? Keywords { get; set; }

    public virtual ICollection<Airport> Airports { get; set; } = new List<Airport>();
}
