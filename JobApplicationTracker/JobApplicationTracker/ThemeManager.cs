using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace JobApplicationTracker
{
    public static class ThemeManager
    {
        public static bool IsDarkMode { get; private set; } = false;

        private static Image imgDark;
        private static Image imgLight;

        static ThemeManager()
        {
            var assembly = Assembly.GetExecutingAssembly();

            string[] allResources = assembly.GetManifestResourceNames();

            string darkPath = allResources.FirstOrDefault(r => r.EndsWith("ToggleDark.png"));
            string lightPath = allResources.FirstOrDefault(r => r.EndsWith("ToggleLight.png"));

            if (darkPath != null) imgDark = Image.FromStream(assembly.GetManifestResourceStream(darkPath));
            if (lightPath != null) imgLight = Image.FromStream(assembly.GetManifestResourceStream(lightPath));
        }

        public static void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
        }

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
                        button.Image = null;
                        button.BackgroundImage = IsDarkMode ? imgDark : imgLight;
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
                }
            }
        }
    }
}