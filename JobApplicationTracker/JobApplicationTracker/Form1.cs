using System;
using System.Collections.Generic;
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
            LoadData();
        }

        // Method to apply modern styles to the form and its controls
        private void ApplyModernStyles()
        {
            // Set the form's background color and font
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            // Sets the form window name
            this.Text = "Job Application Tracker";

            // Placeholder text for the input fields to guide the user
            txtCompanyName.PlaceholderText = "e.g. Stripe, Inc.";
            txtJobTitle.PlaceholderText = "e.g. Junior Developer";
            txtLocation.PlaceholderText = "e.g. Tampere, Helsinki or Remote";

            // Loop through all controls in the form and apply styles based on their type
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

            // Style the Save button with a flat appearance and custom colors
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = Color.FromArgb(33, 33, 33);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;

            // Style the DataGridView for a modern look
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