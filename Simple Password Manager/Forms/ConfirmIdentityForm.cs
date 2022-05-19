using SimplePM.Library;
using SimplePM.Library.Diagnostics;
using SimplePM.Library.Networking;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePM.Forms
{
    public partial class ConfirmIdentityForm : Form
    {
        private bool isReset;
        private string newMasterPassword;
        public ConfirmIdentityForm(bool isReset, string newMasterPassword = null)
        {
            InitializeComponent();
            confirmButton.SF.Alignment = StringAlignment.Center;
            DialogResult = DialogResult.Cancel;
            this.isReset = isReset;
            this.newMasterPassword = newMasterPassword;
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isReset)
                {
                    var (ID, MasterPassword, MasterSalt) = await UserDataSyncProvider.AuthorizeAsync(loginTextBox.Texts, passwordTextBox.Texts);
                    SettingsProcessor.UpdateAccountID(ID);
                    SettingsProcessor.UpdateMasterPassword(MasterPassword);
                    SettingsProcessor.UpdateMasterPassword(MasterSalt);
                    SettingsProcessor.UpdateSignedInStatus(true);
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(newMasterPassword))
                    {
                        var (NewMasterPassword, NewMasterSalt) = await UserDataSyncProvider.ResetMasterPasswordAsync(loginTextBox.Texts, passwordTextBox.Texts, newMasterPassword);
                        SettingsProcessor.UpdateMasterPassword(NewMasterPassword);
                        SettingsProcessor.UpdateMasterPassword(NewMasterSalt);
                        SettingsProcessor.UpdateResetStatus(true);
                    }
                    else
                    {
                        MessageBox.Show("Entered master password is empty. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)
            {
                var type = typeof(UserDataSyncProvider);
                System.Reflection.MethodInfo method = type.GetMethod("AuthorizeAsync");
                if (ex.ParamName == method.GetParamName(0))
                {
                    MessageBox.Show("Incorrect login");
                    return;
                }
                if (ex.ParamName == method.GetParamName(1))
                {
                    MessageBox.Show("Incorrect password");
                    return;
                }
                MessageBox.Show($"{ex.GetType()}: {ex.Message}. Proceeding in standalone mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.CreateExceptionEntry(ex);
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}. Proceeding in standalone mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}. Proceeding in standalone mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.CreateExceptionEntry(ex);
            }
            finally
            {
                Close();
            }
        }
    }
}
