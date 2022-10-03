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

namespace YBP_final_zola
{
    public partial class Not_Assigned : Form
    {
        public Not_Assigned()
        {
            InitializeComponent();
        }
        BindingSource bsource1;
        private void button1_Click(object sender, EventArgs e)
        {
            //BindingSource bsource = new BindingSource();
            bsource1 = new BindingSource();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Order1 left join TT On Order1.Number=TT.Orders WHERE TT.Orders IS NULL and TT.Orders IS NULL AND Acct BETWEEN '" + dateTimePickerFrom.Value.ToString() + "'AND '" + dateTimePicker2.Value.ToString() + "'", con);
            DataSet ds1 = new DataSet();
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
            da1.Fill(ds1, "Order1");
            //BindingSource bsource = new BindingSource();
            bsource1.DataSource = ds1.Tables["Order1"];
            Datagridview.DataSource = bsource1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bsource1.Filter = string.Format(" Dealer_name LIKE '%{0}%' OR Number LIKE '%{0}%' ", textBox1.Text);
        }
    }
    
}
