using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
// Necessary Libraries

namespace JobApplicationTracker
{
    public static class ThemeManager
    {
        // Property to track the current theme mode (dark or light)
        public static bool IsDarkMode { get; private set; } = false;

        // Images for the theme toggle button and edit button in both dark and light modes
        private static Image imgDark;
        private static Image imgLight;

        private static Image imgEditDark;
        private static Image imgEditLight;

        private static Image imgDeleteDark;
        private static Image imgDeleteLight;

        static ThemeManager()
        {
            // Load images from embedded resources
            var assembly = Assembly.GetExecutingAssembly();
            string[] allResources = assembly.GetManifestResourceNames();

            string darkPath = allResources.FirstOrDefault(r => r.EndsWith("ToggleDark.png"));
            string lightPath = allResources.FirstOrDefault(r => r.EndsWith("ToggleLight.png"));
            string editDarkPath = allResources.FirstOrDefault(r => r.EndsWith("Dark_Pencil.png"));
            string editLightPath = allResources.FirstOrDefault(r => r.EndsWith("Light_Pencil.png"));
            string delDarkPath = allResources.FirstOrDefault(r => r.EndsWith("Dark_Delete.png"));
            string delLightPath = allResources.FirstOrDefault(r => r.EndsWith("Light_Delete.png"));


            if (darkPath != null) imgDark = Image.FromStream(assembly.GetManifestResourceStream(darkPath));
            if (lightPath != null) imgLight = Image.FromStream(assembly.GetManifestResourceStream(lightPath));
            if (editDarkPath != null) imgEditDark = Image.FromStream(assembly.GetManifestResourceStream(editDarkPath));
            if (editLightPath != null) imgEditLight = Image.FromStream(assembly.GetManifestResourceStream(editLightPath));
            if (delDarkPath != null) imgDeleteDark = Image.FromStream(assembly.GetManifestResourceStream(delDarkPath));
            if (delLightPath != null) imgDeleteLight = Image.FromStream(assembly.GetManifestResourceStream(delLightPath));
        }

        // Set the theme to opposite of the current mode (dark to light or light to dark)
        public static void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
        }

        // Dark and Light mode color schemes for the application
        public static void ApplyTheme(Form form)
        {
            Color backColor = IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            Color foreColor = IsDarkMode ? Color.White : Color.Black;
            Color controlBackColor = IsDarkMode ? Color.FromArgb(45, 45, 45) : Color.White;
            Color buttonBackColor = IsDarkMode ? Color.FromArgb(60, 60, 60) : Color.FromArgb(33, 33, 33);
            Color gridBorderColor = IsDarkMode ? Color.FromArgb(60, 60, 60) : Color.FromArgb(230, 230, 230);
            Color gridSelectionColor = IsDarkMode ? Color.FromArgb(70, 70, 70) : Color.FromArgb(245, 245, 245);

            form.BackColor = backColor;
            form.ForeColor = foreColor;

            // Loop through all controls in the form and apply the appropriate colors and styles based on their type
            foreach (Control control in form.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = controlBackColor;
                    textBox.ForeColor = foreColor;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = controlBackColor;
                    comboBox.ForeColor = foreColor;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (control is Label label)
                {
                    label.ForeColor = foreColor;
                }
                else if (control is Button button)
                {
                    button.BackColor = buttonBackColor;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    if (button.Name == "btnThemeToggle")
                    {
                        // Set the theme toggle button's image based on the current theme
                        button.Image = null;
                        button.BackgroundImage = IsDarkMode ? imgDark : imgLight;
                        button.BackgroundImageLayout = ImageLayout.Zoom;
                        button.BackColor = backColor;
                    }
                    // Set the edit button's image based on the current theme
                    else if (button.Name == "btnEdit")
                    {
                        button.Text = "";
                        button.Image = null;
                        button.BackgroundImage = IsDarkMode ? imgEditDark : imgEditLight;
                        button.BackgroundImageLayout = ImageLayout.Zoom;
                        button.BackColor = backColor;
                    }
                }
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = backColor;
                    grid.GridColor = gridBorderColor;

                    grid.DefaultCellStyle.BackColor = controlBackColor;
                    grid.DefaultCellStyle.ForeColor = foreColor;
                    grid.DefaultCellStyle.SelectionBackColor = gridSelectionColor;
                    grid.DefaultCellStyle.SelectionForeColor = foreColor;

                    grid.ColumnHeadersDefaultCellStyle.BackColor = controlBackColor;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;

                    if (grid.Columns.Contains("EditColumn") && grid.Columns["EditColumn"] is DataGridViewImageColumn editCol)
                    {
                        editCol.Image = IsDarkMode ? imgEditDark : imgEditLight;
                    }

                    if (grid.Columns.Contains("DeleteColumn") && grid.Columns["DeleteColumn"] is DataGridViewImageColumn delCol)
                    {
                        delCol.Image = IsDarkMode ? imgDeleteDark : imgDeleteLight;
                    }
                }
            }
        }
    }
}