using SimplePM.Library;
using System;
using System.Drawing;

namespace SimplePM.Forms
{
    public partial class PassGeneratorForm : ShadowedForm
    {
        public PassGeneratorForm()
        {
            InitializeComponent();
            customButton1.SF.Alignment = StringAlignment.Center;
            for (int i = 8; i < 128; i++)
            {
                customComboBox1.Items.Add(i);
            }
            customComboBox1.SelectedIndex = 8;
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(customComboBox1.SelectedItem.ToString(), out value))
            {
                customTextBox1.Texts = PasswordGenerator.Generate(value);
            }
        }
    }
}
