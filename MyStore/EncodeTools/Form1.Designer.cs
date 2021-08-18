namespace EncodeTools
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbOrg = new System.Windows.Forms.GroupBox();
            this.panTools = new System.Windows.Forms.Panel();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnUrlEncode = new System.Windows.Forms.Button();
            this.btnUrlDecode = new System.Windows.Forms.Button();
            this.btn2Base64 = new System.Windows.Forms.Button();
            this.btnFromBase64 = new System.Windows.Forms.Button();
            this.gbOrg.SuspendLayout();
            this.panTools.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOrg
            // 
            this.gbOrg.Controls.Add(this.txtOrg);
            this.gbOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOrg.Location = new System.Drawing.Point(0, 0);
            this.gbOrg.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbOrg.Name = "gbOrg";
            this.gbOrg.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbOrg.Size = new System.Drawing.Size(1444, 348);
            this.gbOrg.TabIndex = 0;
            this.gbOrg.TabStop = false;
            this.gbOrg.Text = "原始內容";
            // 
            // panTools
            // 
            this.panTools.Controls.Add(this.btnFromBase64);
            this.panTools.Controls.Add(this.btn2Base64);
            this.panTools.Controls.Add(this.btnUrlDecode);
            this.panTools.Controls.Add(this.btnUrlEncode);
            this.panTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTools.Location = new System.Drawing.Point(0, 348);
            this.panTools.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panTools.Name = "panTools";
            this.panTools.Size = new System.Drawing.Size(1444, 47);
            this.panTools.TabIndex = 1;
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.txtOutput);
            this.gbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOutput.Location = new System.Drawing.Point(0, 395);
            this.gbOutput.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbOutput.Size = new System.Drawing.Size(1444, 470);
            this.gbOutput.TabIndex = 2;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "結果";
            // 
            // txtOrg
            // 
            this.txtOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrg.Location = new System.Drawing.Point(5, 27);
            this.txtOrg.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtOrg.Multiline = true;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOrg.Size = new System.Drawing.Size(1434, 316);
            this.txtOrg.TabIndex = 0;
            this.txtOrg.WordWrap = false;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(5, 27);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(1434, 438);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            // 
            // btnUrlEncode
            // 
            this.btnUrlEncode.Location = new System.Drawing.Point(12, 8);
            this.btnUrlEncode.Name = "btnUrlEncode";
            this.btnUrlEncode.Size = new System.Drawing.Size(139, 30);
            this.btnUrlEncode.TabIndex = 0;
            this.btnUrlEncode.Text = "URL Encode";
            this.btnUrlEncode.UseVisualStyleBackColor = true;
            this.btnUrlEncode.Click += new System.EventHandler(this.btnUrlEncode_Click);
            // 
            // btnUrlDecode
            // 
            this.btnUrlDecode.Location = new System.Drawing.Point(157, 8);
            this.btnUrlDecode.Name = "btnUrlDecode";
            this.btnUrlDecode.Size = new System.Drawing.Size(139, 30);
            this.btnUrlDecode.TabIndex = 1;
            this.btnUrlDecode.Text = "URL Decode";
            this.btnUrlDecode.UseVisualStyleBackColor = true;
            this.btnUrlDecode.Click += new System.EventHandler(this.btnUrlDecode_Click);
            // 
            // btn2Base64
            // 
            this.btn2Base64.Location = new System.Drawing.Point(302, 8);
            this.btn2Base64.Name = "btn2Base64";
            this.btn2Base64.Size = new System.Drawing.Size(139, 30);
            this.btn2Base64.TabIndex = 2;
            this.btn2Base64.Text = "ToBase64";
            this.btn2Base64.UseVisualStyleBackColor = true;
            this.btn2Base64.Click += new System.EventHandler(this.btn2Base64_Click);
            // 
            // btnFromBase64
            // 
            this.btnFromBase64.Location = new System.Drawing.Point(447, 9);
            this.btnFromBase64.Name = "btnFromBase64";
            this.btnFromBase64.Size = new System.Drawing.Size(139, 30);
            this.btnFromBase64.TabIndex = 3;
            this.btnFromBase64.Text = "FromBase64";
            this.btnFromBase64.UseVisualStyleBackColor = true;
            this.btnFromBase64.Click += new System.EventHandler(this.btnFromBase64_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 865);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.panTools);
            this.Controls.Add(this.gbOrg);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "Encode/Decode";
            this.gbOrg.ResumeLayout(false);
            this.gbOrg.PerformLayout();
            this.panTools.ResumeLayout(false);
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrg;
        private System.Windows.Forms.Panel panTools;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.TextBox txtOrg;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnUrlDecode;
        private System.Windows.Forms.Button btnUrlEncode;
        private System.Windows.Forms.Button btnFromBase64;
        private System.Windows.Forms.Button btn2Base64;
    }
}

