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
    
    public partial class Osoba
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Osoba()
        {
            this.Karta = new HashSet<Karta>();
        }
    
        public int Id { get; set; }
        public int Adres { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
    
        public virtual Adres Adres1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Karta> Karta { get; set; }
    }
}
