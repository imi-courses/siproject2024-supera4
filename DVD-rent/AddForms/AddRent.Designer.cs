
namespace DVD_rent.AddForms
{
    partial class AddRent
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
            this.ButtonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rentDate = new System.Windows.Forms.DateTimePicker();
            this.returnDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.TextBox();
            this.Client = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseClient = new System.Windows.Forms.Button();
            this.choosePledge = new System.Windows.Forms.Button();
            this.Pledge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseDisks = new System.Windows.Forms.Button();
            this.DVDs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(326, 230);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(99, 23);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Дата возвращения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Дата аренды";
            // 
            // rentDate
            // 
            this.rentDate.Location = new System.Drawing.Point(225, 60);
            this.rentDate.Name = "rentDate";
            this.rentDate.Size = new System.Drawing.Size(200, 22);
            this.rentDate.TabIndex = 16;
            // 
            // returnDate
            // 
            this.returnDate.Location = new System.Drawing.Point(225, 88);
            this.returnDate.Name = "returnDate";
            this.returnDate.Size = new System.Drawing.Size(200, 22);
            this.returnDate.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Цена";
            // 
            // money
            // 
            this.money.Location = new System.Drawing.Point(225, 116);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(200, 22);
            this.money.TabIndex = 20;
            // 
            // Client
            // 
            this.Client.Location = new System.Drawing.Point(225, 144);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(200, 22);
            this.Client.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Клиент";
            // 
            // chooseClient
            // 
            this.chooseClient.Location = new System.Drawing.Point(431, 144);
            this.chooseClient.Name = "chooseClient";
            this.chooseClient.Size = new System.Drawing.Size(75, 23);
            this.chooseClient.TabIndex = 23;
            this.chooseClient.Text = "Выбрать";
            this.chooseClient.UseVisualStyleBackColor = true;
            this.chooseClient.Click += new System.EventHandler(this.chooseClient_Click);
            // 
            // choosePledge
            // 
            this.choosePledge.Location = new System.Drawing.Point(431, 173);
            this.choosePledge.Name = "choosePledge";
            this.choosePledge.Size = new System.Drawing.Size(75, 23);
            this.choosePledge.TabIndex = 29;
            this.choosePledge.Text = "Выбрать";
            this.choosePledge.UseVisualStyleBackColor = true;
            this.choosePledge.Click += new System.EventHandler(this.choosePledge_Click);
            // 
            // Pledge
            // 
            this.Pledge.Location = new System.Drawing.Point(225, 173);
            this.Pledge.Name = "Pledge";
            this.Pledge.Size = new System.Drawing.Size(200, 22);
            this.Pledge.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Залог";
            // 
            // chooseDisks
            // 
            this.chooseDisks.Location = new System.Drawing.Point(431, 201);
            this.chooseDisks.Name = "chooseDisks";
            this.chooseDisks.Size = new System.Drawing.Size(75, 23);
            this.chooseDisks.TabIndex = 32;
            this.chooseDisks.Text = "Выбрать";
            this.chooseDisks.UseVisualStyleBackColor = true;
            this.chooseDisks.Click += new System.EventHandler(this.chooseDisks_Click);
            // 
            // DVDs
            // 
            this.DVDs.Location = new System.Drawing.Point(225, 201);
            this.DVDs.Name = "DVDs";
            this.DVDs.Size = new System.Drawing.Size(200, 22);
            this.DVDs.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Диски";
            // 
            // AddRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 316);
            this.Controls.Add(this.chooseDisks);
            this.Controls.Add(this.DVDs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.choosePledge);
            this.Controls.Add(this.Pledge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chooseClient);
            this.Controls.Add(this.Client);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.money);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.returnDate);
            this.Controls.Add(this.rentDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ButtonSave);
            this.Name = "AddRent";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker rentDate;
        private System.Windows.Forms.DateTimePicker returnDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox money;
        private System.Windows.Forms.TextBox Client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseClient;
        private System.Windows.Forms.Button choosePledge;
        private System.Windows.Forms.TextBox Pledge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chooseDisks;
        private System.Windows.Forms.TextBox DVDs;
        private System.Windows.Forms.Label label7;
    }
}