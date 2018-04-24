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

        // SQL Connection String
        const string connString = "Server=PL09\\MTCDB;Database=AdventureWorks2012;Trusted_Connection=True;User ID=AdvWorks2012;Password=1234;";
        SqlConnection sqlConn = new SqlConnection(connString);




        public OrderSearch()
        {
            InitializeComponent();
        }



        private void OrderSearch_Load(object sender, EventArgs e)
        {

            // Once the forms load, populate the combo box with data

            // Establishes a data adapter
            SqlDataAdapter sqlDa = new SqlDataAdapter("spCustomerList", sqlConn);
            // Establishes a data table
            DataTable dtCustomers = new DataTable();

            // Declares variables
            int CustomerID;
            string CustomerName;

            try
            {
                // Adapter fills my data table
                sqlDa.Fill(dtCustomers);

                // Puts the data into an array if found in the data row in the data table.
                foreach (DataRow drCustomers in dtCustomers.Rows)
                {
                    CustomerID = int.Parse(drCustomers.ItemArray[0].ToString());
                    CustomerName = drCustomers.ItemArray[1].ToString();
                    cbCustName.Items.Add(new cboObject(CustomerID, CustomerName));
                }
            }

            // Error handeling
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went terribly wrong...");
            }



        }



        private void cbCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Once a new customer name is selected from the combo box, pull up that particular
            // person's order history.

            // Finds my cboObject class, then it uses the data provided from the form
            // and populates the data in the class
            cboObject currentObject = (cboObject)cbCustName.SelectedItem;

            // Variable declaration

            // Sets CustomerID variable to the CustomerID variable in the cboObject class
            int CustomerID = currentObject.CustomerID;

            // Creates a new data table
            DataTable dtCustomerOrders = new DataTable();



            try
            {

                // SQL Command to run the stored procedure from SQL database
                SqlCommand sqlComm = new SqlCommand("spSalesOrderSearch", sqlConn);
                // Sets the command type to a stored procedure
                sqlComm.CommandType = CommandType.StoredProcedure;
                // Adds a parameter to the stored procedure (This is so the stored procedure knows
                // what data to pull and provide to the form
                SqlParameter prmCustomerID = new SqlParameter("@CustomerID", CustomerID);
                sqlComm.Parameters.Add(prmCustomerID);
                // Establishes a new data adapter
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlComm);


                // Data adapter fills the data table
                sqlDa.Fill(dtCustomerOrders);

                // Establishes that the data grid will be filled with data from the data table
                dgOrders.DataSource = dtCustomerOrders;
                // Sets text in the tbCustomerID Text box to equal the customer ID the is currently selected
                tbCustomerID.Text = CustomerID.ToString();

                // Clears text box upod new selection of a customer
                tbSalesID.Text = "";

            }
            catch (Exception ex)
            {
                // Error handeling
                MessageBox.Show(ex.Message, "Something with terribly wrong...");
            }

        }


        // Class for the combo box object
        public class cboObject
        {
            // Variable declaration
            int cID;
            string cName;
            // Method
            public cboObject(int CustomerID, string CustomerName)
            {
                // Variable declaration
                cID = CustomerID;
                cName = CustomerName;
            }

            public string CustomerName
            {
                // Gets the name provided by the method and sets the variable within the method to the name.
                get { return cName; }
                set { cName = value; }
            }

            public int CustomerID
            {
                // Gets the Customer ID provided by the method and cets the variable with the method
                get { return cID; }
                set { cID = value; }
            }

            public override string ToString()
            {
                // Returns the customer name as a string to the class... Form uses name to fill the combo box.
                return this.CustomerName;
            }
        }

        private void dgOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Takes the data from the first cell of the selected row on the data grid and puts
            // it into the text box for tbSalesID
            DataGridViewRow row = this.dgOrders.Rows[e.RowIndex];
            tbSalesID.Text = row.Cells[0].Value.ToString();
        }
    }
}



