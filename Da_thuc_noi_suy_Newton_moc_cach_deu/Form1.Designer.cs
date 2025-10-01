namespace NewtonInterpolationWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtXstar;
        private System.Windows.Forms.Button btnEval;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnCompute = new System.Windows.Forms.Button();
            this.txtX0 = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtXstar = new System.Windows.Forms.TextBox();
            this.btnEval = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInput
            // 
            this.dgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInput.RowTemplate.Height = 24;
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.RowTemplate.Height = 24;
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.RowTemplate.Height = 24;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCompute);
            this.panelBottom.Controls.Add(this.txtX0);
            this.panelBottom.Controls.Add(this.txtH);
            this.panelBottom.Controls.Add(this.txtXstar);
            this.panelBottom.Controls.Add(this.btnEval);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(10, 10);
            this.btnCompute.Size = new System.Drawing.Size(120, 30);
            this.btnCompute.Text = "Tính nội suy";
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // txtX0
            // 
            this.txtX0.Location = new System.Drawing.Point(150, 14);
            this.txtX0.Size = new System.Drawing.Size(60, 22);
            this.txtX0.Text = "0";
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(220, 14);
            this.txtH.Size = new System.Drawing.Size(60, 22);
            this.txtH.Text = "1";
            // 
            // txtXstar
            // 
            this.txtXstar.Location = new System.Drawing.Point(290, 14);
            this.txtXstar.Size = new System.Drawing.Size(60, 22);
            this.txtXstar.Text = "3";
            // 
            // btnEval
            // 
            this.btnEval.Location = new System.Drawing.Point(360, 10);
            this.btnEval.Size = new System.Drawing.Size(120, 30);
            this.btnEval.Text = "Tính P(x*)";
            this.btnEval.Click += new System.EventHandler(this.btnEval_Click);
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayout.RowCount = 3;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Controls.Add(this.dgvInput, 0, 0);
            this.tableLayout.Controls.Add(this.dgvTable, 1, 0);
            this.tableLayout.Controls.Add(this.dgvResult, 0, 1);
            this.tableLayout.SetColumnSpan(this.dgvResult, 2);
            this.tableLayout.Controls.Add(this.panelBottom, 0, 2);
            this.tableLayout.SetColumnSpan(this.panelBottom, 2);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tableLayout);
            this.Text = "Newton Forward Interpolation (x0, h, y(i))";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
