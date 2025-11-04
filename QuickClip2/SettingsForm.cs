using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using QuickClip;

namespace QuickClip2
{
    public partial class SettingsForm : Form
    {
        private const string AppName = "QuickClip";
        private Keys currentModifiers = Keys.None;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Image Save Directory";
                folderDialog.SelectedPath = txtImagePath.Text;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnBrowseText_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Text Save Directory";
                folderDialog.SelectedPath = txtTextPath.Text;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtTextPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtImagePath.Text))
            {
                MessageBox.Show("Image save path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Directory.CreateDirectory(txtImagePath.Text);
                Directory.CreateDirectory(txtTextPath.Text);

                QuickClip.Properties.Settings.Default.ImageSavePath = txtImagePath.Text;
                QuickClip.Properties.Settings.Default.TextSavePath = txtTextPath.Text;
                QuickClip.Properties.Settings.Default.Hotkey = txtHotkey.Text;
                QuickClip.Properties.Settings.Default.Save();

                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (chkStartup.Checked)
                    {
                        rk.SetValue(AppName, Application.ExecutablePath);
                    }
                    else
                    {
                        rk.DeleteValue(AppName, false);
                    }
                }

                MessageBox.Show("Settings saved successfully.", "QuickClip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtImagePath.Text = QuickClip.Properties.Settings.Default.ImageSavePath;
            txtTextPath.Text = QuickClip.Properties.Settings.Default.TextSavePath;
            txtHotkey.Text = QuickClip.Properties.Settings.Default.Hotkey;

            this.txtHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
            this.txtHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyUp);

            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false))
            {
                chkStartup.Checked = (rk.GetValue(AppName) != null);
            }
        }

        private void setbtn_Click(object sender, EventArgs e)
        {
            txtHotkey.Text = "Press desired hotkey combination...";
            txtHotkey.Focus();
        }

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;

            currentModifiers = e.Modifiers;

            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey ||
                e.KeyCode == Keys.Menu || e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
            {
                txtHotkey.Text = "Press keys...";
                return;
            }

            string hotkey = "";
            if (e.Control) hotkey += "Ctrl + ";
            if (e.Alt) hotkey += "Alt + ";
            if (e.Shift) hotkey += "Shift + ";
            hotkey += e.KeyCode.ToString();

            txtHotkey.Text = hotkey;
            btnSave.Focus();
        }

        private void txtHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            currentModifiers = Keys.None;
        }

        private void aiintegbutton_Click(object sender, EventArgs e)
        {
            frmAI? openAiForm = Application.OpenForms.OfType<frmAI>().FirstOrDefault();
            if (openAiForm != null)
            {
                openAiForm.WindowState = FormWindowState.Normal;
                openAiForm.Activate();
            }
            else
            {
                frmAI aiForm = new frmAI();
                aiForm.Show();
            }
        }

        // Empty event handlers for designer
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtTextPath_TextChanged(object sender, EventArgs e) { }
        private void txtImagePath_TextChanged(object sender, EventArgs e) { }
        private void txtHotkey_TextChanged(object sender, EventArgs e) { }
        private void chkStartup_CheckedChanged(object sender, EventArgs e) { }
    }
}