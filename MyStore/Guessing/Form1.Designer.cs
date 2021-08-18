
namespace Guessing
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
            this.tabFuns = new System.Windows.Forms.TabControl();
            this.pgBlindSQLInjection = new System.Windows.Forms.TabPage();
            this.panBody = new System.Windows.Forms.Panel();
            this.txtTableIdx = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panUp = new System.Windows.Forms.Panel();
            this.btnGuessColumns = new System.Windows.Forms.Button();
            this.btnGuessTableName = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pgExplicitSQLInjection = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGetDataStatus = new System.Windows.Forms.TextBox();
            this.txtSortedColumn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetTableData = new System.Windows.Forms.Button();
            this.txtLoginUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdTable = new System.Windows.Forms.DataGridView();
            this.tabFuns.SuspendLayout();
            this.pgBlindSQLInjection.SuspendLayout();
            this.panBody.SuspendLayout();
            this.panUp.SuspendLayout();
            this.pgExplicitSQLInjection.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFuns
            // 
            this.tabFuns.Controls.Add(this.pgBlindSQLInjection);
            this.tabFuns.Controls.Add(this.pgExplicitSQLInjection);
            this.tabFuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFuns.Location = new System.Drawing.Point(0, 0);
            this.tabFuns.Name = "tabFuns";
            this.tabFuns.SelectedIndex = 0;
            this.tabFuns.Size = new System.Drawing.Size(1200, 600);
            this.tabFuns.TabIndex = 2;
            // 
            // pgBlindSQLInjection
            // 
            this.pgBlindSQLInjection.Controls.Add(this.panBody);
            this.pgBlindSQLInjection.Controls.Add(this.panUp);
            this.pgBlindSQLInjection.Location = new System.Drawing.Point(4, 26);
            this.pgBlindSQLInjection.Name = "pgBlindSQLInjection";
            this.pgBlindSQLInjection.Padding = new System.Windows.Forms.Padding(3);
            this.pgBlindSQLInjection.Size = new System.Drawing.Size(1192, 570);
            this.pgBlindSQLInjection.TabIndex = 0;
            this.pgBlindSQLInjection.Text = "猜 Table & Column Names";
            this.pgBlindSQLInjection.UseVisualStyleBackColor = true;
            // 
            // panBody
            // 
            this.panBody.Controls.Add(this.txtTableIdx);
            this.panBody.Controls.Add(this.txtStatus);
            this.panBody.Controls.Add(this.txtColumns);
            this.panBody.Controls.Add(this.label3);
            this.panBody.Controls.Add(this.txtTableName);
            this.panBody.Controls.Add(this.label2);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(3, 124);
            this.panBody.Margin = new System.Windows.Forms.Padding(4);
            this.panBody.Name = "panBody";
            this.panBody.Size = new System.Drawing.Size(1186, 443);
            this.panBody.TabIndex = 3;
            // 
            // txtTableIdx
            // 
            this.txtTableIdx.Location = new System.Drawing.Point(442, 23);
            this.txtTableIdx.Name = "txtTableIdx";
            this.txtTableIdx.Size = new System.Drawing.Size(106, 27);
            this.txtTableIdx.TabIndex = 6;
            this.txtTableIdx.Text = "1";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(110, 335);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(432, 27);
            this.txtStatus.TabIndex = 5;
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(110, 66);
            this.txtColumns.Multiline = true;
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtColumns.Size = new System.Drawing.Size(432, 262);
            this.txtColumns.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Columns:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(110, 23);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(326, 27);
            this.txtTableName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "TableName:";
            // 
            // panUp
            // 
            this.panUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panUp.Controls.Add(this.btnGuessColumns);
            this.panUp.Controls.Add(this.btnGuessTableName);
            this.panUp.Controls.Add(this.txtURL);
            this.panUp.Controls.Add(this.label1);
            this.panUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panUp.Location = new System.Drawing.Point(3, 3);
            this.panUp.Margin = new System.Windows.Forms.Padding(4);
            this.panUp.Name = "panUp";
            this.panUp.Size = new System.Drawing.Size(1186, 121);
            this.panUp.TabIndex = 1;
            // 
            // btnGuessColumns
            // 
            this.btnGuessColumns.Location = new System.Drawing.Point(178, 57);
            this.btnGuessColumns.Name = "btnGuessColumns";
            this.btnGuessColumns.Size = new System.Drawing.Size(138, 34);
            this.btnGuessColumns.TabIndex = 3;
            this.btnGuessColumns.Text = "猜 Columns";
            this.btnGuessColumns.UseVisualStyleBackColor = true;
            this.btnGuessColumns.Click += new System.EventHandler(this.btnGuessColumns_Click_1);
            // 
            // btnGuessTableName
            // 
            this.btnGuessTableName.Location = new System.Drawing.Point(21, 57);
            this.btnGuessTableName.Name = "btnGuessTableName";
            this.btnGuessTableName.Size = new System.Drawing.Size(138, 34);
            this.btnGuessTableName.TabIndex = 2;
            this.btnGuessTableName.Text = "猜 TableName";
            this.btnGuessTableName.UseVisualStyleBackColor = true;
            this.btnGuessTableName.Click += new System.EventHandler(this.btnGuessTableName_Click_1);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(67, 13);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(480, 27);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "http://localhost:44375/Product/Detail?ProductID=4&orderBy=UserID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // pgExplicitSQLInjection
            // 
            this.pgExplicitSQLInjection.Controls.Add(this.panel2);
            this.pgExplicitSQLInjection.Controls.Add(this.panel1);
            this.pgExplicitSQLInjection.Location = new System.Drawing.Point(4, 26);
            this.pgExplicitSQLInjection.Name = "pgExplicitSQLInjection";
            this.pgExplicitSQLInjection.Padding = new System.Windows.Forms.Padding(3);
            this.pgExplicitSQLInjection.Size = new System.Drawing.Size(1192, 570);
            this.pgExplicitSQLInjection.TabIndex = 1;
            this.pgExplicitSQLInjection.Text = "找出資料";
            this.pgExplicitSQLInjection.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 424);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtGetDataStatus);
            this.panel1.Controls.Add(this.txtSortedColumn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtLoginEmail);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnGetTableData);
            this.panel1.Controls.Add(this.txtLoginUrl);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 140);
            this.panel1.TabIndex = 0;
            // 
            // txtGetDataStatus
            // 
            this.txtGetDataStatus.Location = new System.Drawing.Point(170, 96);
            this.txtGetDataStatus.Name = "txtGetDataStatus";
            this.txtGetDataStatus.Size = new System.Drawing.Size(432, 27);
            this.txtGetDataStatus.TabIndex = 12;
            // 
            // txtSortedColumn
            // 
            this.txtSortedColumn.Location = new System.Drawing.Point(315, 54);
            this.txtSortedColumn.Name = "txtSortedColumn";
            this.txtSortedColumn.Size = new System.Drawing.Size(128, 27);
            this.txtSortedColumn.TabIndex = 11;
            this.txtSortedColumn.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Sort Column:";
            // 
            // txtLoginEmail
            // 
            this.txtLoginEmail.Location = new System.Drawing.Point(61, 51);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(128, 27);
            this.txtLoginEmail.TabIndex = 9;
            this.txtLoginEmail.Text = "rm@gss.com.tw";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 6;
            // 
            // btnGetTableData
            // 
            this.btnGetTableData.Location = new System.Drawing.Point(15, 90);
            this.btnGetTableData.Name = "btnGetTableData";
            this.btnGetTableData.Size = new System.Drawing.Size(138, 34);
            this.btnGetTableData.TabIndex = 5;
            this.btnGetTableData.Text = "取出Table資料";
            this.btnGetTableData.UseVisualStyleBackColor = true;
            this.btnGetTableData.Click += new System.EventHandler(this.btnGetTableData_Click);
            // 
            // txtLoginUrl
            // 
            this.txtLoginUrl.Location = new System.Drawing.Point(61, 13);
            this.txtLoginUrl.Name = "txtLoginUrl";
            this.txtLoginUrl.Size = new System.Drawing.Size(480, 27);
            this.txtLoginUrl.TabIndex = 4;
            this.txtLoginUrl.Text = "http://localhost:44375/Account/Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "URL:";
            // 
            // grdTable
            // 
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTable.Location = new System.Drawing.Point(15, 21);
            this.grdTable.Name = "grdTable";
            this.grdTable.RowTemplate.Height = 24;
            this.grdTable.Size = new System.Drawing.Size(1007, 334);
            this.grdTable.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.tabFuns);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "猜一猜";
            this.tabFuns.ResumeLayout(false);
            this.pgBlindSQLInjection.ResumeLayout(false);
            this.panBody.ResumeLayout(false);
            this.panBody.PerformLayout();
            this.panUp.ResumeLayout(false);
            this.panUp.PerformLayout();
            this.pgExplicitSQLInjection.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabFuns;
        private System.Windows.Forms.TabPage pgBlindSQLInjection;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.TextBox txtTableIdx;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panUp;
        private System.Windows.Forms.Button btnGuessColumns;
        private System.Windows.Forms.Button btnGuessTableName;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage pgExplicitSQLInjection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetTableData;
        private System.Windows.Forms.TextBox txtLoginUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSortedColumn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGetDataStatus;
        private System.Windows.Forms.DataGridView grdTable;
    }
}

