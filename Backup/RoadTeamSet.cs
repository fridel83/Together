namespace RoadBetterTogether
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoadTeamSet")]
    public partial class RoadTeamSet
    {
        public int Id { get; set; }
    }
}
