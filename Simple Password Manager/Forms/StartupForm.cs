using SimplePM.Library.Diagnostics;
using SimplePM.Library.Networking;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePM.Forms
{
    public partial class StartupForm : ShadowedForm
    {
        private string login;
        private string password;

        public StartupForm(string login = null, string password = null)
        {
            InitializeComponent();
            confirmButton.SF.Alignment = StringAlignment.Center;
            this.login = login;
            this.password = password;
            if (this.login is not null && this.password is not null)
            {
                setMainPassLabel.Visible = true;
            }
            else
            {
                if (Properties.Settings.Default.IsSignedIn)
                {
                    if (Properties.Settings.Default.IsReset)
                    {
                        setMainPassLabel.Visible = true;
                    }
                    else
                    {
                        enterMainPassLabel.Visible = true;
                    }
                }
                else
                {
                    if (Properties.Settings.Default.IsReset)
                    {
                        setMainPassLabel.Visible = true;
                    }
                    else
                    {
                        enterMainPassLabel.Visible = true;
                    }
                }
            }
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(customTextBox1.Texts))
            {
                passwordNullOrEmptyLabel.Visible = true;
                return;
            }
            string enteredMasterPassword = customTextBox1.Texts;
            try
            {
                if (login is not null && password is not null)
                {
                    SettingsProcessor.UpdateMasterPassword(enteredMasterPassword);
                    string accountID = await UserDataSyncProvider.RegisterAsync(login, password, enteredMasterPassword);
                    SettingsProcessor.UpdateAccountID(accountID);
                    SettingsProcessor.UpdateSignedInStatus(true);
                }
                else
                {
                    if (Properties.Settings.Default.IsSignedIn)
                    {
                        if (Properties.Settings.Default.IsReset)
                        {
                            ConfirmIdentityForm confirmIdentityForm = new ConfirmIdentityForm(true, enteredMasterPassword);
                            if (!(confirmIdentityForm.ShowDialog() == DialogResult.OK))
                            {
                                if (MessageBox.Show("Updating master password to remote server failed. Do you wish to sign out and change master password for this particular PC?" +
                                    " (If you want to change master password for your account later, you may do it using \"Manage SPM Account\" menu).",
                                    "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    SettingsProcessor.UpdateMasterPassword(enteredMasterPassword);
                                    SettingsProcessor.UpdateAccountID(String.Empty);
                                    SettingsProcessor.UpdateSignedInStatus(false);
                                    SettingsProcessor.UpdateResetStatus(false);
#warning master password versioning required
                                }
                            }
                        }
                        else
                        {
                            if (!SettingsProcessor.IsEnteredPasswordMatch(enteredMasterPassword))
                            {
                                incorrectPasswordLabel.Visible = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (Properties.Settings.Default.IsReset)
                        {
                            SettingsProcessor.UpdateMasterPassword(enteredMasterPassword);
                            SettingsProcessor.UpdateResetStatus(false);
                        }
                        else
                        {
                            if (!SettingsProcessor.IsEnteredPasswordMatch(enteredMasterPassword))
                            {
                                incorrectPasswordLabel.Visible = true;
                                return;
                            }
                        }
                    }
                }
                ShowMainform();
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                MessageBox.Show($"{ex.Message} Proceeding in standalone mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.CreateExceptionEntry(ex);
            }
        }

        private void visibilityButton_Click(object sender, EventArgs e)
        {
            if (customTextBox1.PasswordChar)
            {
                customTextBox1.PasswordChar = false;
            }
            else
            {
                customTextBox1.PasswordChar = true;
            }
        }

        private void resetLabel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will erase all of your entries. Do you wish to proceed?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SettingsProcessor.UpdateResetStatus(true);
                SettingsProcessor.UpdateMasterPassword(String.Empty, String.Empty);
                Application.Restart();
            }
        }

        private void ShowMainform()
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
