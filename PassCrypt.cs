

using Microsoft.VisualBasic.FileIO;
using PassCrypt.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassCrypt
{
   
    public partial class PassCrypt : Form
    {
        private readonly Functions functions = new Functions();
        bool passwordHidden = true;
        int currentId = 0;
        int menuTracker = 1;
        public PassCrypt()
        {
            InitializeComponent();
            this.searchBox.GotFocus += searchBoxOnFocus;
            this.searchBox.LostFocus += searchBoxLostFocus;
            this.Opacity = 0.0;



        }

        public delegate void serviceGUIDelegate();

        public delegate void serviceGUIDelegate2(FlowLayoutPanel flpmain, PasswordHead ph);
        public void loadAllItemsGUI()
        {
            this.Invoke(new serviceGUIDelegate(loadAllItems));
        }

   

        public void loadFavItemsGUI()
        {
            this.Invoke(new serviceGUIDelegate(loadFavItems));
        }

        public void loadDelItemsGUI()
        {
            this.Invoke(new serviceGUIDelegate(loadDelItems));
        }


        public void loadSearchItemsGUI()
        {
            this.Invoke(new serviceGUIDelegate(loadSearchItems));
        }




        public void loadDelItems()
        {



            foreach (Control item in flpMain.Controls.OfType<PasswordHead>())
            {
                flpMain.Controls.Remove(item);
            }

            flpMain.Controls.Clear();




            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand("SELECT * FROM credential WHERE status = @status ORDER BY websitename ASC", conn);
            credentialcmd.Parameters.AddWithValue("@status", 0);
            PasswordHead ph;
            conn.Open();
            using (SqlDataReader readCredentials = credentialcmd.ExecuteReader())
            {
                while (readCredentials.Read())
                {


                    ph = new PasswordHead();
                    ph.Name = readCredentials["id"].ToString();
                    ph.controlClick += new EventHandler(user_click);
                    ph.DoubleClick += new EventHandler(user_doubleclick);
                    ph.titleLabel = readCredentials["websitename"].ToString();
                    ph.usernameLabel = readCredentials["username"].ToString();
                    ph.passPic.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (readCredentials["webiconurl"].ToString() == string.Empty)
                    {



                        pictureBoxThread(ph.passPic, readCredentials["websiteurl"].ToString());
                    }
                    else
                    {
                        ph.passPic.ImageLocation = readCredentials["webiconurl"].ToString();
                    }


                    addControlToFlowPanelThread(flpMain, ph);

                }
            }
            conn.Close();
        }

        private void user_doubleclick(object sender, EventArgs e)
        {
            var passHead = (PasswordHead)sender;
            functions.restoreFromDatabase("credential", int.Parse(passHead.Name));
            flpMain.Controls.Remove(passHead);
        }

        public void loadFavItems()
        {



            foreach (Control item in flpMain.Controls.OfType<PasswordHead>())
            {
                flpMain.Controls.Remove(item);
            }

            flpMain.Controls.Clear();




            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand("SELECT * FROM credential WHERE status = @status AND fav = @fav ORDER BY websitename ASC", conn);
            credentialcmd.Parameters.AddWithValue("@fav", 1);
            credentialcmd.Parameters.AddWithValue("@status", 1);
            PasswordHead ph;
            conn.Open();
            using (SqlDataReader readCredentials = credentialcmd.ExecuteReader())
            {
                while (readCredentials.Read())
                {


                    ph = new PasswordHead();
                    ph.Name = readCredentials["id"].ToString();
                    ph.controlClick += new EventHandler(user_click);
                    ph.titleLabel = readCredentials["websitename"].ToString();
                    ph.usernameLabel = readCredentials["username"].ToString();
                    ph.passPic.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (readCredentials["webiconurl"].ToString() == string.Empty)
                    {
                        pictureBoxThread(ph.passPic, readCredentials["websiteurl"].ToString());
                    }
                    else
                    {
                        ph.passPic.ImageLocation = readCredentials["webiconurl"].ToString();
                    }


                    addControlToFlowPanelThread(flpMain, ph);

                }
            }
            conn.Close();
        }

        public void loadAllItems()
        {
          

           
                foreach (Control item in flpMain.Controls.OfType<PasswordHead>())
                {
                    flpMain.Controls.Remove(item);
                }

                    flpMain.Controls.Clear();
           



            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand("SELECT * FROM credential WHERE status = @status ORDER BY websitename ASC", conn);
            credentialcmd.Parameters.AddWithValue("@status", 1);
            PasswordHead ph;
            conn.Open();
            using (SqlDataReader readCredentials = credentialcmd.ExecuteReader())
            {
                while (readCredentials.Read())
                {
                   
                    
                        ph = new PasswordHead();
                    ph.Name = readCredentials["id"].ToString();
                    ph.controlClick += new EventHandler(user_click);
                        ph.titleLabel = readCredentials["websitename"].ToString();
                        ph.usernameLabel = readCredentials["username"].ToString();
                        ph.passPic.SizeMode = PictureBoxSizeMode.StretchImage;

                        if (readCredentials["webiconurl"].ToString() == string.Empty)
                        {

                        pictureBoxThread(ph.passPic, readCredentials["websiteurl"].ToString());
             
                        } else
                        {
                            ph.passPic.ImageLocation = readCredentials["webiconurl"].ToString();
                        }


                    //flpMain.Controls.Add(ph);
                    addControlToFlowPanelThread(flpMain, ph);
               
                }
            }
            conn.Close();
            this.Opacity = 100.0;
        }

        public Thread addControlToFlowPanelThread(FlowLayoutPanel flpmain, PasswordHead ph)
        {


            var t = new Thread(() => addControlToFlowPanel(flpmain, ph));
            t.Start();
            return t;
        }

        void addControlToFlowPanel(FlowLayoutPanel flpmain, PasswordHead ph)
        {
            if (InvokeRequired)
            {
                Invoke(new serviceGUIDelegate2(addControlToFlowPanel), flpmain, ph);
                return;
            }


            flpmain.Controls.Add(ph);

        }
  

        public Thread pictureBoxThread(Guna.UI.WinForms.GunaPictureBox param1, string param2)
        {

            try
            {
                Uri myUri = new Uri(param2);
                string host = myUri.Host;
                string favicon = "https://" + host + "/favicon.ico";
                var t = new Thread(() => setPictureBox(param1, favicon));
                t.Start();
              
            } catch (Exception)
            {
              
            }
            return null;
        }


        public void loadSearchItems()
        {



            foreach (Control item in flpMain.Controls.OfType<PasswordHead>())
            {
                flpMain.Controls.Remove(item);
            }

            flpMain.Controls.Clear();




            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand("SELECT * FROM credential WHERE (username LIKE @username OR websitename LIKE @websitename)  ORDER BY websitename ASC", conn);
            credentialcmd.Parameters.AddWithValue("@username", searchBox.Text + "%");
            credentialcmd.Parameters.AddWithValue("@websitename", searchBox.Text + "%");
            PasswordHead ph;
            conn.Open();
            using (SqlDataReader readCredentials = credentialcmd.ExecuteReader())
            {
                while (readCredentials.Read())
                {


                    ph = new PasswordHead();
                    ph.Name = readCredentials["id"].ToString();
                    ph.controlClick += new EventHandler(user_click);
                    ph.titleLabel = readCredentials["websitename"].ToString();
                    ph.usernameLabel = readCredentials["username"].ToString();
                    ph.passPic.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (readCredentials["webiconurl"].ToString() == string.Empty)
                    {
                        pictureBoxThread(ph.passPic, readCredentials["websiteurl"].ToString());
                    }
                    else
                    {
                        ph.passPic.ImageLocation = readCredentials["webiconurl"].ToString();
                    }


                    addControlToFlowPanelThread(flpMain, ph);

                }
            }
            conn.Close();
        }

        public void setPictureBox(Guna.UI.WinForms.GunaPictureBox ph, string path)
        {
            ph.ImageLocation = path;
        }

        private void searchBoxLostFocus(object sender, EventArgs e)
        {
            if (searchBox.Text == string.Empty)
            searchBox.Text = "Search Vault";
        }

        private void searchBoxOnFocus(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search Vault" && searchBox.Text != string.Empty)
            searchBox.Text = null;
        }

        private void menuBtnClick(object sender, EventArgs e)
        {
            var btn = (Guna.UI.WinForms.GunaAdvenceButton)sender;
            functions.btnsToMain(allItemsBtn, favBtn, trashBtn);
            btn.BaseColor = System.Drawing.Color.FromArgb(23, 93, 220);

            if (btn.Name == "allItemsBtn")
            {
                Thread thread = new Thread(loadAllItemsGUI);
                thread.Start();
                menuTracker = 1;
            } else
                if (btn.Name == "trashBtn")
            {
                Thread thread = new Thread(loadDelItemsGUI);
                thread.Start();
                menuTracker = 3;
            }
            else 
                if (btn.Name == "favBtn")
            {
                Thread thread = new Thread(loadFavItemsGUI);
                thread.Start();
                menuTracker = 2;
            }
        }

     

        private void user_click(object sender, EventArgs e)
        {
            var passHead = (PasswordHead)sender;
       
           foreach(PasswordHead passwordHead in flpMain.Controls)
            {
                passwordHead.controlBG = System.Drawing.Color.FromArgb(30, 30, 30);
            }
                passHead.controlBG = System.Drawing.Color.FromArgb(23, 93, 220);

            string credentialId = passHead.Name;

            List<Credential> cred = functions.selectFromDatabase(credentialId, "credential");


            rightIconPic.BackgroundImage = null;
            rightIconPic.SizeMode = PictureBoxSizeMode.StretchImage;

            if (cred.First().webiconurl == string.Empty)
            {
                Uri myUri = new Uri(cred.First().websiteurl.ToString());
                string host = myUri.Host;


                rightIconPic.ImageLocation = "https://" + host + "/favicon.ico";
            } else
            {
                rightIconPic.ImageLocation = cred.First().webiconurl;
            }

       
            txtRightUsername.Text = cred.First().username;
            txtRightPassword.Text = functions.decryptPassword(cred.First().password);
            if (cred.First().type == 1)
            {
                txtRightType.Text = "Login";
            }
            txtRightTitle.Text = cred.First().websitename;
            txtRightWebsite.Text = cred.First().websiteurl;
            txtRightNote.Text = cred.First().notes;
            currentId = int.Parse(passHead.Name);
            string result = functions.getCredentialFavStatus("credential", currentId);
            if (result == "1")
            {
                favPic.BackgroundImage = Resources.icons8_star_48px;
            } else
                if (result == "0")
            {
                favPic.BackgroundImage = Resources.icons8_star_48pxbl;
            }
      
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddCredential addCredential = new AddCredential();
            addCredential.setInsert(true);
            addCredential.ShowDialog();
  
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
         if (passwordHidden == false)
            {
              
                passwordHidden = true;

                txtRightPassword.PasswordChar = '●';
            }
            else
                if (passwordHidden == true)
            {
                passwordHidden = false;
                txtRightPassword.PasswordChar = '\0';
               

            }

            txtRightPassword.UseSystemPasswordChar = passwordHidden;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (currentId == 0)
            {

            } else
            {
                try
                {
                    AddCredential addCredential = new AddCredential();
                    addCredential.setUpdateId(currentId);
                    addCredential.setInsert(false);
                    addCredential.ShowDialog();
                }
                catch (Exception)
                {
                    Console.WriteLine(e);
                }
            }
         
       
       

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            try
            {
                functions.deleteFromDatabase("credential", currentId);
                Thread thread = new Thread(loadAllItemsGUI);
                thread.Start();
            } catch(Exception)
            {
                Console.WriteLine(e);
            }
        
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".csv";
            ofd.Filter = "Comma Separated (*.csv)|*.csv";
            ofd.ShowDialog();
            path = ofd.FileName;
            Console.WriteLine(path);

       try
            {

     
            DataTable csvData = new DataTable();
            using (TextFieldParser csvReader = new TextFieldParser(path))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }
                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();

                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
   
            foreach (DataRow dataRow in csvData.Rows)
            {

                int columnCount = dataRow.Table.Columns.Count;

                if (columnCount == 4)
                {
                    List<KeyValuePair<string, string>> credential = new List<KeyValuePair<string, string>>();

                    List<Credential> credentialObj = new List<Credential>
                      {
                new Credential() {username = dataRow["username"].ToString(), password = functions.encryptPassword(dataRow["password"].ToString()), websitename = dataRow["name"].ToString(), websiteurl= dataRow["url"].ToString(), webiconurl = "", notes = "", type = 0}
            };
                    foreach (var data in credentialObj)
                    {

                        credential.Clear();
                        foreach (var item in data.GetType().GetProperties())
                        {
                            credential.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                        }
                    }

                   functions.insertToDatabase(credential, "credential");
                } else

                if (columnCount == 10)
                {
                    List<KeyValuePair<string, string>> credential = new List<KeyValuePair<string, string>>();

                    List<Credential> credentialObj = new List<Credential>
                      {
                new Credential() {username = dataRow["username"].ToString(), password = dataRow["password"].ToString(), websitename = dataRow["websitename"].ToString(), websiteurl= dataRow["websiteurl"].ToString(), webiconurl = dataRow["webiconurl"].ToString(), notes = dataRow["notes"].ToString(), type = int.Parse(dataRow["type"].ToString())}
            };
                    foreach (var data in credentialObj)
                    {

                        credential.Clear();
                        foreach (var item in data.GetType().GetProperties())
                        {
                            credential.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                        }
                    }

                functions.insertToDatabase(credential, "credential");
                }

            

            }

                Thread thread = new Thread(loadAllItemsGUI);
                thread.Start();
            } catch
            {

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM credential";
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = credentialcmd.ExecuteReader();
            string date = DateTime.Now.ToString("yyyyMMddTHHmmss");
            Console.WriteLine(date);
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "/PassCrypt" +date+".csv";
            StreamWriter sw = new StreamWriter(filename);
            object[] output = new object[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; i++)
                output[i] = reader.GetName(i);
         
            sw.WriteLine(string.Join(",", output));

            while (reader.Read())
            {
 
                reader.GetValues(output);
                sw.WriteLine(string.Join(",", output));
            }

            sw.Close();
            reader.Close();
            conn.Close();
            MessageBox.Show("Exported to your Desktop!");
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Thread thread = new Thread(loadSearchItemsGUI);
                thread.Start();
            }
        }

        private void btnCopyUsername_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText(txtRightUsername.Text);
            } catch(Exception)
            {
                Console.WriteLine(e);
            }
     
        }

        private void btnCopyWebsiteUrl_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText(txtRightWebsite.Text);
            }
            catch (Exception)
            {
                Console.WriteLine(e);
            }

        }

        private void btnPasswordCopy_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText(txtRightPassword.Text);
            }
            catch (Exception)
            {
                Console.WriteLine(e);
            }
         
        }

        private void favPic_Click(object sender, EventArgs e)
        {
            try
            {
                string result = functions.favToDatabase("credential", currentId);
                
                if (result == "1")
                {
                    favPic.BackgroundImage = Resources.icons8_star_48pxbl;
                    if (menuTracker == 2)
                    {
                        foreach (Control item in flpMain.Controls.OfType<PasswordHead>())
                        {
                            if (item.Name == currentId.ToString())
                            {
                                flpMain.Controls.Remove(item);
                            }

                        }
                    }
                }
                else
              if (result == "0")
                {
                    favPic.BackgroundImage = Resources.icons8_star_48px;
                }
            } catch (Exception)
            {
                Console.WriteLine(e);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            functions.restoreFromDatabase("credential", currentId);
            if (menuTracker == 3)
            {
                foreach (Control item in flpMain.Controls.OfType<PasswordHead>())
                {
                    if (item.Name == currentId.ToString())
                    {
                        flpMain.Controls.Remove(item);
                    }

                }
            }
         

     
        }

        private void PassCrypt_Load(object sender, EventArgs e)
        {
         
            Thread thread = new Thread(loadAllItemsGUI);
            thread.Start();

           

        }

      
    }
}
