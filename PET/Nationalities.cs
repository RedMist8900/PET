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
    
    public partial class Nationalities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nationalities()
        {
            this.Persons = new HashSet<Persons>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CountryCode { get; set; }
        public Nullable<int> CprNr { get; set; }
        public Nullable<int> PersonsID { get; set; }
        public Nullable<int> ZipCode { get; set; }
        public string StreetAdress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persons> Persons { get; set; }
    }
}
