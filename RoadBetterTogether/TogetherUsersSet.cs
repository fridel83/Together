namespace RoadBetterTogether
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TogetherUsersSet")]
    public partial class TogetherUsersSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TogetherUsersSet()
        {
            AdressesSet = new HashSet<AdressesSet>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Merci de renseigner votre prénom")]
        [Display(Name = "Prénom")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Merci de renseigner votre nom")]
        [Display(Name = "nom")]
        public string name { get; set; }

        public int age { get; set; }

        [Required(ErrorMessage = "Merci de renseigner votre adresse mail")]
        [Display(Name = "email")]
        [RegularExpression(@"^[^\W][a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\@[a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\.[a-zA-Z]{2,4}$")]
        public string email { get; set; }

        public bool goingMode { get; set; }

        public int TogetherDriversId { get; set; }

        [Required(ErrorMessage = "Merci de renseigner votre login de connexion")]
        [Display(Name = "login")]
        public string login { get; set; }

        [Required(ErrorMessage = "Merci de renseigner votre mot de passe")]
        [Display(Name = "mot de passe")]
        public string password { get; set; }

        public bool actif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdressesSet> AdressesSet { get; set; }

        public virtual TogetherUsersSet_TogetherDrivers TogetherUsersSet_TogetherDrivers { get; set; }
    }
}
