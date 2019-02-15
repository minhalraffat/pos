using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS1.Models
{
    [MetadataType(typeof(UnitMetadata))]
    public partial class Unit
    {
        public string Action { get; set; }
    }

    public class UnitMetadata
    {
        [Required()]
        [DisplayName("Unit Name")]
        public string UName { get; set; }
        public string Single { get; set; }
        public string Box { get; set; }
        public string Carton { get; set; }
        public bool Active { get; set; }
        [Required()]
        [DisplayName("Last Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime LastModified { get; set; }
        [Required()]
        [DisplayName("Date Created")]
        public System.DateTime Createddate { get; set; }
    }
}