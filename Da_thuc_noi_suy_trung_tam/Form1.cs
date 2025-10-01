using System;
using System.Windows.Forms;

namespace NewtonCentralWinForms
{
    public partial class Form1 : Form
    {
        private double[] X;
        private double[] Y;
        private double[,] table;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                int n = dgvInput.Rows.Count - 1;
                Y = new double[n];
                for (int i = 0; i < n; i++)
                    Y[i] = double.Parse(dgvInput.Rows[i].Cells[0].Value.ToString());

                double x0 = double.Parse(txtX0.Text);
                double h = double.Parse(txtH.Text);

                X = new double[n];
                for (int i = 0; i < n; i++) X[i] = x0 + i * h;

                table = NewtonCentral.CentralDifferences(Y);

                // Hiển thị bảng sai phân
                dgvTable.Columns.Clear();
                for (int j = 0; j < n; j++)
                    dgvTable.Columns.Add($"col{j}", $"Δ^{j} y");

                dgvTable.Rows.Clear();
                for (int i = 0; i < n; i++)
                {
                    object[] row = new object[n];
                    for (int j = 0; j < n - i; j++)
                        row[j] = table[i, j];
                    dgvTable.Rows.Add(row);
                }

                dgvResult.Rows.Clear();
                dgvResult.Rows.Add("x0", x0);
                dgvResult.Rows.Add("h", h);

                // Đa thức Stirling dạng công thức
                string polyStr = NewtonCentral.StirlingPolynomial(X, Y);
                dgvResult.Rows.Add("Đa thức Stirling (công thức)", polyStr);

                // Đa thức rút gọn
                string expanded = NewtonCentral.ExpandedPolynomial(X, Y);
                dgvResult.Rows.Add("Đa thức rút gọn", expanded);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập: " + ex.Message);
            }
        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            try
            {
                if (Y == null || X == null)
                {
                    MessageBox.Show("Hãy nhập dữ liệu và bấm 'Tính bảng' trước.");
                    return;
                }

                if (Y.Length < 5)
                {
                    MessageBox.Show("Không đủ điểm để dùng nội suy Stirling (cần ít nhất 5 điểm).");
                    return;
                }

                double xstar = double.Parse(txtXstar.Text);
                double val = NewtonCentral.Interpolate(X, Y, xstar);
                dgvResult.Rows.Add($"P({xstar})", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
