using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Example3
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");

            Console.WriteLine("Enter Eno: ");
            int eno = Convert.ToInt32(Console.ReadLine());

            string query = "select Ename from Employee where Eno="+eno;
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            object ename =  cmd.ExecuteScalar();
            con.Close();
            Console.WriteLine("Ename is: "+ename);

        }
    }
}
