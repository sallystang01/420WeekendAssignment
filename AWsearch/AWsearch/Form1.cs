using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AWsearch
{
    public partial class OrderSearch : Form
    {
        const string connString = "Server=PL09\\MTCDB;Database=AdventureWorks2012;Trusted_Connection=True;User ID=AdvWorks2012;Password=1234;";
        SqlConnection sqlConn = new SqlConnection(connString);

        public OrderSearch()
        {
            InitializeComponent();
        }

        private void cbCustName_SelectedIndexChanged(object sender, EventArgs e)
        {



            DataTable dtCustomers = new DataTable();

            try
            {
                SqlCommand sqlComm = new SqlCommand("spCustomerList", sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlComm);

                sqlDA.Fill(dtCustomers);
                SqlDataReader dr = sqlComm.ExecuteReader();l
                
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
            

        }

       
        }
    

