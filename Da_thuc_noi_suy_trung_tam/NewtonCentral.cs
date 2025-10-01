using System;
using System.Text;
using System.Collections.Generic;

namespace NewtonCentralWinForms   // ⚠️ phải trùng với namespace trong Form1.cs
{
    public static class NewtonCentral
    {
        // Lập bảng sai phân trung tâm (thực chất là bảng sai phân tiến)
        public static double[,] CentralDifferences(double[] Y)
        {
            int n = Y.Length;
            double[,] diff = new double[n, n];
            for (int i = 0; i < n; i++) diff[i, 0] = Y[i];

            for (int j = 1; j < n; j++)
                for (int i = 0; i < n - j; i++)
                    diff[i, j] = diff[i + 1, j - 1] - diff[i, j - 1];

            return diff;
        }

        // Công thức Stirling dạng symbolic
        public static string StirlingPolynomial(double[] X, double[] Y)
        {
            int n = Y.Length;
            double h = X[1] - X[0];
            int m = n / 2;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("P(x) = y_m");
            sb.AppendLine("+ u * (Δy_m + Δy_(m-1))/2");
            sb.AppendLine("+ u^2/2! * Δ²y_(m-1)");
            sb.AppendLine("+ u(u² - 1)/3! * (Δ³y_(m-1) + Δ³y_(m-2))/2");
            sb.AppendLine("+ u²(u² - 1)/4! * Δ⁴y_(m-2) + ...");
            sb.AppendLine($"Trong đó: u = (x - {X[m]})/{h}, m = {m}");
            return sb.ToString();
        }

        // Đa thức rút gọn dạng a0 + a1*x + a2*x^2 + ...
        public static string ExpandedPolynomial(double[] X, double[] Y)
        {
            int n = Y.Length;
            double h = X[1] - X[0];
            double[,] diff = CentralDifferences(Y);
            int m = n / 2;
            double xm = X[m];                 // tâm

            double[] poly = new double[n + 1]; // hệ số theo x^i
            poly[0] = Y[m];

            // term1: u * (Δy_m + Δy_(m-1))/2
            double coeff1 = (diff[m, 1] + diff[m - 1, 1]) / 2.0;
            AddTerm(poly, new double[] { 0, 1 }, coeff1, xm, h);

            // term2: u^2/2! * Δ²y_(m-1)
            double coeff2 = diff[m - 1, 2] / 2.0;
            AddTerm(poly, new double[] { 0, 0, 1 }, coeff2, xm, h);

            // term3: (u^3 - u) * ((Δ³y_(m-1)+Δ³y_(m-2))/12)
            double coeff3 = (diff[m - 1, 3] + diff[m - 2, 3]) / 12.0;
            AddTerm(poly, new double[] { 0, -1, 0, 1 }, coeff3, xm, h);

            // term4: (u^4 - u^2) * (Δ⁴y_(m-2)/24)
            double coeff4 = diff[m - 2, 4] / 24.0;
            AddTerm(poly, new double[] { 0, 0, -1, 0, 1 }, coeff4, xm, h);

            return PolyToString(poly);
        }

        // Tính giá trị nội suy Stirling tại x*
        public static double Interpolate(double[] X, double[] Y, double x)
        {
            int n = Y.Length;
            if (n < 5)
                throw new ArgumentException("Stirling cần ít nhất 5 điểm dữ liệu.");

            double h = X[1] - X[0];
            double[,] diff = CentralDifferences(Y);
            int m = n / 2;

            double u = (x - X[m]) / h;
            double result = Y[m];

            // Bậc 1
            result += u * (diff[m, 1] + diff[m - 1, 1]) / 2.0;
            // Bậc 2
            result += (u * u / 2.0) * diff[m - 1, 2];
            // Bậc 3
            result += (u * (u * u - 1) / 6.0) * (diff[m - 1, 3] + diff[m - 2, 3]) / 2.0;
            // Bậc 4
            result += (u * u * (u * u - 1) / 24.0) * diff[m - 2, 4];

            return result;
        }

        // ================== Các hàm hỗ trợ ==================
        private static void AddTerm(double[] poly, double[] uPoly, double coeff, double xm, double h)
        {
            int maxDeg = uPoly.Length - 1;
            for (int k = 0; k <= maxDeg; k++)
            {
                if (Math.Abs(uPoly[k]) < 1e-12) continue;
                double c = coeff * uPoly[k];

                // ( (x - xm) / h )^k = (1/h^k) * (x - xm)^k
                double[] expanded = BinomialExpand(-xm, 1.0, k);
                for (int i = 0; i < expanded.Length; i++)
                {
                    poly[i] += c * expanded[i] / Math.Pow(h, k);
                }
            }
        }

        private static double[] BinomialExpand(double a, double b, int k)
        {
            double[] coeffs = new double[k + 1];
            for (int i = 0; i <= k; i++)
            {
                coeffs[i] = Binomial(k, i) * Math.Pow(a, k - i) * Math.Pow(b, i);
            }
            return coeffs;
        }

        private static int Binomial(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            int res = 1;
            for (int i = 1; i <= k; i++)
            {
                res = res * (n - i + 1) / i;
            }
            return res;
        }

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
                if (i == 0) sb.Append(c.ToString("0.###"));
                else if (i == 1) sb.Append(c == 1 ? "x" : $"{c:0.###}*x");
                else sb.Append(c == 1 ? $"x^{i}" : $"{c:0.###}*x^{i}");
            }
            return sb.Length > 0 ? sb.ToString() : "0";
        }
    }
}
