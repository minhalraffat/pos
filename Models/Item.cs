//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int Iid { get; set; }
        public string IName { get; set; }
        public int Quantity { get; set; }
        public int brandid { get; set; }
        public int unitid { get; set; }
        public bool Active { get; set; }
        public System.DateTime Createddate { get; set; }
        public System.DateTime LastModified { get; set; }
        public string Genericformula { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
