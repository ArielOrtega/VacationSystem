using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vacations.Models
{
    public class RequestModel
    {

        public class Request
        {
            public int requestId { get; set; }

            [Required(ErrorMessage = "State must be specified")]
            public string state { get; set; }

            [Required(ErrorMessage = "Description must be specified")]
            public string description { get; set; }


            public int daysRequestedCount { get; set; }
            public int midDaysCount { get; set; }
            public int PersonpersonaId { get; set; }
            public System.DateTime createdAt { get; set; }
            public System.DateTime updatedAt { get; set; }
            public int createdBy { get; set; }
            public int updatedBy { get; set; }

        }
    }
}