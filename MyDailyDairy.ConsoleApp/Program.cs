using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MyDailyDairy.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=blackperl;database=MyDailyDairy;user id =sa;password=P@ssw0rd;connection Timeout=10;";
            connectionString = "Data Source=.;Initial Catalog=MyDailyDairy;uid =sa;pwd=P@ssw0rd;Connect Timeout=10;";
            connectionString = "Address=localhost;Initial Catalog=MyDailyDairy;Trusted_Connection=yes;Connect Timeout=10;";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            Console.WriteLine(conn.State.ToString());

            //SqlCommand cmd = new SqlCommand("select count(*) from dbo.Roles", conn);
            //var result = cmd.ExecuteScalar();
            //Console.WriteLine(result.ToString());

            //SqlCommand myCommand = new SqlCommand();
            //myCommand.Connection = conn;
            //myCommand.CommandText = "Insert into dbo.Roles(RoleName) values('Role-9')";
            //int rows = myCommand.ExecuteNonQuery();


            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("Select * from dbo.Roles", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader["RoleID"].ToString());
            }
            conn.Close();
            Console.WriteLine(conn.State.ToString());
            Console.ReadLine();

        }
    }
}
