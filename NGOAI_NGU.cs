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
    
    public partial class NGOAI_NGU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGOAI_NGU()
        {
            this.NV_NGOAI_NGU = new HashSet<NV_NGOAI_NGU>();
        }
    
        public string ma_ngoai_ngu { get; set; }
        public string ten_ngoai_ngu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NV_NGOAI_NGU> NV_NGOAI_NGU { get; set; }
    }
}