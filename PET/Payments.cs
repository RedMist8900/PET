//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PET
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payments()
        {
            this.Informants = new HashSet<Informants>();
        }
    
        public int Id { get; set; }
        public string PreferredPayment { get; set; }
        public Nullable<int> InformantsID { get; set; }
        public Nullable<int> ValutaID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informants> Informants { get; set; }
        public virtual Informants Informants1 { get; set; }
        public virtual Valutas Valutas { get; set; }
    }
}
