using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Expense_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //make the connection
        //connectionString to my db(ExpenseTracker)
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ExpenseTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        //method for sql crud operations(without select) and updating the db
        public void SqlCommand(string querry, SqlConnection con)
        {
            SqlCommand querryCommand = new SqlCommand(querry, con);

            //adding elements
            querryCommand.ExecuteNonQuery();

            //SqlDataAdapter - works as a bridge between DataTable and Server
            //It is used to fill the DataTable and update the data source
            SqlDataAdapter da = new SqlDataAdapter(querryCommand);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        //select method
        public void Select()
        {
            //make the select query
            string select = "SELECT * FROM Information";
            SqlCommand selecingCommand = new SqlCommand(select, con);

            //fill the DataTable and update the data source
            SqlDataAdapter da = new SqlDataAdapter(selecingCommand);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //opening the connection
            con.Open();

            //make the insert query
            string insert = $"INSERT INTO Information(Type, Name, Date, Amount) VALUES ({type_comboBox.Text}, {date_txt.Text}, {name_txt.Text}, {decimal.Parse(amount_txt.Text)})";
            
            //insert
            SqlCommand(insert,con);

            //closing the connection
            con.Close();

            //selecting the table automatically after we insert an element
            Select(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //selecting the table
            Select();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //opening the connection
            con.Open();

            //make the insert query
            string delete = $"delete FROM Information where id={int.Parse(txtDelete.Text)}";

            //delete
            SqlCommand(delete, con);

            //closing the connection
            con.Close();

            //select after deleting
            Select();
        }
    }
}
