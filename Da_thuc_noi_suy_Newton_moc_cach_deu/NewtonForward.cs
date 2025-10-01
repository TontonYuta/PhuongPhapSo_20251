using System;
using System.Text;

namespace NewtonInterpolationWinForms
{
    public static class NewtonForward
    {
        // Lập bảng sai phân tiến
        public static double[,] ForwardDifferences(double[] Y)
        {
            int n = Y.Length;
            double[,] diff = new double[n, n];

            for (int i = 0; i < n; i++) diff[i, 0] = Y[i];

            for (int j = 1; j < n; j++)
                for (int i = 0; i < n - j; i++)
                    diff[i, j] = diff[i + 1, j - 1] - diff[i, j - 1];

            return diff;
        }

        // Đa thức Newton tiến dạng p
        public static string ForwardPolynomial(double[] X, double[] Y)
        {
            int n = Y.Length;
            double h = X[1] - X[0];
            double[,] diff = ForwardDifferences(Y);

            StringBuilder sb = new StringBuilder();
            sb.Append("P(x) = ");
            sb.Append($"{Y[0]}");

            for (int k = 1; k < n; k++)
            {
                sb.Append($" + ({diff[0, k]})");
                for (int j = 0; j < k; j++)
                {
                    sb.Append($" * (p - {j})");
                }
                sb.Append($"/{Factorial(k)}");
            }

            sb.Append($", với p = (x - {X[0]})/{h}");
            return sb.ToString();
        }

        // Đa thức Newton tiến sau khi rút gọn thành a0 + a1*x + ...
        public static string ExpandedPolynomial(double[] X, double[] Y)
        {
            int n = Y.Length;
            double h = X[1] - X[0];
            double[,] diff = ForwardDifferences(Y);

            double[] poly = new double[n]; // hệ số theo x^i
            poly[0] = Y[0];

            for (int k = 1; k < n; k++)
            {
                double[] term = new double[n];
                term[0] = 1; // bắt đầu từ 1

                // nhân (p - j) lần lượt
                for (int j = 0; j < k; j++)
                {
                    double[] next = new double[n];
                    for (int m = 0; m < n - 1; m++)
                    {
                        if (Math.Abs(term[m]) > 1e-12)
                        {
                            next[m] -= term[m] * j; // nhân với -j
                            next[m + 1] += term[m]; // nhân với p
                        }
                    }
                    term = next;
                }

                // nhân hệ số Δ^k y0 / k!
                double coeff = diff[0, k] / Factorial(k);
                for (int m = 0; m < n; m++)
                    poly[m] += coeff * term[m] * Math.Pow(1.0 / h, m);
                // nhân thêm (1/h)^m để đổi từ p -> x
            }

            return PolyToString(poly);
        }

        // Tính giá trị nội suy Newton tiến
        public static double Interpolate(double[] X, double[] Y, double x)
        {
            int n = X.Length;
            double h = X[1] - X[0];
            double[,] diff = ForwardDifferences(Y);

            double p = (x - X[0]) / h;
            double result = Y[0];
            double term = 1.0;

            for (int k = 1; k < n; k++)
            {
                term *= (p - (k - 1)) / k;
                result += term * diff[0, k];
            }
            return result;
        }

        private static int Factorial(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; i++) f *= i;
            return f;
        }

        private static string PolyToString(double[] poly)
        {
            var sb = new StringBuilder();
            for (int i = poly.Length - 1; i >= 0; i--)
            {
                if (Math.Abs(poly[i]) < 1e-10) continue;

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
