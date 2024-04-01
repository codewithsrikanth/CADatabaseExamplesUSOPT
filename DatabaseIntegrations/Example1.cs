using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Example1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Eno: ");
            int eno = Convert.ToInt32(Console.ReadLine());

            //Step-1: Establish the connection by using "SqlConnection"
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");

            //Step-2: Prepare the query and pass to the backend by using "SqlCommand" class
            SqlCommand cmd = new SqlCommand("delete from Employee where Eno="+eno, con);

            //Step-3: Open the connection
            con.Open();

            //Step-4: Execute the query
            int i = cmd.ExecuteNonQuery();

            //Step-5: Close the connection
            con.Close();

            if(i>0)
            {
                Console.WriteLine("Record Deleted");
            }
            else
            {
                Console.WriteLine("Record Not Deleted");
            }
        }
    }
}
