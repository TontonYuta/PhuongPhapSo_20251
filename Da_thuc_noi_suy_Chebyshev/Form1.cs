using Da_thuc_noi_suy_Chebysev;
using System;
using System.Windows.Forms;

namespace Da_thuc_noi_suy_Chebysev
{
    public partial class Form1 : Form
    {
        private int n;
        private double a, b;
        private double[] X, Y;

        public Form1()
        {
            InitializeComponent();

            dgvResult.Columns.Add("Key", "Thông tin");
            dgvResult.Columns.Add("Value", "Giá trị");
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                n = int.Parse(txtN.Text);
                a = double.Parse(txtA.Text);
                b = double.Parse(txtB.Text);

                // Tạo nút Chebyshev
                X = new double[n];
                Y = new double[n];
                for (int i = 0; i < n; i++)
                {
                    double xi = Math.Cos((2.0 * i + 1) / (2.0 * n) * Math.PI);
                    X[i] = 0.5 * ((b - a) * xi + (b + a));
                    Y[i] = F(X[i]);
                }

                string poly = ChebyshevInterpolation.LagrangePolynomial(X, Y);

                dgvResult.Rows.Clear();
                dgvResult.Rows.Add("Số nút", n);
                dgvResult.Rows.Add("Đoạn [a,b]", $"[{a}, {b}]");
                dgvResult.Rows.Add("Các nút Xi", string.Join(", ", X));
                dgvResult.Rows.Add("Giá trị Yi", string.Join(", ", Y));
                dgvResult.Rows.Add("Đa thức Lagrange (Chebyshev)", poly);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập dữ liệu: " + ex.Message);
            }
        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            try
            {
                if (X == null || Y == null)
                {
                    MessageBox.Show("Hãy tính đa thức trước.");
                    return;
                }

                double xstar = double.Parse(txtXstar.Text);
                double val = ChebyshevInterpolation.Interpolate(X, Y, xstar);
                dgvResult.Rows.Add($"P({xstar})", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Hàm f(x) cần nội suy
        private double F(double x)
        {
            return Math.Pow(x, 3) + Math.Pow(x, 2) + 1;
        }
    }
}
