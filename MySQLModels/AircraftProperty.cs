using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AircraftProperty
{
    public string PropertyId { get; set; } = null!;

    public string? Unit { get; set; }

    public string? PropertyType { get; set; }

    public string? PropertyName { get; set; }

    public string? Description { get; set; }
}
