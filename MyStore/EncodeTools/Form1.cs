using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace EncodeTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUrlEncode_Click(object sender, EventArgs e)
        {
            txtOutput.Text = HttpUtility.UrlEncode(txtOrg.Text);
        }

        private void btnUrlDecode_Click(object sender, EventArgs e)
        {
            txtOutput.Text = HttpUtility.UrlDecode(txtOrg.Text);
        }

        private void btn2Base64_Click(object sender, EventArgs e)
        {
            txtOutput.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtOrg.Text));
        }

        private void btnFromBase64_Click(object sender, EventArgs e)
        {
            txtOutput.Text = Encoding.UTF8.GetString(Convert.FromBase64String(txtOrg.Text));
        }
    }
}
