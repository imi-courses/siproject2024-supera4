
namespace DVD_rent.Forms
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.label_login = new System.Windows.Forms.Label();
            this.label_pwd1 = new System.Windows.Forms.Label();
            this.label_pwd2 = new System.Windows.Forms.Label();
            this.label_fullName = new System.Windows.Forms.Label();
            this.fullName = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.pwd1 = new System.Windows.Forms.TextBox();
            this.pwd2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_registration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(235, 159);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(47, 17);
            this.label_login.TabIndex = 0;
            this.label_login.Text = "Логин";
            // 
            // label_pwd1
            // 
            this.label_pwd1.AutoSize = true;
            this.label_pwd1.Location = new System.Drawing.Point(235, 187);
            this.label_pwd1.Name = "label_pwd1";
            this.label_pwd1.Size = new System.Drawing.Size(57, 17);
            this.label_pwd1.TabIndex = 1;
            this.label_pwd1.Text = "Пароль";
            // 
            // label_pwd2
            // 
            this.label_pwd2.AutoSize = true;
            this.label_pwd2.Location = new System.Drawing.Point(235, 215);
            this.label_pwd2.Name = "label_pwd2";
            this.label_pwd2.Size = new System.Drawing.Size(63, 17);
            this.label_pwd2.TabIndex = 2;
            this.label_pwd2.Text = "Ещё раз";
            // 
            // label_fullName
            // 
            this.label_fullName.AutoSize = true;
            this.label_fullName.Location = new System.Drawing.Point(235, 131);
            this.label_fullName.Name = "label_fullName";
            this.label_fullName.Size = new System.Drawing.Size(42, 17);
            this.label_fullName.TabIndex = 3;
            this.label_fullName.Text = "ФИО";
            // 
            // fullName
            // 
            this.fullName.Location = new System.Drawing.Point(301, 128);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(200, 22);
            this.fullName.TabIndex = 4;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(301, 156);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(200, 22);
            this.login.TabIndex = 5;
            // 
            // pwd1
            // 
            this.pwd1.Location = new System.Drawing.Point(301, 184);
            this.pwd1.Name = "pwd1";
            this.pwd1.Size = new System.Drawing.Size(200, 22);
            this.pwd1.TabIndex = 6;
            this.pwd1.UseSystemPasswordChar = true;
            // 
            // pwd2
            // 
            this.pwd2.Location = new System.Drawing.Point(301, 212);
            this.pwd2.Name = "pwd2";
            this.pwd2.Size = new System.Drawing.Size(200, 22);
            this.pwd2.TabIndex = 7;
            this.pwd2.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Регистрация";
            // 
            // btn_registration
            // 
            this.btn_registration.Location = new System.Drawing.Point(384, 240);
            this.btn_registration.Name = "btn_registration";
            this.btn_registration.Size = new System.Drawing.Size(117, 23);
            this.btn_registration.TabIndex = 9;
            this.btn_registration.Text = "Регистрация";
            this.btn_registration.UseVisualStyleBackColor = true;
            this.btn_registration.Click += new System.EventHandler(this.btn_registration_Click);
            // 
            // registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_registration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pwd2);
            this.Controls.Add(this.pwd1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.fullName);
            this.Controls.Add(this.label_fullName);
            this.Controls.Add(this.label_pwd2);
            this.Controls.Add(this.label_pwd1);
            this.Controls.Add(this.label_login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "registration";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_pwd1;
        private System.Windows.Forms.Label label_pwd2;
        private System.Windows.Forms.Label label_fullName;
        private System.Windows.Forms.TextBox fullName;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox pwd1;
        private System.Windows.Forms.TextBox pwd2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_registration;
    }
}