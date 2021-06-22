using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microservico_Crud.Domain
{
    public class Case : IValidatableObject
    {

        public Case()
        {
            this.DateRegistration = DateTime.Now;
        }

        public int? Id { get; set; }        
                
        [Required(ErrorMessage ="{0} required")]
        public string CaseNumber { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string CourtName { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string ResponsibleName { get; set; }

        public DateTime? DateRegistration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex regex = new Regex("[0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][.][0-9][0-9][0-9][0-9].[0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]", RegexOptions.IgnoreCase);
            if(!regex.IsMatch(CaseNumber))
            {
                yield return new ValidationResult(
               $"The Format of Case Number is invalid");
            }
            
        }
    }
}
