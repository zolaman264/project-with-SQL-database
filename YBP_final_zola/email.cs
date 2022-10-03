using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;

namespace YBP_final_zola
{
    public partial class email : Form
    {
        public email()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
     
                SmtpClient cliant = new SmtpClient("smtp.gmail.com",587);
                MailMessage message = new MailMessage();
                message.From = new  MailAddress(txtemail.Text);
                message.To.Add(txtreciver.Text);
                message.Body = txtbody.Text;
                message.Subject = txtsubject.Text;
                cliant.UseDefaultCredentials = false;
                cliant.EnableSsl = true;
                if(txtattachment.Text!="")
                {
                    message.Attachments.Add(new Attachment(txtattachment.Text));
                }
                cliant.Credentials = new System.Net.NetworkCredential(txtemail.Text, txtpassword.Text);
                cliant.Send(message);
                message = null;
                
                MessageBox.Show("message sent succesfully");

            }
            catch(Exception s)
            {
                MessageBox.Show("faild to send https//www.google.com/settings/security/lesssecureapps please try again"+s.Message );

            }


        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            txtattachment.Text = openFileDialog1.FileName.ToString();// Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

      
    }
}
