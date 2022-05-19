
namespace SimplePM.Forms
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.enterMainPassLabel = new System.Windows.Forms.Label();
            this.passwordNullOrEmptyLabel = new System.Windows.Forms.Label();
            this.incorrectPasswordLabel = new System.Windows.Forms.Label();
            this.setMainPassLabel = new System.Windows.Forms.Label();
            this.confirmButton = new SimplePM.Forms.Elements.CustomButton();
            this.customTextBox1 = new SimplePM.Forms.Elements.CustomTextBox();
            this.spmFormStyle1 = new SimplePM.Forms.Elements.SPMFormStyle(this.components);
            this.visibilityButton = new System.Windows.Forms.Button();
            this.resetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enterMainPassLabel
            // 
            this.enterMainPassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enterMainPassLabel.AutoSize = true;
            this.enterMainPassLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.enterMainPassLabel.ForeColor = System.Drawing.Color.White;
            this.enterMainPassLabel.Location = new System.Drawing.Point(127, 100);
            this.enterMainPassLabel.Name = "enterMainPassLabel";
            this.enterMainPassLabel.Size = new System.Drawing.Size(157, 17);
            this.enterMainPassLabel.TabIndex = 1;
            this.enterMainPassLabel.Text = "Enter main password";
            this.enterMainPassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enterMainPassLabel.Visible = false;
            // 
            // incorrectPasswordLabel
            // 
            this.incorrectPasswordLabel.AutoSize = true;
            this.incorrectPasswordLabel.Font = new System.Drawing.Font("Verdana", 7F);
            this.incorrectPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.incorrectPasswordLabel.Location = new System.Drawing.Point(130, 158);
            this.incorrectPasswordLabel.Name = "incorrectPasswordLabel";
            this.incorrectPasswordLabel.Size = new System.Drawing.Size(140, 12);
            this.incorrectPasswordLabel.TabIndex = 3;
            this.incorrectPasswordLabel.Text = "Incorrect main password";
            this.incorrectPasswordLabel.Visible = false;
            // 
            // passwordNullOrEmptyLabel
            // 
            this.passwordNullOrEmptyLabel.AutoSize = true;
            this.passwordNullOrEmptyLabel.Font = new System.Drawing.Font("Verdana", 7F);
            this.passwordNullOrEmptyLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordNullOrEmptyLabel.Location = new System.Drawing.Point(130, 158);
            this.passwordNullOrEmptyLabel.Name = "passwordNullOrEmptyLabel";
            this.passwordNullOrEmptyLabel.Size = new System.Drawing.Size(140, 12);
            this.passwordNullOrEmptyLabel.TabIndex = 3;
            this.passwordNullOrEmptyLabel.Text = "Entered password is empty";
            this.passwordNullOrEmptyLabel.Visible = false;
            // 
            // setMainPassLabel
            // 
            this.setMainPassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setMainPassLabel.AutoSize = true;
            this.setMainPassLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.setMainPassLabel.ForeColor = System.Drawing.Color.White;
            this.setMainPassLabel.Location = new System.Drawing.Point(108, 104);
            this.setMainPassLabel.Name = "setMainPassLabel";
            this.setMainPassLabel.Size = new System.Drawing.Size(194, 17);
            this.setMainPassLabel.TabIndex = 4;
            this.setMainPassLabel.Text = "Please, set main password";
            this.setMainPassLabel.Visible = false;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.BackColor = System.Drawing.Color.Black;
            this.confirmButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.confirmButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.confirmButton.Location = new System.Drawing.Point(175, 225);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(100, 30);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "Unlock";
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // customTextBox1
            // 
            this.customTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTextBox1.BackColor = System.Drawing.Color.Black;
            this.customTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.customTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.customTextBox1.BorderSize = 2;
            this.customTextBox1.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.customTextBox1.Location = new System.Drawing.Point(80, 120);
            this.customTextBox1.Multiline = false;
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.customTextBox1.PasswordChar = true;
            this.customTextBox1.ReadOnly = false;
            this.customTextBox1.Size = new System.Drawing.Size(250, 31);
            this.customTextBox1.TabIndex = 0;
            this.customTextBox1.Texts = "";
            this.customTextBox1.UnderlinedStyle = true;
            // 
            // spmFormStyle1
            // 
            this.spmFormStyle1.AllowUserResize = false;
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
            this.spmFormStyle1.ShowMaximizeButton = false;
            this.spmFormStyle1.ShowMinimizeButton = false;
            // 
            // visibilityButton
            // 
            this.visibilityButton.BackColor = System.Drawing.Color.Transparent;
            this.visibilityButton.BackgroundImage = global::SimplePM.Properties.Resources.visible_icon;
            this.visibilityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.visibilityButton.FlatAppearance.BorderSize = 0;
            this.visibilityButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumOrchid;
            this.visibilityButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.visibilityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visibilityButton.Location = new System.Drawing.Point(336, 121);
            this.visibilityButton.Name = "visibilityButton";
            this.visibilityButton.Size = new System.Drawing.Size(30, 30);
            this.visibilityButton.TabIndex = 5;
            this.visibilityButton.UseVisualStyleBackColor = false;
            this.visibilityButton.Click += new System.EventHandler(this.visibilityButton_Click);
            // 
            // resetLabel
            // 
            this.resetLabel.AutoSize = true;
            this.resetLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.resetLabel.Location = new System.Drawing.Point(77, 199);
            this.resetLabel.Name = "resetLabel";
            this.resetLabel.Size = new System.Drawing.Size(278, 13);
            this.resetLabel.TabIndex = 10;
            this.resetLabel.Text = "If you forgot your password, you can reset app";
            this.resetLabel.Click += new System.EventHandler(this.resetLabel_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.resetLabel);
            this.Controls.Add(this.visibilityButton);
            this.Controls.Add(this.setMainPassLabel);
            this.Controls.Add(this.incorrectPasswordLabel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.enterMainPassLabel);
            this.Controls.Add(this.customTextBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "StartupForm";
            this.Text = "Simple Password Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Elements.SPMFormStyle spmFormStyle1;
        private Elements.CustomTextBox customTextBox1;
        private System.Windows.Forms.Label enterMainPassLabel;
        private Elements.CustomButton confirmButton;
        private System.Windows.Forms.Label incorrectPasswordLabel;
        private System.Windows.Forms.Label passwordNullOrEmptyLabel;
        private System.Windows.Forms.Label setMainPassLabel;
        private System.Windows.Forms.Button visibilityButton;
        private System.Windows.Forms.Label resetLabel;
    }
}