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
        static double dx = 0.05;

        public delegate double dfunction(double[] vars);
        static dfunction func;
       public static double[] minimize(dfunction function, params double[] vars)
        {
            func = function;
            double min = function(vars);
            bool minf = false;

            while (!minf)
            {
                for (
                    int i = 0; i < vars.Length; i++)
                {
                    if((i == 0 || minf == true) && dFunc(vars, i) + e >= 0)
                    {
                        minf = true;
                        continue;
                    }
                   
                    while (dFunc(vars, i) + e < 0)
                    {
                        vars[i] += dx;
                       
                    }
                    
                }
            }
            return vars;
        }

        static double dFunc(double[] vars, int i)
        {
            double[] dVars = new double[vars.Length];
            Array.Copy(vars, dVars, vars.Length);
            dVars[i] += dx;
            return (func(dVars) - func(vars)) / dx;
        }
    }
}
