namespace SimplePM.Forms
{
    partial class ManageAccountForm
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
            this.spmFormStyle1 = new SimplePM.Forms.Elements.SPMFormStyle(this.components);
            this.SuspendLayout();
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
            // ManageAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ManageAccountForm";
            this.Text = "ManageAccountForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Elements.SPMFormStyle spmFormStyle1;
    }
}