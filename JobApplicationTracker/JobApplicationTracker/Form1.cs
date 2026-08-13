// Imports custom font styles and modern UI elements.
using System.Drawing;

namespace JobApplicationTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Initialize the form and apply modern styles and loads saved data.
            InitializeComponent();
            ApplyModernStyles();
            LoadData();
        }

        // Method to apply modern styles to the form and its controls.
        private void ApplyModernStyles()
        {
            // Set the form's background color and font.
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);


            // Loops through all controls in the form and applies specific styles based on control type.
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

            // Apply specific styles to buttons and DataGridView for a modern look.
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
}
