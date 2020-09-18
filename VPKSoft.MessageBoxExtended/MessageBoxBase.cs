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
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended
{
    /// <summary>
    /// A base class for the dialog boxes.
    /// Implements the <see cref="System.Windows.Forms.Form" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MessageBoxBase : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxBase"/> class.
        /// </summary>
        public MessageBoxBase()
        {
            InitializeComponent();
            Disposed += messageBoxBase_Disposed;
            MessageBoxInstances.Add(this);
        }

        private void messageBoxBase_Disposed(object sender, EventArgs e)
        {
            Disposed -= messageBoxBase_Disposed;
            MessageBoxInstances.Remove(this);
        }
        #endregion

        #region Localize
        /// <summary>
        /// Localizes the dialog with a given culture. The culture 'en-US' is used as fall-back.
        /// </summary>
        /// <param name="culture">The culture to use for localization.</param>
        public static void Localize(CultureInfo culture)
        {
            var tabDeliLocalization = new TabDeliLocalization();
            tabDeliLocalization.GetLocalizedTexts(Properties.Resources.Localization);
            TextOk = tabDeliLocalization.GetMessage("txtButtonOk", "&OK", culture.Name);
            TextNo = tabDeliLocalization.GetMessage("txtButtonNo", "&No", culture.Name);
            TextYes = tabDeliLocalization.GetMessage("txtButtonYes", "&Yes", culture.Name);
            TextCancel =
                tabDeliLocalization.GetMessage("txtButtonCancel", "&Cancel", culture.Name);
            TextRetry = tabDeliLocalization.GetMessage("txtButtonRetry", "&Retry", culture.Name);
            TextAbort = tabDeliLocalization.GetMessage("txtButtonAbort", "&Abort", culture.Name);
            TextYesToAll =
                tabDeliLocalization.GetMessage("txtButtonYesToAll", "Yes &to all", culture.Name);
            TextNoToAll =
                tabDeliLocalization.GetMessage("txtButtonNoToAll", "No t&o all", culture.Name);
            TextIgnore =
                tabDeliLocalization.GetMessage("txtButtonIgnore", "&Ignore", culture.Name);
            TextRemember = tabDeliLocalization.GetMessage("txtCheckBoxRememberAnswer", "&Remember answer",
                culture.Name);
            PreviousPasswordInvalid = tabDeliLocalization.GetMessage("txtPreviousPasswordInvalid",
                "The given password was incorrect. Please try again.",
                culture.Name);
        }
        

        /// <summary>
        /// Localizes the dialog with given culture name in the format languagecode2-country/regioncode2. The culture 'en-US' is used as fall-back.
        /// </summary>
        /// <param name="cultureString"></param>
        [SuppressMessage("ReSharper", "CommentTypo")]
        // ReSharper disable once UnusedMember.Global
        public static void Localize(string cultureString)
        {
            try
            {
                Localize(new CultureInfo(cultureString));
            }
            catch
            {
                Localize(CultureInfo.CurrentUICulture);
            }
        }

        /// <summary>
        /// Localizes the dialog using the <see cref="CultureInfo.CurrentUICulture"/>. The culture 'en-US' is used as fall-back.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static void Localize()
        {
            Localize(CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Gets or sets the value indicating if the dialog should be localized in the constructor.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static bool LocalizeOnCreate { get; set; }

        /// <summary>
        /// Gets or sets the text for a No button. To property is for localization.
        /// </summary>
        public static string TextNo { get; set; } = "&No";

        /// <summary>
        /// Gets or sets the text for an OK button. To property is for localization.
        /// </summary>
        public static string TextOk { get; set; } = "&OK";

        /// <summary>
        /// Gets or sets the text for an Yes button. To property is for localization.
        /// </summary>
        public static string TextYes { get; set; } = "&Yes";

        /// <summary>
        /// Gets or sets the text for a Cancel button. To property is for localization.
        /// </summary>
        public static string TextCancel { get; set; } = "&Cancel";

        /// <summary>
        /// Gets or sets the text for a Retry button. To property is for localization.
        /// </summary>
        public static string TextRetry { get; set; } = "&Retry";

        /// <summary>
        /// Gets or sets the text for an Abort button. To property is for localization.
        /// </summary>
        public static string TextAbort { get; set; } = "&Abort";

        /// <summary>
        /// Gets or sets the text for an Yes to all button. To property is for localization.
        /// </summary>
        public static string TextYesToAll { get; set; } = "Yes &to all";

        /// <summary>
        /// Gets or sets the text for an Yes to all button. To property is for localization.
        /// </summary>
        public static string TextNoToAll { get; set; } = "No t&o all";

        /// <summary>
        /// Gets or sets the text for an Ignore button. To property is for localization.
        /// </summary>
        public static string TextIgnore { get; set; } = "&Ignore";

        /// <summary>
        /// Gets or sets the text for a check box asking whether to remember the given answer for the dialog. To property is for localization.
        /// </summary>
        public static string TextRemember { get; set; } = "&Remember answer";

        /// <summary>
        /// Gets or sets the text to indicate the user that the previously given password was invalid.
        /// </summary>
        public static string PreviousPasswordInvalid { get; set; } = "The given password was incorrect. Please try again.";
        #endregion

        #region Buttons
        private Button buttonOk;
        private Button buttonAbort;
        private Button buttonRetry;
        private Button buttonIgnore;
        private Button buttonCancel;
        private Button buttonYes;
        private Button buttonNo;

        /// <summary>
        /// Gets and creates an OK button.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        protected Button ButtonOk
        {
            get
            {
                if (buttonOk == null)
                {
                    buttonOk = new Button {Text = TextOk};
                    buttonOk.Click += delegate
                    {
                        Result = DialogResultExtended.OK;
                        DialogResultAction?.Invoke(Result, false, ActionData);
                        Close();
                    };
                }

                return buttonOk;
            }
        }

        /// <summary>
        /// Gets and creates an Abort button.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        protected Button ButtonAbort
        {
            get
            {
                if (buttonAbort == null)
                {
                    buttonAbort = new Button {Text = TextAbort};
                    buttonAbort.Click += delegate
                    {
                        Result = DialogResultExtended.Abort;
                        DialogResultAction?.Invoke(Result, false, ActionData);
                        Close();
                    };
                }

                return buttonAbort;
            }
        }

        /// <summary>
        /// Gets and creates a Retry button.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        protected Button ButtonRetry
        {
            get
            {
                if (buttonRetry == null)
                {
                    buttonRetry = new Button {Text = TextRetry};
                    buttonRetry.Click += delegate
                    {
                        Result = DialogResultExtended.Retry;
                        DialogResultAction?.Invoke(Result, false, ActionData);
                        Close();
                    };
                }

                return buttonRetry;
            }
        }

        /// <summary>
        /// Gets and creates an Ignore button.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        protected Button ButtonIgnore
        {
            get
            {
                if (buttonIgnore == null)
                {
                    buttonIgnore = new Button {Text = TextIgnore};
                    buttonIgnore.Click += delegate
                    {
                        Result = DialogResultExtended.Ignore;
                        DialogResultAction?.Invoke(Result, false, ActionData);
                        Close();
                    };
                }

                return buttonIgnore;
            }
        }

        /// <summary>
        /// Gets and creates a Cancel button.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        protected Button ButtonCancel
        {
            get
            {
                if (buttonCancel == null)
                {
                    buttonCancel = new Button {Text = TextCancel};
                    buttonCancel.Click += delegate
                    {
                        Result = DialogResultExtended.Cancel;
                        DialogResultAction?.Invoke(Result, false, ActionData);
                        Close();
                    };
                }

                return buttonCancel;
            }
        }

        /// <summary>
        /// Gets and creates an Yes button.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        protected Button ButtonYes
        {
            get
            {
                if (buttonYes == null)
                {
                    buttonYes = new Button {Text = TextYes};
                    buttonYes.Click += delegate
                    {
                        Result = DialogResultExtended.Yes;
                        DialogResultAction?.Invoke(Result, false, ActionData);
                        Close();
                    };
                }

                return buttonYes;
            }
        }

        /// <summary>
        /// Gets and creates a No button.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        protected Button ButtonNo
        {
            get
            {
                if (buttonNo == null)
                {
                    buttonNo = new Button {Text = TextNo};
                    buttonNo.Click += delegate
                    {
                        Result = DialogResultExtended.No;
                        DialogResultAction?.Invoke(Result, false, ActionData);
                        Close();
                    };
                }

                return buttonNo;
            }
        }
        #endregion

        #region ProtectedMethods
        /// <summary>
        /// Creates the buttons for the dialog box with the given <see cref="MessageBoxBase"/> enumeration value.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        /// <returns>A List&lt;Button&gt;. <see cref="Button"/> class instances based on th given parameters.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        protected virtual List<Button> CreateButtons(MessageBoxButtonsExtended buttons)
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
            }

            return uiButtons;
        }

        /// <summary>
        /// Creates the buttons for the dialog box with the given <see cref="MessageBoxBase"/> enumeration value.
        /// </summary>
        /// <returns>A List&lt;Button&gt;. <see cref="Button"/> class instances based on th given parameters.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        protected virtual List<Button> CreateButtons()
        {
            List<Button> uiButtons = new List<Button>();
            return uiButtons;
        }

        /// <summary>
        /// Sets the given list of buttons to the bottom of the dialog.
        /// </summary>
        /// <param name="buttons">The buttons to set.</param>
        /// <param name="useMnemonic">if set to <c>true</c> the mnemonic].</param>
        protected void SetButtons(List<Button> buttons, bool useMnemonic)
        {
            foreach (var button in buttons)
            {
                flpButtons.Controls.Add(button);
                button.UseMnemonic = useMnemonic; // set the (stupid) mnemonic value..
            }
        }
        #endregion

        #region ProtectedProperties
        /// <summary>
        /// Gets or sets the dialog result <see cref="Action{DialogResultExtended, Boolean}"/> action which is called when a button is pressed in the dialog.
        /// The boolean value is a value whether the user answer should be remembered.
        /// </summary>
        /// <value>The action which is called when a button is pressed in the dialog.</value>
        protected Action<DialogResultExtended, bool, object> DialogResultAction { get; set; } 

        /// <summary>
        /// Gets the height of the label with the dialog text.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        protected int LabelHeight
        {
            get
            {
                using(Graphics graphics = CreateGraphics())
                {
                    var size = graphics.MeasureString(lbText.Text, lbText.Font,
                        lbText.Width - lbText.Margin.Horizontal);

                    return (int) Math.Ceiling(size.Height);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the possible OK button is enabled.
        /// </summary>
        protected bool OkButtonEnabled
        {
            get => ButtonOk != null && buttonOk.Enabled;

            set
            {
                if (buttonOk != null)
                {
                    buttonOk.Enabled = value;
                }
            }
        }

        /// <summary>
        /// The <see cref="DialogResultExtended"/> returned by a call to the the Show() method.
        /// </summary>
        protected DialogResultExtended Result { get; set; } = DialogResultExtended.None;

        /// <summary>
        /// Gets the top base size for the dialog size calculation.
        /// </summary>
        protected Size BaseSizeTop
        {
            get
            {
                var coordinateX = 16;
                var coordinateY = 16;
                pbMessageBoxIcon.Location = new Point(coordinateX, coordinateY);

                lbText.Left = pbMessageBoxIcon.Right + 20;
                lbText.Top = coordinateY;
                lbText.Width = ClientSize.Width - 20 - lbText.Left;

                lbText.Height = LabelHeight;

                coordinateY += Math.Max(lbText.Height, pbMessageBoxIcon.Height);

                return new Size(ClientSize.Width, coordinateY);
            }
        }

        /// <summary>
        /// Gets the bottom base size for the dialog size calculation.
        /// </summary>
        protected Size BaseSizeBottom => new Size(ClientSize.Width, (flpButtons.Controls.Count > 0 ? flpButtons.Controls[0].Height : 0) + 25);

        /// <summary>
        /// Gets the total base size for the dialog without any additional controls.
        /// </summary>
        protected Size BaseSizeTotal
        {
            get
            {
                var sizeTop = BaseSizeTop;
                var sizeBottom = BaseSizeBottom;
                return new Size(ClientSize.Width, sizeTop.Height + sizeBottom.Height);
            }
        }
        #endregion

        #region PublicProperties        
        /// <summary>
        /// Gets the currently existing <see cref="MessageBoxBase"/> instances.
        /// </summary>
        /// <value>The currently existing <see cref="MessageBoxBase"/> instances.</value>
        public List<MessageBoxBase> MessageBoxInstances { get; } = new List<MessageBoxBase>();

        /// <summary>
        /// Gets or sets the additional data to be passed to the <see cref="DialogResultAction"/> action.
        /// </summary>
        /// <value>The the additional data to be passed to the <see cref="DialogResultAction"/> action.</value>
        public object ActionData { get; set; }
        #endregion

        #region PublicStaticMethods
        /// <summary>
        /// Gets the message box icon based on the given <see cref="MessageBoxIcon"/> enumeration value.
        /// </summary>
        /// <param name="icon">The icon enumeration value.</param>
        /// <returns>An <see cref="Image"/> instance representing the icon or an empty image if the icon wasn't found.</returns>
        // ReSharper disable once UnusedMember.Global
        public static Image GetMessageBoxIcon(MessageBoxIcon icon)
        {
            // store the size to take higher system DPI setting into account,
            // don't know if size changes though..
            var size = SystemIcons.Asterisk.Size;
            switch (icon)
            {
                case MessageBoxIcon.Asterisk: return SystemIcons.Asterisk.ToBitmap();
                case MessageBoxIcon.Exclamation: return SystemIcons.Exclamation.ToBitmap();
                case MessageBoxIcon.Hand: return SystemIcons.Hand.ToBitmap();
                case MessageBoxIcon.None: return new Bitmap(size.Width, size.Height);
                case MessageBoxIcon.Question: return SystemIcons.Question.ToBitmap();
            }
            return new Bitmap(size.Width, size.Height);
        }
        #endregion
    }
}
