using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassCrypt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string query1 = "SELECT * FROM [user]";
            SqlConnection conn1 = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd1 = new SqlCommand(query1, conn1);
            conn1.Open();
            SqlDataReader myReader = credentialcmd1.ExecuteReader();
            if (!myReader.HasRows)
            {
                Application.Run(new Register());
            } else
            {
                Application.Run(new Login());
            }
            conn1.Close();

          
            
        }
    }
}
