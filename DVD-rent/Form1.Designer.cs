
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спискиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.арендToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассировToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильмовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.черныйСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.залогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
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
            this.черныйСписокToolStripMenuItem,
            this.залогToolStripMenuItem});
            this.спискиToolStripMenuItem.Name = "спискиToolStripMenuItem";
            this.спискиToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.спискиToolStripMenuItem.Text = "Списки";
            // 
            // арендToolStripMenuItem
            // 
            this.арендToolStripMenuItem.Name = "арендToolStripMenuItem";
            this.арендToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.арендToolStripMenuItem.Text = "Аренд";
            // 
            // кассировToolStripMenuItem
            // 
            this.кассировToolStripMenuItem.Name = "кассировToolStripMenuItem";
            this.кассировToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.кассировToolStripMenuItem.Text = "Кассиров";
            this.кассировToolStripMenuItem.Click += new System.EventHandler(this.кассировToolStripMenuItem_Click);
            // 
            // дисковToolStripMenuItem
            // 
            this.дисковToolStripMenuItem.Name = "дисковToolStripMenuItem";
            this.дисковToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.дисковToolStripMenuItem.Text = "Дисков";
            this.дисковToolStripMenuItem.Click += new System.EventHandler(this.дисковToolStripMenuItem_Click);
            // 
            // клиентовToolStripMenuItem
            // 
            this.клиентовToolStripMenuItem.Name = "клиентовToolStripMenuItem";
            this.клиентовToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.клиентовToolStripMenuItem.Text = "Клиентов";
            this.клиентовToolStripMenuItem.Click += new System.EventHandler(this.клиентовToolStripMenuItem_Click);
            // 
            // фильмовToolStripMenuItem
            // 
            this.фильмовToolStripMenuItem.Name = "фильмовToolStripMenuItem";
            this.фильмовToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.фильмовToolStripMenuItem.Text = "Фильмов";
            this.фильмовToolStripMenuItem.Click += new System.EventHandler(this.фильмовToolStripMenuItem_Click);
            // 
            // черныйСписокToolStripMenuItem
            // 
            this.черныйСписокToolStripMenuItem.Name = "черныйСписокToolStripMenuItem";
            this.черныйСписокToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.черныйСписокToolStripMenuItem.Text = "Черный список";
            // 
            // залогToolStripMenuItem
            // 
            this.залогToolStripMenuItem.Name = "залогToolStripMenuItem";
            this.залогToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.залогToolStripMenuItem.Text = "Залог";
            this.залогToolStripMenuItem.Click += new System.EventHandler(this.залогToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
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
        private System.Windows.Forms.ToolStripMenuItem черныйСписокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem залогToolStripMenuItem;
    }
}

