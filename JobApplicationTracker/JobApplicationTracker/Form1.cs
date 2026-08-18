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

        private List<JobApplication> applications;
        private ContextMenuStrip filterMenu;
        private string sortColumn = "";
        private bool sortAscending = true;

        public Form1()
        {
            // Initialize the form components, load json data, and apply modern styles
            InitializeComponent();
            ApplyModernStyles();
            InitializeFilterMenu();
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

            if (this.Controls.ContainsKey("btnFilter"))
            {
                btnFilter.FlatStyle = FlatStyle.Flat;
                btnFilter.FlatAppearance.BorderSize = 1;
                btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                btnFilter.Cursor = Cursors.Hand;
                btnFilter.Click += btnFilter_Click;
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

            dgvApplications.AutoGenerateColumns = false;
            dgvApplications.Columns.Clear();

            DataGridViewTextBoxColumn colCompany = new DataGridViewTextBoxColumn();
            colCompany.DataPropertyName = "CompanyName";
            colCompany.HeaderText = "Company Name";
            dgvApplications.Columns.Add(colCompany);

            DataGridViewTextBoxColumn colTitle = new DataGridViewTextBoxColumn();
            colTitle.DataPropertyName = "JobTitle";
            colTitle.HeaderText = "Role / Title";
            dgvApplications.Columns.Add(colTitle);

            DataGridViewTextBoxColumn colLocation = new DataGridViewTextBoxColumn();
            colLocation.DataPropertyName = "Location";
            colLocation.HeaderText = "Location";
            dgvApplications.Columns.Add(colLocation);

            DataGridViewTextBoxColumn colMethod = new DataGridViewTextBoxColumn();
            colMethod.DataPropertyName = "WorkModel";
            colMethod.HeaderText = "Working Method";
            dgvApplications.Columns.Add(colMethod);

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.DataPropertyName = "ApplicationDate";
            colDate.HeaderText = "Date";
            dgvApplications.Columns.Add(colDate);

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            dgvApplications.Columns.Add(colStatus);

            DataGridViewImageColumn editCol = new DataGridViewImageColumn();
            editCol.Name = "EditColumn";
            editCol.HeaderText = "";
            editCol.Width = 35;
            editCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvApplications.Columns.Add(editCol);

            DataGridViewImageColumn delCol = new DataGridViewImageColumn();
            delCol.Name = "DeleteColumn";
            delCol.HeaderText = "";
            delCol.Width = 35;
            delCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            delCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvApplications.Columns.Add(delCol);

            dgvApplications.CellContentClick -= dgvApplications_CellContentClick;
            dgvApplications.CellContentClick += dgvApplications_CellContentClick;
        }

        private void InitializeFilterMenu()
        {
            filterMenu = new ContextMenuStrip();
            filterMenu.Font = new Font("Segoe UI", 9.5F);

            // 1. Status Filters Category
            ToolStripMenuItem statusMenu = new ToolStripMenuItem("Filter by Status");
            string[] statuses = { "Applied", "Pending", "Interview", "Offer", "Rejected" };
            foreach (string status in statuses)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(status);
                item.CheckOnClick = true;
                item.CheckedChanged += FilterItem_CheckedChanged;
                statusMenu.DropDownItems.Add(item);
            }
            filterMenu.Items.Add(statusMenu);

            // Work Model Filters Category
            ToolStripMenuItem modelMenu = new ToolStripMenuItem("Filter by Work Model");
            string[] models = { "Remote", "Hybrid", "On-site" };
            foreach (string model in models)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(model);
                item.CheckOnClick = true;
                item.CheckedChanged += FilterItem_CheckedChanged;
                modelMenu.DropDownItems.Add(item);
            }
            filterMenu.Items.Add(modelMenu);

            // 3. Clear Filters Button
            filterMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem clearItem = new ToolStripMenuItem("Clear All Filters");
            clearItem.Click += (s, e) => { ClearAllFilters(); };
            filterMenu.Items.Add(clearItem);
        }

        private void ClearAllFilters()
        {
            // Iterate through main menu categories (Status, Work Model)
            foreach (ToolStripItem mainItem in filterMenu.Items)
            {
                if (mainItem is ToolStripMenuItem categoryMenu && categoryMenu.HasDropDownItems)
                {
                    // Iterate through and uncheck all sub-items
                    foreach (ToolStripItem subItem in categoryMenu.DropDownItems)
                    {
                        if (subItem is ToolStripMenuItem checkableItem)
                        {
                            checkableItem.CheckedChanged -= FilterItem_CheckedChanged;
                            checkableItem.Checked = false;
                            checkableItem.CheckedChanged += FilterItem_CheckedChanged;
                        }
                    }
                }
            }
            RefreshGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterMenu.Show(btnFilter, new Point(0, btnFilter.Height));
        }

        private void FilterItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem checkedItem = sender as ToolStripMenuItem;

            // If the user just checked an item, force all other items in that specific sub-menu to uncheck
            if (checkedItem != null && checkedItem.Checked)
            {
                ToolStripDropDownItem parentMenu = checkedItem.OwnerItem as ToolStripDropDownItem;
                if (parentMenu != null)
                {
                    foreach (ToolStripItem otherItem in parentMenu.DropDownItems)
                    {
                        if (otherItem is ToolStripMenuItem menuItem && menuItem != checkedItem)
                        {
                            // Temporarily detach the event to prevent an infinite loop of refreshes
                            menuItem.CheckedChanged -= FilterItem_CheckedChanged;
                            menuItem.Checked = false;
                            menuItem.CheckedChanged += FilterItem_CheckedChanged;
                        }
                    }
                }
            }

            RefreshGrid();
        }

        private void DgvApplications_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clickedColumn = dgvApplications.Columns[e.ColumnIndex].DataPropertyName;

            if (string.IsNullOrEmpty(clickedColumn)) return;

            if (sortColumn == clickedColumn)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                sortColumn = clickedColumn;
                sortAscending = true;
            }

            RefreshGrid();
        }

        private void dgvApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string colName = dgvApplications.Columns[e.ColumnIndex].Name;

                if (colName == "DeleteColumn" || colName == "EditColumn")
                {
                    var app = dgvApplications.Rows[e.RowIndex].DataBoundItem as JobApplication;

                    if (app != null)
                    {
                        if (colName == "EditColumn")
                        {
                            txtCompanyName.Text = app.CompanyName;
                            txtJobTitle.Text = app.JobTitle;
                            txtLocation.Text = app.Location;
                            cmbWorkModel.Text = app.WorkModel;
                            cmbStatus.Text = app.Status;
                            dtpApplicationDate.Value = app.ApplicationDate;
                        }

                        applications.Remove(app);
                        DataManager.SaveApplications(applications);
                        RefreshGrid();
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
            string activeStatus = "";
            string activeModel = "";

            // 1. Find which filters are checked in the background
            if (filterMenu != null && filterMenu.Items.Count >= 2)
            {
                // Extract checked Status
                if (filterMenu.Items[0] is ToolStripMenuItem statusMenu)
                {
                    foreach (ToolStripMenuItem item in statusMenu.DropDownItems)
                    {
                        if (item.Checked) activeStatus = item.Text.ToUpper();
                    }
                }

                // Extract checked Work Model
                if (filterMenu.Items[1] is ToolStripMenuItem modelMenu)
                {
                    foreach (ToolStripMenuItem item in modelMenu.DropDownItems)
                    {
                        if (item.Checked) activeModel = item.Text.ToUpper();
                    }
                }
            }

            // 2. Start with the full Vault list
            List<JobApplication> viewList = new List<JobApplication>(applications);

            // 3. Apply Status Filter (If one is active)
            if (!string.IsNullOrEmpty(activeStatus))
            {
                viewList = viewList.Where(app => !string.IsNullOrEmpty(app.Status) && app.Status.Trim().ToUpper() == activeStatus).ToList();
            }

            // 4. Apply Work Model Filter (If one is active)
            if (!string.IsNullOrEmpty(activeModel))
            {
                viewList = viewList.Where(app => !string.IsNullOrEmpty(app.WorkModel) && app.WorkModel.Trim().ToUpper() == activeModel).ToList();
            }

            // 5. Apply Sorting (Clicking Column Headers)
            if (!string.IsNullOrEmpty(sortColumn))
            {
                var propertyInfo = typeof(JobApplication).GetProperty(sortColumn);
                if (propertyInfo != null)
                {
                    if (sortAscending)
                    {
                        viewList = viewList.OrderBy(app => propertyInfo.GetValue(app, null)).ToList();
                    }
                    else
                    {
                        viewList = viewList.OrderByDescending(app => propertyInfo.GetValue(app, null)).ToList();
                    }
                }
            }

            // 6. Push to Grid
            dgvApplications.DataSource = null;
            dgvApplications.DataSource = viewList;

            lblTotalCount.Text = $"{viewList.Count} Applications Shown ({applications.Count} Total)";
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