//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoadBetterTogether
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdressesSet
    {
        public int Id { get; set; }
        public string rue { get; set; }
        public string Batiment { get; set; }
        public string code_postal { get; set; }
        public string ville { get; set; }
        public int numero { get; set; }
        public int TogetherUsersSet_Id { get; set; }
    
        public virtual AdressesSet_HomeAdress AdressesSet_HomeAdress { get; set; }
        public virtual TogetherUsersSet TogetherUsersSet { get; set; }
        public virtual AdressesSet_WorkAdress AdressesSet_WorkAdress { get; set; }
    }
}
