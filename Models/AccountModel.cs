using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS1.Models
{
    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
        public string Action { get; set; }
    }

    public class AccountMetadata
    {   
        [Required()]
        [DisplayName("Account Name")]
        public string AccName { get; set; }

        [Required()]
        [DisplayName("Account Number")]
        public int AccNum { get; set; }
        [Required()]
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
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