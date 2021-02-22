using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassCrypt
{
    public partial class PasswordHead : UserControl
    {
        public PasswordHead()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("User Click on control")]
        public event EventHandler controlClick;



        public string controlName
        {
            get
            {
                return this.Name;
            }
            set { this.Name = value; }
        }

        public System.Drawing.Color controlBG
        {
            get
            {
                return this.BackColor;
            }

            set
            {
                this.BackColor = value;
            }
        }

        public string titleLabel
        {
            get
            {
                return titleLbl.Text;
            }

            set
            {
                titleLbl.Text = value;
            }

        }

        public string usernameLabel
        {
            get
            {
                return usernameLbl.Text;
            }

            set
            {
                usernameLbl.Text = value;
            }
        }

        public Guna.UI.WinForms.GunaPictureBox passPic
        {
            get
            {
                return passIconPic;
            }

            set
            {
                passIconPic = value;
            }
        }

        public void PasswordHead_Click(object sender, EventArgs e)
        {
            this.controlClick?.Invoke(this, e);
        }

        

    }
}
