namespace RoadBetterTogether
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkAdressSet")]
    public partial class WorkAdressSet
    {
        public int Id { get; set; }
    }
}
