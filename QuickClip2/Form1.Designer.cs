namespace QuickClip2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            trayIcon = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            saveTextToolStripMenuItem = new ToolStripMenuItem();
            aIIntegrationToolStripMenuItem = new ToolStripMenuItem();
            summarizeToolStripMenuItem = new ToolStripMenuItem();
            grammarCheckToolStripMenuItem = new ToolStripMenuItem();
            customPromptToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = contextMenuStrip1;
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "QuickClip";
            trayIcon.Visible = true;
            trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { saveImageToolStripMenuItem, saveTextToolStripMenuItem, aIIntegrationToolStripMenuItem, settingsToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 136);
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(180, 22);
            saveImageToolStripMenuItem.Text = "Save Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // saveTextToolStripMenuItem
            // 
            saveTextToolStripMenuItem.Name = "saveTextToolStripMenuItem";
            saveTextToolStripMenuItem.Size = new Size(180, 22);
            saveTextToolStripMenuItem.Text = "Save Text";
            saveTextToolStripMenuItem.Click += saveTextToolStripMenuItem_Click;
            // 
            // aIIntegrationToolStripMenuItem
            // 
            aIIntegrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { summarizeToolStripMenuItem, grammarCheckToolStripMenuItem, customPromptToolStripMenuItem });
            aIIntegrationToolStripMenuItem.Name = "aIIntegrationToolStripMenuItem";
            aIIntegrationToolStripMenuItem.Size = new Size(180, 22);
            aIIntegrationToolStripMenuItem.Text = "AI integration";
            // 
            // summarizeToolStripMenuItem
            // 
            summarizeToolStripMenuItem.Name = "summarizeToolStripMenuItem";
            summarizeToolStripMenuItem.Size = new Size(180, 22);
            summarizeToolStripMenuItem.Text = "Summarize";
            summarizeToolStripMenuItem.Click += summarizeToolStripMenuItem_Click;
            // 
            // grammarCheckToolStripMenuItem
            // 
            grammarCheckToolStripMenuItem.Name = "grammarCheckToolStripMenuItem";
            grammarCheckToolStripMenuItem.Size = new Size(180, 22);
            grammarCheckToolStripMenuItem.Text = "Grammar check";
            grammarCheckToolStripMenuItem.Click += grammarCheckToolStripMenuItem_Click;
            // 
            // customPromptToolStripMenuItem
            // 
            customPromptToolStripMenuItem.Name = "customPromptToolStripMenuItem";
            customPromptToolStripMenuItem.Size = new Size(180, 22);
            customPromptToolStripMenuItem.Text = "Custom prompt";
            customPromptToolStripMenuItem.Click += customPromptToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 360);
            Name = "Form1";
            Opacity = 0D;
            ShowInTaskbar = false;
            Text = "QuickClip";
            WindowState = FormWindowState.Minimized;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon trayIcon;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripMenuItem saveTextToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aIIntegrationToolStripMenuItem;
        private ToolStripMenuItem summarizeToolStripMenuItem;
        private ToolStripMenuItem grammarCheckToolStripMenuItem;
        private ToolStripMenuItem customPromptToolStripMenuItem;
    }
}
