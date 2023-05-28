using System;

namespace Coursework
{
    internal class Function1
    {
        public Function1(double x, double q)
        {
            X = x;
            Q = q;
        }
        
        public double X { get; set; }
        public double Q { get; set; }

        public double Result {
            get
            {
                if ((Q* Math.Sin(X)) < 0)
                {
                   return (Math.Pow((Q* Math.Sin(X)) * -1, 1 / 3.0) * -1);
                }
                else
                {
                   return Math.Pow((Q* Math.Sin(X)), 1 / 3.0) ;
                }  
            }            
        }       
    }
}
