namespace QuickClip2
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            labelImage = new Label();
            labelText = new Label();
            labelHotkey = new Label();
            txtImagePath = new TextBox();
            txtTextPath = new TextBox();
            txtHotkey = new TextBox();
            btnBrowseImage = new Button();
            btnBrowseText = new Button();
            btnSave = new Button();
            btnClose = new Button();
            setbtn = new Button();
            chkStartup = new CheckBox();
            aiintegbutton = new Button();
            SuspendLayout();
            // 
            // labelImage
            // 
            labelImage.AutoSize = true;
            labelImage.Location = new Point(12, 20);
            labelImage.Name = "labelImage";
            labelImage.Size = new Size(79, 15);
            labelImage.TabIndex = 0;
            labelImage.Text = "Image Folder:";
            labelImage.Click += label1_Click;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new Point(12, 91);
            labelText.Name = "labelText";
            labelText.Size = new Size(67, 15);
            labelText.TabIndex = 1;
            labelText.Text = "Text Folder:";
            labelText.Click += label2_Click;
            // 
            // labelHotkey
            // 
            labelHotkey.AutoSize = true;
            labelHotkey.Location = new Point(12, 166);
            labelHotkey.Name = "labelHotkey";
            labelHotkey.Size = new Size(48, 15);
            labelHotkey.TabIndex = 2;
            labelHotkey.Text = "Hotkey:";
            labelHotkey.Click += label3_Click;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(12, 38);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(190, 23);
            txtImagePath.TabIndex = 3;
            txtImagePath.TextChanged += txtImagePath_TextChanged;
            // 
            // txtTextPath
            // 
            txtTextPath.Location = new Point(12, 109);
            txtTextPath.Name = "txtTextPath";
            txtTextPath.Size = new Size(190, 23);
            txtTextPath.TabIndex = 4;
            txtTextPath.TextChanged += txtTextPath_TextChanged;
            // 
            // txtHotkey
            // 
            txtHotkey.Location = new Point(12, 184);
            txtHotkey.Name = "txtHotkey";
            txtHotkey.Size = new Size(190, 23);
            txtHotkey.TabIndex = 5;
            txtHotkey.TextChanged += txtHotkey_TextChanged;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.FlatStyle = FlatStyle.System;
            btnBrowseImage.Location = new Point(208, 37);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(75, 23);
            btnBrowseImage.TabIndex = 6;
            btnBrowseImage.Text = "Browse";
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // btnBrowseText
            // 
            btnBrowseText.FlatStyle = FlatStyle.System;
            btnBrowseText.Location = new Point(208, 109);
            btnBrowseText.Name = "btnBrowseText";
            btnBrowseText.Size = new Size(75, 23);
            btnBrowseText.TabIndex = 7;
            btnBrowseText.Text = "Browse";
            btnBrowseText.UseVisualStyleBackColor = true;
            btnBrowseText.Click += btnBrowseText_Click;
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.System;
            btnSave.Location = new Point(114, 239);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.System;
            btnClose.Location = new Point(114, 268);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // setbtn
            // 
            setbtn.FlatStyle = FlatStyle.System;
            setbtn.Location = new Point(208, 183);
            setbtn.Name = "setbtn";
            setbtn.Size = new Size(75, 23);
            setbtn.TabIndex = 11;
            setbtn.Text = "Set hotkey";
            setbtn.UseVisualStyleBackColor = true;
            setbtn.Click += setbtn_Click;
            // 
            // chkStartup
            // 
            chkStartup.AutoSize = true;
            chkStartup.Location = new Point(12, 213);
            chkStartup.Name = "chkStartup";
            chkStartup.Size = new Size(152, 19);
            chkStartup.TabIndex = 12;
            chkStartup.Text = "Run at Windows startup";
            chkStartup.UseVisualStyleBackColor = true;
            chkStartup.CheckedChanged += chkStartup_CheckedChanged;
            // 
            // aiintegbutton
            // 
            aiintegbutton.FlatStyle = FlatStyle.System;
            aiintegbutton.Location = new Point(12, 238);
            aiintegbutton.Name = "aiintegbutton";
            aiintegbutton.Size = new Size(88, 23);
            aiintegbutton.TabIndex = 13;
            aiintegbutton.Text = "AI integration";
            aiintegbutton.UseVisualStyleBackColor = true;
            aiintegbutton.Click += aiintegbutton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(304, 301);
            Controls.Add(aiintegbutton);
            Controls.Add(chkStartup);
            Controls.Add(setbtn);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(btnBrowseText);
            Controls.Add(btnBrowseImage);
            Controls.Add(txtHotkey);
            Controls.Add(txtTextPath);
            Controls.Add(txtImagePath);
            Controls.Add(labelHotkey);
            Controls.Add(labelText);
            Controls.Add(labelImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(320, 340);
            MinimumSize = new Size(320, 340);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuickClip - Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelImage;
        private Label labelText;
        private Label labelHotkey;
        private TextBox txtImagePath;
        private TextBox txtTextPath;
        private TextBox txtHotkey;
        private Button btnBrowseImage;
        private Button btnBrowseText;
        private Button btnSave;
        private Button btnClose;
        private Button setbtn;
        private CheckBox chkStartup;
        private Button aiintegbutton;
    }
}