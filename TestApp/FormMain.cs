#region License
/*
MIT License

Copyright(c) 2019 Petteri Kautonen

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxBase.Localize("fi");

            MessageBox.Show(
                MessageBoxExtended.Show(this, "Helevetin helevetin helevetti!", "Testing..",
                    //MessageBoxButtonsExtended.YesNo, 
                    MessageBoxButtonsExtended.YesNoYesToAllRememberNoToAllRemember,
                    MessageBoxIcon.Hand).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxBase.Localize("fi");

            MessageBox.Show(
                MessageBoxQueryPassword.Show(this, "Anna salasana:", "Salasana", true, true, true));
        }

        private string name = Environment.GetEnvironmentVariable("USERNAME");

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxQueryPrimitiveValue<string>.Show(this, "Please give your first and last name", "First and last name",
                MessageBoxIcon.Question, ref name);
        }

        private void MessageBoxQueryPrimitiveValue_ValidateTypeValue(object sender, VPKSoft.MessageBoxExtended.Events.TypeValueValidationEventArgs e)
        {
            if (e.TypeValue.ToString() != name)
            {
                e.IsValid = true;
                e.ValidationErrorMessage = "Please type YOUR name!";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dropDownValue = "Linux";
            MessageBoxQueryPrimitiveValue<string>.Show(this, "Select your operating system", "Operation system selection",
                MessageBoxButtonsExtended.YesNo, MessageBoxIcon.Information, false, null, ComboBoxStyle.DropDown,
                AutoCompleteMode.Suggest, new List<string>(new[] {"Windows", "OS X", "Linux", "Unix", "iOS", "BSD*"}), ref dropDownValue);
        }
    }
}
