﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAH.Models
{
    public class CriterionMatrix
    {
        private double[,] Matrix = new double[0, 0];
        private List<string> Names = new List<string>();
        private List<int> Adress = new List<int>();
        private List<double> WartościKryteriow = new List<double>();
        private double Sum { get; set; }



        public void AddCriterion(string name)
        {
            Names.Add(name);
            Adress.Add(Adress.Count);//może.... sie przyda
            Matrix = new double[Names.Count, Names.Count];
        }

        public void SetValue(string nameX, string nameY, double value)
        {
            int x = Names.IndexOf(nameX);
            int y = Names.IndexOf(nameY);
            Matrix[x, y] = value;
            Matrix[y, x] = 1 / value;

            for(int i=0;i<Names.Count;i++)
            {
                Matrix[i, i] = 1;
            }
        }
        public bool Check()
        {
            for(int i=0;i<Names.Count;i++)
            {
                for (int j = 0; j < Names.Count; j++)
                    if (Matrix[i, j] == 0)
                        return false;
            }
            return true;
        }

        public void WyliczWartosci()
        {
            WartościKryteriow = new List<double>();
            for(int i =0;i< Names.Count;i++)
            {
                double sum=0;
                for(int x=0;x< Names.Count; x++)
                {
                    sum = sum + Matrix[i, x];
                }
                WartościKryteriow.Add(Math.Pow(sum, 1.0 / Names.Count));
            }

            Sum = WartościKryteriow.Sum();

            double testValue = 0;
            for(int i =0;i<WartościKryteriow.Count;i++)
            {
                testValue = testValue + (WartościKryteriow[i] / Sum)*Names.Count;
            }
        }


    }
}
