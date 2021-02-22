using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassCrypt
{
    public partial class Register : Form
    {
        private readonly Functions functions = new Functions();
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            string query1 = "SELECT * FROM [user]";
            SqlConnection conn1 = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd1 = new SqlCommand(query1, conn1);
            conn1.Open();
            SqlDataReader myReader = credentialcmd1.ExecuteReader();
            if (!myReader.HasRows)
            {
                string query = "INSERT INTO [user] (password) VALUES (@password)";
                SqlConnection conn = new SqlConnection(Constants.connectionString);
                SqlCommand credentialcmd = new SqlCommand(query, conn);
                credentialcmd.Parameters.AddWithValue("@password", functions.encryptPassword(txtPassword.Text));
                conn.Open();
                try
                {
                    credentialcmd.ExecuteNonQuery();
                    this.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                    this.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine(e);
                }
                conn.Close();
            } else
            {
                while (myReader.Read())
                {
                    Console.WriteLine("Already have a user " + myReader["password"]);
                }
         
            }
            conn1.Close();






        }
    }
}
