//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AI2_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adres()
        {
            this.Osoba = new HashSet<Osoba>();
        }
    
        public int Id { get; set; }
        public string Miejscowość { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Ulica { get; set; }
        public int Nr_domu { get; set; }
        public Nullable<int> Nr_lokalu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Osoba> Osoba { get; set; }
    }
}
