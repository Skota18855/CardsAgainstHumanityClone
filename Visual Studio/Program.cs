using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CardsAgainstHumanityClone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Trying to Connect to Database
            //try
            //{
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = "userprofiles.database.windows.net";
            //    builder.UserID = "admin1";
            //    builder.Password = "AdminPowers321";
            //    builder.InitialCatalog = "UserProfiles";


            //    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //    {
            //        Console.WriteLine("\nQuery data example:");
            //        Console.WriteLine("=========================================\n");

            //        StringBuilder sb = new StringBuilder();
            //        sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
            //        String sql = sb.ToString();

            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            connection.Open();
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //Console.ReadLine();
            #endregion
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
