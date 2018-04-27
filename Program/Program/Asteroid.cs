using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public class Asteroid
    {
        private Matrix matrix;
        private double timeStamp;

        public Asteroid(double timeStamp, Matrix matrix)
        {
            this.timeStamp = timeStamp;
            this.matrix = matrix;
        }
        
        public static List<Asteroid> ReadAsteriodsFromLines(List<string> lines)
        {
            List<Asteroid> asteroids = new List<Asteroid>();
            List<double> timeStamp = new List<double>();
            List<List<List<double>>> preMatrices = new List<List<List<double>>>();
            int count = Convert.ToInt32(lines.First());
            int currentAsteroid = 0;
            for (int i = 2; i < lines.Count; i++)
            {
                preMatrices.Add(new List<List<double>>());
                string[] split = lines[i-1].Split(' ');
                timeStamp.Add(Convert.ToDouble(split[0]));
                double rows = Convert.ToDouble(split[1]); 
                double columns = Convert.ToDouble(split[2]);
                for (int j = 0; j < rows; j++)
                {
                    string[] columnsStrings = lines[i].Split(' ');
                    preMatrices[currentAsteroid].Add(new List<double>());
                    for (int k = 0; k < columns; k++)
                    {
                        preMatrices[currentAsteroid][j].Add(Convert.ToDouble(columnsStrings[k]));
                    }
                    i++;
                }
                currentAsteroid++;
            }

            for (int i = 0; i < preMatrices.Count; i++)
            {
                asteroids.Add(new Asteroid(timeStamp[i] ,new Matrix(preMatrices[i])));
            }

            return asteroids;
        }

        public Matrix Matrix    
        {
            get => matrix;
            set => matrix = value;
        }

        public double TimeStamp    
        {
            get => timeStamp;
            set => timeStamp = value;
        }
    }
   
}