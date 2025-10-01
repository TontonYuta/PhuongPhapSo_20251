namespace Da_thuc_noi_suy_Chebysev
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtXstar = new System.Windows.Forms.TextBox();
            this.btnCompute = new System.Windows.Forms.Button();
            this.btnEval = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.lblN = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblXstar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(20, 20);
            this.lblN.Text = "Số nút n:";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(100, 18);
            this.txtN.Size = new System.Drawing.Size(80, 23);
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(200, 20);
            this.lblA.Text = "a:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(230, 18);
            this.txtA.Size = new System.Drawing.Size(80, 23);
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(330, 20);
            this.lblB.Text = "b:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(360, 18);
            this.txtB.Size = new System.Drawing.Size(80, 23);
            // 
            // lblXstar
            // 
            this.lblXstar.AutoSize = true;
            this.lblXstar.Location = new System.Drawing.Point(460, 20);
            this.lblXstar.Text = "x*:";
            // 
            // txtXstar
            // 
            this.txtXstar.Location = new System.Drawing.Point(490, 18);
            this.txtXstar.Size = new System.Drawing.Size(80, 23);
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(600, 15);
            this.btnCompute.Size = new System.Drawing.Size(100, 28);
            this.btnCompute.Text = "Tính đa thức";
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // btnEval
            // 
            this.btnEval.Location = new System.Drawing.Point(720, 15);
            this.btnEval.Size = new System.Drawing.Size(100, 28);
            this.btnEval.Text = "Tính P(x*)";
            this.btnEval.Click += new System.EventHandler(this.btnEval_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                   | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(20, 60);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(800, 400);
            this.dgvResult.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblXstar);
            this.Controls.Add(this.txtXstar);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.btnEval);
            this.Controls.Add(this.dgvResult);
            this.Text = "Nội suy Chebyshev";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtXstar;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Button btnEval;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblXstar;
    }
}
