using SimplePM.Forms.Elements;
using SimplePM.Library.Assets.Processing;
using SimplePM.Library.Networking;
using SimplePM.Library.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SimplePM.Library.Diagnostics;

namespace SimplePM.Forms
{
    public partial class MainForm : ShadowedForm
    {
        //Fields
        private string _currentEntryID;
        public static EntriesProcessor processor;

        // Constructor
        public MainForm()
        {
            InitializeComponent();
            processor = new EntriesProcessor();
            UpdateEntriesPanel();
            FormClosed += new FormClosedEventHandler(OnFormClosed);
        }

        // Private Methods
        private async void UpdateEntriesPanel()
        {
            if (Properties.Settings.Default.IsSignedIn)
            {
                try
                {
                    await processor.SynchronizeAsync(Properties.Settings.Default.AccountID);
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
            entriesPanel.Controls.Clear();
            try
            {
                List<Entry> entriesList = processor.RetrieveAll().ToList();
                int y = 0;
                foreach (Entry entry in entriesList)
                {
                    EntriesButton button = new EntriesButton();
                    button.NameText = entry.Name;
                    button.UrlText = entry.URL;
                    button.Location = new Point(0, y);
                    button.Click += (sender, e) => entryButton_Click(sender, e, entry.ID);
                    entriesPanel.Controls.Add(button);
                    y += 70;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}. Application will be closed due to critical malfunction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.CreateExceptionEntry(ex);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.CreateExceptionEntry(ex);
            }
            HideEntryControls();
        }

        private void HideEntryControls()
        {
            label1.Visible = false;
            label2.Visible = false;
            entryNameLabel.Visible = false;
            passVisibilityButton.Visible = false;
            loginTextBox.Visible = false;
            passwordTextBox.Visible = false;
        }

        // UI Elements Event Handlers
        private void addEntryButton_Click(object sender, EventArgs e)
        {
            WorkWithEntryForm workWithEntryForm = new WorkWithEntryForm();
            if (workWithEntryForm.ShowDialog() == DialogResult.OK)
            {
                UpdateEntriesPanel();
            }
        }

        private async void changePassButton_Click(object sender, EventArgs e)
        {
            string oldMasterPassword = Properties.Settings.Default.MasterPassword;
            ChangePassForm changePassForm = new ChangePassForm();
            if (changePassForm.ShowDialog() == DialogResult.OK)
            {
                
                processor.UpdateEntriesEncryption(oldMasterPassword, Properties.Settings.Default.MasterPassword);
                UpdateEntriesPanel();
            }
        }

        private void generatePassButton_Click(object sender, EventArgs e)
        {
            PassGeneratorForm passGeneratorForm = new PassGeneratorForm();
            passGeneratorForm.ShowDialog();
        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            string oldMasterPassword = Properties.Settings.Default.MasterPassword;
            ManageAccountForm manageAccountForm = new ManageAccountForm();
            if (manageAccountForm.ShowDialog() == DialogResult.OK)
            {
                processor.UpdateEntriesEncryption(oldMasterPassword, Properties.Settings.Default.MasterPassword);
                UpdateEntriesPanel();
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            minimizeButton.MouseEntered = false;
            minimizeButton.MousePressed = false;
            ShowInTaskbar = false;
        }

        private void entryButton_Click(object sender, EventArgs e, string id)
        {
            try
            {
                var item = processor.Retrieve(id, Properties.Settings.Default.MasterPassword);
                entryNameLabel.Text = item.Name;
                loginTextBox.Texts = item.Login;
                passwordTextBox.Texts = item.Password;
                _currentEntryID = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.CreateExceptionEntry(ex);
            }
            label1.Visible = true;
            label2.Visible = true;
            entryNameLabel.Visible = true;
            loginTextBox.Visible = true;
            passwordTextBox.Visible = true;
            passVisibilityButton.Visible = true;
        }

        private void editEntryButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(_currentEntryID))
            {
                try
                {
                    var item = processor.Retrieve(_currentEntryID, Properties.Settings.Default.MasterPassword);
                    WorkWithEntryForm workWithEntryForm = new WorkWithEntryForm(item);
                    if (workWithEntryForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateEntriesPanel();
                        entryButton_Click(this, null, _currentEntryID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.GetType()}: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteEntryButton_Click(object sender, EventArgs e)
        {
            try
            {
                processor.Delete(_currentEntryID);
                UpdateEntriesPanel();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void passVisibilityButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.PasswordChar)
            {
                passwordTextBox.PasswordChar = false;
            }
            else
            {
                passwordTextBox.PasswordChar = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            UpdateEntriesPanel();
            ShowInTaskbar = true;
        }

        // Form Event Handlers
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
