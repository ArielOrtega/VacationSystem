using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vacations.Models
{
    public class TurnModel
    {
        public TurnModel()
        {
        }
        public int id { get; set; }
        public string label { get; set; }
        public bool isChecked { get; set; }
    }
}