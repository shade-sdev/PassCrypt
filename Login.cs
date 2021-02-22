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
    public partial class Login : Form
    {

        private readonly Functions functions = new Functions();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query1 = "SELECT * FROM [user] WHERE password = @password";
            SqlConnection conn1 = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd1 = new SqlCommand(query1, conn1);
            credentialcmd1.Parameters.AddWithValue("@password", functions.encryptPassword(txtPassword.Text));
            conn1.Open();
            SqlDataReader myReader = credentialcmd1.ExecuteReader();
            if (!myReader.HasRows)
            {
                MessageBox.Show("Invalid Password");
            } else
            {
                this.Hide();
                PassCrypt passCrypt = new PassCrypt();
                passCrypt.ShowDialog();
                this.Close();
            }
            conn1.Close();
        }
    }
}
