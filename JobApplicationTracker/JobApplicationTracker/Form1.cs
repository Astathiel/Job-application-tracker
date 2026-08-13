using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JobApplicationTracker
{
    public partial class Form1 : Form
    {
        private List<JobApplication> applications;

        public Form1()
        {
            InitializeComponent();
            ApplyModernStyles();
            LoadData();
        }

        private void ApplyModernStyles()
        {
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }

            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = Color.FromArgb(33, 33, 33);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;

            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.BackgroundColor = Color.White;
            dgvApplications.BorderStyle = BorderStyle.None;
            dgvApplications.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvApplications.GridColor = Color.FromArgb(230, 230, 230);
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.AllowUserToResizeRows = false;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvApplications.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
            dgvApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvApplications.ColumnHeadersHeight = 40;

            dgvApplications.DefaultCellStyle.BackColor = Color.White;
            dgvApplications.DefaultCellStyle.ForeColor = Color.Black;
            dgvApplications.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245);
            dgvApplications.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvApplications.RowTemplate.Height = 40;
        }

        private void LoadData()
        {
            applications = DataManager.LoadApplications();
            RefreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) || string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                MessageBox.Show("Company Name and Job Title are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            JobApplication newApp = new JobApplication
            {
                CompanyName = txtCompanyName.Text,
                JobTitle = txtJobTitle.Text,
                Location = txtLocation.Text,
                WorkModel = cmbWorkModel.Text,
                ApplicationDate = dtpApplicationDate.Value,
                Status = cmbStatus.Text
            };

            applications.Add(newApp);
            DataManager.SaveApplications(applications);
            RefreshGrid();
            ClearFields();
        }

        private void RefreshGrid()
        {
            dgvApplications.DataSource = null;
            dgvApplications.DataSource = applications;
        }

        private void ClearFields()
        {
            txtCompanyName.Clear();
            txtJobTitle.Clear();
            txtLocation.Clear();
            cmbWorkModel.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dtpApplicationDate.Value = DateTime.Now;
        }
    }
}