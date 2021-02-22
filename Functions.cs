using PassCrypt.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassCrypt
{
    class Functions
    {

        public void btnsToMain(Guna.UI.WinForms.GunaAdvenceButton allitems, Guna.UI.WinForms.GunaAdvenceButton fav, Guna.UI.WinForms.GunaAdvenceButton trash)
        {
            allitems.BaseColor = System.Drawing.Color.FromArgb(40, 40, 40);
            fav.BaseColor = System.Drawing.Color.FromArgb(40, 40, 40);
            trash.BaseColor = System.Drawing.Color.FromArgb(40, 40, 40);
        }


        public string insertToDatabase(List<KeyValuePair<string, string>> credential, string table)
        {
            string dataFields = null;
            string data = null;
           
            foreach (var item in credential)
            {
                dataFields += item.Key;
                dataFields += ", ";
                data += "@" + item.Key;
                data += ", ";
            }
            dataFields = dataFields.Remove(dataFields.Length - 2, 2);
            data = data.Remove(data.Length - 2, 2);

            string query = "INSERT INTO " + table + " (" + dataFields + ") VALUES (" + data + ")";

            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);

            foreach (var item in credential)
            {
            credentialcmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }

            conn.Open();
            credentialcmd.ExecuteNonQuery();
            conn.Close();
            return query;
            
        }

        public string restoreFromDatabase(string table, int id)
        {
            string query = "UPDATE " + table + " SET status = @status WHERE id = @id";
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
            credentialcmd.Parameters.AddWithValue("@status", 1);
            credentialcmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            credentialcmd.ExecuteNonQuery();
            conn.Close();
            return query;
        }

        public string deleteFromDatabase(string table, int id)
        {
            string query = "UPDATE " + table + " SET status = @status WHERE id = @id";
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
            credentialcmd.Parameters.AddWithValue("@status", 0);
            credentialcmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            credentialcmd.ExecuteNonQuery();
            conn.Close();
            return query;
        }

        public string favToDatabase(string table, int id)
        {
            string result = "";
            string query1 = "SELECT * FROM credential WHERE id = @id";
            SqlConnection conn1 = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd1 = new SqlCommand(query1, conn1);
            credentialcmd1.Parameters.AddWithValue("@id", id);
            conn1.Open();
            SqlDataReader myReader = credentialcmd1.ExecuteReader();
            while (myReader.Read())
            {

                result = myReader["fav"].ToString();
            if (myReader["fav"].ToString() == "0")
                {
                    string query = "UPDATE " + table + " SET fav = @fav WHERE id = @id";
                    SqlConnection conn = new SqlConnection(Constants.connectionString);
                    SqlCommand credentialcmd = new SqlCommand(query, conn);
                    credentialcmd.Parameters.AddWithValue("@fav", 1);
                    credentialcmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    credentialcmd.ExecuteNonQuery();
                    conn.Close();
                } else
                    if (myReader["fav"].ToString() == "1")
                {
                    string query = "UPDATE " + table + " SET fav = @fav WHERE id = @id";
                    SqlConnection conn = new SqlConnection(Constants.connectionString);
                    SqlCommand credentialcmd = new SqlCommand(query, conn);
                    credentialcmd.Parameters.AddWithValue("@fav", 0);
                    credentialcmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    credentialcmd.ExecuteNonQuery();
                    conn.Close();
                }
          

            }

            conn1.Close();


           
            return result;
        }

        public string updateToDatabase(List<KeyValuePair<string, string>> credential, string table, int id)
        {

            string dataFields = null;

            foreach (var item in credential)
            {
                dataFields += item.Key + " = @" + item.Key;
                dataFields += ", ";

            }
            dataFields = dataFields.Remove(dataFields.Length - 2, 2);
            string query = "UPDATE " + table + " SET " + dataFields + " WHERE id = @id";

            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
            credentialcmd.Parameters.AddWithValue("@id", id);
            foreach (var item in credential)
            {
                credentialcmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }

            conn.Open();
            credentialcmd.ExecuteNonQuery();
            conn.Close();
            return query;
       
        }

        public List<Credential> selectFromDatabase(string id, string table)
        {
            string query = "SELECT * FROM " + table + " WHERE id = @id";
            var listCredential = new List<Credential>();
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
         
            credentialcmd.Parameters.AddWithValue("@id", id);

            conn.Open();


            using (SqlDataReader readCredentials = credentialcmd.ExecuteReader())
            {
                while (readCredentials.Read())
                {

                    var cred = new Credential();
                    cred.username = readCredentials["username"].ToString();
                    cred.password = readCredentials["password"].ToString();
                    cred.websitename = readCredentials["websitename"].ToString();
                 
                        cred.webiconurl = readCredentials["webiconurl"].ToString();
                   
                    cred.type = (int)readCredentials["type"];
                    cred.notes = readCredentials["notes"].ToString();
                    cred.websiteurl = readCredentials["websiteurl"].ToString();
                    listCredential.Add(cred);
                }
            }
                    conn.Close();
            return listCredential;
      
        }

        public string getCredentialFavStatus(string table, int id)
        {
            string result = "";
            string query = "SELECT * FROM " + table + " WHERE id = @id";
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
            credentialcmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader myReader = credentialcmd.ExecuteReader();
            while (myReader.Read())
            {
                result = myReader["fav"].ToString();
            }
            return result;

        }

        public List<Credential> selectFavFromDatabase(string id, string table)
        {
            string query = "SELECT * FROM " + table + " WHERE id = @id AND status = @status AND fav = @fav ORDER BY websitename ASC";
            var listCredential = new List<Credential>();
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
            credentialcmd.Parameters.AddWithValue("@status", 1);
            credentialcmd.Parameters.AddWithValue("@id", id);
            credentialcmd.Parameters.AddWithValue("@fav", 1);
            conn.Open();


            using (SqlDataReader readCredentials = credentialcmd.ExecuteReader())
            {
                while (readCredentials.Read())
                {

                    var cred = new Credential();
                    cred.username = readCredentials["username"].ToString();
                    cred.password = readCredentials["password"].ToString();
                    cred.websitename = readCredentials["websitename"].ToString();
                    if (readCredentials["webiconurl"].ToString() == string.Empty)
                    {

                        cred.webiconurl = readCredentials["websiteurl"] + "/favicon.ico";
                    }
                    else
                    {
                        cred.webiconurl = readCredentials["webiconurl"].ToString();
                    }
                    cred.type = (int)readCredentials["type"];
                    cred.notes = readCredentials["notes"].ToString();
                    cred.websiteurl = readCredentials["websiteurl"].ToString();
                    listCredential.Add(cred);
                }
            }
            conn.Close();
            return listCredential;

        }

        public string decryptPassword(string cipherText)
        {
            var key = Resources.key;
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string encryptPassword(string plainText)
        {
            var key = Resources.key;
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }


    }




       class Credential
        {
            public string username { get; set; }
            public string password { get; set; }
            public string websitename { get; set; }
            public string websiteurl { get; set; }
            public string webiconurl { get; set; }
            public string notes { get; set; }
            public int type { get; set; }
        }
}
