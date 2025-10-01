namespace LagrangeInterpolationWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Button btnEval;
        private System.Windows.Forms.TextBox txtXstar;
        private System.Windows.Forms.Label lblXstar;
        private System.Windows.Forms.Panel panelBottom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnCompute = new System.Windows.Forms.Button();
            this.btnEval = new System.Windows.Forms.Button();
            this.txtXstar = new System.Windows.Forms.TextBox();
            this.lblXstar = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // dgvInput
            this.dgvInput.AllowUserToAddRows = true;
            this.dgvInput.AllowUserToDeleteRows = true;
            this.dgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvInput.Width = 300;
            this.dgvInput.Name = "dgvInput";

            // dgvResult
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Name = "dgvResult";

            // lblXstar
            this.lblXstar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.lblXstar.AutoSize = true;
            this.lblXstar.Location = new System.Drawing.Point(310, 295);
            this.lblXstar.Name = "lblXstar";
            this.lblXstar.Size = new System.Drawing.Size(24, 13);
            this.lblXstar.Text = "x*:";

            // txtXstar
            this.txtXstar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.txtXstar.Location = new System.Drawing.Point(340, 292);
            this.txtXstar.Name = "txtXstar";
            this.txtXstar.Size = new System.Drawing.Size(80, 20);

            // btnEval
            this.btnEval.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnEval.Location = new System.Drawing.Point(430, 290);
            this.btnEval.Name = "btnEval";
            this.btnEval.Size = new System.Drawing.Size(120, 25);
            this.btnEval.Text = "Tính P(x*)";
            this.btnEval.UseVisualStyleBackColor = true;
            this.btnEval.Click += new System.EventHandler(this.btnEval_Click);

            // panelBottom
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 50;
            this.panelBottom.Controls.Add(this.btnCompute);

            // btnCompute
            this.btnCompute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCompute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCompute.Location = new System.Drawing.Point(300, 10);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(200, 30);
            this.btnCompute.Text = "Tính đa thức Lagrange";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.lblXstar);
            this.Controls.Add(this.txtXstar);
            this.Controls.Add(this.btnEval);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.dgvInput);
            this.Controls.Add(this.panelBottom);
            this.Name = "Form1";
            this.Text = "Đa thức nội suy Lagrange";

            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
