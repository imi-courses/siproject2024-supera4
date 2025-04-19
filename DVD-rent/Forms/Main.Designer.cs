
namespace DVD_rent
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спискиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.арендToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассировToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильмовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.залогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.Report = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.спискиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // спискиToolStripMenuItem
            // 
            this.спискиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.арендToolStripMenuItem,
            this.кассировToolStripMenuItem,
            this.дисковToolStripMenuItem,
            this.клиентовToolStripMenuItem,
            this.фильмовToolStripMenuItem,
            this.залогToolStripMenuItem});
            this.спискиToolStripMenuItem.Name = "спискиToolStripMenuItem";
            this.спискиToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.спискиToolStripMenuItem.Text = "Списки";
            // 
            // арендToolStripMenuItem
            // 
            this.арендToolStripMenuItem.Name = "арендToolStripMenuItem";
            this.арендToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.арендToolStripMenuItem.Text = "Аренд";
            this.арендToolStripMenuItem.Click += new System.EventHandler(this.арендToolStripMenuItem_Click);
            // 
            // кассировToolStripMenuItem
            // 
            this.кассировToolStripMenuItem.Name = "кассировToolStripMenuItem";
            this.кассировToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.кассировToolStripMenuItem.Text = "Кассиров";
            this.кассировToolStripMenuItem.Click += new System.EventHandler(this.кассировToolStripMenuItem_Click);
            // 
            // дисковToolStripMenuItem
            // 
            this.дисковToolStripMenuItem.Name = "дисковToolStripMenuItem";
            this.дисковToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.дисковToolStripMenuItem.Text = "Дисков";
            this.дисковToolStripMenuItem.Click += new System.EventHandler(this.дисковToolStripMenuItem_Click);
            // 
            // клиентовToolStripMenuItem
            // 
            this.клиентовToolStripMenuItem.Name = "клиентовToolStripMenuItem";
            this.клиентовToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.клиентовToolStripMenuItem.Text = "Клиентов";
            this.клиентовToolStripMenuItem.Click += new System.EventHandler(this.клиентовToolStripMenuItem_Click);
            // 
            // фильмовToolStripMenuItem
            // 
            this.фильмовToolStripMenuItem.Name = "фильмовToolStripMenuItem";
            this.фильмовToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.фильмовToolStripMenuItem.Text = "Фильмов";
            this.фильмовToolStripMenuItem.Click += new System.EventHandler(this.фильмовToolStripMenuItem_Click);
            // 
            // залогToolStripMenuItem
            // 
            this.залогToolStripMenuItem.Name = "залогToolStripMenuItem";
            this.залогToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.залогToolStripMenuItem.Text = "Залог";
            this.залогToolStripMenuItem.Click += new System.EventHandler(this.залогToolStripMenuItem_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(94, 47);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(219, 75);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Отчёт";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Report
            // 
            this.Report.Location = new System.Drawing.Point(32, 111);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(262, 192);
            this.Report.TabIndex = 4;
            this.Report.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "DVD-rent";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спискиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem арендToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кассировToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дисковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильмовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem залогToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.RichTextBox Report;
    }
}

