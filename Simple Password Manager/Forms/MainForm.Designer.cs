
namespace SimplePM.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.spmFormStyle1 = new SimplePM.Forms.Elements.SPMFormStyle(this.components);
            this.addEntryButton = new SimplePM.Forms.Elements.CustomButton();
            this.entriesPanel = new System.Windows.Forms.Panel();
            this.entryInfoPanel = new System.Windows.Forms.Panel();
            this.passVisibilityButton = new System.Windows.Forms.Button();
            this.entryTitlePanel = new System.Windows.Forms.Panel();
            this.entryNameLabel = new System.Windows.Forms.Label();
            this.deleteEntryButton = new System.Windows.Forms.Button();
            this.editEntryButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new SimplePM.Forms.Elements.CustomTextBox();
            this.loginTextBox = new SimplePM.Forms.Elements.CustomTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.changePassButton = new SimplePM.Forms.Elements.CustomButton();
            this.generatePassButton = new SimplePM.Forms.Elements.CustomButton();
            this.minimizeButton = new SimplePM.Forms.Elements.CustomButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.accountButton = new SimplePM.Forms.Elements.CustomButton();
            this.entryInfoPanel.SuspendLayout();
            this.entryTitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // spmFormStyle1
            // 
            this.spmFormStyle1.AllowUserResize = true;
            this.spmFormStyle1.BackColor = System.Drawing.Color.Black;
            this.spmFormStyle1.ControlBoxButtonsWidth = 24;
            this.spmFormStyle1.Form = this;
            this.spmFormStyle1.FormStyle = SimplePM.Forms.Elements.SPMFormStyle.fStyle.Telegram;
            this.spmFormStyle1.HeaderColor = System.Drawing.Color.Black;
            this.spmFormStyle1.HeaderHeight = 20;
            this.spmFormStyle1.HeaderHorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.spmFormStyle1.HeaderImage = null;
            this.spmFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.spmFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.spmFormStyle1.HeaderVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.spmFormStyle1.ShowMaximizeButton = true;
            this.spmFormStyle1.ShowMinimizeButton = true;
            // 
            // addEntryButton
            // 
            this.addEntryButton.BackColor = System.Drawing.Color.Black;
            this.addEntryButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.addEntryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addEntryButton.Location = new System.Drawing.Point(14, 53);
            this.addEntryButton.Name = "addEntryButton";
            this.addEntryButton.Size = new System.Drawing.Size(194, 50);
            this.addEntryButton.TabIndex = 4;
            this.addEntryButton.Text = "Add new entry";
            this.addEntryButton.Click += new System.EventHandler(this.addEntryButton_Click);
            // 
            // entriesPanel
            // 
            this.entriesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.entriesPanel.AutoScroll = true;
            this.entriesPanel.Location = new System.Drawing.Point(214, 53);
            this.entriesPanel.Name = "entriesPanel";
            this.entriesPanel.Size = new System.Drawing.Size(271, 435);
            this.entriesPanel.TabIndex = 5;
            // 
            // entryInfoPanel
            // 
            this.entryInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryInfoPanel.Controls.Add(this.passVisibilityButton);
            this.entryInfoPanel.Controls.Add(this.entryTitlePanel);
            this.entryInfoPanel.Controls.Add(this.passwordTextBox);
            this.entryInfoPanel.Controls.Add(this.loginTextBox);
            this.entryInfoPanel.Controls.Add(this.label2);
            this.entryInfoPanel.Controls.Add(this.label1);
            this.entryInfoPanel.Location = new System.Drawing.Point(492, 53);
            this.entryInfoPanel.Name = "entryInfoPanel";
            this.entryInfoPanel.Size = new System.Drawing.Size(416, 435);
            this.entryInfoPanel.TabIndex = 6;
            // 
            // passVisibilityButton
            // 
            this.passVisibilityButton.BackColor = System.Drawing.Color.Transparent;
            this.passVisibilityButton.BackgroundImage = global::SimplePM.Properties.Resources.visible_icon;
            this.passVisibilityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.passVisibilityButton.FlatAppearance.BorderSize = 0;
            this.passVisibilityButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumOrchid;
            this.passVisibilityButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.passVisibilityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passVisibilityButton.Location = new System.Drawing.Point(350, 127);
            this.passVisibilityButton.Name = "passVisibilityButton";
            this.passVisibilityButton.Size = new System.Drawing.Size(30, 30);
            this.passVisibilityButton.TabIndex = 2;
            this.passVisibilityButton.UseVisualStyleBackColor = false;
            this.passVisibilityButton.Visible = false;
            this.passVisibilityButton.Click += new System.EventHandler(this.passVisibilityButton_Click);
            // 
            // entryTitlePanel
            // 
            this.entryTitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryTitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.entryTitlePanel.Controls.Add(this.entryNameLabel);
            this.entryTitlePanel.Controls.Add(this.deleteEntryButton);
            this.entryTitlePanel.Controls.Add(this.editEntryButton);
            this.entryTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.entryTitlePanel.Name = "entryTitlePanel";
            this.entryTitlePanel.Size = new System.Drawing.Size(416, 66);
            this.entryTitlePanel.TabIndex = 4;
            // 
            // entryNameLabel
            // 
            this.entryNameLabel.AutoSize = true;
            this.entryNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.entryNameLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.entryNameLabel.ForeColor = System.Drawing.Color.White;
            this.entryNameLabel.Location = new System.Drawing.Point(4, 30);
            this.entryNameLabel.Name = "entryNameLabel";
            this.entryNameLabel.Size = new System.Drawing.Size(0, 23);
            this.entryNameLabel.TabIndex = 2;
            // 
            // deleteEntryButton
            // 
            this.deleteEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteEntryButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteEntryButton.BackgroundImage = global::SimplePM.Properties.Resources.delete_icon;
            this.deleteEntryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteEntryButton.FlatAppearance.BorderSize = 0;
            this.deleteEntryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumOrchid;
            this.deleteEntryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.deleteEntryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteEntryButton.Location = new System.Drawing.Point(348, 13);
            this.deleteEntryButton.Name = "deleteEntryButton";
            this.deleteEntryButton.Size = new System.Drawing.Size(40, 40);
            this.deleteEntryButton.TabIndex = 1;
            this.deleteEntryButton.UseVisualStyleBackColor = false;
            this.deleteEntryButton.Click += new System.EventHandler(this.deleteEntryButton_Click);
            // 
            // editEntryButton
            // 
            this.editEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editEntryButton.BackColor = System.Drawing.Color.Transparent;
            this.editEntryButton.BackgroundImage = global::SimplePM.Properties.Resources.edit_icon;
            this.editEntryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editEntryButton.FlatAppearance.BorderSize = 0;
            this.editEntryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumOrchid;
            this.editEntryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.editEntryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editEntryButton.Location = new System.Drawing.Point(293, 13);
            this.editEntryButton.Name = "editEntryButton";
            this.editEntryButton.Size = new System.Drawing.Size(40, 40);
            this.editEntryButton.TabIndex = 0;
            this.editEntryButton.UseVisualStyleBackColor = false;
            this.editEntryButton.Click += new System.EventHandler(this.editEntryButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.Black;
            this.passwordTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.passwordTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.passwordTextBox.BorderSize = 2;
            this.passwordTextBox.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.passwordTextBox.Location = new System.Drawing.Point(118, 126);
            this.passwordTextBox.Multiline = false;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Padding = new System.Windows.Forms.Padding(7);
            this.passwordTextBox.PasswordChar = true;
            this.passwordTextBox.ReadOnly = true;
            this.passwordTextBox.Size = new System.Drawing.Size(226, 31);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Texts = "";
            this.passwordTextBox.UnderlinedStyle = true;
            this.passwordTextBox.Visible = false;
            // 
            // loginTextBox
            // 
            this.loginTextBox.BackColor = System.Drawing.Color.Black;
            this.loginTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.loginTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.loginTextBox.BorderSize = 2;
            this.loginTextBox.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.loginTextBox.Location = new System.Drawing.Point(118, 86);
            this.loginTextBox.Multiline = false;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Padding = new System.Windows.Forms.Padding(7);
            this.loginTextBox.PasswordChar = false;
            this.loginTextBox.ReadOnly = true;
            this.loginTextBox.Size = new System.Drawing.Size(262, 31);
            this.loginTextBox.TabIndex = 2;
            this.loginTextBox.Texts = "";
            this.loginTextBox.UnderlinedStyle = true;
            this.loginTextBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            this.label1.Visible = false;
            // 
            // changePassButton
            // 
            this.changePassButton.BackColor = System.Drawing.Color.Black;
            this.changePassButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.changePassButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.changePassButton.Location = new System.Drawing.Point(14, 110);
            this.changePassButton.Name = "changePassButton";
            this.changePassButton.Size = new System.Drawing.Size(194, 50);
            this.changePassButton.TabIndex = 7;
            this.changePassButton.Text = "Change main password";
            this.changePassButton.Click += new System.EventHandler(this.changePassButton_Click);
            // 
            // generatePassButton
            // 
            this.generatePassButton.BackColor = System.Drawing.Color.Black;
            this.generatePassButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.generatePassButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.generatePassButton.Location = new System.Drawing.Point(14, 166);
            this.generatePassButton.Name = "generatePassButton";
            this.generatePassButton.Size = new System.Drawing.Size(194, 50);
            this.generatePassButton.TabIndex = 8;
            this.generatePassButton.Text = "Generate Password";
            this.generatePassButton.Click += new System.EventHandler(this.generatePassButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minimizeButton.BackColor = System.Drawing.Color.Black;
            this.minimizeButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.minimizeButton.Location = new System.Drawing.Point(14, 438);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(194, 50);
            this.minimizeButton.TabIndex = 9;
            this.minimizeButton.Text = "Minimize";
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Simple Password Manager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // accountButton
            // 
            this.accountButton.BackColor = System.Drawing.Color.Black;
            this.accountButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.accountButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.accountButton.Location = new System.Drawing.Point(14, 222);
            this.accountButton.Name = "accountButton";
            this.accountButton.Size = new System.Drawing.Size(194, 50);
            this.accountButton.TabIndex = 10;
            this.accountButton.Text = "Manage SPM Account";
            this.accountButton.Click += new System.EventHandler(this.accountButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 500);
            this.Controls.Add(this.accountButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.generatePassButton);
            this.Controls.Add(this.changePassButton);
            this.Controls.Add(this.entryInfoPanel);
            this.Controls.Add(this.entriesPanel);
            this.Controls.Add(this.addEntryButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "MainForm";
            this.Text = "Simple Password Manager v0.3 beta";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.entryInfoPanel.ResumeLayout(false);
            this.entryInfoPanel.PerformLayout();
            this.entryTitlePanel.ResumeLayout(false);
            this.entryTitlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Elements.SPMFormStyle spmFormStyle1;
        private Elements.CustomButton addEntryButton;
        private System.Windows.Forms.Panel entriesPanel;
        private System.Windows.Forms.Panel entryInfoPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Elements.CustomTextBox passwordTextBox;
        private Elements.CustomTextBox loginTextBox;
        private Elements.CustomButton changePassButton;
        private Elements.CustomButton generatePassButton;
        private System.Windows.Forms.Panel entryTitlePanel;
        private System.Windows.Forms.Button editEntryButton;
        private System.Windows.Forms.Button deleteEntryButton;
        private System.Windows.Forms.Button passVisibilityButton;
        private System.Windows.Forms.Label entryNameLabel;
        private Elements.CustomButton minimizeButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private Elements.CustomButton accountButton;
    }
}

