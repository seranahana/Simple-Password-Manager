using SimplePM.Library.Diagnostics;
using SimplePM.Library.Models;
using SimplePM.Library.Networking;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePM.Forms
{
    public partial class FirstStartupForm : ShadowedForm
    {
        private readonly string caller;
        public FirstStartupForm(string caller)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            signUpConfirmButton.SF.Alignment = StringAlignment.Center;
            signInButton.SF.Alignment = StringAlignment.Center;
            signUpButton.SF.Alignment = StringAlignment.Center;
            signInConfirmButton.SF.Alignment = StringAlignment.Center;
            this.caller = caller;
        }

        private async void signUpConfirmButton_Click(object sender, EventArgs e)
        {
            string enteredLogin = signUpTextBox1.Texts;
            string enteredPassword = signUpTextBox2.Texts;
            string passwordConfirmation = signUpTextBox3.Texts;
            if (await UserDataSyncProvider.CheckLoginAvailabilityAsync(enteredLogin))
            {
                if (enteredPassword == passwordConfirmation)
                {
                    StartupForm startupForm = new StartupForm(enteredLogin, enteredPassword);
                    startupForm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Entered passwords do not match", "", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("This login is already occupied", "", MessageBoxButtons.OK);
            }
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            ConfirmIdentityForm confirmIdentityForm = new ConfirmIdentityForm(false);
            if (confirmIdentityForm.ShowDialog() == DialogResult.OK)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                Hide();
            }
            else
            {
                StartupForm startupForm = new StartupForm();
                startupForm.Show();
                Hide();
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            signUpLabel1.Visible = true;
            signUpLabel2.Visible = true;
            signUpLabel3.Visible = true;
            greetingsLabel.Visible = false;
            signUpConfirmButton.Visible = true;
            signInButton.Visible = false;
            signUpButton.Visible = false;
            signUpTextBox1.Visible = true;
            signUpTextBox2.Visible = true;
            signUpTextBox3.Visible = true;
            
        }
    }
}
