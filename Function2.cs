using System;

namespace Coursework
{
    internal class Function2
    {
        public Function2(double x, double a, double q)
        {
            X = x;
            A = a;
            Q = q;
        }
        public double Q { get; set; }
        public double X { get; set; }
        public double A { get; set; }

        public string Result { 
            get
            {
                string res = "";
                if (feasibleRegion(ref res))
                    return f().ToString();
                else
                    return res;
            }
        }

        public double f()
        {           
            return Math.Round( Math.Log(X) / (A - X), 3) ;
        }


        public bool feasibleRegion(ref string explanation)
        {
            if (X <= 0)
            {
                explanation = $"Х <= 0";
                return false;
            }
            if (Math.Abs(A - X) <= 0.000001)
            {
                explanation = "Ділення на 0";
                return false;
            }
            explanation = "";
            return true;
        }

    }
}
