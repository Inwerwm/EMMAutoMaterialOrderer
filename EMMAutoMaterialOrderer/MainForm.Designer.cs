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
            this.buttonOpenEMM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenEMM
            // 
            this.buttonOpenEMM.Location = new System.Drawing.Point(328, 144);
            this.buttonOpenEMM.Name = "buttonOpenEMM";
            this.buttonOpenEMM.Size = new System.Drawing.Size(148, 23);
            this.buttonOpenEMM.TabIndex = 0;
            this.buttonOpenEMM.Text = "EMMファイルを開く";
            this.buttonOpenEMM.UseVisualStyleBackColor = true;
            this.buttonOpenEMM.Click += new System.EventHandler(this.buttonOpenEMM_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonOpenEMM);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenEMM;
    }
}

