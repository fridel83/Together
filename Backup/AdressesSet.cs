namespace RoadBetterTogether
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdressesSet")]
    public partial class AdressesSet
    {
        public int Id { get; set; }

        [Required]
        public string rue { get; set; }

        public string Batiment { get; set; }

        [Required]
        public string code_postal { get; set; }

        [Required]
        public string ville { get; set; }

        public int numero { get; set; }

        public int TogetherUsersSet_Id { get; set; }

        public virtual AdressesSet_HomeAdress AdressesSet_HomeAdress { get; set; }

        public virtual TogetherUsersSet TogetherUsersSet { get; set; }

        public virtual AdressesSet_WorkAdress AdressesSet_WorkAdress { get; set; }
    }
}
