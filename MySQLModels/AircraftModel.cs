using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AircraftModel
{
    public string AircraftModelId { get; set; } = null!;

    public string? AircraftFamily { get; set; }

    public string? EngineModels { get; set; }

    public string? AircraftName { get; set; }

    public string? Tags { get; set; }

    public string? Url { get; set; }

    public string? AircraftType { get; set; }

    public int? EngineCount { get; set; }

    public string? NativeName { get; set; }

    public string? PropertyValues { get; set; }

    public string? EngineFamily { get; set; }

    public string? Manufacturer { get; set; }

    public virtual AircraftType? AircraftTypeNavigation { get; set; }

    public virtual AircraftManufacturer? ManufacturerNavigation { get; set; }
}
