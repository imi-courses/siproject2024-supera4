﻿namespace DVD_rent
{
    partial class ClientList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reload = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 369);
            this.dataGridView1.TabIndex = 0;
            // 
            // reload
            // 
            this.reload.Location = new System.Drawing.Point(12, 415);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(98, 23);
            this.reload.TabIndex = 4;
            this.reload.Text = "Обновить";
            this.reload.UseVisualStyleBackColor = true;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(357, 415);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(98, 23);
            this.delete.TabIndex = 5;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(586, 415);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(98, 23);
            this.add.TabIndex = 6;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(690, 415);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(98, 23);
            this.close.TabIndex = 7;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(461, 415);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(119, 23);
            this.edit.TabIndex = 8;
            this.edit.Text = "Редактировать";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(253, 415);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(98, 23);
            this.btnChoose.TabIndex = 19;
            this.btnChoose.Text = "Выбрать";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // search
            // 
            this.search.ForeColor = System.Drawing.Color.Gray;
            this.search.Location = new System.Drawing.Point(12, 12);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(649, 22);
            this.search.TabIndex = 20;
            this.search.Text = "Поиск";
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.Enter += new System.EventHandler(this.search_Enter);
            this.search.Leave += new System.EventHandler(this.search_Leave);
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(667, 10);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 24);
            this.type.TabIndex = 21;
            // 
            // ClientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.type);
            this.Controls.Add(this.search);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.close);
            this.Controls.Add(this.add);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.reload);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientList";
            this.Text = "Список клиентов";
            this.Load += new System.EventHandler(this.ClientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button reload;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ComboBox type;
    }
}