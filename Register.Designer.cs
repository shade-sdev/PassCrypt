namespace PassCrypt
{
    partial class Register
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.rightPanel = new Guna.UI.WinForms.GunaPanel();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.mainCloseBtn = new Guna.UI.WinForms.GunaControlBox();
            this.lblSubTitle = new Guna.UI.WinForms.GunaLabel();
            this.lblTitle = new Guna.UI.WinForms.GunaLabel();
            this.leftPanel = new Guna.UI.WinForms.GunaPanel();
            this.btnRegister = new Guna.UI.WinForms.GunaAdvenceButton();
            this.lblMasterPassword = new Guna.UI.WinForms.GunaLabel();
            this.txtPassword = new Guna.UI.WinForms.GunaTextBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.rightPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rightPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightPanel.BackgroundImage")));
            this.rightPanel.Controls.Add(this.gunaControlBox1);
            this.rightPanel.Controls.Add(this.mainCloseBtn);
            this.rightPanel.Controls.Add(this.lblSubTitle);
            this.rightPanel.Controls.Add(this.lblTitle);
            this.rightPanel.Location = new System.Drawing.Point(458, -5);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(682, 632);
            this.rightPanel.TabIndex = 0;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.Animated = true;
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox1.IconColor = System.Drawing.Color.White;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(624, 2);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(93)))), ((int)(((byte)(220)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(28, 29);
            this.gunaControlBox1.TabIndex = 18;
            // 
            // mainCloseBtn
            // 
            this.mainCloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCloseBtn.Animated = true;
            this.mainCloseBtn.AnimationHoverSpeed = 0.07F;
            this.mainCloseBtn.AnimationSpeed = 0.03F;
            this.mainCloseBtn.IconColor = System.Drawing.Color.White;
            this.mainCloseBtn.IconSize = 15F;
            this.mainCloseBtn.Location = new System.Drawing.Point(652, 2);
            this.mainCloseBtn.Name = "mainCloseBtn";
            this.mainCloseBtn.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(93)))), ((int)(((byte)(220)))));
            this.mainCloseBtn.OnHoverIconColor = System.Drawing.Color.White;
            this.mainCloseBtn.OnPressedColor = System.Drawing.Color.Black;
            this.mainCloseBtn.Size = new System.Drawing.Size(30, 29);
            this.mainCloseBtn.TabIndex = 17;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.White;
            this.lblSubTitle.Location = new System.Drawing.Point(96, 312);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(220, 25);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Register to get started";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Roboto Lt", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(93, 252);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(502, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FIRST TIME REGISTRATION";
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.leftPanel.Controls.Add(this.btnRegister);
            this.leftPanel.Controls.Add(this.lblMasterPassword);
            this.leftPanel.Controls.Add(this.txtPassword);
            this.leftPanel.Location = new System.Drawing.Point(-1, -2);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(461, 629);
            this.leftPanel.TabIndex = 1;
            // 
            // btnRegister
            // 
            this.btnRegister.AnimationHoverSpeed = 0.07F;
            this.btnRegister.AnimationSpeed = 0.03F;
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRegister.BorderColor = System.Drawing.Color.Black;
            this.btnRegister.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnRegister.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnRegister.CheckedForeColor = System.Drawing.Color.White;
            this.btnRegister.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.CheckedImage")));
            this.btnRegister.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnRegister.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegister.FocusedColor = System.Drawing.Color.Empty;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.Image")));
            this.btnRegister.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRegister.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRegister.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnRegister.Location = new System.Drawing.Point(50, 316);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.OnHoverBaseColor = System.Drawing.Color.Black;
            this.btnRegister.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRegister.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRegister.OnHoverImage = null;
            this.btnRegister.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnRegister.OnPressedColor = System.Drawing.Color.Black;
            this.btnRegister.Radius = 3;
            this.btnRegister.Size = new System.Drawing.Size(366, 35);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblMasterPassword
            // 
            this.lblMasterPassword.AutoSize = true;
            this.lblMasterPassword.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterPassword.Location = new System.Drawing.Point(48, 241);
            this.lblMasterPassword.Name = "lblMasterPassword";
            this.lblMasterPassword.Size = new System.Drawing.Size(98, 14);
            this.lblMasterPassword.TabIndex = 4;
            this.lblMasterPassword.Text = "Master Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BaseColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.BorderSize = 1;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPassword.FocusedBorderColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.FocusedForeColor = System.Drawing.Color.DimGray;
            this.txtPassword.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(50, 261);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Radius = 4;
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(366, 32);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.leftPanel;
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = this.rightPanel;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 625);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.rightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaPanel rightPanel;
        private Guna.UI.WinForms.GunaLabel lblSubTitle;
        private Guna.UI.WinForms.GunaLabel lblTitle;
        private Guna.UI.WinForms.GunaPanel leftPanel;
        private Guna.UI.WinForms.GunaTextBox txtPassword;
        private Guna.UI.WinForms.GunaLabel lblMasterPassword;
        private Guna.UI.WinForms.GunaAdvenceButton btnRegister;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI.WinForms.GunaControlBox mainCloseBtn;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
    }
}