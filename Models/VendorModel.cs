using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace POS1.Models
{
    [MetadataType(typeof(VendorMetadata))]
    public partial class Vendor
    {
        public string Action { get; set; }
        public string AccountName { get; set; }
        public string CompanyName { get; set; }
    }

    public class VendorMetadata
    {
        [Required()]
        [DisplayName("Vendor Name")]
        public string VName { get; set; }
        [Required()]
        [DisplayName("Contact Number")]
        public int VContactNumber { get; set; }
        public bool Active { get; set; }
        [Required()]
        [DisplayName("Date Created")]
        public System.DateTime CreatedDate { get; set; }
        [Required()]
        [DisplayName("Last Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime LastModified { get; set; }
        public string Remarks { get; set; }
        [Required()]
        [DisplayName("Company Id")]
        public int Companyid { get; set; }
         [Required()]
        [DisplayName("Account Id")]
        public int Accid { get; set; }
    
    }
}