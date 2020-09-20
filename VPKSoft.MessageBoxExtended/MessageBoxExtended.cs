﻿using System;
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
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxExtended"/> class.
        /// </summary>
        public MessageBoxExtended()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            InitializeComponent();
            var dialogButtons = CreateButtons(buttons);

            DialogResultAction = dialogResultAction;

            foreach (var dialogButton in dialogButtons)
            {
                flpButtons.Controls.Add(dialogButton);
                dialogButton.UseMnemonic = useMnemonic; // set the (stupid) mnemonic value..
            }

            cbRememberAnswer.Text = TextRemember;
            lbText.Text = text;
            base.Text = caption;
            pbMessageBoxIcon.Image = icon;
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, buttons,
            GetMessageBoxIcon(icon), useMnemonic, dialogResultAction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, buttons,
            GetMessageBoxIcon(icon), true, dialogResultAction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, buttons, icon, true,
            dialogResultAction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic) : this(text, caption, buttons, icon, useMnemonic, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic) : this(text, caption, buttons,
            GetMessageBoxIcon(icon), useMnemonic, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon) : this(text, caption, buttons,
            GetMessageBoxIcon(icon), true, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        public MessageBoxExtended(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon) : this(text, caption, buttons, icon, true,
            null)
        {
        }
        #endregion

        #region ShowMethods                
        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
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

            using (var messageBoxExtended = new MessageBoxExtended(text, caption, buttons, icon, useMnemonic, null))
            {
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            using (var messageBoxExtended = new MessageBoxExtended(text, caption, buttons, icon, useMnemonic, dialogResultAction))
            {
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

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), true, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption, MessageBoxButtonsExtended buttons,
            MessageBoxIcon icon, bool useMnemonic,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:VPKSoft.MessageBoxExtended.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption, MessageBoxButtonsExtended buttons,
            MessageBoxIcon icon,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), true, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, icon, useMnemonic, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays an extended message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dialogResultAction">An optional <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, icon, true, dialogResultAction);
        }
        #endregion

        #region PrivateMethods
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
        /// Creates the buttons for the dialog box with the given <see cref="MessageBoxButtonsExtended"/> enumeration value.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        /// <returns>A List&lt;Button&gt;. <see cref="Button"/> class instances based on th given parameters.</returns>
        protected sealed override List<Button> CreateButtons(MessageBoxButtonsExtended buttons)
        {
            List<Button> uiButtons = new List<Button>();

            uiButtons.AddRange(base.CreateButtons(buttons));

            switch (buttons)
            {
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
        #endregion

        #region PrivateProperties
        /// <summary>
        /// Gets or sets a value indicating whether to display the remember my answer check box.
        /// </summary>
        private bool DisplayRememberBox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [check remember box].
        /// </summary>
        /// <value><c>true</c> if [check remember box]; otherwise, <c>false</c>.</value>
        private bool CheckRememberBox { get; set; }
        #endregion

        #region PrivateFields
        private Button buttonYesToAll;
        private Button buttonNoToAll;
        #endregion

        #region Buttons
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
                        DialogResultAction?.Invoke(Result, RememberUserChoice, ActionData);
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
                        DialogResultAction?.Invoke(Result, RememberUserChoice, ActionData);
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
        #endregion

        #region PublicProperties        
        /// <summary>
        /// Gets the message text in the dialog box.
        /// </summary>
        /// <value>The message text in the dialog box.</value>
        public override string MessageText => lbText.Text;
        #endregion

        #region PublicMethods        
        /// <summary>
        /// Gets the icon displayed in the message box.
        /// </summary>
        /// <param name="size">The size the icon should be returned.</param>
        /// <returns>A <see cref="Image" /> instance containing the message box icon resized to the specified size.</returns>
        public override Image GetIcon(Size size)
        {
            return pbMessageBoxIcon.Image != null ? new Bitmap(pbMessageBoxIcon.Image, size) : null;
        }
        #endregion
    }
}
