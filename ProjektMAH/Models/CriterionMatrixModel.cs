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
        public List<CriterionPairModel> PairModel;
        public List<TranslateModel> TransLst = new List<TranslateModel>();
        
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

        public void SetUpPair(List<CriterionPairModel> PairModel_)
        {
            //PairModel = new List<CriterionPairModel>();
            PairModel = PairModel_;
        }

        public void CreateMatrix()
        {
            List<int> Xlst = new List<int>();
            List<int> YLst = new List<int>();
            foreach(var i in PairModel)
            {
            }

            
        }


        public CriterionMatrixModel(List<CriterionModel> lst)
        {
            int size = lst.Count();
            matrix = new double[size, size];
            for(int i =0;i<size;i++)
            {

            }

        }
    }
}
