using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAH.Models
{
    public class AlternativeMatrix2
    {
        public string Kryteria { get; set; }
        public AlternativeMatrix Matrix = new AlternativeMatrix();

        public void SetUp(string n,AlternativeMatrix A)
        {
            Kryteria = n;
            Matrix = A;
        }

    }
}
