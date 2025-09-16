using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AircraftManufacturer
{
    public string ManufacturerName { get; set; } = null!;

    public string? ManufacturerCountry { get; set; }

    public string ManufacturerGuid { get; set; } = null!;

    public virtual ICollection<AircraftModel> AircraftModels { get; set; } = new List<AircraftModel>();

    public virtual ICollection<AircraftType> AircraftTypes { get; set; } = new List<AircraftType>();
}
