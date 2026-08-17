using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
// Necessary Libraries

namespace JobApplicationTracker
{
    // Main Form for the Job Application Tracker
    public partial class Form1 : Form
    {
        // List to hold the job applications in memory
        private List<JobApplication> applications;

        public Form1()
        {
            // Initialize the form components, load json data, and apply modern styles
            InitializeComponent();
            ApplyModernStyles();
            // Apply initial default theme(light mode)
            ThemeManager.ApplyTheme(this);
            LoadData();
            btnSave.Click += BtnSave_Click;
            btnThemeToggle.Click += BtnThemeToggle_Click;
        }

        // Method to apply modern styles to the form and its controls
        private void ApplyModernStyles()
        {
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.Text = "Job Application Tracker";

            // Set placeholder text for the input fields
            txtCompanyName.PlaceholderText = "e.g. Stripe, Inc.";
            txtJobTitle.PlaceholderText = "e.g. Junior Developer";
            txtLocation.PlaceholderText = "e.g. Tampere, Helsinki or Remote";

            
            btnThemeToggle.Text = "";
            btnThemeToggle.ImageAlign = ContentAlignment.MiddleCenter;
            btnThemeToggle.Cursor = Cursors.Hand;


            // iterate through all controls in the form and apply styles based on their type
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

            // Set properties for the Save button
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;

            // Set properties for the DataGridView to make it look clean
            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.BorderStyle = BorderStyle.None;
            dgvApplications.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.AllowUserToResizeRows = false;
            dgvApplications.AllowUserToOrderColumns = false;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set the header style for the DataGridView
            dgvApplications.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvApplications.ColumnHeadersHeight = 40;
            dgvApplications.RowTemplate.Height = 40;

            dgvApplications.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvApplications.ColumnHeadersDefaultCellStyle.BackColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor;


            if (!dgvApplications.Columns.Contains("EditColumn"))
            {
                DataGridViewImageColumn editCol = new DataGridViewImageColumn();
                editCol.Name = "EditColumn";
                editCol.HeaderText = "";
                editCol.Width = 35;
                editCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                editCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvApplications.Columns.Add(editCol);
            }

            if (!dgvApplications.Columns.Contains("DeleteColumn"))
            {
                DataGridViewImageColumn delCol = new DataGridViewImageColumn();
                delCol.Name = "DeleteColumn";
                delCol.HeaderText = "";
                delCol.Width = 35;
                delCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                delCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvApplications.Columns.Add(delCol);
            }

            dgvApplications.CellContentClick -= dgvApplications_CellContentClick;
            dgvApplications.CellContentClick += dgvApplications_CellContentClick;
        }

        private void dgvApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Check if your grid is bound to a list (e.g., BindingList<JobApplication>)
                if (dgvApplications.DataSource is BindingList<JobApplication> list)
                {
                    if (dgvApplications.Columns[e.ColumnIndex].Name == "DeleteColumn")
                    {
                        list.RemoveAt(e.RowIndex);
                    }
                    else if (dgvApplications.Columns[e.ColumnIndex].Name == "EditColumn")
                    {
                        JobApplication app = list[e.RowIndex];

                        txtCompanyName.Text = app.CompanyName;
                        txtJobTitle.Text = app.JobTitle;
                        txtLocation.Text = app.Location;

                        list.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    
                    if (dgvApplications.Columns[e.ColumnIndex].Name == "DeleteColumn")
                    {
                        dgvApplications.Rows.RemoveAt(e.RowIndex);
                    }
                    else if (dgvApplications.Columns[e.ColumnIndex].Name == "EditColumn")
                    {
                        DataGridViewRow row = dgvApplications.Rows[e.RowIndex];

                        txtCompanyName.Text = row.Cells[0].Value?.ToString();
                        txtJobTitle.Text = row.Cells[1].Value?.ToString();
                        txtLocation.Text = row.Cells[2].Value?.ToString();

                        dgvApplications.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void BtnThemeToggle_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();
            ThemeManager.ApplyTheme(this);
        }

        // Method to load job applications from the JSON file and refresh the DataGridView
        private void LoadData()
        {
            applications = DataManager.LoadApplications();
            RefreshGrid();
        }

        // Event handler for the Save button click event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Check if the required fields (Company Name and Job Title) are filled; if not, show a warning message
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) || string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                MessageBox.Show("Company Name and Job Title are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new JobApplication object with the data from the form1 fields
            JobApplication newApp = new JobApplication
            {
                CompanyName = txtCompanyName.Text,
                JobTitle = txtJobTitle.Text,
                Location = txtLocation.Text,
                WorkModel = cmbWorkModel.Text,
                ApplicationDate = dtpApplicationDate.Value,
                Status = cmbStatus.Text
            };

            // Add the new application to the list, save it to the JSON file, refresh the DataGridView, and clear the input fields
            applications.Add(newApp);
            DataManager.SaveApplications(applications);
            RefreshGrid();
            ClearFields();
        }

        // Method to refresh the DataGridView with the current list of job applications
        private void RefreshGrid()
        {
            dgvApplications.DataSource = null;
            dgvApplications.DataSource = applications;
            lblTotalCount.Text = $"{applications.Count} Applications Total";

            // Set the column headers for better readability
            if (dgvApplications.Columns["CompanyName"] != null)
            {
                dgvApplications.Columns["CompanyName"].HeaderText = "Company Name";
                dgvApplications.Columns["JobTitle"].HeaderText = "Role / Title";
                dgvApplications.Columns["Location"].HeaderText = "Location";
                dgvApplications.Columns["WorkModel"].HeaderText = "Working Method";
                dgvApplications.Columns["ApplicationDate"].HeaderText = "Date";
                dgvApplications.Columns["Status"].HeaderText = "Status";
            }
        }

        // Method to clear the input fields in the form1 after saving a job application
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