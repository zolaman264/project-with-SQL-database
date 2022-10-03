using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using MaterialSkin;

namespace YBP_final_zola
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT count(*) from  LOGIN WHERE username='" + txtusername.Text + "' AND password='" + txtpassword.Text + "'", con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                 this.Hide();
                new Form1().Show();
            }
            else
                MessageBox.Show("Invalid username or password");
            con.Close();

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
    
}
