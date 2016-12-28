namespace Mahou
{
    partial class MahouForm
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
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl1lng = new System.Windows.Forms.Label();
            this.lbl2lng = new System.Windows.Forms.Label();
            this.cbLangOne = new System.Windows.Forms.ComboBox();
            this.cbLangTwo = new System.Windows.Forms.ComboBox();
            this.tbCLHK = new System.Windows.Forms.TextBox();
            this.tbCSHK = new System.Windows.Forms.TextBox();
            this.cbTrayIcon = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.GitHubLink = new System.Windows.Forms.LinkLabel();
            this.cbAutorun = new System.Windows.Forms.CheckBox();
            this.gbSBL = new System.Windows.Forms.GroupBox();
            this.gbHK = new System.Windows.Forms.GroupBox();
            this.cbCLineActive = new System.Windows.Forms.CheckBox();
            this.cbCSActive = new System.Windows.Forms.CheckBox();
            this.cbCLActive = new System.Windows.Forms.CheckBox();
            this.tbCLineHK = new System.Windows.Forms.TextBox();
            this.HelpTT = new System.Windows.Forms.ToolTip(this.components);
            this.cbCycleMode = new System.Windows.Forms.CheckBox();
            this.btnUpd = new System.Windows.Forms.Button();
            this.cbSwitchLayoutKeys = new System.Windows.Forms.ComboBox();
            this.cbBlockC = new System.Windows.Forms.CheckBox();
            this.lbswithlayout = new System.Windows.Forms.Label();
            this.cbCSSwitch = new System.Windows.Forms.CheckBox();
            this.cbUseEmulate = new System.Windows.Forms.CheckBox();
            this.cbRePress = new System.Windows.Forms.CheckBox();
            this.cbEatOneSpace = new System.Windows.Forms.CheckBox();
            this.cbResel = new System.Windows.Forms.CheckBox();
            this.cbELSType = new System.Windows.Forms.ComboBox();
            this.btnDDD = new System.Windows.Forms.Button();
            this.gbSBL.SuspendLayout();
            this.gbHK.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(87, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnApply
            // 
            this.btnApply.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.Location = new System.Drawing.Point(6, 251);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(168, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbl1lng
            // 
            this.lbl1lng.BackColor = System.Drawing.Color.Transparent;
            this.lbl1lng.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl1lng.Location = new System.Drawing.Point(6, 23);
            this.lbl1lng.Name = "lbl1lng";
            this.lbl1lng.Size = new System.Drawing.Size(70, 13);
            this.lbl1lng.TabIndex = 3;
            this.lbl1lng.Text = "Language 1:";
            this.lbl1lng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2lng
            // 
            this.lbl2lng.BackColor = System.Drawing.Color.Transparent;
            this.lbl2lng.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl2lng.Location = new System.Drawing.Point(6, 49);
            this.lbl2lng.Name = "lbl2lng";
            this.lbl2lng.Size = new System.Drawing.Size(70, 13);
            this.lbl2lng.TabIndex = 4;
            this.lbl2lng.Text = "Language 2:";
            this.lbl2lng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbLangOne
            // 
            this.cbLangOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLangOne.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLangOne.FormattingEnabled = true;
            this.cbLangOne.Location = new System.Drawing.Point(81, 20);
            this.cbLangOne.Name = "cbLangOne";
            this.cbLangOne.Size = new System.Drawing.Size(102, 21);
            this.cbLangOne.TabIndex = 5;
            this.cbLangOne.SelectedIndexChanged += new System.EventHandler(this.cbLangOne_SelectedIndexChanged);
            // 
            // cbLangTwo
            // 
            this.cbLangTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLangTwo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLangTwo.FormattingEnabled = true;
            this.cbLangTwo.Location = new System.Drawing.Point(81, 45);
            this.cbLangTwo.Name = "cbLangTwo";
            this.cbLangTwo.Size = new System.Drawing.Size(102, 21);
            this.cbLangTwo.TabIndex = 6;
            this.cbLangTwo.SelectedIndexChanged += new System.EventHandler(this.cbLangTwo_SelectedIndexChanged);
            // 
            // tbCLHK
            // 
            this.tbCLHK.BackColor = System.Drawing.SystemColors.Window;
            this.tbCLHK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCLHK.Location = new System.Drawing.Point(136, 12);
            this.tbCLHK.Name = "tbCLHK";
            this.tbCLHK.ReadOnly = true;
            this.tbCLHK.Size = new System.Drawing.Size(176, 22);
            this.tbCLHK.TabIndex = 11;
            this.tbCLHK.Text = "Pause";
            this.tbCLHK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCLHK_KeyDown);
            this.tbCLHK.MouseHover += new System.EventHandler(this.tbCLHK_MouseHover);
            // 
            // tbCSHK
            // 
            this.tbCSHK.BackColor = System.Drawing.SystemColors.Window;
            this.tbCSHK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCSHK.Location = new System.Drawing.Point(136, 37);
            this.tbCSHK.Name = "tbCSHK";
            this.tbCSHK.ReadOnly = true;
            this.tbCSHK.Size = new System.Drawing.Size(176, 22);
            this.tbCSHK.TabIndex = 12;
            this.tbCSHK.Text = "Scroll";
            this.tbCSHK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCSHK_KeyDown);
            this.tbCSHK.MouseHover += new System.EventHandler(this.tbCSHK_MouseHover);
            // 
            // cbTrayIcon
            // 
            this.cbTrayIcon.AutoSize = true;
            this.cbTrayIcon.BackColor = System.Drawing.Color.Transparent;
            this.cbTrayIcon.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbTrayIcon.Location = new System.Drawing.Point(201, 193);
            this.cbTrayIcon.Name = "cbTrayIcon";
            this.cbTrayIcon.Size = new System.Drawing.Size(102, 17);
            this.cbTrayIcon.TabIndex = 14;
            this.cbTrayIcon.Text = "Show tray icon";
            this.cbTrayIcon.UseVisualStyleBackColor = false;
            this.cbTrayIcon.MouseHover += new System.EventHandler(this.TrayIconCheckBox_MouseHover);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHelp.Location = new System.Drawing.Point(249, 251);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // GitHubLink
            // 
            this.GitHubLink.AutoSize = true;
            this.GitHubLink.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GitHubLink.Location = new System.Drawing.Point(11, 9);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(89, 13);
            this.GitHubLink.TabIndex = 16;
            this.GitHubLink.TabStop = true;
            this.GitHubLink.Text = "View on GitHub";
            this.GitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLink_LinkClicked);
            this.GitHubLink.MouseHover += new System.EventHandler(this.GitHubLink_MouseHover);
            // 
            // cbAutorun
            // 
            this.cbAutorun.AutoSize = true;
            this.cbAutorun.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAutorun.Location = new System.Drawing.Point(110, 9);
            this.cbAutorun.Name = "cbAutorun";
            this.cbAutorun.Size = new System.Drawing.Size(152, 17);
            this.cbAutorun.TabIndex = 17;
            this.cbAutorun.Text = "Autostart with Windows";
            this.cbAutorun.UseVisualStyleBackColor = true;
            // 
            // gbSBL
            // 
            this.gbSBL.Controls.Add(this.lbl1lng);
            this.gbSBL.Controls.Add(this.lbl2lng);
            this.gbSBL.Controls.Add(this.cbLangOne);
            this.gbSBL.Controls.Add(this.cbLangTwo);
            this.gbSBL.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbSBL.Location = new System.Drawing.Point(6, 169);
            this.gbSBL.Name = "gbSBL";
            this.gbSBL.Size = new System.Drawing.Size(189, 77);
            this.gbSBL.TabIndex = 19;
            this.gbSBL.TabStop = false;
            this.gbSBL.Text = "Switch between layouts";
            this.gbSBL.MouseHover += new System.EventHandler(this.gbSBL_MouseHover);
            // 
            // gbHK
            // 
            this.gbHK.Controls.Add(this.tbCLHK);
            this.gbHK.Controls.Add(this.cbCLineActive);
            this.gbHK.Controls.Add(this.cbCSActive);
            this.gbHK.Controls.Add(this.cbCLActive);
            this.gbHK.Controls.Add(this.tbCLineHK);
            this.gbHK.Controls.Add(this.tbCSHK);
            this.gbHK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbHK.Location = new System.Drawing.Point(6, 31);
            this.gbHK.Name = "gbHK";
            this.gbHK.Size = new System.Drawing.Size(318, 93);
            this.gbHK.TabIndex = 20;
            this.gbHK.TabStop = false;
            this.gbHK.Text = "HotKeys";
            // 
            // cbCLineActive
            // 
            this.cbCLineActive.AutoSize = true;
            this.cbCLineActive.Checked = true;
            this.cbCLineActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCLineActive.Location = new System.Drawing.Point(6, 65);
            this.cbCLineActive.Name = "cbCLineActive";
            this.cbCLineActive.Size = new System.Drawing.Size(91, 17);
            this.cbCLineActive.TabIndex = 17;
            this.cbCLineActive.Text = "Convert line:";
            this.cbCLineActive.UseVisualStyleBackColor = true;
            this.cbCLineActive.CheckedChanged += new System.EventHandler(this.cbCLineActive_CheckedChanged);
            // 
            // cbCSActive
            // 
            this.cbCSActive.AutoSize = true;
            this.cbCSActive.Checked = true;
            this.cbCSActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCSActive.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbCSActive.Location = new System.Drawing.Point(6, 40);
            this.cbCSActive.Name = "cbCSActive";
            this.cbCSActive.Size = new System.Drawing.Size(118, 17);
            this.cbCSActive.TabIndex = 16;
            this.cbCSActive.Text = "Convert selection:";
            this.cbCSActive.UseVisualStyleBackColor = true;
            this.cbCSActive.CheckedChanged += new System.EventHandler(this.cbCSActive_CheckedChanged);
            // 
            // cbCLActive
            // 
            this.cbCLActive.AutoSize = true;
            this.cbCLActive.BackColor = System.Drawing.Color.Transparent;
            this.cbCLActive.Checked = true;
            this.cbCLActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCLActive.Location = new System.Drawing.Point(6, 15);
            this.cbCLActive.Name = "cbCLActive";
            this.cbCLActive.Size = new System.Drawing.Size(120, 17);
            this.cbCLActive.TabIndex = 15;
            this.cbCLActive.Text = "Convert last word:";
            this.cbCLActive.UseVisualStyleBackColor = false;
            this.cbCLActive.CheckedChanged += new System.EventHandler(this.cbCLActive_CheckedChanged);
            // 
            // tbCLineHK
            // 
            this.tbCLineHK.BackColor = System.Drawing.SystemColors.Window;
            this.tbCLineHK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCLineHK.Location = new System.Drawing.Point(136, 62);
            this.tbCLineHK.Name = "tbCLineHK";
            this.tbCLineHK.ReadOnly = true;
            this.tbCLineHK.Size = new System.Drawing.Size(176, 22);
            this.tbCLineHK.TabIndex = 14;
            this.tbCLineHK.Text = "Shift + Pause";
            this.tbCLineHK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCLineHK_KeyDown);
            this.tbCLineHK.MouseHover += new System.EventHandler(this.tbCLineHK_MouseHover);
            // 
            // HelpTT
            // 
            this.HelpTT.AutoPopDelay = 25000;
            this.HelpTT.BackColor = System.Drawing.Color.Empty;
            this.HelpTT.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.HelpTT.InitialDelay = 500;
            this.HelpTT.ReshowDelay = 100;
            this.HelpTT.UseAnimation = false;
            // 
            // cbCycleMode
            // 
            this.cbCycleMode.AutoSize = true;
            this.cbCycleMode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCycleMode.Location = new System.Drawing.Point(201, 212);
            this.cbCycleMode.Name = "cbCycleMode";
            this.cbCycleMode.Size = new System.Drawing.Size(85, 17);
            this.cbCycleMode.TabIndex = 22;
            this.cbCycleMode.Text = "Cycle Mode";
            this.cbCycleMode.UseVisualStyleBackColor = true;
            this.cbCycleMode.CheckedChanged += new System.EventHandler(this.cbCycleMode_CheckedChanged);
            this.cbCycleMode.MouseHover += new System.EventHandler(this.cbCycleMode_MouseHover);
            // 
            // btnUpd
            // 
            this.btnUpd.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.btnUpd.Location = new System.Drawing.Point(261, 6);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(64, 24);
            this.btnUpd.TabIndex = 23;
            this.btnUpd.Text = "Update";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            this.btnUpd.MouseHover += new System.EventHandler(this.btnUpd_MouseHover);
            // 
            // cbSwitchLayoutKeys
            // 
            this.cbSwitchLayoutKeys.DisplayMember = "0";
            this.cbSwitchLayoutKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitchLayoutKeys.FormattingEnabled = true;
            this.cbSwitchLayoutKeys.Items.AddRange(new object[] {
            "CapsLock",
            "Left Control",
            "Right Control",
            "None"});
            this.cbSwitchLayoutKeys.Location = new System.Drawing.Point(201, 147);
            this.cbSwitchLayoutKeys.Name = "cbSwitchLayoutKeys";
            this.cbSwitchLayoutKeys.Size = new System.Drawing.Size(93, 21);
            this.cbSwitchLayoutKeys.TabIndex = 24;
            this.cbSwitchLayoutKeys.ValueMember = "0";
            this.cbSwitchLayoutKeys.MouseHover += new System.EventHandler(this.cbSwitchLayoutKeys_MouseHover);
            // 
            // cbBlockC
            // 
            this.cbBlockC.Location = new System.Drawing.Point(201, 174);
            this.cbBlockC.Name = "cbBlockC";
            this.cbBlockC.Size = new System.Drawing.Size(102, 17);
            this.cbBlockC.TabIndex = 0;
            this.cbBlockC.Text = "Block CTRL";
            this.cbBlockC.UseVisualStyleBackColor = true;
            this.cbBlockC.MouseHover += new System.EventHandler(this.cbBlockAC_MouseHover);
            // 
            // lbswithlayout
            // 
            this.lbswithlayout.AutoSize = true;
            this.lbswithlayout.BackColor = System.Drawing.Color.Transparent;
            this.lbswithlayout.Location = new System.Drawing.Point(189, 131);
            this.lbswithlayout.Name = "lbswithlayout";
            this.lbswithlayout.Size = new System.Drawing.Size(114, 13);
            this.lbswithlayout.TabIndex = 25;
            this.lbswithlayout.Text = "Switch layout by key:";
            // 
            // cbCSSwitch
            // 
            this.cbCSSwitch.AutoSize = true;
            this.cbCSSwitch.Location = new System.Drawing.Point(12, 130);
            this.cbCSSwitch.Name = "cbCSSwitch";
            this.cbCSSwitch.Size = new System.Drawing.Size(77, 17);
            this.cbCSSwitch.TabIndex = 7;
            this.cbCSSwitch.Text = "CS-Switch";
            this.cbCSSwitch.UseVisualStyleBackColor = true;
            this.cbCSSwitch.MouseHover += new System.EventHandler(this.cbUseCycleForCS_MouseHover);
            // 
            // cbUseEmulate
            // 
            this.cbUseEmulate.AutoSize = true;
            this.cbUseEmulate.Location = new System.Drawing.Point(201, 232);
            this.cbUseEmulate.Name = "cbUseEmulate";
            this.cbUseEmulate.Size = new System.Drawing.Size(48, 17);
            this.cbUseEmulate.TabIndex = 26;
            this.cbUseEmulate.Text = "Emu";
            this.cbUseEmulate.UseVisualStyleBackColor = true;
            this.cbUseEmulate.CheckedChanged += new System.EventHandler(this.cbUseEmulate_CheckedChanged);
            this.cbUseEmulate.MouseHover += new System.EventHandler(this.cbUseEmulate_MouseHover);
            // 
            // cbRePress
            // 
            this.cbRePress.AutoSize = true;
            this.cbRePress.Location = new System.Drawing.Point(110, 131);
            this.cbRePress.Name = "cbRePress";
            this.cbRePress.Size = new System.Drawing.Size(69, 17);
            this.cbRePress.TabIndex = 27;
            this.cbRePress.Text = "Re-Press";
            this.cbRePress.UseVisualStyleBackColor = true;
            this.cbRePress.MouseHover += new System.EventHandler(this.cbRePress_MouseHover);
            // 
            // cbEatOneSpace
            // 
            this.cbEatOneSpace.AutoSize = true;
            this.cbEatOneSpace.Location = new System.Drawing.Point(12, 149);
            this.cbEatOneSpace.Name = "cbEatOneSpace";
            this.cbEatOneSpace.Size = new System.Drawing.Size(49, 17);
            this.cbEatOneSpace.TabIndex = 28;
            this.cbEatOneSpace.Text = "\" \" ←";
            this.cbEatOneSpace.UseVisualStyleBackColor = true;
            this.cbEatOneSpace.MouseHover += new System.EventHandler(this.cbEatOneSpace_MouseHover);
            // 
            // cbResel
            // 
            this.cbResel.AutoSize = true;
            this.cbResel.Location = new System.Drawing.Point(110, 151);
            this.cbResel.Name = "cbResel";
            this.cbResel.Size = new System.Drawing.Size(73, 17);
            this.cbResel.TabIndex = 29;
            this.cbResel.Text = "Re-Select";
            this.cbResel.UseVisualStyleBackColor = true;
            this.cbResel.MouseHover += new System.EventHandler(this.cbResel_MouseHover);
            // 
            // cbELSType
            // 
            this.cbELSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbELSType.FormattingEnabled = true;
            this.cbELSType.Items.AddRange(new object[] {
            "Alt+Shift",
            "Ctrl+Shift",
            "Win+Space"});
            this.cbELSType.Location = new System.Drawing.Point(250, 230);
            this.cbELSType.Name = "cbELSType";
            this.cbELSType.Size = new System.Drawing.Size(73, 21);
            this.cbELSType.TabIndex = 30;
            this.cbELSType.MouseHover += new System.EventHandler(this.cbELSType_MouseHover);
            // 
            // btnDDD
            // 
            this.btnDDD.Location = new System.Drawing.Point(298, 146);
            this.btnDDD.Name = "btnDDD";
            this.btnDDD.Size = new System.Drawing.Size(25, 23);
            this.btnDDD.TabIndex = 31;
            this.btnDDD.Text = "...";
            this.btnDDD.UseVisualStyleBackColor = true;
            this.btnDDD.Click += new System.EventHandler(this.btnDDD_Click);
            // 
            // MahouForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 277);
            this.Controls.Add(this.btnDDD);
            this.Controls.Add(this.gbSBL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbELSType);
            this.Controls.Add(this.cbResel);
            this.Controls.Add(this.cbEatOneSpace);
            this.Controls.Add(this.cbRePress);
            this.Controls.Add(this.cbUseEmulate);
            this.Controls.Add(this.cbCSSwitch);
            this.Controls.Add(this.cbBlockC);
            this.Controls.Add(this.cbSwitchLayoutKeys);
            this.Controls.Add(this.lbswithlayout);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.cbCycleMode);
            this.Controls.Add(this.gbHK);
            this.Controls.Add(this.cbAutorun);
            this.Controls.Add(this.GitHubLink);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cbTrayIcon);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOK);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Mahou.Properties.Resources.MahouTrayHD;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MahouForm";
            this.Text = "Mahou";
            this.Activated += new System.EventHandler(this.MahouForm_Activated);
            this.Deactivate += new System.EventHandler(this.MahouForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MahouForm_FormClosing);
            this.Load += new System.EventHandler(this.MahouForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MahouForm_VisibleChanged);
            this.gbSBL.ResumeLayout(false);
            this.gbHK.ResumeLayout(false);
            this.gbHK.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl1lng;
        private System.Windows.Forms.Label lbl2lng;
        private System.Windows.Forms.ComboBox cbLangOne;
        private System.Windows.Forms.ComboBox cbLangTwo;
        private System.Windows.Forms.TextBox tbCLHK;
        private System.Windows.Forms.TextBox tbCSHK;
        private System.Windows.Forms.CheckBox cbTrayIcon;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.LinkLabel GitHubLink;
        private System.Windows.Forms.CheckBox cbAutorun;
        private System.Windows.Forms.GroupBox gbSBL;
        private System.Windows.Forms.GroupBox gbHK;
        private System.Windows.Forms.ToolTip HelpTT;
        private System.Windows.Forms.CheckBox cbCycleMode;
        private System.Windows.Forms.TextBox tbCLineHK;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.CheckBox cbCLineActive;
        private System.Windows.Forms.CheckBox cbCSActive;
        private System.Windows.Forms.CheckBox cbCLActive;
        private System.Windows.Forms.ComboBox cbSwitchLayoutKeys;
        private System.Windows.Forms.CheckBox cbBlockC;
        private System.Windows.Forms.Label lbswithlayout;
        private System.Windows.Forms.CheckBox cbCSSwitch;
        private System.Windows.Forms.CheckBox cbUseEmulate;
        private System.Windows.Forms.CheckBox cbRePress;
        private System.Windows.Forms.CheckBox cbEatOneSpace;
        private System.Windows.Forms.CheckBox cbResel;
        private System.Windows.Forms.ComboBox cbELSType;
        private System.Windows.Forms.Button btnDDD;
    }
}