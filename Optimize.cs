using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_3_Coordinate_Descent
{
    class Optimize
    {
        static double e = 0.01;

        public delegate double dfunction(double[] vars);
        static dfunction func;
        public static double[] minimize(dfunction function, params double[] x)
        {
            func = function;
            double A;
            double B = function(x);
            int i = -1;
            int pointNum = 1;
            do
            {
                A = B;
                i = (i + 1) % x.Length;

                dichotomy(x, i);

                B = func(x);
                Console.WriteLine(String.Format("M{0} = ({1:F2}; {2:F2}), F = {3:F2}",
                   pointNum, x[0], x[1], B));
                pointNum++;

            } while (Math.Abs(A - B) > e);

            return x;
        }


        static double dichotomy(double[] vars, int i)
        { 
            double[] aVars = new double[vars.Length];
            Array.Copy(vars, aVars, vars.Length);

            double[] bVars = new double[vars.Length];
            Array.Copy(vars, bVars, vars.Length);

            double a = vars[i] - 100;
            double b = vars[i] + 100;
            
            while(Math.Abs(b - a) > e)
            {
                aVars[i] = vars[i] - e;
                bVars[i] = vars[i] + e;
                if(func(aVars) < func(bVars))
                {
                    b = vars[i];
                    
                } else
                {
                    a = vars[i];
                }
                vars[i] = (a + b) / 2;
            }

            return vars[i];
        }
    }
}
