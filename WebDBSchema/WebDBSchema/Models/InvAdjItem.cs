//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDBSchema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvAdjItem
    {
        public int Id { get; set; }
        public int InvAdjHdrId { get; set; }
        public int InvItemId { get; set; }
        public int InvUomId { get; set; }
        public string QtyAdded { get; set; }
        public string QtyDeduct { get; set; }
    
        public virtual InvAdjHdr InvAdjHdr { get; set; }
        public virtual InvItem InvItem { get; set; }
        public virtual InvUom InvUom { get; set; }
    }
}
