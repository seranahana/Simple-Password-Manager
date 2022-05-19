
namespace SimplePM.Forms
{
    partial class PassGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassGeneratorForm));
            this.customButton1 = new Elements.CustomButton();
            this.spmFormStyle1 = new Elements.SPMFormStyle(this.components);
            this.customComboBox1 = new Elements.CustomComboBox();
            this.customTextBox1 = new Elements.CustomTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.Black;
            this.customButton1.Font = new System.Drawing.Font("Verdana", 11F);
            this.customButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.customButton1.Location = new System.Drawing.Point(212, 220);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(76, 30);
            this.customButton1.TabIndex = 0;
            this.customButton1.Text = "Generate";
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // spmFormStyle1
            // 
            this.spmFormStyle1.AllowUserResize = false;
            this.spmFormStyle1.BackColor = System.Drawing.Color.Black;
            this.spmFormStyle1.ControlBoxButtonsWidth = 24;
            this.spmFormStyle1.Form = this;
            this.spmFormStyle1.FormStyle = Elements.SPMFormStyle.fStyle.Telegram;
            this.spmFormStyle1.HeaderColor = System.Drawing.Color.Black;
            this.spmFormStyle1.HeaderHeight = 20;
            this.spmFormStyle1.HeaderHorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.spmFormStyle1.HeaderImage = null;
            this.spmFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.spmFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.spmFormStyle1.HeaderVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.spmFormStyle1.ShowMaximizeButton = false;
            this.spmFormStyle1.ShowMinimizeButton = true;
            // 
            // customComboBox1
            // 
            this.customComboBox1.BackColor = System.Drawing.Color.Black;
            this.customComboBox1.BorderColor = System.Drawing.Color.White;
            this.customComboBox1.BorderSize = 1;
            this.customComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.customComboBox1.ForeColor = System.Drawing.Color.White;
            this.customComboBox1.IconColor = System.Drawing.Color.White;
            this.customComboBox1.ListBackColor = System.Drawing.Color.Black;
            this.customComboBox1.ListForeColor = System.Drawing.Color.White;
            this.customComboBox1.Location = new System.Drawing.Point(225, 80);
            this.customComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.customComboBox1.Name = "customComboBox1";
            this.customComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.customComboBox1.Size = new System.Drawing.Size(200, 30);
            this.customComboBox1.TabIndex = 1;
            this.customComboBox1.Texts = "";
            // 
            // customTextBox1
            // 
            this.customTextBox1.BackColor = System.Drawing.Color.Black;
            this.customTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.customTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.customTextBox1.BorderSize = 2;
            this.customTextBox1.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.customTextBox1.Location = new System.Drawing.Point(47, 160);
            this.customTextBox1.Multiline = false;
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.customTextBox1.PasswordChar = false;
            this.customTextBox1.ReadOnly = false;
            this.customTextBox1.Size = new System.Drawing.Size(378, 31);
            this.customTextBox1.TabIndex = 2;
            this.customTextBox1.Texts = "";
            this.customTextBox1.UnderlinedStyle = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password length";
            // 
            // PassGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customTextBox1);
            this.Controls.Add(this.customComboBox1);
            this.Controls.Add(this.customButton1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "PassGeneratorForm";
            this.Text = "Password Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Elements.SPMFormStyle spmFormStyle1;
        private Elements.CustomButton customButton1;
        private Elements.CustomTextBox customTextBox1;
        private Elements.CustomComboBox customComboBox1;
        private System.Windows.Forms.Label label1;
    }
}