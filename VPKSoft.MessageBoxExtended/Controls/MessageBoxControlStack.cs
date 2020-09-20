using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// Class MessageBoxStack.
    /// Implements the <see cref="VPKSoft.MessageBoxExtended.Controls.MessageBoxControlBase" />
    /// </summary>
    /// <seealso cref="VPKSoft.MessageBoxExtended.Controls.MessageBoxControlBase" />
    public partial class MessageBoxControlStack : MessageBoxControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxControlStack"/> class.
        /// </summary>
        public MessageBoxControlStack()
        {
            InitializeComponent();
        }

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

        /// <summary>
        /// Gets or sets the caption format of a message box when visible.
        /// </summary>
        /// <value>The caption format of a message box when visible.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the caption format of a message box when visible.")]
        public string CaptionFormat { get; set; } = @" {0}";

        /// <summary>
        /// Gets or sets the caption format of a message box when minimized.
        /// </summary>
        /// <value>The caption format of a message box when minimized.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the caption format of a message box when minimized.")]
        public string CaptionFormatMinimize { get; set; } = @" {0}: {1}";
        #endregion

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

        private List<Control> ResizeContainerControls { get; } = new List<Control>();

        /// <summary>
        /// Creates the container control for the dialog box to be added to the control.
        /// </summary>
        /// <param name="messageBox">The message box to add to the control.</param>
        /// <param name="minimized">A value indicating whether the message box should be minimized in the container control.</param>
        /// <returns>The container control for the dialog box to be added to the control.</returns>
        protected override Control CreateContainerControl(MessageBoxBase messageBox, bool minimized)
        {
            TableLayoutPanel panelFormContainer = new TableLayoutPanel
            {
                RowCount = 3,
                ColumnCount = 4,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Top
            };

            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panelFormContainer.RowStyles.Add(minimized ? new RowStyle(SizeType.Absolute, 0) : new RowStyle(SizeType.AutoSize));
            panelFormContainer.ColumnStyles.Add(minimized ? new ColumnStyle(SizeType.Absolute, 30) : new ColumnStyle(SizeType.Absolute, 0));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            panelFormContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            #region CloseBox
            var pnCloseBox = new Panel
            {
                BackgroundImage = CloseButtonImage, BackgroundImageLayout = ImageLayout.Center,
                Margin = new Padding(0), Dock = DockStyle.Fill
            };

            pnCloseBox.MouseHover += delegate(object sender, EventArgs args)
            {
                ((Panel) sender).BackColor = DialogCloseButtonHoverBackground;
                ((Panel) sender).BackgroundImage = CloseButtonHoverImage;
            };

            pnCloseBox.Click += delegate
            { 
                messageBox.ForceClose();
                using (panelFormContainer)
                {
                    Controls.Remove(panelFormContainer);
                    PerformLayout();
                }
            };

            pnCloseBox.MouseLeave += delegate(object sender, EventArgs args)
            {
                ((Panel) sender).BackColor = DialogCloseButtonBackground;
                ((Panel) sender).BackgroundImage = CloseButtonImage;
            };

            panelFormContainer.Controls.Add(pnCloseBox, 3, 0);
            #endregion

            #region IconBox
            var iconBox = new Panel
            {
                BackgroundImage = messageBox.GetIcon(new Size(30, 30)), BackgroundImageLayout = ImageLayout.Center,
                Margin = new Padding(0), Dock = DockStyle.Fill, Tag = minimized,
            };

            panelFormContainer.Controls.Add(iconBox, 0, 0);
            #endregion

            #region TitleCaption
            var label = new Label
            {
                Text = minimized
                    ? string.Format(CaptionFormatMinimize, messageBox.Text, messageBox.MessageText)
                    : string.Format(CaptionFormat, messageBox.Text),
                Parent = panelFormContainer, AutoSize = false, AutoEllipsis = true,
                Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft,
            };
            panelFormContainer.Controls.Add(label, 1,  0);
            #endregion

            #region ExpandBox
            var minMaxBox = new Panel
            {
                BackgroundImage = minimized ? ExpandButtonImageMinimize : ExpandButtonHoverImage, BackgroundImageLayout = ImageLayout.Center,
                Margin = new Padding(0), Dock = DockStyle.Fill, Tag = minimized,
            };

            minMaxBox.MouseHover += delegate(object sender, EventArgs args)
            {
                ((Panel) sender).BackColor = DialogExpandButtonHoverBackground;
                ((Panel) sender).BackgroundImage = ExpandButtonHoverImage;
            };

            minMaxBox.MouseLeave += delegate(object sender, EventArgs args)
            {
                ((Panel) sender).BackColor = DialogExpandButtonBackground;
                ((Panel) sender).BackgroundImage = ExpandButtonHoverImage;
            };

            minMaxBox.Click += delegate
            {
                var previousMinimized = (bool) minMaxBox.Tag;

                panelFormContainer.ColumnStyles[0] = previousMinimized
                    ? new ColumnStyle(SizeType.Absolute, 0)
                    : new ColumnStyle(SizeType.Absolute, 30);

                panelFormContainer.RowStyles[2] = previousMinimized
                    ? new RowStyle(SizeType.AutoSize)
                    : new RowStyle(SizeType.Absolute, 0);

                minMaxBox.BackgroundImage = previousMinimized ? ExpandButtonImageMinimize : ExpandButtonImage;

                messageBox.Dock = previousMinimized ? DockStyle.Fill : DockStyle.None;

                minMaxBox.Tag = !previousMinimized;

                label.Text = previousMinimized
                    ? string.Format(CaptionFormatMinimize, messageBox.Text, messageBox.MessageText)
                    : string.Format(CaptionFormat, messageBox.Text);

                PerformLayout();
            };

            panelFormContainer.Controls.Add(minMaxBox, 2, 0);
            #endregion


//            panelFormContainer.SetColumnSpan(label, 2);
            panelFormContainer.Controls.Add(messageBox, 0,  2);
            panelFormContainer.SetColumnSpan(messageBox, 4);

            PerformLayout();

            return panelFormContainer;
        }

        private void pnStackDialog_Resize(object sender, EventArgs e)
        {
            foreach (var dialog in pnStackDialog.Controls)
            {
//                var panel = ((TableLayoutPanel) dialog);
//                panel.Width = pnStackDialog.ClientSize.Width;

                //dialog.Width = ClientSize.Width;
            }
        }
    }
}
