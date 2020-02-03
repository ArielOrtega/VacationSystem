using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vacations.Models
{
    public class DateModel
    {
        public DateModel()
        {
            turn = new List<Turn>();
            turn.Add(new Turn()
            {
                id = 1,
                label = "Morning",
                isChecked = false //On the add view, no genres are selected by default
            });
            turn.Add(new Turn()
            {
                id = 2,
                label = "Afternoon",
                isChecked = false //On the add view, no genres are selected by default
            });

        }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime date { get; set; }
        public List<Turn> turn { get; set; }//1 morning, 2 afternoon, 3 complete day

    }
}
