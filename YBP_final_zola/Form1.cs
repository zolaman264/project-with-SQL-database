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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        BindingSource bsource1;
        bool orders = true;
        //String dtserach = "";

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SearchLoading.Hide();
            txtSearch.Show();
            label1.Show();
            orders = true;

            //BindingSource bsource = new BindingSource();
            bsource1 = new BindingSource();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Order1 WHERE Acct BETWEEN '" + dateTimePickerFrom.Value.ToString() + "'AND '" + dateTimePicker2.Value.ToString() + "'", con);
            DataSet ds1 = new DataSet();
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
            da1.Fill(ds1, "Order1");
            //BindingSource bsource = new BindingSource();
            bsource1.DataSource = ds1.Tables["Order1"];
            dataGridView1.DataSource = bsource1;
            con.Close();

        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            SearchLoading.Hide();
            txtSearch.Show();
            label1.Show();
            orders = false;


            bsource1 = new BindingSource();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM TT WHERE Arrival_date BETWEEN '" + dateTimePickerFrom.Value.ToString() + "'AND '" + dateTimePicker2.Value.ToString() + "'", con);
            DataSet ds1 = new DataSet();
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
            da1.Fill(ds1, " TT");
            bsource1.DataSource = ds1.Tables[" TT"];
            dataGridView1.DataSource = bsource1;
            con.Close();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            SearchLoading.Show();
            txtSearch.Hide();
            label1.Show();
            orders = false;

            bsource1 = new BindingSource();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Loading WHERE Date BETWEEN '" + dateTimePickerFrom.Value.ToString() + "'AND '" + dateTimePicker2.Value.ToString() + "'", con);
            DataSet ds1 = new DataSet();
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
            da1.Fill(ds1, "Loading");
            bsource1.DataSource = ds1.Tables["Loading"];
            dataGridView1.DataSource = bsource1;
            con.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (orders == true)
            {
                bsource1.Filter = string.Format("Dealer_name  LIKE '%{0}%' OR Number LIKE '%{0}%'", txtSearch.Text);

            }
            else

                bsource1.Filter = string.Format("Destination  LIKE '%{0}%' OR plateN LIKE '%{0}%' ", txtSearch.Text);
        }

        private void SearchLoading_TextChanged(object sender, EventArgs e)
        {
            bsource1.Filter = string.Format(" Destination_name LIKE '%{0}%' OR Invoice_number LIKE '%{0}%'  OR Product LIKE '%{0}%' ", SearchLoading.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SearchLoading.Hide();
            txtSearch.Hide();
            label1.Hide();
        }

        private void btnImpOrd_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog ope = new OpenFileDialog();
                ope.Filter = "Excel Files|*.xls;*xlsx;*.xlsn";
                if (ope.ShowDialog() == DialogResult.Cancel)

                    return;
                FileStream stream = new FileStream(ope.FileName, FileMode.Open);
                IExcelDataReader excelreader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet result = excelreader.AsDataSet();
                DataClasses1DataContext conn = new DataClasses1DataContext();
                foreach (DataTable table in result.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        Order1 addtable = new Order1()
                        {
                            Acct = Convert.ToDateTime(dr[0]),
                            Dealer_name = Convert.ToString(dr[1]),
                            Product = Convert.ToString(dr[2]),
                            QTY = Convert.ToString(dr[3]),
                            Number = Convert.ToString(dr[4])
                        };
                        conn.Order1s.InsertOnSubmit(addtable);
                    }
                }
                conn.SubmitChanges();
                excelreader.Close();
                stream.Close();
                MessageBox.Show("Data Inserted To Order");
            }
            catch(Exception )
            {
                MessageBox.Show("Check for the excel you inserted");
            }
                    



        }

        private void btnImpTT_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog ope = new OpenFileDialog();
                ope.Filter = "Excel Files|*.xls;*xlsx;*.xlsn";
                if (ope.ShowDialog() == DialogResult.Cancel)

                    return;
                FileStream stream = new FileStream(ope.FileName, FileMode.Open);
                IExcelDataReader excelreader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet result = excelreader.AsDataSet();
                DataClasses1DataContext conn = new DataClasses1DataContext();
                foreach (DataTable table in result.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        TT addtable = new TT()
                        {
                            Seq = Convert.ToString(dr[0]),
                            plateN = Convert.ToString(dr[1]),
                            Orders = Convert.ToString(dr[2]),
                            Destination = Convert.ToString(dr[3]),
                            Product = Convert.ToString(dr[4]),
                            Arrival_date = Convert.ToDateTime(dr[5]),
                            Assign_date = Convert.ToDateTime(dr[6])
                        };
                        conn.TTs.InsertOnSubmit(addtable);
                    }
                }
                conn.SubmitChanges();
                excelreader.Close();
                stream.Close();
                MessageBox.Show("Data Inserted To TT");
                    }
            catch (Exception)
            {
                MessageBox.Show(" Check for the excel you inserted");
            }


        }

        private void btnImpDelv_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog ope = new OpenFileDialog();
                ope.Filter = "Excel Files|*.xls;*xlsx;*.xlsn";
                if (ope.ShowDialog() == DialogResult.Cancel)

                    return;
                FileStream stream = new FileStream(ope.FileName, FileMode.Open);
                IExcelDataReader excelreader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet result = excelreader.AsDataSet();
                DataClasses1DataContext conn = new DataClasses1DataContext();
                foreach (DataTable table in result.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        Loading addtable = new Loading()
                        {
                            Date = Convert.ToDateTime(dr[0]),
                            Order_number = Convert.ToString(dr[1]),
                            Invoice_number = Convert.ToString(dr[2]),
                            Destination_name = Convert.ToString(dr[3]),
                            Product = Convert.ToString(dr[4]),
                            volume = Convert.ToString(dr[5]),
                            truck_number = Convert.ToString(dr[6]),
                            FDCnumber = Convert.ToString(dr[6])
                        };
                        conn.Loadings.InsertOnSubmit(addtable);
                    }
                }
                conn.SubmitChanges();
                excelreader.Close();
                stream.Close();
                MessageBox.Show("Data Inserted To Loading");
            }
            catch (Exception)
            {
                MessageBox.Show(" Check for the excel you inserted");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Update().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Not_Assigned().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Backup_And_Restore().Show();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Backup_And_Restore().Show();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            new email().Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Help().Show();
        }
    }
}
