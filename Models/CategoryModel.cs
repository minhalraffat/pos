using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS1.Models
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {
        public string Action { get; set; }
    }

    public class CategoryMetadata
    {   
        [Required()]
        [DisplayName("Category Name")]
        public string CName { get; set; }
        [Required()]
        [DisplayName("Description")]
        public string CDes { get; set; }
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