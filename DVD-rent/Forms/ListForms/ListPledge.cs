﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DVD_rent.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVD_rent.Models;

namespace DVD_rent
{

    public partial class PledgeList : Form
    {
        public string ChoosenPledgeId;

        public PledgeList()
        {
            string[] types = { "PledgeType", "Series", "Number", "Money", "RentId" };
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("PledgeType", "Тип залога");
            dataGridView1.Columns.Add("Series", "Серия");
            dataGridView1.Columns.Add("Number", "Номер");
            dataGridView1.Columns.Add("Money", "Деньги");
            dataGridView1.Columns.Add("RentId", "RentId");
            type.Items.AddRange(types);
            type.SelectedIndex = 0;
            type.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddPledge addPledge = new AddPledge();
            addPledge.ShowDialog();
            ReloadGridView();
        }
        public void ReloadGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (Pledge pledge in PledgeController.GetAllPledges())
            {
                dataGridView1.Rows.Add(pledge.Id, pledge.PledgeType, pledge.Series, pledge.Number, pledge.Money, pledge.Rents.Any() ? pledge.Rents.ToArray()[0].Id : -1);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите для удаления");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить?",
                "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount > 0)
                    {
                        for (int i = 0; i < selectedRowCount; i++)
                        {
                            PledgeController.DeletePledgeById(int.Parse(dataGridView1.SelectedRows[i].Cells["Id"].Value.ToString()));
                        }
                    }
                    ReloadGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите для редактирования");
                return;
            }

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                AddPledge addPledge = new AddPledge(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                addPledge.ShowDialog();
                ReloadGridView();
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text != "Поиск" && search.ForeColor != Color.Gray)
            {

                string searchText = search.Text.Trim();
                List<Pledge> filteredPledges = new List<Pledge>();
                
                if (string.IsNullOrEmpty(searchText))
                {
                    ReloadGridView();
                    return;
                }

                if (type.SelectedItem.ToString() == "PledgeType")
                {
                    filteredPledges = PledgeController.GetAllPledges()
                    .Where(p =>
                        p.PledgeType.ToString().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Series")
                {
                    filteredPledges = PledgeController.GetAllPledges()
                    .Where(p =>
                        p.Series.ToString().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Number")
                {
                    filteredPledges = PledgeController.GetAllPledges()
                    .Where(p =>
                        p.Number.ToString().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "Money")
                {
                    filteredPledges = PledgeController.GetAllPledges()
                    .Where(p =>
                        p.Money.ToString().Contains(searchText)
                    )
                    .ToList();
                }
                else if (type.SelectedItem.ToString() == "RentId")
                {
                    filteredPledges = PledgeController.GetAllPledges()
                    .Where(p =>
                        p.Rents.Any() && p.Rents.First().Id.ToString().Contains(searchText)
                    )
                    .ToList();
                }
                dataGridView1.Rows.Clear();
                foreach (Pledge pledge in filteredPledges)
                {
                    dataGridView1.Rows.Add(pledge.Id, pledge.PledgeType, pledge.Series, pledge.Number, pledge.Money, pledge.Rents.Any() ? pledge.Rents.ToArray()[0].Id : -1);
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void search_Enter(object sender, EventArgs e)
        {
            if (search.ForeColor == Color.Gray)
            {
                search.Text = "";
                search.ForeColor = SystemColors.WindowText;
            }
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                search.Text = "Поиск";
                search.ForeColor = Color.Gray;
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                ChoosenPledgeId = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                this.Close();
            }
        }

        private void PledgeList_Load(object sender, EventArgs e)
        {
            ReloadGridView();
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
