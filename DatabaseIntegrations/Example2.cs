using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Example2
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true");
            Console.WriteLine("Enter Eno: ");
            int eno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Ename: ");
            string ename = Console.ReadLine();
            Console.WriteLine("Enter Job: ");
            string job = Console.ReadLine();
            Console.WriteLine("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter DeptName: ");
            string dname = Console.ReadLine();

            string query = $"insert into Employee values({eno},'{ename}','{job}',{salary},'{dname}')";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i > 0)
            {
                Console.WriteLine("Record Inserted");
            }
            else
            {
                Console.WriteLine("Record not inserted");
            }


        }
    }
}
