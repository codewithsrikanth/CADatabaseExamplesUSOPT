using System.Data;
using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Employee
    {
        public int Eno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string Dname { get; set; }
    }
    class Example6
    {        
        static void Main(string[] args)
        {
            Employee emp = GetEmpDetails();
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");            
            //SqlCommand cmd = new SqlCommand("sp_InsertRec", con);
            //SqlCommand cmd = new SqlCommand("sp_UpdateRec", con);
            SqlCommand cmd = new SqlCommand("sp_DeleteRec", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eno", emp.Eno);
            //cmd.Parameters.AddWithValue("@ename", emp.Ename);
            //cmd.Parameters.AddWithValue("@job", emp.Job);
            //cmd.Parameters.AddWithValue("@salary", emp.Salary);
            //cmd.Parameters.AddWithValue("@dname", emp.Dname);
            con.Open();
            int rec = cmd.ExecuteNonQuery();
            con.Close();
            if(rec > 0 )
            {
                //Console.WriteLine("Record Inserted");
                //Console.WriteLine("Record Updated");
                Console.WriteLine("Record Deleted");
            }
            else
            {
                //Console.WriteLine("Record Not Inserted");
                //Console.WriteLine("Record Not Updated");
                Console.WriteLine("Record Not Deleted");
            }
        }
        static Employee GetEmpDetails()
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter Employee Details: ");
            emp.Eno = Convert.ToInt32(Console.ReadLine());
            //emp.Ename = Console.ReadLine();
            //emp.Job = Console.ReadLine();
            //emp.Salary = Convert.ToDouble(Console.ReadLine());
            //emp.Dname = Console.ReadLine();
            return emp;
        }
    }
}
