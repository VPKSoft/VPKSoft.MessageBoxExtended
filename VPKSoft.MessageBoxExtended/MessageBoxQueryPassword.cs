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
using VPKSoft.MessageBoxExtended.Utility;

// The stock icon (C)::https://www.pngguru.com/free-transparent-background-png-clipart-rbcyh

namespace VPKSoft.MessageBoxExtended
{
    /// <summary>
    /// A dialog to query a password from the user.
    /// Implements the <see cref="VPKSoft.MessageBoxExtended.MessageBoxBase" />
    /// </summary>
    /// <seealso cref="VPKSoft.MessageBoxExtended.MessageBoxBase" />
    public partial class MessageBoxQueryPassword : MessageBoxBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxQueryPassword"/> class.
        /// </summary>
        public MessageBoxQueryPassword()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="password">A password to set to the contents of the password </param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPassword(string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength, string password,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            InitializeComponent();

            if (LocalizeOnCreate)
            {
                Localize();
            }

            SetButtons(CreateButtons(), useMnemonic);

            DialogResultAction = dialogResultAction;

            lbText.Text = text;
            base.Text = caption;
            if (icon != null)
            {
                pbMessageBoxIcon.Image = icon;
            }

            CancelButton = ButtonCancel;
            AcceptButton = ButtonOk;
            ShowPasswordStrength = showPasswordStrength;

            ComplainInvalidPassword = givenPasswordInvalid;

            lbInvalidPasswordComplaint.Text = PreviousPasswordInvalid;
            tbPassword.Text = password;

            pbColorSlide.Image = PasswordStrengthSliderImage;
            pbMessageBoxIcon.Image = PasswordIconImage;
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="password">A password to set to the contents of the password </param>
        public MessageBoxQueryPassword(string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength, string password) : this(
            text, caption, icon, useMnemonic, givenPasswordInvalid, showPasswordStrength, password, null)
        {

        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPassword(string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, icon,
            useMnemonic, givenPasswordInvalid, false, null, dialogResultAction)
        {
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        public MessageBoxQueryPassword(string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid) : this(text, caption, icon,
            useMnemonic, givenPasswordInvalid, false, null, null)
        {
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPassword(string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, icon, useMnemonic,
            givenPasswordInvalid, showPasswordStrength, null, dialogResultAction)
        {
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        public MessageBoxQueryPassword(string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength) : this(text, caption, icon, useMnemonic,
            givenPasswordInvalid, showPasswordStrength, null, null)
        {
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPassword(string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid, Action<DialogResultExtended, bool, object> dialogResultAction)
            : this(text, caption, null, useMnemonic, givenPasswordInvalid, false, null, dialogResultAction)
        {
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        public MessageBoxQueryPassword(string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid)
            : this(text, caption, null, useMnemonic, givenPasswordInvalid, false, null, null)
        {
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public MessageBoxQueryPassword(string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, null, useMnemonic,
            givenPasswordInvalid, showPasswordStrength, null, dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="givenPasswordInvalid">A value indicating whether the previously given password was invalid and this should be indicated to the user by additional label.</param>
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public MessageBoxQueryPassword(string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength) : this(text, caption, null,
            useMnemonic,
            givenPasswordInvalid, showPasswordStrength, null, null)
        {
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPassword(string text, string caption,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, null, true, false,
            false, null, dialogResultAction)
        {
        }

        /// <summary>
        /// Initializes a new password query message box with the specified text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public MessageBoxQueryPassword(string text, string caption) : this(text, caption, null, true, false,
            false, null, null)
        {
        }
        #endregion

        #region ShowMethods
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
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="password">A password to set to the contents of the password </param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength, string password,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            using (var messageBoxExtended = new MessageBoxQueryPassword(text, caption, icon, useMnemonic,
                givenPasswordInvalid, showPasswordStrength, password, dialogResultAction)) 
            {
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
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="password">A password to set to the contents of the password </param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength, string password)
        {
            return Show(owner, text, caption, icon, useMnemonic, givenPasswordInvalid, showPasswordStrength, password,
                null);
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
            return Show(owner, text, caption, icon, useMnemonic, givenPasswordInvalid, false, null, null);
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
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, icon, useMnemonic, givenPasswordInvalid, false, null, dialogResultAction);
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
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength)
        {
            return Show(owner, text, caption, icon, useMnemonic, givenPasswordInvalid, showPasswordStrength, null, null);
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
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, icon, useMnemonic, givenPasswordInvalid, showPasswordStrength, null, dialogResultAction);
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
            return Show(owner, text, caption, null, useMnemonic, givenPasswordInvalid, false, null, null);
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
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, null, useMnemonic, givenPasswordInvalid, false, null, dialogResultAction);
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
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength)
        {
            return Show(owner, text, caption, null, useMnemonic, givenPasswordInvalid, showPasswordStrength, null, null);
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
        /// <param name="showPasswordStrength">A value indicating whether to display password strength indicated by a progress bar.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            bool useMnemonic, bool givenPasswordInvalid, bool showPasswordStrength, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, null, useMnemonic, givenPasswordInvalid, showPasswordStrength, null, dialogResultAction);
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
            return Show(owner, text, caption, null, useMnemonic, false, false, null, null);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, and caption.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption,
            bool useMnemonic, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, null, useMnemonic, false, false, null, dialogResultAction);
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
            return Show(owner, text, caption, null, true, false, false, null, null);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an password query message box in front of the specified object and with the specified text, and caption.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>A string containing the user given password or null in case the user selected to cancel the dialog.</returns>
        public static string Show(IWin32Window owner, string text, string caption, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, null, true, false, false, null, dialogResultAction);
        }
        #endregion


        private bool ComplainInvalidPassword { get; set; }

        private bool ShowPasswordStrength { get; set; }

        /// <summary>
        /// Creates the buttons for the dialog box with the given <see cref="MessageBoxBase"/> enumeration value.
        /// </summary>
        /// <returns>A List&lt;Button&gt;. <see cref="Button"/> class instances based on th given parameters.</returns>
        protected sealed override List<Button> CreateButtons()
        {
            return new List<Button> {ButtonOk, ButtonCancel};
        }

        // a field to hold the PasswordStrengthSliderImage property value..
        private static Image _passwordStrengthSliderImage;

        /// <summary>
        /// Gets or sets the password strength indicator slider image used with the password dialog.
        /// </summary>
        public static Image PasswordStrengthSliderImage
        {
            get => _passwordStrengthSliderImage ?? Properties.Resources.color_slide;
            set => _passwordStrengthSliderImage = value;
        }

        // a field to hold the PasswordIconImage property value..
        private static Image _passwordIconImage;

        /// <summary>
        /// Gets or sets password icon to be used with the password dialog.
        /// </summary>
        public static Image PasswordIconImage
        {
            get => _passwordIconImage ?? Properties.Resources.password;
            set => _passwordIconImage = value;
        }


        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            ButtonOk.Enabled = !string.IsNullOrEmpty(tbPassword.Text);
            DisplayPasswordScore();
        }

        private void MessageBoxQueryPassword_Shown(object sender, EventArgs e)
        {
            ButtonOk.Enabled = !string.IsNullOrEmpty(tbPassword.Text);
            lbInvalidPasswordComplaint.Visible = ComplainInvalidPassword;

            tbPassword.Top = BaseSizeTop.Height + 6;
            lbInvalidPasswordComplaint.Top = tbPassword.Bottom + 6;

            var sizeY = BaseSizeTotal.Height + tbPassword.Height + 12 +
                        (ComplainInvalidPassword ? lbInvalidPasswordComplaint.Height + 10 : 0);

            pbColorSlide.Visible = ShowPasswordStrength;
            pnColorSlide.Visible = ShowPasswordStrength;

            DisplayPasswordScore();

            ClientSize = new Size(ClientSize.Width, sizeY);
            tbPassword.Focus();
            tbPassword.SelectAll();
        }

        /// <summary>
        /// Displays the password strength displaying a part of an image based to the password strength.
        /// </summary>
        private void DisplayPasswordScore()
        {
            if (!ShowPasswordStrength)
            {
                return;
            }

            var passwordStrength = PasswordMeasureStrength.PasswordStrength(tbPassword.Text);
            passwordStrength *= pbColorSlide.Width / 10.0;

            var width = (int) passwordStrength;

            pnColorSlide.Top = tbPassword.Bottom;
            pbColorSlide.Top = tbPassword.Bottom;

            pnColorSlide.Width = pbColorSlide.Width - width;
            pnColorSlide.Left = pbColorSlide.Left + width;

        }
    }
}
