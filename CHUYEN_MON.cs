//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRM_Desktop
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHUYEN_MON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUYEN_MON()
        {
            this.HSNVs = new HashSet<HSNV>();
        }
    
        public string ma_chuyen_mon { get; set; }
        public string ten_chuyen_mon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HSNV> HSNVs { get; set; }
    }
}
