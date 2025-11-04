using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickClip
{
    public static class HotkeyManager
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static Form _mainForm;
        private static int _nextId = 1;

        public static int GrammarHotkeyId { get; private set; }
        public static int SummarizeHotkeyId { get; private set; }
        public static int CustomPromptHotkeyId { get; private set; }

        public static void Initialize(Form mainForm)
        {
            _mainForm = mainForm;

            // Initial registration from saved settings
            RegisterAll();
        }

        public static void RegisterAll()
        {
            UnregisterAll();

            GrammarHotkeyId = RegisterHotkeyFromSetting(Properties.Settings.Default.HotkeyGrammar);
            SummarizeHotkeyId = RegisterHotkeyFromSetting(Properties.Settings.Default.HotkeySummarize);
            CustomPromptHotkeyId = RegisterHotkeyFromSetting(Properties.Settings.Default.HotkeyCustomPrompt);
        }

        private static int RegisterHotkeyFromSetting(string hotkey)
        {
            if (_mainForm == null || string.IsNullOrWhiteSpace(hotkey)) return 0;
            if (!TryParseHotkey(hotkey, out Keys key, out uint modifiers)) return 0;

            int id = _nextId++;
            RegisterHotKey(_mainForm.Handle, id, modifiers, (uint)key);
            return id;
        }

        public static void UnregisterAll()
        {
            if (_mainForm == null) return;
            if (GrammarHotkeyId != 0) UnregisterHotKey(_mainForm.Handle, GrammarHotkeyId);
            if (SummarizeHotkeyId != 0) UnregisterHotKey(_mainForm.Handle, SummarizeHotkeyId);
            if (CustomPromptHotkeyId != 0) UnregisterHotKey(_mainForm.Handle, CustomPromptHotkeyId);
        }

        public static void UpdateHotkey(string type, string newHotkey)
        {
            if (_mainForm == null) return;
            if (!TryParseHotkey(newHotkey, out Keys key, out uint modifiers)) return;

            int id = type switch
            {
                "Grammar" => GrammarHotkeyId,
                "Summarize" => SummarizeHotkeyId,
                "CustomPrompt" => CustomPromptHotkeyId,
                _ => 0
            };

            if (id != 0)
                UnregisterHotKey(_mainForm.Handle, id);

            int newId = _nextId++;
            RegisterHotKey(_mainForm.Handle, newId, modifiers, (uint)key);

            switch (type)
            {
                case "Grammar": GrammarHotkeyId = newId; break;
                case "Summarize": SummarizeHotkeyId = newId; break;
                case "CustomPrompt": CustomPromptHotkeyId = newId; break;
            }
        }

        private static bool TryParseHotkey(string text, out Keys key, out uint modifiers)
        {
            key = Keys.None;
            modifiers = 0;
            string[] parts = text.Split('+', StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string p = part.Trim().ToLower();
                switch (p)
                {
                    case "ctrl": modifiers |= 0x2; break;
                    case "alt": modifiers |= 0x1; break;
                    case "shift": modifiers |= 0x4; break;
                    default:
                        if (Enum.TryParse(typeof(Keys), p, true, out object result))
                            key = (Keys)result;
                        break;
                }
            }

            return key != Keys.None;
        }
    }
}
