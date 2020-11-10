using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// A toggle button control to display stacked <see cref="MessageBoxExtended"/> instances.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class MessageBoxExpandStack : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxExpandStack"/> class.
        /// </summary>
        public MessageBoxExpandStack()
        {
            InitializeComponent();
            MessageBoxContainer = new Form {ControlBox = false, ShowInTaskbar = false, Size = new Size(650, 250), Parent = ParentForm};
            MessageBoxContainer.Controls.Add(MessageBoxContainerControl);
            MessageBoxContainer.Deactivate += messageBoxContainer_Deactivate;
            MessageBoxContainer.SizeChanged += messageBoxContainer_SizeChanged;
            MessageBoxContainerControl.MessageBoxClosed += messageBoxControlStackMain_MessageBoxClosed;
            MessageBoxContainerControl.DialogCountChanged = count =>
            {
                lbDialogCounter.Text = count.ToString();
            };
            MessageBoxContainerControl.MessageBoxClosed += messageBoxContainerControl_MessageBoxClosed;
            Disposed += messageBoxExpandStack_Disposed;
            lbText.Text = Name;
            base.BackColor = SystemColors.ControlDark;
            tlpMain.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Gets or sets the <see cref="Form"/> containing the <see cref="MessageBoxContainerToolset"/> message box container.
        /// </summary>
        /// <value>The message box container.</value>
        private Form MessageBoxContainer { get; }

        /// <summary>
        /// Gets or sets the size of the message box container size in case it was adjusted.
        /// </summary>
        /// <value>The size of the message box container size in case it was adjusted.</value>
        private Size ContainerSavedSize { get; set; }

        #region PublicMethods
        /// <summary>
        /// Scrolls the view to the top.
        /// </summary>
        public void ScrollToTop() => MessageBoxContainerControl.ScrollToTop();

        /// <inheritdoc cref="MessageBoxControlStack.AddDialog(MessageBoxBase,bool)"/>
        public void AddDialog(MessageBoxBase messageBox, bool minimized) => MessageBoxContainerControl.AddDialog(messageBox, minimized);

        /// <inheritdoc cref="MessageBoxControlStack.AddDialog(MessageBoxBase,bool,uint)"/>
        public void AddDialog(MessageBoxBase messageBox, bool minimized, uint priority) => MessageBoxContainerControl.AddDialog(messageBox, minimized, priority);
        #endregion

        #region PublicProperties
        /// <summary>
        /// Gets or sets the size of the form containing the message box container control.
        /// </summary>
        /// <value>The size of the form containing the message box container control.</value>
        [Description("he message box container control.")]
        [Category("The size of the form containing the message box container control.")]
        [Browsable(true)]
        public Size MessageBoxContainerControlExpandSize
        {
            get => MessageBoxContainer.Size;
            set => MessageBoxContainer.Size = value;
        }
        
        /// <summary>
        /// Gets or sets the message box container control.
        /// </summary>
        /// <value>The message box container control.</value>
        [Description("he message box container control.")]
        [Category("Controls")]
        [Browsable(true)]
        public MessageBoxContainerToolset MessageBoxContainerControl { get; set; } =
            new MessageBoxContainerToolset {Dock = DockStyle.Fill};

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <returns>The text associated with this control.</returns>
        [Description("The text associated with this control.")]
        [Category("Appearance")]
        [Browsable(true)]
        public override string Text
        {
            get => lbText.Text;

            set => lbText.Text = value;
        }

        /// <summary>
        /// Gets or sets the border color for the control.
        /// </summary>
        /// <value>A <see cref="T:System.Drawing.Color" /> that represents the border color of the control.</value>
        [Description("The border color for the control.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Color BorderColor
        {
            get => base.BackColor;

            set => base.BackColor = value;
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>A <see cref="T:System.Drawing.Color" /> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor" /> property.</value>
        [Description("The background color for the control.")]
        [Category("Appearance")]
        [Browsable(true)]
        public new Color BackColor
        {
            get => tlpMain.BackColor;

            set => tlpMain.BackColor = value;
        }

        private Color foreColor = SystemColors.ControlText;

        /// <summary>
        /// >Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The foreground <see cref="T:System.Drawing.Color" /> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColor" /> property.</value>
        [Description("The foreground color of the control.")]
        [Category("Appearance")]
        [Browsable(true)]
        public override Color ForeColor //{ get; set; }
        {
            get => foreColor;

            set
            {
                foreColor = value;
                tlpMain.ForeColor = value;
            }
        }

        private bool openDownWards;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog list should open downwards.
        /// </summary>
        /// <value><c>true</c> if the dialog list should open downwards; otherwise, <c>false</c>.</value>
        [Description("The value indicating whether the dialog list should open downwards.")]
        [Category("Behaviour")]
        [Browsable(true)]
        public bool OpenDownWards 
        { 
            get => openDownWards;
            set
            {
                openDownWards = value;
                pnToggleImage.BackgroundImage = OpenDownWards ? imageOpenDownwards : imageOpenUpwards;
            } 
        }

        private Image imageOpenDownwards = Properties.Resources.arrow_down;

        /// <summary>
        /// Gets or sets the image indicating that the dialog list is opening downwards.
        /// </summary>
        /// <value>The image indicating that the dialog list is opening downwards.</value>
        [Category("Appearance")]
        [Description("The image indicating that the dialog list is opening downwards.")]
        [Browsable(true)]
        public Image ImageOpenDownwards
        {
            get => imageOpenDownwards;

            set
            {
                imageOpenDownwards = value;
                pnToggleImage.BackgroundImage = OpenDownWards ? value : imageOpenDownwards;
            }
        }

        private Image imageOpenUpwards = Properties.Resources.arrow_up;

        /// <summary>
        /// Gets or sets the image indicating that the dialog list is opening upwards.
        /// </summary>
        /// <value>The image indicating that the dialog list is opening upwards.</value>
        [Category("Appearance")]
        [Description("The image indicating that the dialog list is opening upwards.")]
        [Browsable(true)]
        public Image ImageOpenUpwards
        {
            get => imageOpenUpwards;

            set
            {
                imageOpenUpwards = value;
                pnToggleImage.BackgroundImage = OpenDownWards ? imageOpenUpwards : value;
            }
        }

        /// <summary>
        ///Gets or sets the background color for the dialog counter label control.
        /// </summary>
        /// <value>The background color for the dialog counter label control.</value>
        [Category("Appearance")]
        [Description("The background color for the dialog counter label control.")]
        [Browsable(true)]        
        public Color LabelDialogCounterBackColor
        {
            get => lbDialogCounter.BackColor;

            set => lbDialogCounter.BackColor = value;
        }

        /// <summary>
        /// Gets or sets the foreground color of the dialog counter label control.
        /// </summary>
        /// <value>The foreground color of the dialog counter label control.</value>
        [Category("Appearance")]
        [Description("The foreground color of the dialog counter label control.")]
        [Browsable(true)]        
        public Color LabelDialogCounterForeColor
        {
            get => lbDialogCounter.ForeColor;

            set => lbDialogCounter.ForeColor = value;
        }

        /// <summary>
        /// Gets or sets the dialog counter label font.
        /// </summary>
        /// <value>The label dialog counter label font.</value>
        [Category("Appearance")]
        [Description("The label dialog counter label font.")]
        [Browsable(true)]        
        public Font LabelDialogCounterFont
        {
            get => lbDialogCounter.Font;

            set => lbDialogCounter.Font = value;
        }
        #endregion

        #region InternalEvents
        private bool NoSizeChange { get; set; }

        private DateTime LostFocusTime { get; set; }

        private bool HideDeactivate => (DateTime.Now - LostFocusTime).TotalSeconds < 0.2;

        private void messageBoxContainer_SizeChanged(object sender, EventArgs e)
        {
            if (NoSizeChange)
            {
                return;
            }

            var form = (Form) sender;
            ContainerSavedSize = form.Size;
        }

        private void messageBoxContainer_Deactivate(object sender, EventArgs e)
        {
            var form = (Form) sender;
            form.Hide();
            LostFocusTime = DateTime.Now;
        }

        private void messageBoxExpandStack_Disposed(object sender, EventArgs e)
        {
            MessageBoxContainer.SizeChanged -= messageBoxContainer_SizeChanged;
            MessageBoxContainer.Deactivate -= messageBoxContainer_Deactivate;
            MessageBoxContainerControl.MessageBoxClosed -= messageBoxControlStackMain_MessageBoxClosed;
            Disposed -= messageBoxExpandStack_Disposed;
        }

        private void pnToggleImage_Click(object sender, EventArgs e)
        {
            if (HideDeactivate)
            {
                return;
            }

            if (!MessageBoxContainer.Visible)
            {
                MessageBoxContainer.Visible = true;

                MessageBoxContainer.Size =
                    ContainerSavedSize == default ? MessageBoxContainer.Size : ContainerSavedSize;

                var point = Parent?.PointToScreen(Location) ?? PointToScreen(Location);


                if (OpenDownWards)
                {
                    var newPoint = new Point(point.X, point.Y + Height + MessageBoxContainer.Height);
                    if (newPoint.Y > Screen.FromPoint(newPoint).Bounds.Height) // size adjustment point..
                    {
                        NoSizeChange = true;
                        ContainerSavedSize = MessageBoxContainer.Size;
                        var difference = Screen.FromPoint(newPoint).Bounds.Height - newPoint.Y;
                        MessageBoxContainer.Height += difference;
                        NoSizeChange = false;
                    }

                    point.Y += Height;
                }
                else
                {
                    point.Y -= MessageBoxContainer.Height - SystemInformation.HorizontalResizeBorderThickness * 2;

                    if (point.Y < 0) // size adjustment point..
                    {
                        NoSizeChange = true;
                        ContainerSavedSize = MessageBoxContainer.Size;
                        MessageBoxContainer.Height += point.Y;
                        point.Y = 0;
                        NoSizeChange = false;
                    }
                }

                point.X -= SystemInformation.VerticalResizeBorderThickness * 2 - 1;

                //point.Y += MessageBoxContainer.Height - MessageBoxContainer.ClientSize.Height;

                MessageBoxContainer.Location = point; 
                    
                MessageBoxContainer.BringToFront();
                ScrollToTop();
            }
            else
            {
                MessageBoxContainer.Hide();
            }
        }

        private void messageBoxContainerControl_MessageBoxClosed(object sender, MessageBoxEventArgs e)
        {
            RaiseMessageBoxClosed(this, e);
            var count = MessageBoxContainerControl.DialogCount - 1;
            lbDialogCounter.Text = count.ToString();
        }
        #endregion

        #region PublicEvents
        /// <summary>
        /// Occurs when the message box is closed.
        /// </summary>
        public event MessageBoxControlBase.OnDialogBoxClosed MessageBoxClosed;

        /// <summary>
        /// Raises the <see cref="MessageBoxClosed"/> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MessageBoxEventArgs"/> instance containing the event data.</param>
        internal void RaiseMessageBoxClosed(object sender, MessageBoxEventArgs e)
        {
            MessageBoxClosed?.Invoke(sender, e);
        }

        private void messageBoxControlStackMain_MessageBoxClosed(object sender, MessageBoxEventArgs e)
        {
            lbDialogCounter.Text = MessageBoxContainerControl.DialogCount.ToString();
            var count = MessageBoxContainerControl.DialogCount - 1;
            lbDialogCounter.Text = count.ToString();
        }
        #endregion
    }
}
