using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AircraftEngine
{
    public int EngineId { get; set; }

    public string EngineName { get; set; } = null!;

    public string? EngineFamily { get; set; }

    public int? ManufacturerId { get; set; }

    public string? Guid { get; set; }
}
