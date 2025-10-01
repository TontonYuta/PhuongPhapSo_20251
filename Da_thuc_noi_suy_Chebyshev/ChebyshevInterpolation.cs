using System;
using System.Text;

namespace Da_thuc_noi_suy_Chebysev
{
    public static class ChebyshevInterpolation
    {
        // Lagrange đa thức nội suy
        public static string LagrangePolynomial(double[] X, double[] Y)
        {
            int n = X.Length;
            StringBuilder sb = new StringBuilder();
            sb.Append("P(x) = ");

            for (int i = 0; i < n; i++)
            {
                if (i > 0) sb.Append(" + ");
                sb.Append($"({Y[i]})");
                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    sb.Append($" * (x - {X[j]})/({X[i]} - {X[j]})");
                }
            }
            return sb.ToString();
        }

        // Tính giá trị P(x*) bằng công thức Lagrange
        public static double Interpolate(double[] X, double[] Y, double x)
        {
            int n = X.Length;
            double result = 0.0;

            for (int i = 0; i < n; i++)
            {
                double term = Y[i];
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                        term *= (x - X[j]) / (X[i] - X[j]);
                }
                result += term;
            }
            return result;
        }
    }
}
