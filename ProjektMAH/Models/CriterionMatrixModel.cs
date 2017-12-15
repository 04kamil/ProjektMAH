using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAH.Models
{
    public class CriterionMatrixModel
    {
        public double [,] matrix { get; set; }
        
        public CriterionMatrixModel(int size)
        {
            matrix = new double[size,size];

            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    matrix[i, j] = 0;

                }
            }
            for (int i = 0; i < size; i++)
                matrix[i, i] = 1;
        }
    }
}
