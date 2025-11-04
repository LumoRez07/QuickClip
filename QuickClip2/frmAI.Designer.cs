namespace QuickClip
{
    partial class frmAI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAI));
            labelgrammar = new Label();
            labelsummarize = new Label();
            labelcustomprompt = new Label();
            labelapikey = new Label();
            hotkeygrammar = new TextBox();
            locationgrammar = new TextBox();
            hotkeysummarize = new TextBox();
            locationsummarize = new TextBox();
            hotkeycustomprompt = new TextBox();
            locationcustomprompt = new TextBox();
            txtboxapikey = new TextBox();
            browsegrammar = new Button();
            setkeygrammar = new Button();
            browsesummarize = new Button();
            setkeysummarize = new Button();
            browsecustomprompt = new Button();
            setkeycustomprompt = new Button();
            setapikey = new Button();
            txtCustomPrompt = new TextBox();
            SuspendLayout();
            // 
            // labelgrammar
            // 
            labelgrammar.AutoSize = true;
            labelgrammar.Location = new Point(24, 25);
            labelgrammar.Name = "labelgrammar";
            labelgrammar.Size = new Size(141, 15);
            labelgrammar.TabIndex = 0;
            labelgrammar.Text = "Grammar check settings :";
            labelgrammar.Click += labelgrammar_Click;
            // 
            // labelsummarize
            // 
            labelsummarize.AutoSize = true;
            labelsummarize.Location = new Point(285, 25);
            labelsummarize.Name = "labelsummarize";
            labelsummarize.Size = new Size(116, 15);
            labelsummarize.TabIndex = 1;
            labelsummarize.Text = "Summarize settings :";
            labelsummarize.Click += labelsummarize_Click;
            // 
            // labelcustomprompt
            // 
            labelcustomprompt.AutoSize = true;
            labelcustomprompt.Location = new Point(24, 141);
            labelcustomprompt.Name = "labelcustomprompt";
            labelcustomprompt.Size = new Size(142, 15);
            labelcustomprompt.TabIndex = 2;
            labelcustomprompt.Text = "Custom Prompt settings :";
            labelcustomprompt.Click += labelcustomprompt_Click;
            // 
            // labelapikey
            // 
            labelapikey.AutoSize = true;
            labelapikey.Location = new Point(285, 141);
            labelapikey.Name = "labelapikey";
            labelapikey.Size = new Size(52, 15);
            labelapikey.TabIndex = 3;
            labelapikey.Text = "API key :";
            labelapikey.Click += labelapikey_Click;
            // 
            // hotkeygrammar
            // 
            hotkeygrammar.Location = new Point(24, 43);
            hotkeygrammar.Name = "hotkeygrammar";
            hotkeygrammar.Size = new Size(191, 23);
            hotkeygrammar.TabIndex = 4;
            hotkeygrammar.Text = "Click here to set hotkey";
            hotkeygrammar.TextChanged += hotkeygrammar_TextChanged;
            // 
            // locationgrammar
            // 
            locationgrammar.Location = new Point(24, 72);
            locationgrammar.Name = "locationgrammar";
            locationgrammar.Size = new Size(191, 23);
            locationgrammar.TabIndex = 5;
            locationgrammar.TextChanged += locationgrammar_TextChanged;
            // 
            // hotkeysummarize
            // 
            hotkeysummarize.Location = new Point(248, 43);
            hotkeysummarize.Name = "hotkeysummarize";
            hotkeysummarize.Size = new Size(191, 23);
            hotkeysummarize.TabIndex = 6;
            hotkeysummarize.Text = "Click here to set hotkey";
            hotkeysummarize.TextChanged += hotkeysummarize_TextChanged;
            // 
            // locationsummarize
            // 
            locationsummarize.Location = new Point(248, 72);
            locationsummarize.Name = "locationsummarize";
            locationsummarize.Size = new Size(191, 23);
            locationsummarize.TabIndex = 7;
            locationsummarize.TextChanged += locationsummarize_TextChanged;
            // 
            // hotkeycustomprompt
            // 
            hotkeycustomprompt.Location = new Point(24, 160);
            hotkeycustomprompt.Name = "hotkeycustomprompt";
            hotkeycustomprompt.Size = new Size(191, 23);
            hotkeycustomprompt.TabIndex = 8;
            hotkeycustomprompt.Text = "Click here to set hotkey";
            hotkeycustomprompt.TextChanged += hotkeycustomprompt_TextChanged;
            // 
            // locationcustomprompt
            // 
            locationcustomprompt.Location = new Point(24, 185);
            locationcustomprompt.Name = "locationcustomprompt";
            locationcustomprompt.Size = new Size(191, 23);
            locationcustomprompt.TabIndex = 9;
            locationcustomprompt.TextChanged += locationcustomprompt_TextChanged;
            // 
            // txtboxapikey
            // 
            txtboxapikey.Location = new Point(248, 159);
            txtboxapikey.Name = "txtboxapikey";
            txtboxapikey.Size = new Size(191, 23);
            txtboxapikey.TabIndex = 10;
            txtboxapikey.TextChanged += txtboxapikey_TextChanged;
            // 
            // browsegrammar
            // 
            browsegrammar.Location = new Point(38, 101);
            browsegrammar.Name = "browsegrammar";
            browsegrammar.Size = new Size(75, 23);
            browsegrammar.TabIndex = 11;
            browsegrammar.Text = "Browse";
            browsegrammar.UseVisualStyleBackColor = true;
            browsegrammar.Click += browsegrammar_Click;
            // 
            // setkeygrammar
            // 
            setkeygrammar.Location = new Point(119, 101);
            setkeygrammar.Name = "setkeygrammar";
            setkeygrammar.Size = new Size(75, 23);
            setkeygrammar.TabIndex = 12;
            setkeygrammar.Text = "Set Hotkey";
            setkeygrammar.UseVisualStyleBackColor = true;
            setkeygrammar.Click += setkeygrammar_Click;
            // 
            // browsesummarize
            // 
            browsesummarize.Location = new Point(262, 101);
            browsesummarize.Name = "browsesummarize";
            browsesummarize.Size = new Size(75, 23);
            browsesummarize.TabIndex = 13;
            browsesummarize.Text = "Browse";
            browsesummarize.UseVisualStyleBackColor = true;
            browsesummarize.Click += browsesummarize_Click;
            // 
            // setkeysummarize
            // 
            setkeysummarize.Location = new Point(343, 101);
            setkeysummarize.Name = "setkeysummarize";
            setkeysummarize.Size = new Size(75, 23);
            setkeysummarize.TabIndex = 14;
            setkeysummarize.Text = "Set Hotkey";
            setkeysummarize.UseVisualStyleBackColor = true;
            setkeysummarize.Click += setkeysummarize_Click;
            // 
            // browsecustomprompt
            // 
            browsecustomprompt.Location = new Point(38, 243);
            browsecustomprompt.Name = "browsecustomprompt";
            browsecustomprompt.Size = new Size(75, 23);
            browsecustomprompt.TabIndex = 15;
            browsecustomprompt.Text = "Browse";
            browsecustomprompt.UseVisualStyleBackColor = true;
            browsecustomprompt.Click += browsecustomprompt_Click;
            // 
            // setkeycustomprompt
            // 
            setkeycustomprompt.Location = new Point(119, 243);
            setkeycustomprompt.Name = "setkeycustomprompt";
            setkeycustomprompt.Size = new Size(75, 23);
            setkeycustomprompt.TabIndex = 16;
            setkeycustomprompt.Text = "Set Hotkey";
            setkeycustomprompt.UseVisualStyleBackColor = true;
            setkeycustomprompt.Click += setkeycustomprompt_Click;
            // 
            // setapikey
            // 
            setapikey.Location = new Point(264, 188);
            setapikey.Margin = new Padding(8, 3, 8, 3);
            setapikey.Name = "setapikey";
            setapikey.Size = new Size(154, 23);
            setapikey.TabIndex = 17;
            setapikey.Text = "Set (save settings)";
            setapikey.UseVisualStyleBackColor = true;
            setapikey.Click += setapikey_Click;
            // 
            // txtCustomPrompt
            // 
            txtCustomPrompt.Location = new Point(24, 214);
            txtCustomPrompt.Multiline = true;
            txtCustomPrompt.Name = "txtCustomPrompt";
            txtCustomPrompt.Size = new Size(191, 23);
            txtCustomPrompt.TabIndex = 18;
            txtCustomPrompt.Text = "Custom prompt goes here...";
            txtCustomPrompt.TextChanged += txtCustomPrompt_TextChanged;
            // 
            // frmAI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 268);
            Controls.Add(txtCustomPrompt);
            Controls.Add(setapikey);
            Controls.Add(setkeycustomprompt);
            Controls.Add(browsecustomprompt);
            Controls.Add(setkeysummarize);
            Controls.Add(browsesummarize);
            Controls.Add(setkeygrammar);
            Controls.Add(browsegrammar);
            Controls.Add(txtboxapikey);
            Controls.Add(locationcustomprompt);
            Controls.Add(hotkeycustomprompt);
            Controls.Add(locationsummarize);
            Controls.Add(hotkeysummarize);
            Controls.Add(locationgrammar);
            Controls.Add(hotkeygrammar);
            Controls.Add(labelapikey);
            Controls.Add(labelcustomprompt);
            Controls.Add(labelsummarize);
            Controls.Add(labelgrammar);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuickClip - AI integration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelgrammar;
        private Label labelsummarize;
        private Label labelcustomprompt;
        private Label labelapikey;
        private TextBox hotkeygrammar;
        private TextBox locationgrammar;
        private TextBox hotkeysummarize;
        private TextBox locationsummarize;
        private TextBox hotkeycustomprompt;
        private TextBox locationcustomprompt;
        private TextBox txtboxapikey;
        private Button browsegrammar;
        private Button setkeygrammar;
        private Button browsesummarize;
        private Button setkeysummarize;
        private Button browsecustomprompt;
        private Button setkeycustomprompt;
        private Button setapikey;
        private TextBox txtCustomPrompt;
    }
}