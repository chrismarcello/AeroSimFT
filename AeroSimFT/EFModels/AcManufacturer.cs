using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AcManufacturer
{
    public int AcManId { get; set; }

    public int AcManPid { get; set; }

    public string? ManufacturerName { get; set; }

    public int AcManCountryId { get; set; }
}
