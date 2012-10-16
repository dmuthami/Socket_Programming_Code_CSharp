using System;
//using System.Collections.Generic;
using System.Text;

namespace DefaultNamespace
{
    class Calculations
    {
        public Calculations()
        {
        }

        public double CalculateDistace(Position pointOne, Position pointTwo)
        {
            double A = radian(pointOne.X);
            double B = radian(pointOne.Y);
            double C = radian(pointTwo.X);
            double D = radian(pointTwo.Y);

            double dist = 0;
            if ((A == C) && (B == D))
            {
                dist = 0;
            }
            else
            {
                if ((Math.Sin(A) * Math.Sin(C)) + (Math.Cos(A) * Math.Cos(C) * Math.Cos(B - D)) > 1)
                {
                    dist = 6367 * Math.Acos(1);
                }
                else
                {
                    dist = 6367 * Math.Acos((Math.Sin(A) * Math.Sin(C)) + (Math.Cos(A) * Math.Cos(C) * Math.Cos(B - D)));
                }
                //double conversion = (double)8.0/(double)5.0;
                //dist = (dist * conversion);

            }
            return dist;
        }

        private double radian(double Value)
        {
            double rad = 0;
            rad = Value / (180 / (22 / 7));
            return rad;
        }
    }
}
