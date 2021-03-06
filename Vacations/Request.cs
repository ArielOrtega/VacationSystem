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
    using Vacations.Models;
    
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            this.Day = new HashSet<Day>();
            this.VacationInfo = new HashSet<VacationInfo>();
        }

        public List<DateModel> days { get; set; }
        public int requestId { get; set; }
        public string state { get; set; }
        public string description { get; set; }
        public int daysRequestedCount { get; set; }
        public int midDaysCount { get; set; }
        public int PersonpersonaId { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Day> Day { get; set; }
        public virtual Person1 Person1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VacationInfo> VacationInfo { get; set; }
    }
}
