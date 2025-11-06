using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickClip;

namespace QuickClip2
{
    public partial class Form1 : Form
    {
        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated && this.DesignMode)
            {
                base.SetVisibleCore(value);
            }
            else
            {
                base.SetVisibleCore(false);
            }
        }

        // Global Hotkey Setup
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int HOTKEY_ID = 1;
        private const uint WM_HOTKEY = 0x0312;

        // Modifier keys
        private const uint MOD_NONE = 0x0000;
        private const uint MOD_ALT = 0x0001;
        private const uint MOD_CONTROL = 0x0002;
        private const uint MOD_SHIFT = 0x0004;
        private const uint MOD_WIN = 0x0008;

        public Form1()
        {
            InitializeComponent();
            HotkeyManager.Initialize(this);

            this.ShowInTaskbar = false;
            trayIcon.Visible = true;
            trayIcon.BalloonTipTitle = "QuickClip is running";
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Clipboard.ContainsImage())
                {
                    trayIcon.ShowBalloonTip(2000, "QuickClip", "Clipboard does not contain an image.", ToolTipIcon.Info);
                    return;
                }

                Image? img = Clipboard.GetImage();
                if (img is null)
                {
                    trayIcon.ShowBalloonTip(2000, "QuickClip", "Failed to retrieve image from clipboard.", ToolTipIcon.Warning);
                    return;
                }

                string? imgPath = QuickClip.Properties.Settings.Default.ImageSavePath;
                if (string.IsNullOrWhiteSpace(imgPath))
                {
                    trayIcon.ShowBalloonTip(2000, "QuickClip", "Image save path is not configured.", ToolTipIcon.Warning);
                    img.Dispose();
                    return;
                }

                if (!Directory.Exists(imgPath))
                {
                    Directory.CreateDirectory(imgPath);
                }

                string fileName = Path.Combine(imgPath, $"Image_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                using (img)
                {
                    img.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                }

                trayIcon.ShowBalloonTip(2000, "QuickClip", "Image saved to " + fileName, ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Clipboard.ContainsText())
                {
                    trayIcon.ShowBalloonTip(2000, "QuickClip", "Clipboard does not contain text.", ToolTipIcon.Info);
                    return;
                }

                string text = Clipboard.GetText();
                string? textPath = QuickClip.Properties.Settings.Default.TextSavePath;
                if (string.IsNullOrWhiteSpace(textPath))
                {
                    trayIcon.ShowBalloonTip(2000, "QuickClip", "Text save path is not configured.", ToolTipIcon.Warning);
                    return;
                }

                if (!Directory.Exists(textPath))
                {
                    Directory.CreateDirectory(textPath);
                }

                string fileName = Path.Combine(textPath, $"Text_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                File.WriteAllText(fileName, text);
                trayIcon.ShowBalloonTip(2000, "QuickClip", "Text saved to " + fileName, ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving text: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnregisterGlobalHotkey();

            try
            {
                using (SettingsForm settingsForm = new SettingsForm())
                {
                    if (settingsForm.ShowDialog() == DialogResult.OK)
                    {
                        RegisterGlobalHotkey();
                    }
                    else
                    {
                        RegisterGlobalHotkey();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening settings: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RegisterGlobalHotkey();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnregisterGlobalHotkey();
            HotkeyManager.UnregisterAll();
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (QuickClip.Properties.Settings.Default.FirstLaunch)
                {
                    string img = QuickClip.Properties.Settings.Default.ImageSavePath;
                    string txt = QuickClip.Properties.Settings.Default.TextSavePath;

                    if (!string.IsNullOrEmpty(img)) Directory.CreateDirectory(img);
                    if (!string.IsNullOrEmpty(txt)) Directory.CreateDirectory(txt);

                    QuickClip.Properties.Settings.Default.FirstLaunch = false;
                    QuickClip.Properties.Settings.Default.Save();

                    trayIcon.BalloonTipText = "Right click the tray icon to access settings.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during first launch setup: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RegisterGlobalHotkey();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            settingsToolStripMenuItem_Click(sender, e);
        }

        private void RegisterGlobalHotkey()
        {
            try
            {
                string hotkeyString = QuickClip.Properties.Settings.Default.Hotkey;
                if (string.IsNullOrWhiteSpace(hotkeyString))
                {
                    return;
                }

                (uint modifiers, uint vk) = ParseHotkeyString(hotkeyString);

                if (vk != 0)
                {
                    bool success = RegisterHotKey(this.Handle, HOTKEY_ID, modifiers, vk);
                    if (!success)
                    {
                        MessageBox.Show("Hotkey registration failed! Is it already in use by another app?", "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to register hotkey: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (uint modifiers, uint vk) ParseHotkeyString(string hotkeyString)
        {
            uint modifiers = MOD_NONE;
            uint vk = 0;

            if (string.IsNullOrWhiteSpace(hotkeyString))
            {
                return (modifiers, vk);
            }

            string[] parts = hotkeyString.Split(new[] { " + " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                if (part.Equals("Ctrl", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= MOD_CONTROL;
                }
                else if (part.Equals("Shift", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= MOD_SHIFT;
                }
                else if (part.Equals("Alt", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= MOD_ALT;
                }
                else
                {
                    try
                    {
                        vk = (uint)(Keys)Enum.Parse(typeof(Keys), part, true);
                    }
                    catch
                    {
                        return (MOD_NONE, 0);
                    }
                }
            }
            return (modifiers, vk);
        }

        private void UnregisterGlobalHotkey()
        {
            try
            {
                UnregisterHotKey(this.Handle, HOTKEY_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to unregister hotkey: " + ex.Message, "QuickClip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int hotkeyId = m.WParam.ToInt32();

                if (hotkeyId == HOTKEY_ID)
                {
                    // Main clipboard save hotkey
                    TriggerAutoSave();
                }
                else if (hotkeyId == HotkeyManager.GrammarHotkeyId)
                {
                    // Grammar check hotkey
                    _ = HandleAIShortcut("grammar");
                }
                else if (hotkeyId == HotkeyManager.SummarizeHotkeyId)
                {
                    // Summarize hotkey
                    _ = HandleAIShortcut("summarize");
                }
                else if (hotkeyId == HotkeyManager.CustomPromptHotkeyId)
                {
                    // Custom prompt hotkey
                    _ = HandleAIShortcut("customprompt");
                }
            }
            base.WndProc(ref m);
        }

        private void TriggerAutoSave()
        {
            if (Clipboard.ContainsImage())
            {
                saveImageToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            else if (Clipboard.ContainsText())
            {
                saveTextToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            else
            {
                trayIcon.ShowBalloonTip(2000, "QuickClip", "Clipboard does not contain image or text to save.", ToolTipIcon.Info);
            }
        }

        private async Task HandleAIShortcut(string mode)
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    trayIcon.ShowBalloonTip(2000, "QuickClip AI", "Images can't be used for AI integration.", ToolTipIcon.Warning);
                    return;
                }

                if (!Clipboard.ContainsText())
                {
                    trayIcon.ShowBalloonTip(2000, "QuickClip AI", "No text found in clipboard.", ToolTipIcon.Warning);
                    return;
                }

                bool copyToClipboardgrammar = QuickClip.Properties.Settings.Default.CopyToClipboardGrammar;
                bool copyToClipboardsummarize = QuickClip.Properties.Settings.Default.CopyToClipboardSummarize;
                bool copyToClipboardcustomprompt = QuickClip.Properties.Settings.Default.CopyToClipboardCustomprompt;
                string input = Clipboard.GetText();
                string apiKey = QuickClip.Properties.Settings.Default.ApiKey;
                string customPrompt = QuickClip.Properties.Settings.Default.CustomPrompt;

                string outputFolder = mode switch
                {
                    "grammar" => QuickClip.Properties.Settings.Default.LocationGrammar,
                    "summarize" => QuickClip.Properties.Settings.Default.LocationSummarize,
                    "customprompt" => QuickClip.Properties.Settings.Default.LocationCustomPrompt,
                    _ => QuickClip.Properties.Settings.Default.LocationCustomPrompt
                };

                trayIcon.ShowBalloonTip(1500, "QuickClip AI", $"{mode} request sent...", ToolTipIcon.Info);

                string savedFile = await GeminiHelper.ProcessWithGemini(mode, input, apiKey, customPrompt, outputFolder);

                if (mode == "grammar" && copyToClipboardgrammar ||
                    mode == "summarize" && copyToClipboardsummarize ||
                    mode == "customprompt" && copyToClipboardcustomprompt)
                {
                    string resultText = File.ReadAllText(savedFile);
                    Clipboard.SetText(resultText);
                    trayIcon.ShowBalloonTip(3000, "QuickClip AI", $"Processed text saved to {savedFile} and copied to clipboard.", ToolTipIcon.Info);
                }
                else
                {
                    trayIcon.ShowBalloonTip(3000, "QuickClip AI", $"Processed text saved to {savedFile}.", ToolTipIcon.Info);
                }

            }
            catch (Exception ex)
            {
                trayIcon.ShowBalloonTip(3000, "QuickClip AI Error", ex.Message, ToolTipIcon.Error);
            }
        }

        private async void summarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await HandleAIShortcut("summarize");
        }

        private async void grammarCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await HandleAIShortcut("grammar");
        }

        private async void customPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await HandleAIShortcut("customprompt");
        }
    }
}