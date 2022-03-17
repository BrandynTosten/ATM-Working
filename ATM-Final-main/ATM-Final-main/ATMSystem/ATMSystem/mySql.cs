using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem
{
    class mySql
    {
        //CONNECTION STRING
        private SqlConnection con = new SqlConnection("server=localhost;database=AccountingTracker;UID=sa;password=123456789");


        //--------------------------------INSERT QUERIES-----------------------------------------------
        public void InsertInto(string UserName, string Password, string FirstName, string LastName)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO UserInfo (UserName, Password, FirstName, LastName) VALUES (@UserName, @Password, @FirstName, @LastName)", con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ExpenseInsert(double amount, DateTime date, string description, string category, int userId)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Expense (ExAmount, ExDate, ExDescription, ExCategory, UserId) VALUES (@Amount, @date, @description, @category, @userId)", con);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@userId", userId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }



        //-------------------------------SELECT QUERIES-------------------------------------------------

        public bool SelectUser(string userName)
        {

            SqlCommand cmd2 = new SqlCommand("select * from UserInfo where UserName=@UserName", con);
            cmd2.Parameters.AddWithValue("@UserName", userName);

            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            if (dt.Rows.Count > 0)
            {
                con.Close();

                return true;
            }
            else
            {
                con.Close();
                return false;
            }



        }

        public DataTable IdentifierUser(string userName, string password)
        {

            SqlCommand cmd2 = new SqlCommand("select * from UserInfo where UserName=@UserName AND Password=@Password", con);
            cmd2.Parameters.AddWithValue("@UserName", userName);
            cmd2.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            if (dt.Rows.Count > 0)
            {
                con.Close();

                return dt;
            }
            else
            {
                con.Close();
                return dt;
            }



        }

        public DataTable GetExpenses(int UserId)
        {
            SqlCommand cmd2 = new SqlCommand("select ExAmount AS Amount,ExDate As Date, ExDescription As Description, ExCategory AS Category  from Expense where UserId =@userId", con);
            cmd2.Parameters.AddWithValue("@userId", UserId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            con.Close();
            return dt;


        }

      
    }
}
