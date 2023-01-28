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
        
        private void button1_Click(object sender, EventArgs e)
        {
            //make the connection
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ExpenseTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            //open the connection
            con.Open();
            //make the insert query
            string insert = $"INSERT INTO Information(Type, Name, Date, Amount) VALUES ({type_comboBox.Text}, {date_txt.Text}, {name_txt.Text}, {decimal.Parse(amount_txt.Text)})";
            SqlCommand addingCommand = new SqlCommand(insert, con);
            //adding elements
            addingCommand.ExecuteNonQuery();
            //close the connection
            con.Close();
            string select = "SELECT * FROM Information";
            SqlCommand selecingCommand = new SqlCommand(select, con);
            SqlDataAdapter da = new SqlDataAdapter(selecingCommand);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ExpenseTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            string select = "SELECT * FROM Information";
            SqlCommand selecingCommand = new SqlCommand(select, con);
            SqlDataAdapter da = new SqlDataAdapter(selecingCommand);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ExpenseTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string delete = $"delete FROM Information where id={int.Parse(txtDelete.Text)}";
            SqlCommand deletingCommand = new SqlCommand(delete, con);
            deletingCommand.ExecuteNonQuery();
            con.Close();
            string select = "SELECT * FROM Information";
            SqlCommand selecingCommand = new SqlCommand(select, con);
            SqlDataAdapter da = new SqlDataAdapter(selecingCommand);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
