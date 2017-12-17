using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAH.Models
{
    public class CriterionModel
    {
        public String Name { get; set; }
        //public double Value { get; set; }
        //public int adress { get; set; }

        public CriterionModel(string _name)
        {
            Name = _name;
            //Value = 0;
        }
    }
}
