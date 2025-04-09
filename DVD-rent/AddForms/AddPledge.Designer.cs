
namespace DVD_rent
{
    partial class AddPledge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPledge));
            this.pledgeType = new System.Windows.Forms.ComboBox();
            this.series = new System.Windows.Forms.TextBox();
            this.numbers = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pledgeType
            // 
            this.pledgeType.FormattingEnabled = true;
            this.pledgeType.Location = new System.Drawing.Point(92, 18);
            this.pledgeType.Name = "pledgeType";
            this.pledgeType.Size = new System.Drawing.Size(121, 21);
            this.pledgeType.TabIndex = 0;
            this.pledgeType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // series
            // 
            this.series.Location = new System.Drawing.Point(92, 45);
            this.series.Name = "series";
            this.series.Size = new System.Drawing.Size(121, 20);
            this.series.TabIndex = 1;
            // 
            // numbers
            // 
            this.numbers.Location = new System.Drawing.Point(92, 71);
            this.numbers.Name = "numbers";
            this.numbers.Size = new System.Drawing.Size(121, 20);
            this.numbers.TabIndex = 2;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(92, 97);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(121, 20);
            this.price.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Вид залога:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Серия:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Номер:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Деньги:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddPledge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 162);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.price);
            this.Controls.Add(this.numbers);
            this.Controls.Add(this.series);
            this.Controls.Add(this.pledgeType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPledge";
            this.Text = "AddPledge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pledgeType;
        private System.Windows.Forms.TextBox series;
        private System.Windows.Forms.TextBox numbers;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}