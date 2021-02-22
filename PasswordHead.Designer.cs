namespace PassCrypt
{
    partial class PasswordHead
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.passIconPic = new Guna.UI.WinForms.GunaPictureBox();
            this.titleLbl = new Guna.UI.WinForms.GunaLabel();
            this.usernameLbl = new Guna.UI.WinForms.GunaLabel();
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.passIconPic)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // passIconPic
            // 
            this.passIconPic.BackColor = System.Drawing.Color.Transparent;
            this.passIconPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.passIconPic.BaseColor = System.Drawing.Color.White;
            this.passIconPic.Location = new System.Drawing.Point(19, 15);
            this.passIconPic.Name = "passIconPic";
            this.passIconPic.Size = new System.Drawing.Size(40, 40);
            this.passIconPic.TabIndex = 0;
            this.passIconPic.TabStop = false;
            this.passIconPic.Click += new System.EventHandler(this.PasswordHead_Click);
            // 
            // titleLbl
            // 
            this.titleLbl.Font = new System.Drawing.Font("Roboto Bk", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.Color.White;
            this.titleLbl.Location = new System.Drawing.Point(79, 18);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(232, 21);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "Adobe";
            this.titleLbl.Click += new System.EventHandler(this.PasswordHead_Click);
            // 
            // usernameLbl
            // 
            this.usernameLbl.Font = new System.Drawing.Font("Roboto Bk", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.usernameLbl.Location = new System.Drawing.Point(79, 38);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(232, 15);
            this.usernameLbl.TabIndex = 2;
            this.usernameLbl.Text = "shade@shade.ga";
            this.usernameLbl.Click += new System.EventHandler(this.PasswordHead_Click);
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.Radius = 1;
            this.gunaElipse2.TargetControl = this.passIconPic;
            // 
            // PasswordHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.passIconPic);
            this.Name = "PasswordHead";
            this.Size = new System.Drawing.Size(339, 70);
            this.Click += new System.EventHandler(this.PasswordHead_Click);
            ((System.ComponentModel.ISupportInitialize)(this.passIconPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaLabel usernameLbl;
        private Guna.UI.WinForms.GunaLabel titleLbl;
        private Guna.UI.WinForms.GunaPictureBox passIconPic;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
    }
}
