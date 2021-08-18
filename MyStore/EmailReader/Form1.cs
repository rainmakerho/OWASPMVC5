using Aspose.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenEmailFile_Click(object sender, EventArgs e)
        {
            if (openEmlFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                var filePath = openEmlFileDialog.FileName;
                var mailMessage = MailMessage.Load(filePath, new EmlLoadOptions());
                txtSubject.Text = mailMessage.Subject;

                txtEmailBody.Text = mailMessage.Body;
            }
        }

        private void ReadEmailFile(string emailFilePath)
        {
            

        }
    }
}
