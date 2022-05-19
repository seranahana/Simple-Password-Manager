using SimplePM.Library.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePM.Forms
{
    public partial class WorkWithEntryForm : ShadowedForm
    {
        private static Entry EntryToEdit;
        private static bool AsEditor = false;
        public WorkWithEntryForm()
        {
            InitializeComponent();
            customButton1.SF.Alignment = StringAlignment.Center;
            DialogResult = DialogResult.Cancel;
            AsEditor = false;
        }
        public WorkWithEntryForm(Entry entryToEdit)
        {
            InitializeComponent();
            customButton1.SF.Alignment = StringAlignment.Center;
            customButton1.Text = "Confirm";
            customTextBox1.Texts = entryToEdit.Name;
            customTextBox2.Texts = entryToEdit.URL;
            customTextBox3.Texts = entryToEdit.Login;
            customTextBox4.Texts = entryToEdit.Password;
            Text = "Edit entry";
            DialogResult = DialogResult.Cancel;
            EntryToEdit = entryToEdit;
            AsEditor = true;
        }
        private void customButton1_Click(object sender, EventArgs e)
        {
            string name = customTextBox1.Texts;
            string url = customTextBox2.Texts;
            string login = customTextBox3.Texts;
            string password = customTextBox4.Texts;
            try
            {
                if (AsEditor)
                {
                    MainForm.processor.Update(EntryToEdit.ID, name, url, login, password, SettingsProcessor.SaltedAndHashedMasterPassword);
                }
                else
                {
                    MainForm.processor.Create(name, url, login, password, SettingsProcessor.SaltedAndHashedMasterPassword);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"{ex.GetType()}: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
