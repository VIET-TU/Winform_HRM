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
    
    public partial class GIOI_TINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIOI_TINH()
        {
            this.HSNVs = new HashSet<HSNV>();
        }
    
        public string ma_gioi_tinh { get; set; }
        public string ten_gioi_tinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HSNV> HSNVs { get; set; }
    }
}
