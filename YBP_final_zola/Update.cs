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

    public partial class Update : Form
    {
        Boolean orderstatus = false;
        Boolean ttstatus = false;
        Boolean loadingstatus = false; 
        public Update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (!(String.IsNullOrEmpty(txtSearch.Text)))
                {
                    if (orderstatus == true) {

                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
                        con.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Order1 WHERE ID='" + txtSearch.Text.ToString() + "'", con);
                        DataSet ds1 = new DataSet();
                        SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
                        da1.Fill(ds1, "Order1");
                        txtAcct.Text = ds1.Tables[0].Rows[0]["Acct"].ToString();
                        txtDealer.Text = ds1.Tables[0].Rows[0]["Dealer_name"].ToString();
                        txtProduct.Text = ds1.Tables[0].Rows[0]["Product"].ToString();
                        txtqty.Text = ds1.Tables[0].Rows[0]["QTY"].ToString();
                        txtnum.Text = ds1.Tables[0].Rows[0]["Number"].ToString();
                        txtId.Text = ds1.Tables[0].Rows[0]["ID"].ToString();
                    }
                    else if (ttstatus == true) {

                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
                        con.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM TT WHERE ID='" + txtSearch.Text.ToString() + "'", con);
                        DataSet ds1 = new DataSet();
                        SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
                        da1.Fill(ds1, "TT");
                        txtseq.Text = ds1.Tables[0].Rows[0]["Seq"].ToString();
                        txtplateN.Text = ds1.Tables[0].Rows[0]["PlateN"].ToString();
                        txtOrder.Text = ds1.Tables[0].Rows[0]["Orders"].ToString();
                        txtDestination.Text = ds1.Tables[0].Rows[0]["Destination"].ToString();
                        ttproduct.Text = ds1.Tables[0].Rows[0]["Product"].ToString();
                        txtarrivaldate.Text = ds1.Tables[0].Rows[0]["Arrival_date"].ToString();
                        txtassigndate.Text = ds1.Tables[0].Rows[0]["Assign_date"].ToString();

                    }
                    else if (loadingstatus == true)
                    {

                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
                        con.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Loading WHERE ID='" + txtSearch.Text.ToString() + "'", con);
                        DataSet ds1 = new DataSet();
                        SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
                        da1.Fill(ds1, "Loading");
                        txtloadingdate.Text = ds1.Tables[0].Rows[0]["Date"].ToString();
                        txtloadingordernumber.Text = ds1.Tables[0].Rows[0]["Order_number"].ToString();
                        txtloadinginvoice.Text = ds1.Tables[0].Rows[0]["Invoice_number"].ToString();
                        txtloadingdestination.Text = ds1.Tables[0].Rows[0]["Destination_name"].ToString();
                        txtloadingproduct.Text = ds1.Tables[0].Rows[0]["Product"].ToString();
                        txtloadingvolume.Text = ds1.Tables[0].Rows[0]["Volume"].ToString();
                        txtloadingtruck.Text = ds1.Tables[0].Rows[0]["truck_number"].ToString();
                        txtloadingfdc.Text = ds1.Tables[0].Rows[0]["FDCnumber"].ToString();

                    }
                }
                else
                    MessageBox.Show("You have To Enter ID ");
            }
            catch(Exception  )
            {
                MessageBox.Show("There is no such kind of ID try typing again");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            con.Open();
          
                SqlDataReader dr;
            if (orderstatus == true) { 
                SqlCommand cmd = new SqlCommand("UPDATE Order1 set Acct='"+txtAcct.Text+"',Dealer_name='"+txtDealer.Text+"',Product='"+txtProduct.Text+"',QTY='"+txtqty.Text+"',Number='"+txtnum.Text+"' WHERE ID='"+txtSearch.Text+"'",con);
                dr = cmd.ExecuteReader();
                MessageBox.Show("Data Updated");
            }
            else if (ttstatus == true)
            {
                SqlCommand cmd = new SqlCommand("UPDATE TT set Seq='" + txtseq.Text + "',plateN='" + txtplateN.Text + "',Orders='"+txtOrder.Text+"',Destination='" + txtDestination.Text + "',Product='" + ttproduct.Text + "',Arrival_date='" + txtarrivaldate.Text + "',Assign_date='" + txtassigndate.Text + "' WHERE ID='" + txtSearch.Text + "'", con);
                dr = cmd.ExecuteReader();
                MessageBox.Show("Data Updated");
            }
            else if(loadingstatus==true){
                SqlCommand cmd = new SqlCommand("UPDATE Loading set Date='" + txtloadingdate.Text + "',Order_number='" + txtloadingordernumber.Text + "',Invoice_number='" + txtloadinginvoice.Text + "',Destination_name='" + txtloadingdestination.Text + "',Product='" + txtloadingproduct.Text + "',volume='" + txtloadingvolume.Text + "',truck_number='" + txtloadingtruck.Text + "',FDCnumber='" + txtloadingfdc.Text + "' WHERE ID='" + txtSearch.Text + "'", con);
                dr = cmd.ExecuteReader();
                MessageBox.Show("Data Updated");

            }



        }

        private void Update_Load(object sender, EventArgs e)
        {
            txtAcct.Hide();
            txtDealer.Hide();
            txtId.Hide();
            txtnum.Hide();
            txtProduct.Hide();
            txtqty.Hide();
            //txtSearch.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            //button1.Hide();
            //button2.Hide();
            //**********************************
            txtloadingdate.Hide();
            txtloadingdestination.Hide();
            txtloadingfdc.Hide();
            txtloadinginvoice.Hide();
            txtloadingvolume.Hide();
            txtloadingtruck.Hide();
            txtloadingordernumber.Hide();
            txtloadingproduct.Hide();
            //**********************
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();

            //***********************
            txtseq.Hide();
            txtplateN.Hide();
            txtOrder.Hide();
            txtDestination.Hide();
            ttproduct.Hide();
            txtarrivaldate.Hide();
            txtassigndate.Hide();
            //*****************
            ttseq.Hide();
            ttorder.Hide();
            ttplate.Hide();
            ttdestination.Hide();
            ttproduct.Hide();
            ttarrival.Hide();
            ttassign.Hide();
            ttproductlable.Hide();
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            orderstatus = true;
            ttstatus = false;
            loadingstatus = false;
            txtAcct.Show();
            txtDealer.Show();
            txtId.Show();
            txtnum.Show();
            txtProduct.Show();
            txtqty.Show();
            txtSearch.Show();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            button1.Show();
            button2.Show();
            //******************************************
            txtloadingdate.Hide();
            txtloadingdestination.Hide();
            txtloadingfdc.Hide();
            txtloadinginvoice.Hide();
            txtloadingvolume.Hide();
            txtloadingtruck.Hide();
            txtloadingordernumber.Hide();
            txtloadingproduct.Hide();
            //*********
            txtseq.Hide();
            txtplateN.Hide();
            txtOrder.Hide();
            txtDestination.Hide();
            ttproduct.Hide();
            txtarrivaldate.Hide();
            txtassigndate.Hide();
            //***********************
            ttseq.Hide();
            ttplate.Hide();
            ttdestination.Hide();
            ttproduct.Hide();
            ttarrival.Hide();
            ttassign.Hide();
            ttorder.Hide();
            ttproductlable.Hide();
            //**************
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            ttstatus = true;
            orderstatus = false;
            loadingstatus = false;
            txtloadingdate.Hide();
            txtloadingdestination.Hide();
            txtloadingfdc.Hide();
            txtloadinginvoice.Hide();
            txtloadingvolume.Hide();
            txtloadingtruck.Hide();
            txtloadingordernumber.Hide();
            txtloadingproduct.Hide();
            txtSearch.Show();
            //****************

            txtAcct.Hide();
            txtDealer.Hide();
            txtId.Hide();
            txtnum.Hide();
            txtProduct.Hide();
            txtqty.Hide();
           
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            //*************
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();

            //*********************
            txtseq.Show();
            txtplateN.Show();
            txtOrder.Show();
            txtDestination.Show();
            ttproduct.Show();
            txtarrivaldate.Show();
            txtassigndate.Show();
            //*****************
            ttseq.Show();
            ttorder.Show();
            ttplate.Show();
            ttdestination.Show();
            ttproduct.Show();
            ttarrival.Show();
            ttassign.Show();
            ttproductlable.Show();
        }

        private void btnloading_Click(object sender, EventArgs e)
        {
            loadingstatus = true;
            orderstatus = false;
            ttstatus = false;
            txtloadingdate.Show();
            txtloadingdestination.Show();
            txtloadingfdc.Show();
            txtloadinginvoice.Show();
            txtloadingvolume.Show();
            txtloadingtruck.Show();
            txtloadingordernumber.Show();
            txtloadingproduct.Show();
            txtSearch.Show();
            //*****************

            txtAcct.Hide();
            txtDealer.Hide();
            txtId.Hide();
            txtnum.Hide();
            txtProduct.Hide();
            txtqty.Hide();
           
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            //**************
            label14.Show();
            label15.Show();
            label16.Show();
            label17.Show();
            label18.Show();
            label19.Show();
            label20.Show();
            label21.Show();
            //********************
            txtseq.Hide();
            txtOrder.Hide();
            txtplateN.Hide();
            txtDestination.Hide();
            ttproduct.Hide();
            txtarrivaldate.Hide();
            txtassigndate.Hide();
            //**************
            ttseq.Hide();
            ttplate.Hide();
            ttdestination.Hide();
            ttproduct.Hide();
            ttarrival.Hide();
            ttassign.Hide();
            ttorder.Hide();
            ttproductlable.Hide();
        }

        private void lblplatenumber_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
