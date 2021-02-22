using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassCrypt
{
    class Constants
    {

       public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory + @"\PassCrypt.mdf;Integrated Security=True;Encrypt=False";        
       // public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shade\source\repos\PassCrypt\PassCrypt.mdf;Integrated Security=True";

    }
}
