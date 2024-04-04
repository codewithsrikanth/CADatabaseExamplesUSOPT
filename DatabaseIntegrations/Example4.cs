using System.Data.SqlClient;

namespace DatabaseIntegrations
{
    class Example4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Have you registered? (Yes/No)");
            string regChoice = Console.ReadLine();
            if (regChoice.ToLower() == "yes")
            {
                Console.WriteLine("Enter Username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();
                bool loginResponse = Login(username, password);
                if(loginResponse == true)
                {
                    //Employee Table
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Credentials");                    
                }
            }
            else if (regChoice.ToLower() == "no")
            {
                //Registration
                Console.WriteLine("Enter Firstname: ");
                string firstname = Console.ReadLine();
                Console.WriteLine("Enter LastName: ");
                string lastname = Console.ReadLine();
                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string password = Console.ReadLine();
                Console.WriteLine("Enter DateOfBirth: ");
                DateTime dob = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter State: ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter City: ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter Pincode: ");
                string pincode = Console.ReadLine();
                Console.WriteLine("Enter Phone Number: ");
                string phoneNum = Console.ReadLine();
                bool regResponce = Registration(firstname, lastname, email, password, dob, state, city, pincode, phoneNum);

            }
        }
        static bool Login(string username, string password)
        {
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            string query = $"select count(*) from Registration where Email='{username}' and Password='{password}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int recFound = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            if(recFound > 0)
                return true;
            else
                return false;
        }
        static bool Registration(string fname, string lname, string email, string password, DateTime dob, string state, string city, string pincode, string phonenum)
        {
            return true;
        }
    }
}
