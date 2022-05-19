namespace SimplePM.Forms
{
    partial class ConfirmIdentityForm
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
            this.confirmButton = new SimplePM.Forms.Elements.CustomButton();
            this.confirmIdentityLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new SimplePM.Forms.Elements.CustomTextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new SimplePM.Forms.Elements.CustomTextBox();
            this.spmFormStyle1 = new SimplePM.Forms.Elements.SPMFormStyle(this.components);
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.Black;
            this.confirmButton.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirmButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.confirmButton.Location = new System.Drawing.Point(227, 323);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(117, 23);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // confirmIdentityLabel
            // 
            this.confirmIdentityLabel.AutoSize = true;
            this.confirmIdentityLabel.Font = new System.Drawing.Font("Verdana", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirmIdentityLabel.ForeColor = System.Drawing.Color.White;
            this.confirmIdentityLabel.Location = new System.Drawing.Point(130, 80);
            this.confirmIdentityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.confirmIdentityLabel.Name = "confirmIdentityLabel";
            this.confirmIdentityLabel.Size = new System.Drawing.Size(288, 17);
            this.confirmIdentityLabel.TabIndex = 18;
            this.confirmIdentityLabel.Text = "Please, confirm your identity to proceed";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.Black;
            this.loginLabel.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginLabel.ForeColor = System.Drawing.Color.White;
            this.loginLabel.Location = new System.Drawing.Point(146, 137);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(121, 17);
            this.loginLabel.TabIndex = 17;
            this.loginLabel.Text = "Enter your login";
            // 
            // loginTextBox
            // 
            this.loginTextBox.BackColor = System.Drawing.Color.Black;
            this.loginTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.loginTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.loginTextBox.BorderSize = 2;
            this.loginTextBox.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.loginTextBox.Location = new System.Drawing.Point(146, 158);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loginTextBox.Multiline = false;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.loginTextBox.PasswordChar = false;
            this.loginTextBox.ReadOnly = false;
            this.loginTextBox.Size = new System.Drawing.Size(292, 33);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Texts = "";
            this.loginTextBox.UnderlinedStyle = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(142, 214);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(119, 17);
            this.passwordLabel.TabIndex = 18;
            this.passwordLabel.Text = "Enter password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.Black;
            this.passwordTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.passwordTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.passwordTextBox.BorderSize = 2;
            this.passwordTextBox.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.passwordTextBox.Location = new System.Drawing.Point(146, 232);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.passwordTextBox.Multiline = false;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.passwordTextBox.PasswordChar = true;
            this.passwordTextBox.ReadOnly = false;
            this.passwordTextBox.Size = new System.Drawing.Size(292, 33);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Texts = "";
            this.passwordTextBox.UnderlinedStyle = true;
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
            this.spmFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.spmFormStyle1.HeaderVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.spmFormStyle1.ShowMaximizeButton = true;
            this.spmFormStyle1.ShowMinimizeButton = true;
            // 
            // ConfirmIdentityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 404);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.confirmIdentityLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(117, 58);
            this.Name = "ConfirmIdentityForm";
            this.Text = "Confirm identity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Elements.SPMFormStyle spmFormStyle1;
        private Elements.CustomButton confirmButton;
        private System.Windows.Forms.Label confirmIdentityLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private Elements.CustomTextBox loginTextBox;
        private Elements.CustomTextBox passwordTextBox;

    }
}