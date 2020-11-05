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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VPKSoft.MessageBoxExtended.Controls.Classes;
using VPKSoft.MessageBoxExtended.Controls.Enumerations;
using VPKSoft.MessageBoxExtended.Controls.Interfaces;

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// Class MessageBoxStack.
    /// Implements the <see cref="VPKSoft.MessageBoxExtended.Controls.MessageBoxControlBase" />
    /// </summary>
    /// <seealso cref="VPKSoft.MessageBoxExtended.Controls.MessageBoxControlBase" />
    public partial class MessageBoxControlStack : MessageBoxControlBase, INotifyPropertyChanged, IMessageBoxContainerOrdering<MessageBoxControlStack, TableLayoutDialogBox>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxControlStack"/> class.
        /// </summary>
        public MessageBoxControlStack()
        {
            InitializeComponent();
            PropertyChanged += messageBoxControlStack_PropertyChanged;
            Disposed += messageBoxControlStack_Disposed;
        }
        #endregion

        #region PublicProperties
        /// <summary>
        /// Gets the dialog count of the control.
        /// </summary>
        /// <value>The dialog count of the control.</value>
        [Browsable(false)]
        public int DialogCount => ResizeContainerControls.Count;

        /// <summary>
        /// Gets or sets the action which is called when the dialog count is changed.
        /// </summary>
        /// <value>The action which is called when the dialog count is changed.</value>
        [Browsable(false)]
        public Action<int> DialogCountChanged { get; set; }
        #endregion

        #region Constants
        private const string NameFontDialogTitle = "LabelTitle";
        private const string NameFontDialogText = "LabelText";
        private const string NameExpandBox = "ExpandBox";
        private const string NameTimeInfoBox = "NameTimeInfoBox";
        private const string NameCaptionPanel = "Title";
        private const string NameCloseBox = "CloseBox";
        #endregion

        #region DesignerProperties
        /// <summary>
        /// Gets or sets the dialog close button background color (inactive).
        /// </summary>
        /// <value>The dialog close button background color (inactive).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog close button background color (inactive).")]
        public Color DialogCloseButtonBackground { get; set; } = SystemColors.Control;

        /// <summary>
        /// Gets or sets the dialog close button hover background color (active).
        /// </summary>
        /// <value>The dialog close button hover background color (active).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog close button hover background color (active).")]
        public Color DialogCloseButtonHoverBackground { get; set; } = Color.FromArgb(0xff, 0xe8, 0x11, 0x23);

        /// <summary>
        /// Gets or sets the dialog expand button background color (inactive).
        /// </summary>
        /// <value>The dialog expand button background color (inactive).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog expand button background color (inactive).")]
        public Color DialogExpandButtonBackground { get; set; } = SystemColors.Control;

        /// <summary>
        /// Gets or sets the dialog expand button hover background color (active).
        /// </summary>
        /// <value>The dialog expand button hover background color (active).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog expand button hover background color (active).")]
        public Color DialogExpandButtonHoverBackground { get; set; } = SystemColors.ControlDark;

        /// <summary>
        /// Gets or sets the dialog time info button background color (inactive).
        /// </summary>
        /// <value>The dialog time info button background color (inactive).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog time info button background color (inactive).")]
        public Color DialogTimeButtonBackground { get; set; } = SystemColors.Control;

        /// <summary>
        /// Gets or sets the dialog time info button hover background color (active).
        /// </summary>
        /// <value>The dialog time info button hover background color (active).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog time info button hover background color (active).")]
        public Color DialogTimeButtonHoverBackground { get; set; } = SystemColors.Control;

        /// <summary>
        /// Gets or sets the close button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/>.
        /// </summary>
        /// <value>The close button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the close button image when the dialog is embeded within a control.")]
        public Image CloseButtonImage { get; set; } = Properties.Resources.win10_close;

        /// <summary>
        /// Gets or sets the close button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and mouse hovers over the button.
        /// </summary>
        /// <value>The close button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and mouse hovers over the button.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the close button hover image when the dialog is embeded within a control.")]
        public Image CloseButtonHoverImage { get; set; } = Properties.Resources.win10_close_white;

        /// <summary>
        /// Gets or sets the expand button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible.
        /// </summary>
        /// <value>The expand button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the expand button image when the dialog is embeded within a control and the dialog is invisible.")]
        public Image ExpandButtonImage { get; set; } = Properties.Resources.plus_flat;

        /// <summary>
        /// Gets or sets the expand button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible and mouse hovers over the button.
        /// </summary>
        /// <value>The expand button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible and mouse hovers over the button.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the expand button hover image when the dialog is embeded within a control and the dialog is invisible.")]
        public Image ExpandButtonHoverImage { get; set; } = Properties.Resources.plus_flat;

        /// <summary>
        /// Gets or sets the time information button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible and mouse hovers over the button.
        /// </summary>
        /// <value>The time information button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible and mouse hovers over the button.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the time information button image when the dialog is embeded within a control and the dialog is invisible.")]
        public Image TimeInfoButtonImage { get; set; } = Properties.Resources.clock_flat_borderless_3;

        /// <summary>
        /// Gets or sets the time information button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible and mouse hovers over the button.
        /// </summary>
        /// <value>The time information button image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is invisible and mouse hovers over the button.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the time information button hover image when the dialog is embeded within a control and the dialog is invisible.")]
        public Image TimeInfoButtonHoverImage { get; set; } = Properties.Resources.clock_flat_borderless_3;

        /// <summary>
        /// Gets or sets the expand button minimize image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is visible.
        /// </summary>
        /// <value>The expand button minimize image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is visible.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the expand button minimize image when the dialog is embeded within a control and the dialog is visible.")]
        public Image ExpandButtonImageMinimize { get; set; } = Properties.Resources.minus_flat;

        /// <summary>
        /// Gets or sets the expand button minimize image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is visible and mouse hovers over the button.
        /// </summary>
        /// <value>The expand button minimize image when the <see cref="MessageBoxBase"/> <see cref="BorderStyle"/> is set to <see cref="BorderStyle.None"/> and the message box is visible and mouse hovers over the button.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the expand button hover minimize image when the dialog is embeded within a control and the dialog is visible.")]
        public Image ExpandButtonImageHoverMinimize { get; set; } = Properties.Resources.minus_flat;

        /// <summary>
        /// Gets or sets the date and time format used to display the date and time in a title bar tool tip of a docked dialog.
        /// </summary>
        /// <value>date and time format used to display the date and time in a title bar tool tip of a docked dialog.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the date and time format used to display the date and time in a title bar tool tip of a docked dialog.")]
        public string TimeFormat { get; set; } = "G";

        // ReSharper disable once InconsistentNaming
        private Font fontDialogTitle;

        // ReSharper disable once InconsistentNaming

        // ReSharper disable once InconsistentNaming
        private Font fontDialogTitleExpanded;

        // ReSharper disable once InconsistentNaming

        // ReSharper disable once InconsistentNaming
        private Font fontDialogText;

        // ReSharper disable once InconsistentNaming

        /// <summary>
        /// Gets or sets the font for the embedded dialog title text.
        /// </summary>
        /// <value>The font for the embedded dialog title text.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the font for the embedded dialog title text.")]
        public Font FontDialogTitle
        {
            get => fontDialogTitle ?? new Font(Font, FontStyle.Bold);

            set => fontDialogTitle = value;
        }

        /// <summary>
        /// Gets or sets the foreground color for the dialog title text.
        /// </summary>
        /// <value>The foreground color for the dialog title text.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the foreground color for the dialog title text.")]
        public Color DialogTitleForeColor { get; set; } = SystemColors.ControlText;

        /// <summary>
        /// Gets or sets the font for the embedded dialog title text when the dialog is expanded.
        /// </summary>
        /// <value>The font for the embedded dialog title text when the dialog is expanded.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the font for the embedded dialog title text when the dialog is expanded.")]
        public Font FontDialogTitleExpanded
        {
            get => fontDialogTitleExpanded ?? Font;

            set => fontDialogTitleExpanded = value;
        }

        /// <summary>
        /// Gets or sets the foreground color for the dialog title text when the dialog is expanded.
        /// </summary>
        /// <value>The foreground color for the dialog title text when the dialog is expanded.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the foreground color for the dialog title text when the dialog is expanded.")]
        public Color DialogTitleExpandedForeColor { get; set; } = SystemColors.ControlText;

        /// <summary>
        /// Gets or sets the font for the embedded dialog text.
        /// </summary>
        /// <value>The font for the embedded dialog text.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the font for the embedded dialog text.")]
        public Font FontDialogText
        {
            get => fontDialogText ?? Font;

            set => fontDialogText = value;
        }

        /// <summary>
        /// Gets or sets the foreground color for the dialog text when the dialog is expanded.
        /// </summary>
        /// <value>The foreground color for the dialog text when the dialog is expanded.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the foreground color for the dialog text when the dialog is expanded.")]
        public Color DialogTextForeColor { get; set; } = SystemColors.ControlText;

        /// <summary>
        /// Gets or sets the default <see cref="DialogResultExtended"/> dialog result if a dialog is closed via the close button.
        /// </summary>
        /// <value>The default close result.</value>
        [Browsable(true)]
        [Category("Behaviour")]
        [Description("Gets or sets the default dialog result if a dialog is closed via the close button.")]
        public DialogResultExtended DefaultCloseResult { get; set; }

        /// <summary>
        /// Gets or sets the size of the title icon when the dialog is minimized.
        /// </summary>
        /// <value>The size of the title icon when the dialog is minimized.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the size of the title icon when the dialog is minimized.")]
        public Size TitleIconSize { get; set; } = new Size(24, 24);

        /// <summary>
        /// Gets or sets the height of the title of the dialog box contained within the control.
        /// </summary>
        /// <value>The height of the title of the dialog box contained within the control.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the height of the title of the dialog box contained within the control.")]
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// Gets or sets the width of the title icon area.
        /// </summary>
        /// <value>The width of the title icon area.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the width of the title icon area.")]
        public int TitleIconAreaWidth { get; set; } = 30;
        #endregion

        #region PublicMethods        
        /// <summary>
        /// Scrolls the view to the top.
        /// </summary>
        public void ScrollToTop()
        {
            pnStackDialog.AutoScrollPosition = new Point(0, 0);
            pnStackDialog.VerticalScroll.Value = 0;
        }

        /// <summary>
        /// Sets the expand state of all the message boxes within the control to a specified value.
        /// </summary>
        /// <param name="expanded">if set to <c>true</c> all the message boxes within the control are expanded.</param>
        public void SetExpandAll(bool expanded)
        {
            foreach (var control in ResizeContainerControls)
            {
                control?.ToggleExpandAction(expanded);
            }
        }

        /// <summary>
        /// Toggles the message box expanded state.
        /// </summary>
        /// <returns><c>true</c> if all the message box states were set to expanded, <c>false</c> otherwise.</returns>
        public bool ToggleExpandAll()
        {
            var expanded = ResizeContainerControls.Count(f => f.Expanded);
            var collapsed = ResizeContainerControls.Count - expanded;

            var expand = collapsed >= expanded;
            SetExpandAll(expand);
            return expand;
        }

        /// <summary>
        /// Closes all the <see cref="MessageBoxBase"/> dialog boxes with the specified result.
        /// </summary>
        /// <param name="closeResult">The <see cref="DialogResultExtended"/> result.</param>
        public void CloseAllWithResult(DialogResultExtended closeResult)
        {
            for (int i = ResizeContainerControls.Count - 1; i >= 0; i--)
            {
                ResizeContainerControls[i]?.CloseDialogAction(closeResult);
            }
        }

        /// <summary>
        /// Adds the dialog to the control.
        /// </summary>
        /// <param name="messageBox">The dialog to add to the control.</param>
        /// <param name="minimized">A value indicated whether the message box should be added as minimized.</param>
        public override void AddDialog(MessageBoxBase messageBox, bool minimized)
        {
            base.AddDialog(messageBox, minimized);

            messageBox.TopLevel = false;
            messageBox.FormBorderStyle = FormBorderStyle.None;
            messageBox.Visible = true;
            messageBox.CloseOnClick = false;
            messageBox.Dock = minimized ? DockStyle.None : DockStyle.Fill;

            pnStackDialog.Controls.Add(CreateContainerControl(messageBox, minimized));

            pnStackDialog.VerticalScroll.Value = 0;
        }

        /// <summary>
        /// Adds the dialog to the control.
        /// </summary>
        /// <param name="messageBox">The dialog to add to the control.</param>
        /// <param name="minimized">A value indicated whether the message box should be added as minimized.</param>
        /// <param name="priority">The priority of the message box added to the control. This is an integer value and the importance grows upwards.</param>
        public override void AddDialog(MessageBoxBase messageBox, bool minimized, uint priority)
        {
            messageBox.Priority = priority;
            AddDialog(messageBox, minimized);
        }

        #endregion

        #region PrivateProperties
        /// <summary>
        /// Gets the resizable container controls for the embedded dialog boxes.
        /// </summary>
        /// <value>The resizable container controls for the embedded dialog boxes.</value>
        private List<TableLayoutDialogBox> ResizeContainerControls { get; } = new List<TableLayoutDialogBox>();
        #endregion

        #region ProtectedMethods        
        /// <summary>
        /// Creates the container control for the dialog box to be added to the control.
        /// </summary>
        /// <param name="messageBox">The message box to add to the control.</param>
        /// <param name="minimized">A value indicating whether the message box should be minimized in the container control.</param>
        /// <returns>The container control for the dialog box to be added to the control.</returns>
        protected override Control CreateContainerControl(MessageBoxBase messageBox, bool minimized)
        {
            #region ContainerPanel
            // create a TableLayoutPanel as a container for the single MessageBoxBase instance..
            TableLayoutDialogBox panelFormContainer = new TableLayoutDialogBox
            {
                RowCount = 3,
                ColumnCount = 5,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Top,
                MessageBox = messageBox,
            };

            // set the row and column styles for the container..
            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, TitleHeight));
            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panelFormContainer.RowStyles.Add(minimized ? new RowStyle(SizeType.Absolute, 0) : new RowStyle(SizeType.AutoSize));
            panelFormContainer.ColumnStyles.Add(minimized ? new ColumnStyle(SizeType.Absolute, TitleIconAreaWidth) : new ColumnStyle(SizeType.Absolute, 0));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, TitleIconAreaWidth));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, TitleIconAreaWidth));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, TitleIconAreaWidth));
            #endregion

            #region CloseBox
            // create the close button (Panel) for the message box container..
            var pnCloseBox = new Panel
            {
                BackgroundImage = CloseButtonImage, BackgroundImageLayout = ImageLayout.Center,
                Margin = new Padding(0), Dock = DockStyle.Fill,
                Name = NameCloseBox, // set the name to identify the control..
                Tag = false,
            };

            // handling for the mouse hover event for the close button..
            pnCloseBox.MouseHover += delegate(object sender, EventArgs args)
            {
                ((Panel) sender).BackColor = DialogCloseButtonHoverBackground;
                ((Panel) sender).BackgroundImage = CloseButtonHoverImage;
                ((Panel) sender).Tag = true; // indicate mouse over control..
            };

            // handling for the mouse leave event for the close button..
            pnCloseBox.MouseLeave += delegate(object sender, EventArgs args)
            {
                ((Panel) sender).BackColor = DialogCloseButtonBackground;
                ((Panel) sender).BackgroundImage = CloseButtonImage;
                ((Panel) sender).Tag = false; // indicate mouse over control..
            };

            // this action is invoked by the MessageBoxBase descendant class..
            messageBox.DialogResultAction = (resultExtended, rememberAnswer, data) =>
            {
                var eventArgs = new MessageBoxEventArgs
                {
                    Data = data, 
                    DialogResult = resultExtended, 
                    MessageBox = messageBox, 
                    RememberAnswer = rememberAnswer,
                    MessageBoxId = messageBox.Id,
                };

                // raise the message box close event..
                RaiseMessageBoxClosed(this, eventArgs);

                // close and dispose of the message box if it is allowed to close..
                if (eventArgs.AllowMessageBoxClose)
                {
                    messageBox.ForceClose();
                    using (panelFormContainer)
                    {
                        Controls.Remove(panelFormContainer);
                        ResizeContainerControls.Remove(panelFormContainer);
                        PerformLayout();
                    }
                }
            };

            // create the action to close a single dialog with a specified result..
            panelFormContainer.CloseDialogAction = delegate(DialogResultExtended resultExtended)
            {
                // always close..
                messageBox.Result = resultExtended;
                messageBox.ForceClose();
                using (panelFormContainer) // do the dispose thing..
                {
                    Controls.Remove(panelFormContainer);
                    ResizeContainerControls.Remove(panelFormContainer);
                    PerformLayout();
                }
            };

            // handling for the click event for the close button..
            pnCloseBox.Click += delegate
            {
                // call the previously defined action with the default close result..
                panelFormContainer.CloseDialogAction(DefaultCloseResult);
            };

            // add the close button to the dialog container control..
            panelFormContainer.Controls.Add(pnCloseBox, 4, 0);
            #endregion

            #region IconBox
            // create an icon box for the dialog container in case the dialog is minimized..
            var iconBox = new Panel
            {
                BackgroundImage = messageBox.GetIcon(TitleIconSize), BackgroundImageLayout = ImageLayout.Center,
                Margin = new Padding(0), Dock = DockStyle.Fill, Tag = minimized,
                Name = "IconBox", // set the name to identify the control..
            };

            // add the icon box to the dialog container control..
            panelFormContainer.Controls.Add(iconBox, 0, 0);
            #endregion

            #region TitleCaption
            // create a title for the dialog as it is docked to the container control without a border..
            var labelCaptionPanel = new TableLayoutPanel // the TableLayoutPanel instance for the Label controls..
            {
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Name = NameCaptionPanel, // set the name to identify the control..
            };

            // set the row and column styles for the title container..
            labelCaptionPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            labelCaptionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            labelCaptionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));

            // create a title Label control for the embedded dialog..
            var label = new Label
            {
                Text = messageBox.Text,
                Parent = panelFormContainer, 
                AutoSize = false, 
                AutoEllipsis = true,
                Dock = DockStyle.Fill, 
                TextAlign = ContentAlignment.MiddleLeft, 
                Font = minimized ? FontDialogTitle : FontDialogTitleExpanded,
                ForeColor = minimized ? DialogTitleExpandedForeColor : DialogTitleForeColor,
                Name = NameFontDialogTitle, // set the name to identify the control..
            };

            // create a text Label control for the embedded dialog..
            var labelText = new Label
            {
                Text = minimized ? messageBox.MessageText : string.Empty,
                Parent = panelFormContainer, 
                AutoSize = false, 
                AutoEllipsis = true,
                Dock = DockStyle.Fill, 
                TextAlign = ContentAlignment.MiddleLeft,
                Font = FontDialogText,
                ForeColor = DialogTextForeColor,
                Name = NameFontDialogText, // set the name to identify the control..
            };

            // add the labels to the title Label control..
            labelCaptionPanel.Controls.Add(label, 0, 0);
            labelCaptionPanel.Controls.Add(labelText, 1, 0);
            panelFormContainer.Controls.Add(labelCaptionPanel, 1,  0);
            #endregion

            #region ExpandBox
            // create and expand toggle button (Panel) for the dialog..
            var minMaxBox = new Panel
            {
                BackgroundImage = minimized ? ExpandButtonImage : ExpandButtonImageMinimize, 
                BackgroundImageLayout = ImageLayout.Center,
                Margin = new Padding(0), 
                Dock = DockStyle.Fill, 
                Tag = minimized ? ControlButtonState.Minimized : ControlButtonState.Expanded,
                Name = NameExpandBox, // set the name to identify the control..
            };

            // handling for the mouse hover event for the expand toggle button..
            minMaxBox.MouseHover += delegate(object sender, EventArgs args)
            {
                var state = (ControlButtonState) minMaxBox.Tag;
                ((Panel) sender).BackColor = DialogExpandButtonHoverBackground;
                ((Panel) sender).BackgroundImage =
                    state.HasFlag(ControlButtonState.Expanded)
                        ? ExpandButtonImageHoverMinimize
                        : ExpandButtonHoverImage;

                minMaxBox.Tag = state | ControlButtonState.MouseHover;
            };

            // handling for the mouse leave event for the expand toggle button..
            minMaxBox.MouseLeave += delegate(object sender, EventArgs args)
            {
                var state = (ControlButtonState) minMaxBox.Tag;
                ((Panel) sender).BackColor = DialogExpandButtonBackground;
                ((Panel) sender).BackgroundImage = state.HasFlag(ControlButtonState.Expanded)
                    ? ExpandButtonImageMinimize
                    : ExpandButtonImage;
                minMaxBox.Tag = state & ~ControlButtonState.MouseHover;
            };

            panelFormContainer.IsExpanded =
                () => ((ControlButtonState) minMaxBox.Tag).HasFlag(ControlButtonState.Expanded);
            

            panelFormContainer.ToggleExpandAction = expand =>
            {
                var state = (ControlButtonState) minMaxBox.Tag;

                // do nothing is nothing is required to be done..
                if (state.HasFlag(ControlButtonState.Expanded) && expand ||
                    state.HasFlag(ControlButtonState.Minimized) && !expand)
                {
                    return;
                }

                panelFormContainer.ColumnStyles[0] = expand
                    ? new ColumnStyle(SizeType.Absolute, 0)
                    : new ColumnStyle(SizeType.Absolute, 30);

                panelFormContainer.RowStyles[2] = expand
                    ? new RowStyle(SizeType.AutoSize)
                    : new RowStyle(SizeType.Absolute, 0);

                minMaxBox.BackgroundImage = expand
                    ? ExpandButtonImageMinimize
                    : ExpandButtonImage;

                messageBox.Dock = expand ? DockStyle.Fill : DockStyle.None;

                // invert the enumeration values..
                state = expand ? state ^ ControlButtonState.Minimized : state | ControlButtonState.Minimized;
                state = expand ? state | ControlButtonState.Expanded : state ^ ControlButtonState.Expanded;

                minMaxBox.Tag = state;

                labelText.Text = expand ? string.Empty : messageBox.MessageText;
                label.Font = expand ? FontDialogTitleExpanded : FontDialogTitle;

                PerformLayout();
            };

            // handling for the click event for the expand toggle button..
            minMaxBox.Click += delegate
            {
                panelFormContainer.ToggleExpandAction(!panelFormContainer.Expanded);
            };

            // add the expand toggle button to the dialog container control..
            panelFormContainer.Controls.Add(minMaxBox, 3, 0);
            #endregion

            #region TimeBox
            // create and time information button (Panel) for the dialog..
            var timeBox = new Panel
            {
                BackgroundImage = TimeInfoButtonImage, 
                BackgroundImageLayout = ImageLayout.Center,
                Margin = new Padding(0), 
                Dock = DockStyle.Fill, 
                Tag = ControlButtonState.Expanded,
                Name = NameTimeInfoBox, // set the name to identify the control..
            };

            // handling for the mouse hover event for the time information button..
            timeBox.MouseHover += delegate(object sender, EventArgs args)
            {
                var state = (ControlButtonState) timeBox.Tag;
                ((Panel) sender).BackColor = DialogTimeButtonHoverBackground;
                ((Panel) sender).BackgroundImage = TimeInfoButtonHoverImage;

                timeBox.Tag = state | ControlButtonState.MouseHover;
            };

            // handling for the mouse leave event for the expand toggle button..
            timeBox.MouseLeave += delegate(object sender, EventArgs args)
            {
                var state = (ControlButtonState) timeBox.Tag;
                ((Panel) sender).BackColor = DialogTimeButtonBackground;
                ((Panel) sender).BackgroundImage = TimeInfoButtonImage;
                timeBox.Tag = state & ~ControlButtonState.MouseHover;
            };

            // set the dialog creation time to the tool tip..
            ttMain.SetToolTip(timeBox, messageBox.DialogCreated.ToString(TimeFormat));

            // add the expand toggle button to the dialog container control..
            panelFormContainer.Controls.Add(timeBox, 2, 0);
            #endregion

            // add the dialog box to the container control..
            panelFormContainer.Controls.Add(messageBox, 0,  2);
            panelFormContainer.SetColumnSpan(messageBox, 5);

            // layout the control..
            PerformLayout();

            // add the control to the collection for property update setting..
            ResizeContainerControls.Add(panelFormContainer);
            DialogCountChanged?.Invoke(DialogCount);

            // return to created dialog box container
            return panelFormContainer;
        }
        #endregion

        #region EventHandlers
        /// <summary>
        /// Handles the Disposed event of the messageBoxControlStack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <a onclick="return false;" href="EventArgs" originaltag="see">EventArgs</a> instance containing the event data.</param>
        private void messageBoxControlStack_Disposed(object sender, EventArgs e)
        {
            PropertyChanged -= messageBoxControlStack_PropertyChanged;
            Disposed -= messageBoxControlStack_Disposed;
        }

        private void messageBoxControlStack_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            foreach (var panel in ResizeContainerControls)
            {
                var minimized = (bool?) panel.Controls.Find(NameExpandBox, false).FirstOrDefault()?.Tag == true;

                // handle the dialog title properties..
                if (e.PropertyName == nameof(FontDialogTitle) || 
                    e.PropertyName == nameof(FontDialogTitleExpanded) ||
                    e.PropertyName == nameof(DialogTitleForeColor) ||
                    e.PropertyName == nameof(DialogTitleExpandedForeColor)) 
                {
                    var control = (Label) panel.Controls.Find(NameFontDialogTitle, true).FirstOrDefault();
                    if (control != null)
                    {
                        control.Font = minimized ? FontDialogTitle : FontDialogTitleExpanded;
                        control.ForeColor = minimized ? DialogTitleForeColor : DialogTitleExpandedForeColor;

                    }
                }

                // handle the dialog text properties..
                if (e.PropertyName == nameof(FontDialogText) ||
                    e.PropertyName == nameof(DialogTextForeColor))
                {
                    var control = (Label) panel.Controls.Find(NameFontDialogText, true).FirstOrDefault();
                    if (control != null)
                    {
                        control.Font = FontDialogText;
                        control.ForeColor = DialogTextForeColor;
                    }
                }

                // handle the close button properties..
                if (e.PropertyName == nameof(CloseButtonHoverImage) ||
                    e.PropertyName == nameof(CloseButtonImage) ||
                    e.PropertyName == nameof(DialogCloseButtonBackground) ||
                    e.PropertyName == nameof(DialogCloseButtonHoverBackground))
                {
                    var control = (Panel) panel.Controls.Find(NameCloseBox, true).FirstOrDefault();
                    if (control != null)
                    {
                        var mouseHover = (bool) control.Tag;
                        control.BackgroundImage = mouseHover ? CloseButtonHoverImage : CloseButtonImage;
                        control.BackColor = mouseHover ? DialogCloseButtonHoverBackground : DialogCloseButtonBackground;
                    }
                }

                // handle the close button properties..
                if (e.PropertyName == nameof(ExpandButtonHoverImage) ||
                    e.PropertyName == nameof(ExpandButtonImage) ||
                    e.PropertyName == nameof(DialogExpandButtonBackground) ||
                    e.PropertyName == nameof(DialogExpandButtonHoverBackground) ||
                    e.PropertyName == nameof(ExpandButtonImage) ||
                    e.PropertyName == nameof(ExpandButtonHoverImage))
                {
                    var control = (Panel) panel.Controls.Find(NameExpandBox, true).FirstOrDefault();
                    if (control != null)
                    {
                        var state = (ControlButtonState) control.Tag;

                        control.BackgroundImage = state.HasFlag(ControlButtonState.MouseHover)
                            ? CloseButtonHoverImage
                            : CloseButtonImage;

                        control.BackColor = state.HasFlag(ControlButtonState.MouseHover)
                            ? DialogCloseButtonHoverBackground
                            : DialogCloseButtonBackground;

                        if (state.HasFlag(ControlButtonState.Expanded))
                        {
                            control.BackgroundImage = state.HasFlag(ControlButtonState.MouseHover)
                                ? ExpandButtonHoverImage
                                : ExpandButtonImage;
                        }
                    }
                }                
                

                if (e.PropertyName == nameof(FontDialogText))
                {
                    var control = (Label) panel.Controls.Find(NameFontDialogText, true).FirstOrDefault();
                    if (control != null)
                    {
                        control.Font = FontDialogText;
                    }
                }

                if (e.PropertyName == nameof(FontDialogTitleExpanded))
                {
                    var control = (Label) panel.Controls.Find(NameFontDialogTitle, true).FirstOrDefault();
                    if (control != null && !minimized)
                    {
                        control.Font = FontDialogTitleExpanded;
                    }
                }

                if (e.PropertyName == nameof(DialogTitleForeColor))
                {
                    var control = (Label) panel.Controls.Find(NameFontDialogTitle, true).FirstOrDefault();
                    if (control != null && !minimized)
                    {
                        control.ForeColor = DialogTitleForeColor;
                    }
                }

                if (e.PropertyName == nameof(DialogTitleForeColor))
                {
                    var control = (Label) panel.Controls.Find(NameFontDialogTitle, true).FirstOrDefault();
                    if (control != null && !minimized)
                    {
                        control.ForeColor = DialogTitleForeColor;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        #pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore CS0067

        #region Sorting        
        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in ascending order by their creation time <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.DialogCreated" />.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByTime()
        {
            return OrderBy(false, f => f.MessageBox.DialogCreated);
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in descending order by their creation time <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.DialogCreated" />.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByTimeDescending()
        {
            return OrderBy(true, f => f.MessageBox.DialogCreated);
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in specified order by their creation time <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.DialogCreated" />.
        /// </summary>
        /// <param name="descending">if set to <c>true</c> the items are ordered in descending order.</param>
        /// <returns>MessageBoxControlStack.</returns>
        public MessageBoxControlStack OrderByTime(bool descending)
        {
            return descending ? OrderByTimeDescending() : OrderByTime();
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in ascending order by their priority <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.Priority" />.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByPriority()
        {
            return OrderBy(false, f => f.MessageBox.Priority);
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in descending order by their priority <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.Priority" />.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByPriorityDescending()
        {
            return OrderBy(true, f => f.MessageBox.Priority);
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in a specified order by their priority <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.DialogCreated" />.
        /// </summary>
        /// <param name="descending">if set to <c>true</c> the items are ordered in descending order.</param>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByPriority(bool descending)
        {
            return descending ? OrderByTimeDescending() : OrderByTime();
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in ascending order by their type <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.MessageBoxType" />.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByType()
        {
            return OrderBy(false, f => f.MessageBox.MessageBoxType);
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in descending order by their type <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.MessageBoxType" />.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByTypeDescending()
        {
            return OrderBy(true, f => f.MessageBox.MessageBoxType);
        }

        /// <summary>
        /// Sorts the <see cref="T:VPKSoft.MessageBoxExtended.MessageBoxBase" /> instances of the sequence in a specified order by their priority <see cref="P:VPKSoft.MessageBoxExtended.MessageBoxBase.Priority" />.
        /// </summary>
        /// <param name="descending">if set to <c>true</c> the items are ordered in descending order.</param>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderByType(bool descending)
        {
            return OrderBy(true, f => f.MessageBox.Priority);
        }

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <typeparam name="TContainerMember">The type of the t container member.</typeparam>
        /// <param name="descending">if set to <c>true</c> [descending].</param>
        /// <param name="orderFunc">The order function.</param>
        /// <returns>An instance to a class implementing the <see cref="MessageBoxControlStack" /> instance whose elements are sorted according to the method call.</returns>
        public MessageBoxControlStack OrderBy<TContainerMember>(bool @descending, Func<TableLayoutDialogBox, TContainerMember> orderFunc)
        {
            var controls = new List<TableLayoutDialogBox>(ResizeContainerControls.ToArray());

            pnStackDialog.Controls.Clear();
            ResizeContainerControls.Clear();

            controls = descending
                ? controls.OrderByDescending(orderFunc).ToList()
                : controls.OrderBy(orderFunc).ToList();


            foreach (var control in controls)
            {
                pnStackDialog.Controls.Add(control);
                ResizeContainerControls.Add(control);
            }

            return this;
        }
        #endregion
    }
}
