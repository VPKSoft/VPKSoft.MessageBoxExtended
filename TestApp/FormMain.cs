#region License
/*
MIT License

Copyright(c) 2020 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VPKSoft.MessageBoxExtended;

namespace TestApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            MessageBoxQueryPrimitiveValue<string>.ValidateTypeValue += MessageBoxQueryPrimitiveValue_ValidateTypeValue;

            ListDialogTypes();
            ListDialogButtons();
            cmbLocale.SelectedIndex = 1;
        }

        private void ListDialogTypes()
        {
            List<int> addedValues = new List<int>();

            foreach (var value in Enum.GetValues(typeof(MessageBoxIcon)))
            {
                if (addedValues.Contains((int) value))
                {
                    continue;
                }

                addedValues.Add((int)value);
                cmbDialogType.Items.Add(value);
            }

            cmbDialogType.SelectedItem = MessageBoxIcon.Asterisk;
        }

        private void ListDialogButtons()
        {
            List<int> addedValues = new List<int>();

            foreach (var value in Enum.GetValues(typeof(MessageBoxButtonsExtended)))
            {
                if (addedValues.Contains((int) value))
                {
                    continue;
                }

                addedValues.Add((int)value);
                cmbDialogButtons.Items.Add(value);
            }

            cmbDialogButtons.SelectedItem = MessageBoxButtonsExtended.YesNo;
        }

        private string name = Environment.GetEnvironmentVariable("USERNAME");

        private void MessageBoxQueryPrimitiveValue_ValidateTypeValue(object sender, VPKSoft.MessageBoxExtended.Events.TypeValueValidationEventArgs e)
        {
            if (e.DropDownMode)
            {
                return;
            }

            if (e.TypeValue.ToString() != name)
            {
                e.IsValid = false;
                e.ValidationErrorMessage = "Please type YOUR computer user name!";
            }
        }

        private string AddNumbers(string text)
        {
            var previous = text;
            text = text.Replace("#N1#", ((int) numericUpDown1.Value).ToString());

            if (text != previous)
            {
                if ((int)numericUpDown1.Value == 9999)
                {
                    numericUpDown1.Value = 1;
                }
                else
                {
                    numericUpDown1.Value++;
                }
            }

            previous = text;
            text = text.Replace("#N2#", ((int) numericUpDown2.Value).ToString());

            if (text != previous)
            {
                if ((int)numericUpDown2.Value == 9999)
                {
                    numericUpDown2.Value = 1;
                }
                else
                {
                    numericUpDown2.Value++;
                }
            }

            return text;
        }

        private void btAddDialog_Click(object sender, EventArgs e)
        {
            if (tcMain.SelectedTab == tabExpandStack)
            {
                messageBoxExpandStack.AddDialog(new MessageBoxExtended(AddNumbers(tbDialogText.Text), AddNumbers(tbDialogTitle.Text),
                    (MessageBoxButtonsExtended)cmbDialogButtons.SelectedItem,
                    (MessageBoxIcon)cmbDialogType.SelectedItem), false);
            }

            if (tcMain.SelectedTab == tabResizeDialogContainer)
            {
                messageBoxContainerResize.AddDialog(new MessageBoxExtended(AddNumbers(tbDialogText.Text), AddNumbers(tbDialogTitle.Text),
                    (MessageBoxButtonsExtended)cmbDialogButtons.SelectedItem,
                    (MessageBoxIcon)cmbDialogType.SelectedItem), false);
            }
        }

        private void messageBoxExpandStack_MessageBoxClosed(object sender, VPKSoft.MessageBoxExtended.Controls.MessageBoxEventArgs e)
        {
            e.AllowMessageBoxClose = true;
        }

        private void btTestErrorMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                MessageBoxExtended.Show(this, "Testing catastrophic failure message!", "Testing..",
                    MessageBoxButtonsExtended.YesNoYesToAllRememberNoToAllRemember,
                    MessageBoxIcon.Hand).ToString());
        }

        private void btTestPasswordDialog_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                MessageBoxQueryPassword.Show(this, "Provide your password:", "Password", true, true, true));
        }

        private void btStringQueryTest_Click(object sender, EventArgs e)
        {
            MessageBoxQueryPrimitiveValue<string>.Show(this, "Please give your computer user name", "Computer user name",
                MessageBoxIcon.Question, ref name);
        }

        private void btTestDropDownSelect_Click(object sender, EventArgs e)
        {
            string dropDownValue = "Linux";
            MessageBoxQueryPrimitiveValue<string>.Show(this, "Select your operating system", "Operation system selection",
                MessageBoxButtonsExtended.YesNo, MessageBoxIcon.Information, true, null, ComboBoxStyle.DropDown,
                AutoCompleteMode.Suggest, new List<string>(new[] {"Windows", "OS X", "Linux", "Unix", "iOS", "BSD*"}), ref dropDownValue);
        }

        private void tcMain_Selected(object sender, TabControlEventArgs e)
        {
            pnTabPageFirst.Visible = e.TabPage == tabDialogTest;
        }

        private void cmbLocale_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox) sender;
            var locale = combo.SelectedItem.ToString().Split('/')[1].Trim().Substring(0, 2);
            MessageBoxBase.Localize(locale);
        }
    }
}
