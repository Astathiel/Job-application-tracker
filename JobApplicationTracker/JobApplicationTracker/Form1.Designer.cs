namespace JobApplicationTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBox txtCompanyName;
            label_add_new_application = new Label();
            label_company_name = new Label();
            label_role = new Label();
            txtJobTitle = new TextBox();
            txtLocation = new TextBox();
            label_location = new Label();
            cmbWorkModel = new ComboBox();
            label_work_method = new Label();
            label_application_date = new Label();
            dtpApplicationDate = new DateTimePicker();
            cmbStatus = new ComboBox();
            label_Status = new Label();
            btnSave = new Button();
            dgvApplications = new DataGridView();
            label_applications_amount = new Label();
            label1 = new Label();
            txtCompanyName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();
            // 
            // txtCompanyName
            // 
            txtCompanyName.ForeColor = SystemColors.WindowFrame;
            txtCompanyName.Location = new Point(22, 64);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(430, 31);
            txtCompanyName.TabIndex = 1;
            txtCompanyName.Text = "e.g. Stripe, Inc.";
            // 
            // label_add_new_application
            // 
            label_add_new_application.AutoSize = true;
            label_add_new_application.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_add_new_application.ForeColor = Color.Black;
            label_add_new_application.Location = new Point(22, 9);
            label_add_new_application.Name = "label_add_new_application";
            label_add_new_application.Size = new Size(180, 21);
            label_add_new_application.TabIndex = 0;
            label_add_new_application.Text = "ADD NEW APPLICATION";
            // 
            // label_company_name
            // 
            label_company_name.AutoSize = true;
            label_company_name.Location = new Point(20, 39);
            label_company_name.Name = "label_company_name";
            label_company_name.Size = new Size(141, 25);
            label_company_name.TabIndex = 2;
            label_company_name.Text = "Comapny Name";
            // 
            // label_role
            // 
            label_role.AutoSize = true;
            label_role.Location = new Point(486, 39);
            label_role.Name = "label_role";
            label_role.Size = new Size(85, 25);
            label_role.TabIndex = 3;
            label_role.Text = "Role/Title";
            // 
            // txtJobTitle
            // 
            txtJobTitle.ForeColor = SystemColors.WindowFrame;
            txtJobTitle.Location = new Point(487, 64);
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new Size(369, 31);
            txtJobTitle.TabIndex = 4;
            txtJobTitle.Text = "e.g. Junior Developer";
            // 
            // txtLocation
            // 
            txtLocation.ForeColor = SystemColors.WindowFrame;
            txtLocation.Location = new Point(901, 64);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(318, 31);
            txtLocation.TabIndex = 6;
            txtLocation.Text = "e.g. Tampere, Helsinki or Remote";
            // 
            // label_location
            // 
            label_location.AutoSize = true;
            label_location.Location = new Point(901, 39);
            label_location.Name = "label_location";
            label_location.Size = new Size(79, 25);
            label_location.TabIndex = 5;
            label_location.Text = "Location";
            // 
            // cmbWorkModel
            // 
            cmbWorkModel.ForeColor = SystemColors.WindowFrame;
            cmbWorkModel.FormattingEnabled = true;
            cmbWorkModel.Items.AddRange(new object[] { "On-site, Remote, Hybrid" });
            cmbWorkModel.Location = new Point(22, 131);
            cmbWorkModel.Name = "cmbWorkModel";
            cmbWorkModel.Size = new Size(370, 33);
            cmbWorkModel.TabIndex = 7;
            cmbWorkModel.Text = "Select Option...";
            // 
            // label_work_method
            // 
            label_work_method.AutoSize = true;
            label_work_method.Location = new Point(22, 106);
            label_work_method.Name = "label_work_method";
            label_work_method.Size = new Size(147, 25);
            label_work_method.TabIndex = 8;
            label_work_method.Text = "Working Method";
            // 
            // label_application_date
            // 
            label_application_date.AutoSize = true;
            label_application_date.Location = new Point(440, 106);
            label_application_date.Name = "label_application_date";
            label_application_date.Size = new Size(144, 25);
            label_application_date.TabIndex = 9;
            label_application_date.Text = "Application Date";
            // 
            // dtpApplicationDate
            // 
            dtpApplicationDate.CalendarForeColor = SystemColors.WindowFrame;
            dtpApplicationDate.CalendarTitleForeColor = SystemColors.WindowFrame;
            dtpApplicationDate.CalendarTrailingForeColor = SystemColors.WindowFrame;
            dtpApplicationDate.Format = DateTimePickerFormat.Short;
            dtpApplicationDate.Location = new Point(440, 131);
            dtpApplicationDate.Name = "dtpApplicationDate";
            dtpApplicationDate.Size = new Size(320, 31);
            dtpApplicationDate.TabIndex = 10;
            // 
            // cmbStatus
            // 
            cmbStatus.ForeColor = SystemColors.WindowFrame;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "APPLIED, PENDING, INTERVIEW, OFFER, REJECTED" });
            cmbStatus.Location = new Point(824, 131);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(252, 33);
            cmbStatus.TabIndex = 11;
            cmbStatus.Text = "Select Status...";
            // 
            // label_Status
            // 
            label_Status.AutoSize = true;
            label_Status.Location = new Point(824, 103);
            label_Status.Name = "label_Status";
            label_Status.Size = new Size(155, 25);
            label_Status.TabIndex = 12;
            label_Status.Text = "Application Status";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(1107, 131);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // dgvApplications
            // 
            dgvApplications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Location = new Point(22, 196);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.RowHeadersWidth = 62;
            dgvApplications.Size = new Size(1197, 443);
            dgvApplications.TabIndex = 14;
            // 
            // label_applications_amount
            // 
            label_applications_amount.AutoSize = true;
            label_applications_amount.Location = new Point(20, 640);
            label_applications_amount.Name = "label_applications_amount";
            label_applications_amount.Size = new Size(167, 25);
            label_applications_amount.TabIndex = 15;
            label_applications_amount.Text = "0 Applications Total";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1012, 640);
            label1.Name = "label1";
            label1.Size = new Size(207, 25);
            label1.TabIndex = 16;
            label1.Text = "All changes saved locally";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(label1);
            Controls.Add(label_applications_amount);
            Controls.Add(dgvApplications);
            Controls.Add(btnSave);
            Controls.Add(label_Status);
            Controls.Add(cmbStatus);
            Controls.Add(dtpApplicationDate);
            Controls.Add(label_application_date);
            Controls.Add(label_work_method);
            Controls.Add(cmbWorkModel);
            Controls.Add(txtLocation);
            Controls.Add(label_location);
            Controls.Add(txtJobTitle);
            Controls.Add(label_role);
            Controls.Add(label_company_name);
            Controls.Add(txtCompanyName);
            Controls.Add(label_add_new_application);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_add_new_application;
        private Label label_company_name;
        private Label label_role;
        private TextBox txtJobTitle;
        private TextBox txtLocation;
        private Label label_location;
        private ComboBox cmbWorkModel;
        private Label label_work_method;
        private Label label_application_date;
        private DateTimePicker dtpApplicationDate;
        private ComboBox cmbStatus;
        private Label label_Status;
        private Button btnSave;
        private DataGridView dgvApplications;
        private Label label_applications_amount;
        private Label label1;
    }
}
