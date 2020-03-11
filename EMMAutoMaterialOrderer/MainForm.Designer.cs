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
            this.SuspendLayout();
            // 
            // buttonReadEMM
            // 
            this.buttonReadEMM.Location = new System.Drawing.Point(331, 132);
            this.buttonReadEMM.Name = "buttonReadEMM";
            this.buttonReadEMM.Size = new System.Drawing.Size(148, 23);
            this.buttonReadEMM.TabIndex = 0;
            this.buttonReadEMM.Text = "EMMファイルを読込";
            this.buttonReadEMM.UseVisualStyleBackColor = true;
            this.buttonReadEMM.Click += new System.EventHandler(this.buttonReadEMM_Click);
            // 
            // buttonWriteEMM
            // 
            this.buttonWriteEMM.Location = new System.Drawing.Point(331, 199);
            this.buttonWriteEMM.Name = "buttonWriteEMM";
            this.buttonWriteEMM.Size = new System.Drawing.Size(148, 23);
            this.buttonWriteEMM.TabIndex = 0;
            this.buttonWriteEMM.Text = "EMMファイルを書込";
            this.buttonWriteEMM.UseVisualStyleBackColor = true;
            this.buttonWriteEMM.Click += new System.EventHandler(this.buttonWriteEMM_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonWriteEMM);
            this.Controls.Add(this.buttonReadEMM);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReadEMM;
        private System.Windows.Forms.Button buttonWriteEMM;
    }
}

