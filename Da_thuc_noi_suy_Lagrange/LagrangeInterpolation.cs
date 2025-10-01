using System;
using System.Text;

namespace LagrangeInterpolationWinForms
{
    public static class LagrangeInterpolation
    {
        // Tính giá trị nội suy tại x*
        public static double Interpolate(double[] X, double[] Y, double x)
        {
            int n = X.Length;
            double result = 0;

            for (int i = 0; i < n; i++)
            {
                double term = Y[i];
                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    term *= (x - X[j]) / (X[i] - X[j]);
                }
                result += term;
            }

            return result;
        }

        // In đa thức dạng công thức Lagrange (chưa rút gọn)
        public static string Polynomial(double[] X, double[] Y)
        {
            int n = X.Length;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("P(x) = ");

            for (int i = 0; i < n; i++)
            {
                sb.Append($"{Y[i]} * [");

                bool first = true;
                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    if (!first) sb.Append(" * ");
                    sb.Append($"(x - {X[j]})/({X[i]} - {X[j]})");
                    first = false;
                }

                sb.Append("]");
                if (i < n - 1) sb.AppendLine(" + ");
            }

            return sb.ToString();
        }

        // Rút gọn đa thức Lagrange về dạng chuẩn a0 + a1*x + ...
        public static string ExpandedPolynomial(double[] X, double[] Y)
        {
            int n = X.Length;
            double[] poly = new double[n]; // hệ số theo x^i

            for (int i = 0; i < n; i++)
            {
                // L_i(x) = ∏ (x - X[j])/(X[i] - X[j])
                double[] Li = { 1.0 };

                double denom = 1.0;
                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    denom *= (X[i] - X[j]);
                    Li = MultiplyPoly(Li, new double[] { -X[j], 1 }); // nhân (x - X[j])
                }

                for (int k = 0; k < Li.Length; k++)
                {
                    poly[k] += Y[i] * Li[k] / denom;
                }
            }

            return PolyToString(poly);
        }

        // Nhân 2 đa thức
        private static double[] MultiplyPoly(double[] A, double[] B)
        {
            double[] res = new double[A.Length + B.Length - 1];
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < B.Length; j++)
                    res[i + j] += A[i] * B[j];
            return res;
        }

        // In đa thức
        private static string PolyToString(double[] poly)
        {
            var sb = new StringBuilder();
            for (int i = poly.Length - 1; i >= 0; i--)
            {
                if (Math.Abs(poly[i]) < 1e-9) continue;

                if (sb.Length > 0)
                    sb.Append(poly[i] >= 0 ? " + " : " - ");
                else if (poly[i] < 0)
                    sb.Append("-");

                double c = Math.Abs(poly[i]);
                if (i == 0) sb.Append(c);
                else if (i == 1) sb.Append($"{c}*x");
                else sb.Append($"{c}*x^{i}");
            }
            return sb.Length > 0 ? sb.ToString() : "0";
        }
    }
}
