using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DatabaseIntegrations
{
    class Example8
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath("D:\\Sessions\\US-OPT\\C#.Net\\DatabaseIntegrations\\DatabaseIntegrations")
                .AddJsonFile("appsettings.json").Build();
            string conStr = configuration.GetConnectionString("SqlConn");
            using(var connection = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Employee", connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Print the columns
                foreach(DataColumn col in dt.Columns)
                {
                    Console.Write($"{col.ColumnName,-10}");
                }
                Console.WriteLine();
                //Print Values/Data
                foreach(DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        Console.Write($"{item,-10}");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
