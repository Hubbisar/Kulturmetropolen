//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KMService
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCategory
    {
        public tblCategory()
        {
            this.tblEvent = new HashSet<tblEvent>();
        }
    
        public string Category { get; set; }
        public string MainCategory { get; set; }
    
        public virtual ICollection<tblEvent> tblEvent { get; set; }
    }
}
