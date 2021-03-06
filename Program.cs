using System;

namespace LB_3_Coordinate_Descent
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] min = Optimize.minimize(func, 10, -10);
            for (int i = 0; i < min.Length; i++)
            {
                Console.WriteLine("x{0:F3} = {1:F3}", i + 1, min[i]);
            }
            Console.WriteLine("F min = {0:F3}", func(min));
        }

        static public double func(double[] vars)
        {
            return Math.Pow(vars[0], 4)
                + Math.Pow(vars[1], 4)
                + 2 * Math.Pow(vars[0], 2) * Math.Pow(vars[1], 2)
                + -4 * vars[0] + 3;

        }
    }
}
