using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace TestingConn
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            string connectionStr = "Data Source=DESKTOP-LI4SJSJ;Initial Catalog=MYDATABASE;Integrated Security=True";

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionStr;
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM MYTABLE";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1));
                        }
                    }
                    conn.Close();
                }
            }
            Console.ReadKey();
        }
    }
}
