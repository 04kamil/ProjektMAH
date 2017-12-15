using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAH.Models
{
    public class AlternativeModel
    {
        public String Name { get; set; }
        public double Value { get; set; }

        public AlternativeModel(string _name)
        {
            Name = _name;
            Value = 0;
        }
    }
}
