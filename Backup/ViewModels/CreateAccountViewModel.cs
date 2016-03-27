using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RoadBetterTogether.Models.ValidationForm;

namespace RoadBetterTogether.ViewModels
{
    public class CreateAccountViewModel
    {
        public TogetherUsersSet user { get; set; }
        public AdressesSet home { get; set; } 
        public AdressesSet work { get; set; } 
        //public TogetherCarsSet car { get; set; } 
    }
}