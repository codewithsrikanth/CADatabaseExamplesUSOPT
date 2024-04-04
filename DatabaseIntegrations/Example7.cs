using System.Data;
using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Example7
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            SqlCommand cmd = new SqlCommand("sp_Select", con);
            cmd.CommandType =  CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr =  cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Console.WriteLine($"{dr["Eno"]} -   {dr["Ename"]}   -   {dr["Job"]} -   {dr["Salary"]}  -   {dr["Dname"]}");
                }
            }
            else
            {
                Console.WriteLine("No Record(s) Found");
            }

            con.Close();
        }
    }
}
