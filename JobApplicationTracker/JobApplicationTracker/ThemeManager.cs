using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

// Import libraries and UI elements

namespace JobApplicationTracker
{
   public static class ThemeManager
    {
        // Property to track the current theme mode (dark or light) defaults to light mode
        public static bool IsDarkMode { get; private set; } = false;

        // Method to toggle between dark and light mode
        public static void ToggleTheme()
        {
            // Sets the boolean value to the opposite of its current state (True -> False, False -> True)
            IsDarkMode = !IsDarkMode;
            
        }

        // Method to apply the current theme to a given form and its controls
        public static void ApplyTheme(Form form)
        {
            // Define colors based on the current theme mode
            Color backColor = IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            Color foreColor = IsDarkMode ? Color.White : Color.Black;
            Color controlBackColor = IsDarkMode ? Color.FromArgb(45, 45, 45) : Color.White;
            Color buttonBackColor = IsDarkMode ? Color.FromArgb(60, 60, 60) : Color.FromArgb(33, 33, 33);
            Color gridBorderColor = IsDarkMode ? Color.FromArgb(60, 60, 60) : Color.FromArgb(230, 230, 230);
            Color gridSelectionColor = IsDarkMode ? Color.FromArgb(70, 70, 70) : Color.FromArgb(245, 245, 245);

            form.BackColor = backColor;
            form.ForeColor = foreColor;

            // Loops trough every invidual UI element on the form
            foreach (Control control in form.Controls)
            {
                // Checks if the type of element in the loop is a TextBox
                if (control is TextBox textBox)
                {
                    // Set the TextBox properties based on the current theme
                    textBox.BackColor = controlBackColor;
                    textBox.ForeColor = foreColor;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                // Checks if the type of element in the loop is a ComboBox
                else if (control is ComboBox comboBox)
                {
                    // Set the ComboBox properties based on the current theme
                    comboBox.BackColor = controlBackColor;
                    comboBox.ForeColor = foreColor;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                // Checks if the type of element in the loop is a Label
                else if (control is Label label)
                {
                    // Set the Label properties based on the current theme so label remains readable in both dark and light mode
                    label.ForeColor = foreColor;
                }
                // Checks if the type of element in the loop is a Button
                else if (control is Button button)
                {
                    // Set the Button properties based on the current theme
                    button.BackColor = buttonBackColor;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                }
                // Checks if the type of element in the loop is a DataGridView
                else if (control is DataGridView grid)
                {
                    // Set the DataGridView properties based on the current theme
                    grid.BackgroundColor = backColor;
                    grid.GridColor = gridBorderColor;

                    grid.DefaultCellStyle.BackColor = controlBackColor;
                    grid.DefaultCellStyle.ForeColor = foreColor;
                    grid.DefaultCellStyle.SelectionBackColor = gridSelectionColor;
                    grid.DefaultCellStyle.SelectionForeColor = foreColor;

                    grid.ColumnHeadersDefaultCellStyle.BackColor = controlBackColor;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
                }
            }
    }
}
