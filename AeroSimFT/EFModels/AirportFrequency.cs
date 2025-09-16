using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AirportFrequency
{
    public int FreqId { get; set; }

    public int AirportId { get; set; }

    public string? AirportIdent { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public double? FrequencyMhz { get; set; }

    public virtual Airport Airport { get; set; } = null!;
}
