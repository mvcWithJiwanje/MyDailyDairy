using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace MyDailyDairy.ConsoleApp
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

    }

    public class UserDetail
    {
        public int UserDetailID { get; set; }
        public string FirstName { get; set; }

    }

    public class UserDetailModel : User
    {
        public string FirstName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sconn = new SqlConnection(@"data source=.;initial catalog=nepselive;user id=sa;password=P@ssw0rd");

            //var reader = SqlHelper.ExecuteReader(sconn, CommandType.Text, "Select * from DatabaseLog");

            //while (reader.Read())
            //{
            //    Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            //}

            //var cmd = SqlHelper.CreateCommand(sconn, "IsMemberBroker", new string[] { "@memberId", "1" });


            var ds=SqlHelper.ExecuteDataset(sconn, "IsMemberBroker", new string[] { "@memberId"});

            Console.Read();

            User objUser = new User { UserId = 1, UserName = "user-01" };
            List<User> lstUser = new List<User> { new User { UserId = 2, UserName = "user003" }, new User { UserId = 3, UserName = "user004" } };
            lstUser.Add(objUser);

            UserDetail ud = new UserDetail();
            ud.UserDetailID = 1;
            ud.FirstName = "Nischal";

            UserDetail ud1 = new UserDetail();
            ud1.UserDetailID = 2;
            ud1.FirstName = "Prem";

            UserDetail ud3 = new UserDetail();
            ud3.UserDetailID = 3;
            ud3.FirstName = "Anushka";

            List<UserDetail> lstUserDetail = new List<UserDetail>();
            lstUserDetail.Add(ud);
            lstUserDetail.Add(ud1);
            lstUserDetail.Add(ud3);

            var resultSet = from x in lstUser
                            join y in lstUserDetail
                            on x.UserId equals y.UserDetailID
                            select new { x.UserName, y.FirstName };

            var resultSetModel = (from x in lstUser
                                 join y in lstUserDetail
                                 on x.UserId equals y.UserDetailID
                                 where x.UserId>1
                                 select new UserDetailModel
                                 {
                                     UserId = x.UserId,
                                     UserName = x.UserName,
                                     FirstName = y.FirstName
                                 }).ToList();

            
            //resultSetModel.Add(new UserDetailModel { UserId = 4, UserName = "", FirstName = "Ravi" });

            foreach (var item in resultSetModel)
            {
                Console.WriteLine(item.FirstName);
            }


            //foreach (var item in resultSet)
            //{
            //    Console.WriteLine(item.FirstName + "-" + item.UserName);
            //}

            Console.ReadLine();



            string connectionString = "server=blackperl;database=MyDailyDairy;user id =sa;password=P@ssw0rd;connection Timeout=10;";
            connectionString = "Data Source=.;Initial Catalog=MyDailyDairy;uid =sa;pwd=P@ssw0rd;Connect Timeout=10;";
            connectionString = "Address=localhost;Initial Catalog=MyDailyDairy;Trusted_Connection=yes;Connect Timeout=10;";
            //connectionString = "Address=techiesnepal.db.11365196.hostedresource.com;Initial Catalog=techiesnepal;uid =techiesnepal;pwd=Sagarmatha@123;Connect Timeout=10;";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            Console.WriteLine(conn.State.ToString());
            conn.Close();
            Console.Read();
            //SqlCommand cmd = new SqlCommand("select count(*) from dbo.Roles", conn);
            //var result = cmd.ExecuteScalar();
            //Console.WriteLine(result.ToString());

            //SqlCommand myCommand = new SqlCommand();
            //myCommand.Connection = conn;
            //myCommand.CommandText = "Insert into dbo.Roles(RoleName) values('Role-9')";
            //int rows = myCommand.ExecuteNonQuery();


            //SqlDataReader reader = null;
            //SqlCommand cmd = new SqlCommand("Select * from dbo.Roles", conn);
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.GetInt32(0));
            //    Console.WriteLine(reader.GetString(1));
            //    Console.WriteLine(reader["RoleID"].ToString());
            //}
            //conn.Close();
            //Console.WriteLine(conn.State.ToString());


            //string roleNme = "Role-0";
            //string strQuery = "select * from dbo.Roles where rolename=" + roleNme;
            //SqlCommand cmd = new SqlCommand(strQuery, conn);
            //cmd.ExecuteNonQuery();




            string qry = "Select * from dbo.Roles where roleid=@id";
            SqlParameter paramRoleName = new SqlParameter("@id", 15);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand sqlcmd = new SqlCommand(qry, con))
                {
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.Parameters.AddWithValue("@id", 15);
                    //sqlcmd.Parameters.Add(paramRoleName);

                    using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr.GetString(1));
                        }
                    }
                }
            }


            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                using (SqlCommand c = new SqlCommand("InserUserWithRole", cn))
                {
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("@UserName", SqlDbType.VarChar).Value = "user-001";
                    c.Parameters.AddWithValue("@RoleName", "Role-15");
                    c.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    c.Parameters.AddWithValue("@IsApproved", "true");
                    c.Parameters.AddWithValue("@Status", 2);

                    //SqlParameter NumTitles = testCMD.Parameters.Add("@numtitlesout", SqlDbType.VarChar, 11);
                    //NumTitles.Direction = ParameterDirection.Output;

                    int result = c.ExecuteNonQuery();
                }
            }



            Console.ReadLine();

        }
    }
}
