using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassCrypt
{
    public partial class AddCredential : Form
    {
        private readonly Functions functions = new Functions();
        public bool insert;
        public int updateId;
        public AddCredential()
        {
            InitializeComponent();

        }

        public void setInsert(bool insert)
        {
            this.insert = insert;
        }

        public void setUpdateId(int id)
        {
            this.updateId = id;
        }


        public void setForInsert()
        {
            lblTitle.Text = "ADD CREDENTIAL";
            btnAddCredential.Text = "Add";
        }

        public void setForUpdate()
        {
            lblTitle.Text = "UPDATE CREDENTIAL";
            btnAddCredential.Text = "Update";
        }

        private void btnAddCredential_Click(object sender, EventArgs e)
        {

            string errors = string.Empty;

            if (txtUsername.Text == string.Empty)
            {
                errors += "Username cannot be empty \n";
            }

            if (txtPassword.Text == string.Empty)
            {
                errors += "Password cannot be empty \n";
            }

            if (txtWebsiteName.Text == string.Empty)
            {
                errors += "Website name cannot be empty \n";
            }

            if (txtWebsiteUrl.Text == string.Empty)
            {
                errors += "Website Url cannot be empty \n";
            }

            if ((!txtWebsiteUrl.Text.Contains("https://")) && (!txtWebsiteUrl.Text.Contains("http://")))
            {
                errors += "Invalid Website, website must contain https:// or http:// \n";
            }

            if (errors != string.Empty)
            {
                MessageBox.Show(errors);
            }


            if (errors == string.Empty)
            {

           
            Console.WriteLine(updateId);
            if (insert == true)
            {
             
                List<KeyValuePair<string, string>> credential = new List<KeyValuePair<string, string>>();
                List<Credential> credentialObj = new List<Credential>

            {
                new Credential() {username = txtUsername.Text, password = functions.encryptPassword(txtPassword.Text), websitename = txtWebsiteName.Text, websiteurl= txtWebsiteUrl.Text, webiconurl = txtWebIconUrl.Text, notes = txtNotes.Text, type = cmbTypes.SelectedIndex}
            };

                foreach (var data in credentialObj)
                {

                    credential.Clear();
                    foreach (var item in data.GetType().GetProperties())
                    {
                        credential.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                    }
                }

                Console.WriteLine(functions.insertToDatabase(credential, "credential"));

                var passCryptForm = Application.OpenForms.OfType<PassCrypt>().FirstOrDefault();
                Thread thread = new Thread(passCryptForm.loadAllItemsGUI);
                thread.Start();
            } else
                if (insert == false)
            {

                List<KeyValuePair<string, string>> credential = new List<KeyValuePair<string, string>>();
                List<Credential> credentialObj = new List<Credential>

            {
                new Credential() {username = txtUsername.Text, password = functions.encryptPassword(txtPassword.Text), websitename = txtWebsiteName.Text, websiteurl= txtWebsiteUrl.Text, webiconurl = txtWebIconUrl.Text, notes = txtNotes.Text, type = cmbTypes.SelectedIndex}
            };

                foreach (var data in credentialObj)
                {

                    credential.Clear();
                    foreach (var item in data.GetType().GetProperties())
                    {
                        credential.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                    }
                }

                Console.WriteLine(functions.updateToDatabase(credential, "credential", updateId));
                var passCryptForm = Application.OpenForms.OfType<PassCrypt>().FirstOrDefault();
                Thread thread = new Thread(passCryptForm.loadAllItemsGUI);
                thread.Start();
          

            }
                errors = string.Empty;
            this.Close();
            }
        }

        private void AddCredential_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(insert);

                if (insert == true)
                {
                    setForInsert();
                }
                else
                    if (insert == false)
                {
                    setForUpdate();
                    List<Credential> cred = functions.selectFromDatabase(updateId.ToString(), "credential");
                    txtUsername.Text = cred.First().username.ToString();
                    txtPassword.Text = functions.decryptPassword(cred.First().password.ToString());
                    txtWebsiteName.Text = cred.First().websitename.ToString();
                    txtNotes.Text = cred.First().notes.ToString();
                    txtWebsiteUrl.Text = cred.First().websiteurl.ToString();
                    txtWebIconUrl.Text = cred.First().webiconurl.ToString();
                }
            } catch (Exception)
            {

            }
        
        }
    }
}
