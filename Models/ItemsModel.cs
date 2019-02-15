using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace POS1.Models
{
    [MetadataType(typeof(ItemMetadata))]
    public partial class Item
    {
        public string Action { get; set; }
    }

    public class ItemMetadata
    {
        [Required()]
        [DisplayName("Item Name")]
        public string IName { get; set; }
        [Required()]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [Required()]
        [DisplayName("Brand Id")]
        public int brandid { get; set; }
        [Required()]
        [DisplayName("Unit Id")]
        public int unitid { get; set; }
        public bool Active { get; set; }
        [Required()]
        [DisplayName("Date Created")]
        public System.DateTime Createddate { get; set; }
        [Required()]
        [DisplayName("Last Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public System.DateTime LastModified { get; set; }
        
        [DisplayName("Generic Formula")]
        public string Genericformula { get; set; }
    
    }
}