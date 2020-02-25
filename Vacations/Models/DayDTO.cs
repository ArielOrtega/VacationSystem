using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vacations.Models
{
    public class DayDTO
    {

        public int dayId { get; set; }
        public System.DateTime day1 { get; set; }
        public int turn { get; set; }
        public String turnName { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public int RequestrequestId { get; set; }

        public virtual Request Request { get; set; }

    }
}