using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MsStorageLocation
    {
        public string LocationId { get; set; } = null!;
        public string? LocationName { get; set; }
        public int Id { get; set; }
    }
}
