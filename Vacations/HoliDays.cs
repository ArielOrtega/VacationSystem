//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vacations
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoliDays
    {
        public int holiDaysId { get; set; }
        public byte isObligatory { get; set; }
        public System.DateTime date { get; set; }
        public byte isPaid { get; set; }
        public System.DateTime cratedAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public Nullable<System.DateTime> DayDay { get; set; }
    
        public virtual Day Day { get; set; }
    }
}