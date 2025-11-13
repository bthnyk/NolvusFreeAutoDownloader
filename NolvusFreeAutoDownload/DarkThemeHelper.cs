using System.Drawing;
using System.Windows.Forms;

namespace NolvusFreeAutoDownloader
{
    public static class DarkThemeHelper
    {
        public static void ApplyDarkTheme(Form form)
        {
            form.BackColor = Color.FromArgb(30, 30, 30);
            form.ForeColor = Color.White;

            ApplyThemeToControls(form.Controls, isDark: true);
        }

        public static void ApplyLightTheme(Form form)
        {
            form.BackColor = SystemColors.Control;
            form.ForeColor = SystemColors.ControlText;

            ApplyThemeToControls(form.Controls, isDark: false);
        }

        private static void ApplyThemeToControls(Control.ControlCollection controls, bool isDark)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.BackColor = isDark ? Color.FromArgb(45, 45, 45) : SystemColors.Window;
                    ctrl.ForeColor = isDark ? Color.White : SystemColors.WindowText;
                }
                else if (ctrl is RichTextBox rtb)
                {
                    if (isDark)
                    {
                        rtb.BackColor = Color.Black;
                        rtb.ForeColor = Color.Green;
                    }
                    else
                    {
                        rtb.BackColor = Color.FromArgb(242, 242, 242);
                        rtb.ForeColor = Color.FromArgb(51, 51, 51);
                    }

                    rtb.Font = new Font("Consolas", 10, FontStyle.Regular);
                    rtb.BorderStyle = BorderStyle.None;
                }
                else if (ctrl is Button button)
                {
                    button.BackColor = isDark ? Color.FromArgb(70, 70, 70) : SystemColors.Control;
                    button.ForeColor = isDark ? Color.White : SystemColors.ControlText;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = isDark ? Color.Gray : SystemColors.ActiveBorder;
                }
                else if (ctrl is GroupBox)
                {
                    ctrl.ForeColor = isDark ? Color.White : SystemColors.ControlText;
                }
                else
                {
                    ctrl.BackColor = isDark ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
                    ctrl.ForeColor = isDark ? Color.White : SystemColors.ControlText;
                }

                if (ctrl.HasChildren)
                    ApplyThemeToControls(ctrl.Controls, isDark);
            }
        }
    }
}