using System;
using System.Windows.Forms;

namespace NewtonInterpolationWinForms
{
    public partial class Form1 : Form
    {
        private double[] X;
        private double[] Y;
        private double[,] table;

        public Form1()
        {
            InitializeComponent();

            dgvInput.Columns.Add("Y", "Y(i)");
            dgvResult.Columns.Add("Key", "Thông tin");
            dgvResult.Columns.Add("Value", "Giá trị");

            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                int n = dgvInput.Rows.Count - 1;
                Y = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Y[i] = double.Parse(dgvInput.Rows[i].Cells[0].Value.ToString());
                }

                double x0 = double.Parse(txtX0.Text);
                double h = double.Parse(txtH.Text);

                X = new double[n];
                for (int i = 0; i < n; i++) X[i] = x0 + i * h;

                table = NewtonForward.ForwardDifferences(Y);

                // Hiển thị bảng sai phân
                dgvTable.Columns.Clear();
                for (int j = 0; j < n; j++)
                {
                    dgvTable.Columns.Add($"col{j}", $"Δ^{j} y");
                }
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

                // In các sai phân Δy0, Δ²y0, ...
                for (int k = 1; k < n; k++)
                {
                    dgvResult.Rows.Add($"Δ^{k} y0", table[0, k]);
                }

                // In đa thức Newton tiến dạng p
                string polyStr = NewtonForward.ForwardPolynomial(X, Y);
                dgvResult.Rows.Add("Đa thức Newton tiến (dạng p)", polyStr);

                // In đa thức rút gọn
                string polyExpanded = NewtonForward.ExpandedPolynomial(X, Y);
                dgvResult.Rows.Add("Đa thức rút gọn", polyExpanded);


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
                double xstar = double.Parse(txtXstar.Text);
                double val = NewtonForward.Interpolate(X, Y, xstar);
                dgvResult.Rows.Add($"P({xstar})", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
