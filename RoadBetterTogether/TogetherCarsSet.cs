namespace RoadBetterTogether
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TogetherCarsSet")]
    public partial class TogetherCarsSet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "merci de renseigner une immatriculation") ]
        public string immatriculation { get; set; }

        [Required(ErrorMessage = "merci de renseigner une marque")]
        public string marque { get; set; }

        [Required(ErrorMessage = "merci de renseigner une annee")]
        public string annee { get; set; }

        public int? RoadTeamId { get; set; }

        public int places { get; set; }

        public int TogetherDrivers_Id { get; set; }

        public virtual TogetherUsersSet_TogetherDrivers TogetherUsersSet_TogetherDrivers { get; set; }
    }
}
