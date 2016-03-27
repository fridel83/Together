using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace RoadBetterTogether.Models.ValidationForm
{
    public class IsPasswordOk : ValidationAttribute , IClientValidatable 
    {
        public string pass1 { get; set; }
        public string pass2 { get; set; }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ValidationType = "verifmail";
            rule.ErrorMessage = FormatErrorMessage(metadata.DisplayName);
            rule.ValidationParameters.Add("password1", pass1);
            rule.ValidationParameters.Add("password2", pass2);
            return new List<ModelClientValidationRule> { rule }; 
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo propertyInfo1 = validationContext.ObjectType.GetProperty(this.pass1);
            PropertyInfo propertyInfo2 = validationContext.ObjectType.GetProperty(this.pass2);
            object otherPorpertiesValues = propertyInfo1.GetMethod.Invoke(validationContext.ObjectInstance, null);
            if (!(otherPorpertiesValues is string))
                throw new NotSupportedException("la propriéte de comparaison doit etre une chaine");

            string passValue = (string)propertyInfo1.GetValue(validationContext.ObjectInstance);
            string passValue2 = (string)propertyInfo2.GetValue(validationContext.ObjectInstance);
            if (passValue != passValue2)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;


        }
    }
}