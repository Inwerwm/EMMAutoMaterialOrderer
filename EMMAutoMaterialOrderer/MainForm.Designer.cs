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
            this.SuspendLayout();
            // 
            // buttonReadEMM
            // 
            this.buttonReadEMM.Location = new System.Drawing.Point(386, 165);
            this.buttonReadEMM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReadEMM.Name = "buttonReadEMM";
            this.buttonReadEMM.Size = new System.Drawing.Size(173, 29);
            this.buttonReadEMM.TabIndex = 0;
            this.buttonReadEMM.Text = "EMMファイルを読込";
            this.buttonReadEMM.UseVisualStyleBackColor = true;
            this.buttonReadEMM.Click += new System.EventHandler(this.buttonReadEMM_Click);
            // 
            // buttonWriteEMM
            // 
            this.buttonWriteEMM.Location = new System.Drawing.Point(386, 249);
            this.buttonWriteEMM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonWriteEMM.Name = "buttonWriteEMM";
            this.buttonWriteEMM.Size = new System.Drawing.Size(173, 29);
            this.buttonWriteEMM.TabIndex = 0;
            this.buttonWriteEMM.Text = "EMMファイルを書込";
            this.buttonWriteEMM.UseVisualStyleBackColor = true;
            this.buttonWriteEMM.Click += new System.EventHandler(this.buttonWriteEMM_Click);
            // 
            // buttonReadBasisPmx
            // 
            this.buttonReadBasisPmx.Location = new System.Drawing.Point(637, 165);
            this.buttonReadBasisPmx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReadBasisPmx.Name = "buttonReadBasisPmx";
            this.buttonReadBasisPmx.Size = new System.Drawing.Size(173, 29);
            this.buttonReadBasisPmx.TabIndex = 0;
            this.buttonReadBasisPmx.Text = "材質並び順変更前PMXを読込";
            this.buttonReadBasisPmx.UseVisualStyleBackColor = true;
            this.buttonReadBasisPmx.Click += new System.EventHandler(this.buttonReadBasisPmx_Click);
            // 
            // buttonReadTargetPMX
            // 
            this.buttonReadTargetPMX.Location = new System.Drawing.Point(637, 249);
            this.buttonReadTargetPMX.Name = "buttonReadTargetPMX";
            this.buttonReadTargetPMX.Size = new System.Drawing.Size(173, 29);
            this.buttonReadTargetPMX.TabIndex = 1;
            this.buttonReadTargetPMX.Text = "材質並び順変更後PMXを読込";
            this.buttonReadTargetPMX.UseVisualStyleBackColor = true;
            this.buttonReadTargetPMX.Click += new System.EventHandler(this.buttonReadTargetPMX_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.buttonReadTargetPMX);
            this.Controls.Add(this.buttonWriteEMM);
            this.Controls.Add(this.buttonReadBasisPmx);
            this.Controls.Add(this.buttonReadEMM);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReadEMM;
        private System.Windows.Forms.Button buttonWriteEMM;
        private System.Windows.Forms.Button buttonReadBasisPmx;
        private System.Windows.Forms.Button buttonReadTargetPMX;
    }
}

