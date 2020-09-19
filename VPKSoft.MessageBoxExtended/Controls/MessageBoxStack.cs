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
    public partial class MessageBoxStack : MessageBoxControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxStack"/> class.
        /// </summary>
        public MessageBoxStack()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the dialog to the control.
        /// </summary>
        /// <param name="messageBox">The dialog to add to the control.</param>
        public override void AddDialog(MessageBoxBase messageBox)
        {
            base.AddDialog(messageBox);

            messageBox.TopLevel = false;
            messageBox.FormBorderStyle = FormBorderStyle.None;
            messageBox.Visible = true;
            messageBox.CloseOnClick = false;
            messageBox.Dock = DockStyle.Fill;

            pnStackDialog.Controls.Add(CreateContainerControl(messageBox));

//            panelFormContainer.Height = messageBox.Height + (int)panelFormContainer.RowStyles[0].Height +
            //panelFormContainer.Margin.Vertical + panelFormContainer.Padding.Vertical;

        }

        private List<Control> ResizeContainerControls { get; } = new List<Control>();

        /// <summary>
        /// Creates the container control for the dialog box to be added to the control.
        /// </summary>
        /// <param name="messageBox">The message box to add to the control.</param>
        /// <returns>The container control for the dialog box to be added to the control.</returns>
        protected override Control CreateContainerControl(MessageBoxBase messageBox)
        {
            TableLayoutPanel panelFormContainer = new TableLayoutPanel
            {
                RowCount = 3,
                ColumnCount = 3,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Top
            };

            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panelFormContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panelFormContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            panelFormContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            var pnCloseBox = new Panel
            {
                BackgroundImage = Properties.Resources.win10_close, BackgroundImageLayout = ImageLayout.Center,
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
                }
            };

            pnCloseBox.MouseLeave += delegate(object sender, EventArgs args)
            {
                ((Panel) sender).BackColor = DialogCloseButtonBackground;
                ((Panel) sender).BackgroundImage = CloseButtonImage;
            };

            panelFormContainer.Controls.Add(pnCloseBox, 2, 0);

            var label = new Label
            {
                Text = @" " + messageBox.Text, Parent = panelFormContainer, AutoSize = false, AutoEllipsis = true,
                Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft
            };

            panelFormContainer.Controls.Add(label, 0,  0);
            panelFormContainer.SetColumnSpan(label, 2);
            panelFormContainer.Controls.Add(messageBox, 0,  2);
            panelFormContainer.SetColumnSpan(messageBox, 3);
            return panelFormContainer;
        }

        private void pnStackDialog_Resize(object sender, EventArgs e)
        {
            foreach (var dialog in pnStackDialog.Controls)
            {
                ((Control) dialog).Width = pnStackDialog.ClientSize.Width;
                //dialog.Width = ClientSize.Width;
            }
        }
    }
}
