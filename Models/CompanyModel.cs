using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace POS1.Models
{
    [MetadataType(typeof(CompanyMetadata))]
    public partial class Company
    {
public string Action { get; set; }
        internal void Foo()
        {
            throw new NotImplementedException();
        }
    }

    public class CompanyMetadata
    {
        [Required]
        [Display(Name = "Company Name", Description = "")]
        public string ComName { get; set; }
        [Required()]
        [DisplayName("Company Address")]
        public string ComAdd { get; set; }
        public bool Active { get; set; }
        [Required()]
        [DisplayName("Date Created")]
        public System.DateTime Createddate { get; set; }
        [Required()]
        [DisplayName("Last Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public System.DateTime LastModified { get; set; }
        

    }
}