using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Example9
    {
        static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath("D:\\Sessions\\US-OPT\\C#.Net\\DatabaseIntegrations\\DatabaseIntegrations")
               .AddJsonFile("appsettings.json").Build();
            string conStr = configuration.GetConnectionString("SqlConn");
            return conStr;
        }
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Employee",con);
                da.Fill(dt);
            }
            DisplayDataTable(dt);

            //Insert a new row to the data table
            DataRow newRow = dt.NewRow();
            Console.WriteLine("Enter Employee Details: ");
            newRow["Eno"] = Convert.ToInt32(Console.ReadLine());
            newRow["Ename"] = Console.ReadLine();
            newRow["Job"] = Console.ReadLine();
            newRow["Salary"] = Convert.ToDouble(Console.ReadLine());
            newRow["Dname"] = Console.ReadLine();
            dt.Rows.Add(newRow);
            Console.WriteLine("Record Inserted into Data Table");
            DisplayDataTable(dt);

            //Update
            DataRow rowToUpdate = dt.Rows[0];
            rowToUpdate["Ename"] = "Srikanth Rallabandi";
            Console.WriteLine("Record Updated in Datatable");
            //DisplayDataTable(dt);

            //Delete
            DataRow rowToDelete = dt.Rows[7];
            rowToDelete.Delete();
            Console.WriteLine("Record Updated in Datatable");
            //DisplayDataTable(dt);

            using(SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using(SqlCommandBuilder bldr = new SqlCommandBuilder())
                {
                    bldr.DataAdapter = new SqlDataAdapter("select * from Employee", con);
                    SqlDataAdapter da = bldr.DataAdapter as SqlDataAdapter;
                    da.Update(dt);
                }
            }
            Console.WriteLine("Records Updated to DB");
            DisplayDataTable(dt);
            Console.Read();

        }

        private static void DisplayDataTable(DataTable dt)
        {
            //Print the columns
            foreach (DataColumn col in dt.Columns)
            {
                Console.Write($"{col.ColumnName,-10}");
            }
            Console.WriteLine();
            //Print Values/Data
            foreach (DataRow row in dt.Rows)
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
