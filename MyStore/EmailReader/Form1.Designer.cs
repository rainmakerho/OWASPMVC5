
namespace EmailReader
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
            this.panButtons = new System.Windows.Forms.Panel();
            this.panBody = new System.Windows.Forms.Panel();
            this.openEmlFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenEmailFile = new System.Windows.Forms.Button();
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.panButtons.SuspendLayout();
            this.panBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.btnOpenEmailFile);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panButtons.Location = new System.Drawing.Point(0, 0);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(800, 58);
            this.panButtons.TabIndex = 0;
            // 
            // panBody
            // 
            this.panBody.Controls.Add(this.txtSubject);
            this.panBody.Controls.Add(this.txtEmailBody);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(0, 58);
            this.panBody.Name = "panBody";
            this.panBody.Size = new System.Drawing.Size(800, 392);
            this.panBody.TabIndex = 1;
            // 
            // openEmlFileDialog
            // 
            this.openEmlFileDialog.Filter = "Email|*.eml";
            // 
            // btnOpenEmailFile
            // 
            this.btnOpenEmailFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenEmailFile.Name = "btnOpenEmailFile";
            this.btnOpenEmailFile.Size = new System.Drawing.Size(109, 40);
            this.btnOpenEmailFile.TabIndex = 0;
            this.btnOpenEmailFile.Text = "Open Email File";
            this.btnOpenEmailFile.UseVisualStyleBackColor = true;
            this.btnOpenEmailFile.Click += new System.EventHandler(this.btnOpenEmailFile_Click);
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtEmailBody.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEmailBody.Location = new System.Drawing.Point(0, 36);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEmailBody.Size = new System.Drawing.Size(800, 356);
            this.txtEmailBody.TabIndex = 0;
            // 
            // txtSubject
            // 
            this.txtSubject.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSubject.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSubject.Location = new System.Drawing.Point(0, 0);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(800, 30);
            this.txtSubject.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panButtons);
            this.Name = "Form1";
            this.Text = "Email Reader";
            this.panButtons.ResumeLayout(false);
            this.panBody.ResumeLayout(false);
            this.panBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.OpenFileDialog openEmlFileDialog;
        private System.Windows.Forms.Button btnOpenEmailFile;
        private System.Windows.Forms.TextBox txtEmailBody;
        private System.Windows.Forms.TextBox txtSubject;
    }
}

