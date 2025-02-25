
namespace DVD_rent
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.testingBox = new System.Windows.Forms.RichTextBox();
            this.execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testingBox
            // 
            this.testingBox.Location = new System.Drawing.Point(12, 12);
            this.testingBox.Name = "testingBox";
            this.testingBox.Size = new System.Drawing.Size(600, 96);
            this.testingBox.TabIndex = 1;
            this.testingBox.Text = "";
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(46, 137);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(97, 23);
            this.execute.TabIndex = 2;
            this.execute.Text = "Выполнить";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.testingBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox testingBox;
        private System.Windows.Forms.Button execute;
    }
}

