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
    
    public partial class Wypozyczenia
    {
        public int Id { get; set; }
        public Nullable<int> Pracownik { get; set; }
        public int Wypożyczający { get; set; }
        public int Książka { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> Data_rezerwacji { get; set; }
        public Nullable<System.DateTime> Data_wypożyczenia { get; set; }
        public Nullable<System.DateTime> Termin_Zwrotu { get; set; }
        public Nullable<int> Wysokość_kary { get; set; }
    
        public virtual Karta Karta { get; set; }
        public virtual Karta Karta1 { get; set; }
        public virtual Ksiazki Ksiazki { get; set; }
        public virtual Status Status1 { get; set; }
    }
}
