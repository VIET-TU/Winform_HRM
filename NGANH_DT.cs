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
    
    public partial class NGANH_DT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGANH_DT()
        {
            this.QTDTs = new HashSet<QTDT>();
        }
    
        public string ma_nganh_dt { get; set; }
        public string ten_nganh_dt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QTDT> QTDTs { get; set; }
    }
}