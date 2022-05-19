using SimplePM.Library.Diagnostics;
using SimplePM.Library.Networking;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePM.Forms
{
    public partial class ChangePassForm : ShadowedForm
    {
        public ChangePassForm()
        {
            InitializeComponent();
            customButton1.SF.Alignment = StringAlignment.Center;
            DialogResult = DialogResult.Cancel;
        }

        private async void customButton1_Click(object sender, EventArgs e)
        {
            if (SettingsProcessor.IsEnteredPasswordMatch(customTextBox1.Texts))
            {
                if (customTextBox2.Texts == customTextBox3.Texts && String.IsNullOrWhiteSpace(customTextBox2.Texts) && String.IsNullOrWhiteSpace(customTextBox3.Texts))
                {
                    string oldMasterPassword = Properties.Settings.Default.MasterPassword;
                    SettingsProcessor.UpdateMasterPassword(customTextBox2.Texts);
                    DialogResult = DialogResult.OK;
                    if (Properties.Settings.Default.IsSignedIn)
                    {
                        try
                        {
                            await UserDataSyncProvider.UploadMasterPasswordAsync(Properties.Settings.Default.AccountID, oldMasterPassword, customTextBox2.Texts);
                        }
                        catch (System.Net.Http.HttpRequestException ex)
                        {
                            MessageBox.Show($"{ex.Message} Proceeding in standalone mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{ex.GetType()}: {ex.Message}. Proceeding in standalone mode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Logger.CreateExceptionEntry(ex);
                        }
                    }
                    Close();
                }
                else
                {
                    label5.Visible = true;
                }
            }
            else
            {
                label4.Visible = true;
            }
        }
    }
}
