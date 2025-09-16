using System;
using System.Collections.Generic;

namespace AeroSimFT.EFModels;

public partial class AcCategory
{
    public int AcCatId { get; set; }

    public int AcPcatId { get; set; }

    public string? AcCatName { get; set; }
}
