using System;
using System.Windows.Forms;

namespace LagrangeInterpolationWinForms
{
    public partial class Form1 : Form
    {
        private double[] X;
        private double[] Y;

        public Form1()
        {
            InitializeComponent();

            dgvInput.Columns.Add("X", "X(i)");
            dgvInput.Columns.Add("Y", "Y(i)");

            dgvResult.Columns.Add("Key", "Thông tin");
            dgvResult.Columns.Add("Value", "Giá trị");

            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                int n = dgvInput.Rows.Count - 1;
                X = new double[n];
                Y = new double[n];

                for (int i = 0; i < n; i++)
                {
                    X[i] = double.Parse(dgvInput.Rows[i].Cells[0].Value.ToString());
                    Y[i] = double.Parse(dgvInput.Rows[i].Cells[1].Value.ToString());
                }

                dgvResult.Rows.Clear();
                dgvResult.Rows.Add("Đa thức Lagrange (công thức)", LagrangeInterpolation.Polynomial(X, Y));
                dgvResult.Rows.Add("Đa thức rút gọn", LagrangeInterpolation.ExpandedPolynomial(X, Y));

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
                double xstar = double.Parse(txtXstar.Text);
                double val = LagrangeInterpolation.Interpolate(X, Y, xstar);
                dgvResult.Rows.Add($"P({xstar})", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
