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
using VPKSoft.MessageBoxExtended.Controls.Enumerations;

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// Class MessageBoxStack.
    /// Implements the <see cref="VPKSoft.MessageBoxExtended.Controls.MessageBoxControlBase" />
    /// </summary>
    /// <seealso cref="VPKSoft.MessageBoxExtended.Controls.MessageBoxControlBase" />
    public partial class MessageBoxControlStack : MessageBoxControlBase, INotifyPropertyChanged
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
        #region Constants

        private const string NameFontDialogTitle = "LabelTitle";
        private const string NameFontDialogText = "LabelText";
        private const string NameExpandBox = "ExpandBox";
        private const string NameCaptionPanel = "Title";
        private const string NameCloseBox = "CloseBox";

        #endregion

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

        #region DesignerProperties
        /// <summary>
        /// Gets or sets the dialog close button background color (inactive).
        /// </summary>
        /// <value>The dialog close button background color (inactive).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog close button background color (inactive).")]
        public Color DialogCloseButtonBackground { get; set; } = SystemColors.Window;

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
        public Color DialogExpandButtonBackground { get; set; } = SystemColors.Window;

        /// <summary>
        /// Gets or sets the dialog expand button hover background color (active).
        /// </summary>
        /// <value>The dialog expand button hover background color (active).</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the dialog expand button hover background color (active).")]
        public Color DialogExpandButtonHoverBackground { get; set; } = SystemColors.Control;

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
        #endregion

        #region PublicMethods
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
        }
        #endregion

        #region PrivateProperties
        /// <summary>
        /// Gets the resizable container controls for the embedded dialog boxes.
        /// </summary>
        /// <value>The resizable container controls for the embedded dialog boxes.</value>
        private List<TableLayoutPanel> ResizeContainerControls { get; } = new List<TableLayoutPanel>();
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
            TableLayoutPanel panelFormContainer = new TableLayoutPanel
            {
                RowCount = 3,
                ColumnCount = 4,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Top
            };

            // set the row and column styles for the container..
            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panelFormContainer.RowStyles.Add(minimized ? new RowStyle(SizeType.Absolute, 0) : new RowStyle(SizeType.AutoSize));
            panelFormContainer.ColumnStyles.Add(minimized ? new ColumnStyle(SizeType.Absolute, 30) : new ColumnStyle(SizeType.Absolute, 0));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
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

            // handling for the click event for the close button..
            pnCloseBox.Click += delegate
            { 
                messageBox.ForceClose();
                using (panelFormContainer)
                {
                    Controls.Remove(panelFormContainer);
                    ResizeContainerControls.Remove(panelFormContainer);
                    PerformLayout();
                }
            };

            // add the close button to the dialog container control..
            panelFormContainer.Controls.Add(pnCloseBox, 3, 0);
            #endregion

            #region IconBox
            // create an icon box for the dialog container in case the dialog is minimized..
            var iconBox = new Panel
            {
                BackgroundImage = messageBox.GetIcon(new Size(28, 28)), BackgroundImageLayout = ImageLayout.Center,
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
                Text = minimized ? string.Empty : messageBox.MessageText,
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

            // handling for the click event for the expand toggle button..
            minMaxBox.Click += delegate
            {
                var state = (ControlButtonState) minMaxBox.Tag;

                panelFormContainer.ColumnStyles[0] = !state.HasFlag(ControlButtonState.Expanded)
                    ? new ColumnStyle(SizeType.Absolute, 0)
                    : new ColumnStyle(SizeType.Absolute, 30);

                panelFormContainer.RowStyles[2] = !state.HasFlag(ControlButtonState.Expanded)
                    ? new RowStyle(SizeType.AutoSize)
                    : new RowStyle(SizeType.Absolute, 0);

                minMaxBox.BackgroundImage = !state.HasFlag(ControlButtonState.Expanded)
                    ? ExpandButtonImageMinimize
                    : ExpandButtonImage;

                messageBox.Dock = !state.HasFlag(ControlButtonState.Expanded) ? DockStyle.Fill : DockStyle.None;

                minMaxBox.Tag = state ^ ControlButtonState.Expanded;

                labelText.Text = !state.HasFlag(ControlButtonState.Expanded) ? string.Empty : messageBox.MessageText;
                label.Font = !state.HasFlag(ControlButtonState.Expanded) ? FontDialogTitleExpanded : FontDialogTitle;

                PerformLayout();
            };

            // add the expand toggle button to the dialog container control..
            panelFormContainer.Controls.Add(minMaxBox, 2, 0);
            #endregion

            // add the dialog box to the container control..
            panelFormContainer.Controls.Add(messageBox, 0,  2);
            panelFormContainer.SetColumnSpan(messageBox, 4);

            // layout the control..
            PerformLayout();

            // add the control to the collection for property update setting..
            ResizeContainerControls.Add(panelFormContainer);

            // return to created dialog box container
            return panelFormContainer;
        }
        #endregion

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

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        #pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore CS0067
    }
}
