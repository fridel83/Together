using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoadBetterTogether.ViewModels
{
    public class UserAutenticate
    {
        [Required(ErrorMessage ="merci de renseigner votre login")]
        [Display(Name ="login")]
        public string login { get; set; }
        [Required(ErrorMessage = "merci de renseigner votre mot de passe")]
        [Display(Name = "mot de passe")]
        public string mdp { get; set; }
        public bool isAuthenticate { get; set; }
    }
}