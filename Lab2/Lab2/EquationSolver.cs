using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class EquationSolver
    {
        public static double[] SolveLinear(double k, double b)
        {
            double[] sol = new double[1];
            sol[0] = -b / k;
            return sol;
        }

        public static double[] SolveQuadratic(double a, double b, double c)
        {

            double disc = b * b - 4 * a * c;

            if (disc > 0)
            {
                double[] sol = new double[2];
                double r1 = (-b + Math.Sqrt(disc)) / (2 * a);
                double r2 = (-b - Math.Sqrt(disc)) / (2 * a);
                sol[0] = r1;
                sol[1] = r2;
                return sol;

            }
            else if (disc == 0)
            {
                double[] sol = new double[1];
                double r = -b / (2 * a);
                sol[0] = r;
                return sol;
            }
            else
            {
                double[] sol = new double[0];
                return sol;
            }
        }
    }
}
