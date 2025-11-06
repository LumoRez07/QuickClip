using System;
using System.IO;
using System.Windows.Forms;

namespace QuickClip
{
    public partial class frmAI : Form
    {
        private Keys currentModifiers = Keys.None;

        public frmAI()
        {
            InitializeComponent();

            this.hotkeygrammar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
            this.hotkeysummarize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
            this.hotkeycustomprompt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);

            LoadSettings();
        }

        private void LoadSettings()
        {
            txtboxapikey.Text = Properties.Settings.Default.ApiKey;

            hotkeygrammar.Text = Properties.Settings.Default.HotkeyGrammar;
            locationgrammar.Text = Properties.Settings.Default.LocationGrammar;

            hotkeysummarize.Text = Properties.Settings.Default.HotkeySummarize;
            locationsummarize.Text = Properties.Settings.Default.LocationSummarize;

            hotkeycustomprompt.Text = Properties.Settings.Default.HotkeyCustomPrompt;
            locationcustomprompt.Text = Properties.Settings.Default.LocationCustomPrompt;

            txtCustomPrompt.Text = Properties.Settings.Default.CustomPrompt;
        }

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;

            currentModifiers = e.Modifiers;

            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey ||
                e.KeyCode == Keys.Menu || e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
            {
                return;
            }

            string hotkey = "";
            if (e.Control) hotkey += "Ctrl + ";
            if (e.Alt) hotkey += "Alt + ";
            if (e.Shift) hotkey += "Shift + ";
            hotkey += e.KeyCode.ToString();

            TextBox? activeBox = sender as TextBox;
            if (activeBox != null)
            {
                activeBox.Text = hotkey;
            }

            setapikey.Focus();
        }

        private void BrowseForPath(TextBox pathBox)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Save Directory";
                folderDialog.SelectedPath = pathBox.Text;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    pathBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void UpdateHotkey(string type, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show("Please enter a valid hotkey.", "QuickClip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (type)
            {
                case "Grammar":
                    Properties.Settings.Default.HotkeyGrammar = value;
                    break;
                case "Summarize":
                    Properties.Settings.Default.HotkeySummarize = value;
                    break;
                case "CustomPrompt":
                    Properties.Settings.Default.HotkeyCustomPrompt = value;
                    break;
            }

            Properties.Settings.Default.Save();
            HotkeyManager.UpdateHotkey(type, value);

            MessageBox.Show($"Hotkey for {type} updated successfully!", "QuickClip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void browsegrammar_Click(object sender, EventArgs e)
        {
            BrowseForPath(locationgrammar);
        }

        private void setkeygrammar_Click(object sender, EventArgs e)
        {
            UpdateHotkey("Grammar", hotkeygrammar.Text);
        }

        private void browsesummarize_Click(object sender, EventArgs e)
        {
            BrowseForPath(locationsummarize);
        }

        private void setkeysummarize_Click(object sender, EventArgs e)
        {
            UpdateHotkey("Summarize", hotkeysummarize.Text);
        }

        private void browsecustomprompt_Click(object sender, EventArgs e)
        {
            BrowseForPath(locationcustomprompt);
        }

        private void setkeycustomprompt_Click(object sender, EventArgs e)
        {
            UpdateHotkey("CustomPrompt", hotkeycustomprompt.Text);
        }

        private void setapikey_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(locationgrammar.Text))
                    Directory.CreateDirectory(locationgrammar.Text);
                if (!string.IsNullOrWhiteSpace(locationsummarize.Text))
                    Directory.CreateDirectory(locationsummarize.Text);
                if (!string.IsNullOrWhiteSpace(locationcustomprompt.Text))
                    Directory.CreateDirectory(locationcustomprompt.Text);

                Properties.Settings.Default.ApiKey = txtboxapikey.Text;

                Properties.Settings.Default.HotkeyGrammar = hotkeygrammar.Text;
                Properties.Settings.Default.LocationGrammar = locationgrammar.Text;

                Properties.Settings.Default.HotkeySummarize = hotkeysummarize.Text;
                Properties.Settings.Default.LocationSummarize = locationsummarize.Text;

                Properties.Settings.Default.HotkeyCustomPrompt = hotkeycustomprompt.Text;
                Properties.Settings.Default.LocationCustomPrompt = locationcustomprompt.Text;

                Properties.Settings.Default.CustomPrompt = txtCustomPrompt.Text;

                Properties.Settings.Default.Save();

                // Re-register all hotkeys with the new settings
                HotkeyManager.RegisterAll();

                MessageBox.Show("AI settings saved successfully!\n\nHotkeys have been updated.",
                    "QuickClip - AI Integration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving AI settings: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelgrammar_Click(object sender, EventArgs e) { }
        private void hotkeygrammar_TextChanged(object sender, EventArgs e) { }
        private void locationgrammar_TextChanged(object sender, EventArgs e) { }
        private void labelsummarize_Click(object sender, EventArgs e) { }
        private void hotkeysummarize_TextChanged(object sender, EventArgs e) { }
        private void locationsummarize_TextChanged(object sender, EventArgs e) { }
        private void labelcustomprompt_Click(object sender, EventArgs e) { }
        private void hotkeycustomprompt_TextChanged(object sender, EventArgs e) { }
        private void locationcustomprompt_TextChanged(object sender, EventArgs e) { }
        private void labelapikey_Click(object sender, EventArgs e) { }
        private void txtboxapikey_TextChanged(object sender, EventArgs e) { }
        private void txtCustomPrompt_TextChanged(object sender, EventArgs e) { }

        private void frmAI_Load(object sender, EventArgs e)
        {
            copytoclipboardcustompromptcheckbox.Checked = Properties.Settings.Default.CopyToClipboardCustomprompt;
            copytoclipboardgrammarcheckbox.Checked = Properties.Settings.Default.CopyToClipboardGrammar;
            copytoclipboardsummarizecheckbox.Checked = Properties.Settings.Default.CopyToClipboardSummarize;
        }

        private void copytoclipboardsummarizecheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CopyToClipboardSummarize = copytoclipboardsummarizecheckbox.Checked;
        }

        private void copytoclipboardcustompromptcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CopyToClipboardCustomprompt = copytoclipboardcustompromptcheckbox.Checked;
        }

        private void copytoclipboardgrammarcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CopyToClipboardGrammar = copytoclipboardgrammarcheckbox.Checked;
        }

        private void custompromptlabeltext_Click(object sender, EventArgs e)
        {

        }
    }
}