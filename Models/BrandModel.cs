using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace POS1.Models
{
    [MetadataType(typeof(BrandMetadata))]
    public partial class Brand
    {
        public string Action { get; set; }
    }

    public class BrandMetadata
    {
        [Required()]
        [Display(Name = "Brand Name", Description = "")]
        public string BName { get; set; }
        [Required()]
        [DisplayName("Description")]
        public string BDesc { get; set; }
        [Required()]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [Required()]
        [DisplayName("Category Id")]
        public int Categoryid { get; set; }

        public bool Active { get; set; }
        [Required()]
        [DisplayName("Date Created")]
        public System.DateTime Createddate { get; set; }
        [Required()]
        [DisplayName("Last Modified")]
        public System.DateTime LastModified { get; set; }

        public virtual Category Category { get; set; }
    
    }
}