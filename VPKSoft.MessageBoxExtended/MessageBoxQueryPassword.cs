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
using System.Drawing;
using System.Windows.Forms;

// The stock icon (C)::https://www.pngguru.com/free-transparent-background-png-clipart-rbcyh

namespace VPKSoft.MessageBoxExtended
{
    public partial class MessageBoxQueryPassword : MessageBoxBase
    {
        public MessageBoxQueryPassword()
        {
            InitializeComponent();
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, caption, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="password">A password to set to the contents of the password </param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, string password)
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            using (var messageBoxExtended = new MessageBoxQueryPassword())
            {
                messageBoxExtended.SetButtons(messageBoxExtended.CreateButtons(), useMnemonic);

                messageBoxExtended.lbText.Text = text;
                messageBoxExtended.Text = caption;
                if (icon != null)
                {
                    messageBoxExtended.pbMessageBoxIcon.Image = icon;
                }

                messageBoxExtended.CancelButton = messageBoxExtended.ButtonCancel;
                messageBoxExtended.AcceptButton = messageBoxExtended.ButtonOk;

                messageBoxExtended.complainInvalidPassword = givenPasswordInvalid;

                messageBoxExtended.lbInvalidPasswordComplaint.Text = PreviousPasswordInvalid;
                messageBoxExtended.tbPassword.Text = password;

                if (owner == null)
                {
                    messageBoxExtended.ShowDialog();
                }
                else
                {
                    messageBoxExtended.ShowDialog(owner);
                }

                return messageBoxExtended.Result != DialogResultExtended.OK ? null : messageBoxExtended.tbPassword.Text;
            }
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, caption, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid)
        {
            return Show(owner, text, caption, icon, useMnemonic, givenPasswordInvalid, null);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, and caption.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid)
        {
            return Show(owner, text, caption, null, useMnemonic, givenPasswordInvalid, null);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, and caption.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            bool useMnemonic)
        {
            return Show(owner, text, caption, null, useMnemonic, false, null);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, and caption.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption)
        {
            return Show(owner, text, caption, null, true, false, null);
        }


        private bool complainInvalidPassword;

        /// <summary>
        /// Creates the buttons for the dialog box with the given <see cref="MessageBoxBase"/> enumeration value.
        /// </summary>
        /// <returns>A List&lt;Button&gt;. <see cref="Button"/> class instances based on th given parameters.</returns>
        protected override List<Button> CreateButtons()
        {
            return new List<Button> {ButtonOk, ButtonCancel};
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            ButtonOk.Enabled = !string.IsNullOrEmpty(tbPassword.Text);
        }

        private void MessageBoxQueryPassword_Shown(object sender, EventArgs e)
        {
            ButtonOk.Enabled = !string.IsNullOrEmpty(tbPassword.Text);
            lbInvalidPasswordComplaint.Visible = complainInvalidPassword;

            tbPassword.Top = BaseSizeTop.Height + 6;
            lbInvalidPasswordComplaint.Top = tbPassword.Bottom + 6;

            var sizeY = BaseSizeTotal.Height + tbPassword.Height + 12 +
                        (complainInvalidPassword ? lbInvalidPasswordComplaint.Height + 10 : 0);

            ClientSize = new Size(ClientSize.Width, sizeY);
            tbPassword.Focus();
            tbPassword.SelectAll();
        }
    }
}
