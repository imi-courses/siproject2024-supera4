
namespace DVD_rent
{
    partial class PledgeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PledgeList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.reload = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(582, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(435, 359);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(74, 19);
            this.add.TabIndex = 1;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(515, 359);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(74, 19);
            this.close.TabIndex = 2;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(355, 359);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(74, 19);
            this.delete.TabIndex = 3;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // reload
            // 
            this.reload.Location = new System.Drawing.Point(6, 359);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(74, 19);
            this.reload.TabIndex = 4;
            this.reload.Text = "Обновить";
            this.reload.UseVisualStyleBackColor = true;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(275, 359);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(74, 19);
            this.edit.TabIndex = 5;
            this.edit.Text = "Редактировать";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // search
            // 
            this.search.ForeColor = System.Drawing.Color.Gray;
            this.search.Location = new System.Drawing.Point(6, 6);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(582, 20);
            this.search.TabIndex = 6;
            this.search.Text = "Поиск";
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.Enter += new System.EventHandler(this.search_Enter);
            this.search.Leave += new System.EventHandler(this.search_Leave);
            // 
            // PledgeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 387);
            this.Controls.Add(this.search);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.reload);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.close);
            this.Controls.Add(this.add);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PledgeList";
            this.Text = "PledgeList";
            this.Load += new System.EventHandler(this.Form_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button reload;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.TextBox search;
    }
}