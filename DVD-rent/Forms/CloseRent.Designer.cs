
namespace DVD_rent.Forms
{
    partial class CloseRent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseRent));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Fullname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_pledgeType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_PledgeData = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_closeRent = new System.Windows.Forms.Button();
            this.returnDate = new System.Windows.Forms.DateTimePicker();
            this.overdue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО клиента";
            // 
            // txt_Fullname
            // 
            this.txt_Fullname.Location = new System.Drawing.Point(135, 6);
            this.txt_Fullname.Name = "txt_Fullname";
            this.txt_Fullname.ReadOnly = true;
            this.txt_Fullname.Size = new System.Drawing.Size(212, 22);
            this.txt_Fullname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Срок сдачи до";
            // 
            // txt_pledgeType
            // 
            this.txt_pledgeType.Location = new System.Drawing.Point(135, 62);
            this.txt_pledgeType.Name = "txt_pledgeType";
            this.txt_pledgeType.ReadOnly = true;
            this.txt_pledgeType.Size = new System.Drawing.Size(212, 22);
            this.txt_pledgeType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Залог";
            // 
            // txt_PledgeData
            // 
            this.txt_PledgeData.Location = new System.Drawing.Point(353, 62);
            this.txt_PledgeData.Name = "txt_PledgeData";
            this.txt_PledgeData.ReadOnly = true;
            this.txt_PledgeData.Size = new System.Drawing.Size(212, 22);
            this.txt_PledgeData.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 322);
            this.dataGridView1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Диски";
            // 
            // btn_closeRent
            // 
            this.btn_closeRent.Location = new System.Drawing.Point(648, 87);
            this.btn_closeRent.Name = "btn_closeRent";
            this.btn_closeRent.Size = new System.Drawing.Size(140, 23);
            this.btn_closeRent.TabIndex = 9;
            this.btn_closeRent.Text = "Закрыть аренду";
            this.btn_closeRent.UseVisualStyleBackColor = true;
            this.btn_closeRent.Click += new System.EventHandler(this.btn_closeRent_Click);
            // 
            // returnDate
            // 
            this.returnDate.Location = new System.Drawing.Point(135, 34);
            this.returnDate.Name = "returnDate";
            this.returnDate.Size = new System.Drawing.Size(212, 22);
            this.returnDate.TabIndex = 10;
            // 
            // overdue
            // 
            this.overdue.AutoSize = true;
            this.overdue.Location = new System.Drawing.Point(353, 37);
            this.overdue.Name = "overdue";
            this.overdue.Size = new System.Drawing.Size(0, 17);
            this.overdue.TabIndex = 11;
            // 
            // CloseRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.overdue);
            this.Controls.Add(this.returnDate);
            this.Controls.Add(this.btn_closeRent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_PledgeData);
            this.Controls.Add(this.txt_pledgeType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Fullname);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CloseRent";
            this.Text = "Закрытие аренды";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Fullname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_pledgeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PledgeData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_closeRent;
        private System.Windows.Forms.DateTimePicker returnDate;
        private System.Windows.Forms.Label overdue;
    }
}