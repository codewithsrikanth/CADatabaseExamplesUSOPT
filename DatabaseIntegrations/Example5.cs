using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Example5
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            SqlCommand cmd = new SqlCommand("select * from Employee", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Console.WriteLine($"{dr["Eno"]} -   {dr["Ename"]}   -   {dr["Job"]} -   {dr["Salary"]}  -   {dr["Dname"]}");
                }
            }
            else
            {
                Console.WriteLine("No Record(s) Available");
            }
            con.Close();
            
        }
    }
}
