namespace EMMAutoMaterialOrderer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonReadEMM = new System.Windows.Forms.Button();
            this.buttonWriteEMM = new System.Windows.Forms.Button();
            this.buttonReadBasisPmx = new System.Windows.Forms.Button();
            this.buttonReadTargetPMX = new System.Windows.Forms.Button();
            this.listBoxOrderObj = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxReadEMM = new System.Windows.Forms.TextBox();
            this.textBoxReadBasisPmx = new System.Windows.Forms.TextBox();
            this.textBoxReadTargetPMX = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReadEMM
            // 
            this.buttonReadEMM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadEMM.Location = new System.Drawing.Point(5, 7);
            this.buttonReadEMM.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.buttonReadEMM.Name = "buttonReadEMM";
            this.buttonReadEMM.Size = new System.Drawing.Size(419, 86);
            this.buttonReadEMM.TabIndex = 0;
            this.buttonReadEMM.Text = "EMMファイルを読込";
            this.buttonReadEMM.UseVisualStyleBackColor = true;
            this.buttonReadEMM.Click += new System.EventHandler(this.buttonReadEMM_Click);
            // 
            // buttonWriteEMM
            // 
            this.buttonWriteEMM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteEMM.Location = new System.Drawing.Point(434, 507);
            this.buttonWriteEMM.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.buttonWriteEMM.Name = "buttonWriteEMM";
            this.buttonWriteEMM.Size = new System.Drawing.Size(825, 86);
            this.buttonWriteEMM.TabIndex = 0;
            this.buttonWriteEMM.Text = "EMMファイルを書込";
            this.buttonWriteEMM.UseVisualStyleBackColor = true;
            this.buttonWriteEMM.Click += new System.EventHandler(this.buttonWriteEMM_Click);
            // 
            // buttonReadBasisPmx
            // 
            this.buttonReadBasisPmx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadBasisPmx.Location = new System.Drawing.Point(434, 107);
            this.buttonReadBasisPmx.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.buttonReadBasisPmx.Name = "buttonReadBasisPmx";
            this.buttonReadBasisPmx.Size = new System.Drawing.Size(825, 86);
            this.buttonReadBasisPmx.TabIndex = 0;
            this.buttonReadBasisPmx.Text = "材質並び順変更前PMXを読込";
            this.buttonReadBasisPmx.UseVisualStyleBackColor = true;
            this.buttonReadBasisPmx.Click += new System.EventHandler(this.buttonReadBasisPmx_Click);
            // 
            // buttonReadTargetPMX
            // 
            this.buttonReadTargetPMX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadTargetPMX.Location = new System.Drawing.Point(434, 305);
            this.buttonReadTargetPMX.Margin = new System.Windows.Forms.Padding(5);
            this.buttonReadTargetPMX.Name = "buttonReadTargetPMX";
            this.buttonReadTargetPMX.Size = new System.Drawing.Size(825, 90);
            this.buttonReadTargetPMX.TabIndex = 1;
            this.buttonReadTargetPMX.Text = "材質並び順変更後PMXを読込";
            this.buttonReadTargetPMX.UseVisualStyleBackColor = true;
            this.buttonReadTargetPMX.Click += new System.EventHandler(this.buttonReadTargetPMX_Click);
            // 
            // listBoxOrderObj
            // 
            this.listBoxOrderObj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOrderObj.FormattingEnabled = true;
            this.listBoxOrderObj.ItemHeight = 25;
            this.listBoxOrderObj.Location = new System.Drawing.Point(5, 105);
            this.listBoxOrderObj.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxOrderObj.Name = "listBoxOrderObj";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxOrderObj, 6);
            this.listBoxOrderObj.Size = new System.Drawing.Size(419, 479);
            this.listBoxOrderObj.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.tableLayoutPanel1.Controls.Add(this.buttonReadTargetPMX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxOrderObj, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonReadEMM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonReadBasisPmx, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonWriteEMM, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReadEMM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReadBasisPmx, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReadTargetPMX, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 600);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // textBoxReadEMM
            // 
            this.textBoxReadEMM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReadEMM.Location = new System.Drawing.Point(434, 7);
            this.textBoxReadEMM.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.textBoxReadEMM.Multiline = true;
            this.textBoxReadEMM.Name = "textBoxReadEMM";
            this.textBoxReadEMM.ReadOnly = true;
            this.textBoxReadEMM.Size = new System.Drawing.Size(825, 86);
            this.textBoxReadEMM.TabIndex = 3;
            // 
            // textBoxReadBasisPmx
            // 
            this.textBoxReadBasisPmx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReadBasisPmx.Location = new System.Drawing.Point(434, 207);
            this.textBoxReadBasisPmx.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.textBoxReadBasisPmx.Multiline = true;
            this.textBoxReadBasisPmx.Name = "textBoxReadBasisPmx";
            this.textBoxReadBasisPmx.ReadOnly = true;
            this.textBoxReadBasisPmx.Size = new System.Drawing.Size(825, 86);
            this.textBoxReadBasisPmx.TabIndex = 3;
            // 
            // textBoxReadTargetPMX
            // 
            this.textBoxReadTargetPMX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReadTargetPMX.Location = new System.Drawing.Point(434, 407);
            this.textBoxReadTargetPMX.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.textBoxReadTargetPMX.Multiline = true;
            this.textBoxReadTargetPMX.Name = "textBoxReadTargetPMX";
            this.textBoxReadTargetPMX.ReadOnly = true;
            this.textBoxReadTargetPMX.Size = new System.Drawing.Size(825, 86);
            this.textBoxReadTargetPMX.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.MinimumSize = new System.Drawing.Size(1280, 640);
            this.Name = "MainForm";
            this.Text = "EMM Auto Material Orderer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReadEMM;
        private System.Windows.Forms.Button buttonWriteEMM;
        private System.Windows.Forms.Button buttonReadBasisPmx;
        private System.Windows.Forms.Button buttonReadTargetPMX;
        private System.Windows.Forms.ListBox listBoxOrderObj;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxReadEMM;
        private System.Windows.Forms.TextBox textBoxReadBasisPmx;
        private System.Windows.Forms.TextBox textBoxReadTargetPMX;
    }
}

