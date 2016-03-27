namespace RoadBetterTogether
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompagnySiteSet")]
    public partial class CompagnySiteSet
    {
        public int Id { get; set; }

        public int TogetherCompagnyId { get; set; }

        [Required]
        public string adresse { get; set; }

        public virtual TogetherCompagnySet TogetherCompagnySet { get; set; }
    }
}
