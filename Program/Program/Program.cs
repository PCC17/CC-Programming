using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace Program
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string name = "lvl3-0.inp";
            StreamWriter writer = new StreamWriter(name + "output");
            string[] lines = File.ReadAllLines(name);
            List<Asteroid> asteroidList = Asteroid.ReadAsteriodsFromLines(lines.ToList());
            for (int i = 0; i < asteroidList.Count; i+=2)
            {
                asteroidList[i + 1].Matrix.FieldsList.Reverse();
                asteroidList[i].Matrix.recalculateFields();
                asteroidList[i + 1].Matrix.recalculateFields();
                double sum = 0;
                for (int j = 0; j < asteroidList[i + 1].Matrix.FieldsList.Count; j++)
                {
                    for (int k = 0; k <  asteroidList[i + 1].Matrix.FieldsList[j].Count; k++)
                    {
                        if (asteroidList[i + 1].Matrix.FieldsList[j][k] == 1 &&
                            asteroidList[i].Matrix.FieldsList[j][k] == 1)
                        {
                            sum += asteroidList[i + 1].Matrix.max;
                        }
                        else
                        {
                            if(asteroidList[i + 1].Matrix.FieldsList[j][k] == 0)
                                sum += asteroidList[i].Matrix.max;
                            else
                                sum += asteroidList[i+1].Matrix.max;
                        }
                            
                    }
                    
                }
                
                writer.WriteLine(asteroidList[i].TimeStamp + " " + sum);
                Console.WriteLine(asteroidList[i].TimeStamp + " " + sum);
            }
            writer.Close();
        }
    }
}