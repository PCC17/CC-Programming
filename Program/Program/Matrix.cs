using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public class Matrix
    {
        private List<List<double>> fieldsList;
        public double max;
        public Matrix(List<List<double>> fieldsList)
        {
            this.fieldsList = fieldsList;
        }

        public List<List<double>> FieldsList    
        {
            get => fieldsList;
            set => fieldsList = value;
        }

        public double SumOfFields()
        {
            double sum = 0;
            foreach (var row in fieldsList)
            {
                foreach (var column in row)
                {
                    sum += column;
                }
            }
            return sum;
        }

        public int getNumberOfCoveredFields()
        {
            int sum = 0;
            foreach (var row in fieldsList)
            {
                foreach (var column in row)
                {
                    if (column != 0)
                        sum++;
                }
            }
            return sum;
        }
        
        public int getNearestFields()
        {
            double minValue = -1;
            int sum = 0;
            foreach (var row in fieldsList)
            {
                foreach (var column in row)
                {
                    if (minValue == -1 && column != 0)
                        minValue = column;
                    if (column < minValue && column != 0)
                        minValue = column;
                }
            }
            
            foreach (var row in fieldsList)
            {
                foreach (var column in row)
                {
                    if (column == minValue)
                        sum++;
                }
            }
            return sum;
        }
        
        public void recalculateFields()
        {
            double minValue = -1;
            max = 0;
            foreach (var row in fieldsList)
            {
                foreach (var column in row)
                {
                    if (minValue == -1 && column != 0)
                        minValue = column;
                    if (column < minValue && column != 0)
                        minValue = column;
                    if (column >= max)
                        max = column;
                }
            }

            max -= minValue;

            for (int i = 0; i < fieldsList.Count; i++)
            {
                for (int j = 0; j < fieldsList[i].Count; j++)
                {
                    if (fieldsList[i][j] != 0)
                        fieldsList[i][j] = fieldsList[i][j] - minValue + 1;
                }
            }
            
        }
    }
}