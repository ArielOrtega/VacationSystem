using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vacations.Models
{
    public class RequestDTO
    {
        public RequestDTO()
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
        public string personName { get; set; }
        public string departmentName { get; set; }
        public List<DayDTO> requestDays { get; set;  }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Day> Day { get; set; }
        public virtual Person1 Person1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VacationInfo> VacationInfo { get; set; }

    }
}