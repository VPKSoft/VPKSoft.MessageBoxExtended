using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended
{
    /// <summary>
    /// An extended message box with a customizable icon and extended button and result set.
    /// Implements the <see cref="VPKSoft.MessageBoxExtended.MessageBoxBase" />
    /// </summary>
    /// <seealso cref="VPKSoft.MessageBoxExtended.MessageBoxBase" />
    public partial class MessageBoxExtended : MessageBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxExtended"/> class.
        /// </summary>
        public MessageBoxExtended()
        {
            InitializeComponent();
        }

        #region ShowMethods
        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic)
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            using (var messageBoxExtended = new MessageBoxExtended())
            {

                var dialogButtons = messageBoxExtended.CreateButtons(buttons);

                foreach (var dialogButton in dialogButtons)
                {
                    messageBoxExtended.flpButtons.Controls.Add(dialogButton);
                    dialogButton.UseMnemonic = useMnemonic; // set the (stupid) mnemonic value..
                }


                messageBoxExtended.cbRememberAnswer.Text = TextRemember;
                messageBoxExtended.lbText.Text = text;
                messageBoxExtended.Text = caption;
                messageBoxExtended.pbMessageBoxIcon.Image = icon;

                if (owner == null)
                {
                    messageBoxExtended.ShowDialog();
                }
                else
                {
                    messageBoxExtended.ShowDialog(owner);
                }

                return messageBoxExtended.Result;
            }
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), true);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption, MessageBoxButtonsExtended buttons,
            MessageBoxIcon icon, bool useMnemonic)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption, MessageBoxButtonsExtended buttons,
            MessageBoxIcon icon)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), true);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic)
        {
            return Show(null, text, caption, buttons, icon, useMnemonic);
        }

        // Documentation: (©): Microsoft  (copy/paste) documentation whit modifications..
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon)
        {
            return Show(null, text, caption, buttons, icon, true);
        }
        #endregion

        private void MessageBoxExtended_Shown(object sender, EventArgs e)
        {
            var coordinateY = BaseSizeTop.Height;

            cbRememberAnswer.Visible = DisplayRememberBox;

            if (DisplayRememberBox)
            {
                coordinateY += 6;
                cbRememberAnswer.Top = coordinateY;
                cbRememberAnswer.Checked = CheckRememberBox;
                coordinateY += 6 + cbRememberAnswer.Height;
            }
            else
            {
                coordinateY += 12;
            }

            var sizeY = coordinateY + BaseSizeBottom.Height;

            ClientSize = new Size(ClientSize.Width, sizeY);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display the remember my answer check box.
        /// </summary>
        private bool DisplayRememberBox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [check remember box].
        /// </summary>
        /// <value><c>true</c> if [check remember box]; otherwise, <c>false</c>.</value>
        private bool CheckRememberBox { get; set; }

        /// <summary>
        /// Creates the buttons for the dialog box with the given <see cref="MessageBoxButtonsExtended"/> enumeration value.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        /// <returns>A List&lt;Button&gt;. <see cref="Button"/> class instances based on th given parameters.</returns>
        protected override List<Button> CreateButtons(MessageBoxButtonsExtended buttons)
        {
            List<Button> uiButtons = new List<Button>();

            switch (buttons)
            {
                case MessageBoxButtonsExtended.OK:
                    uiButtons.Add(ButtonOk);
                    break;

                case MessageBoxButtonsExtended.AbortRetryIgnore:
                    uiButtons.Add(ButtonAbort);
                    uiButtons.Add(ButtonRetry);
                    uiButtons.Add(ButtonIgnore);
                    break;

                case MessageBoxButtonsExtended.OKCancel:
                    uiButtons.Add(ButtonOk);
                    uiButtons.Add(ButtonCancel);
                    break;

                case MessageBoxButtonsExtended.RetryCancel:
                    uiButtons.Add(ButtonRetry);
                    uiButtons.Add(ButtonCancel);
                    break;

                case MessageBoxButtonsExtended.YesNo:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    break;

                case MessageBoxButtonsExtended.YesNoCancel:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonCancel);
                    break;

                case MessageBoxButtonsExtended.YesNoYesToAll:
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonYesToAll);
                    break;

                case MessageBoxButtonsExtended.YesNoYesToAllRememberChecked:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonYesToAll);
                    DisplayRememberBox = true;
                    CheckRememberBox = true;
                    break;

                case MessageBoxButtonsExtended.YesNoYesToAllRemember:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonYesToAll);
                    DisplayRememberBox = true;
                    CheckRememberBox = false;
                    break;

                case MessageBoxButtonsExtended.YesNoYesToAllNoToAll:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonYesToAll);
                    uiButtons.Add(ButtonNoToAll);
                    DisplayRememberBox = false;
                    CheckRememberBox = false;
                    break;

                case MessageBoxButtonsExtended.YesNoYesToAllRememberNoToAllRemember:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonYesToAll);
                    uiButtons.Add(ButtonNoToAll);
                    DisplayRememberBox = true;
                    CheckRememberBox = false;
                    break;

                case MessageBoxButtonsExtended.YesNoYesToAllNoToAllRememberChecked:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonYesToAll);
                    uiButtons.Add(ButtonNoToAll);
                    DisplayRememberBox = true;
                    CheckRememberBox = true;
                    break;

                case MessageBoxButtonsExtended.YesNoNoToAll:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonNoToAll);
                    break;

                case MessageBoxButtonsExtended.YesNoNoToAllRemember:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonNoToAll);
                    DisplayRememberBox = true;
                    CheckRememberBox = false;
                    break;

                case MessageBoxButtonsExtended.YesNoNoToAllRememberChecked:
                    uiButtons.Add(ButtonYes);
                    uiButtons.Add(ButtonNo);
                    uiButtons.Add(ButtonNoToAll);
                    DisplayRememberBox = true;
                    CheckRememberBox = true;
                    break;
            }

            return uiButtons;
        }

        private Button buttonYesToAll;
        private Button buttonNoToAll;

        /// <summary>
        /// Gets and creates an Yes to all button.
        /// </summary>
        private Button ButtonYesToAll
        {
            get
            {
                if (buttonYesToAll == null)
                {
                    buttonYesToAll = new Button {Text = TextYesToAll};
                    buttonYesToAll.Click += delegate
                    {
                        Result = RememberUserChoice
                            ? DialogResultExtended.YesToAllRemember
                            : DialogResultExtended.YesToAll;
                        Close();
                    };
                }

                return buttonYesToAll;
            }
        }

        /// <summary>
        /// Gets and creates a No to all button.
        /// </summary>
        private Button ButtonNoToAll
        {
            get
            {
                if (buttonNoToAll == null)
                {
                    buttonNoToAll = new Button {Text = TextNoToAll};
                    buttonNoToAll.Click += delegate
                    {
                        Result = RememberUserChoice
                            ? DialogResultExtended.NoToAllRemember
                            : DialogResultExtended.NoToAll;
                        Close();
                    };
                }

                return buttonNoToAll;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user selected the remember choice check box.
        /// Obviously false is returned if the check box is not visible.
        /// </summary>
        private bool RememberUserChoice
        {
            get
            {
                if (DisplayRememberBox)
                {
                    return cbRememberAnswer.Checked;
                }

                return false;
            }
        }
    }
}
