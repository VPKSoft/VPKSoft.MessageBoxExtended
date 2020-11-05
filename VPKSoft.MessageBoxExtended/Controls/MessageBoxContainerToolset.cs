using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// A GUI control for the <see cref="MessageBoxControlStack"/> control.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class MessageBoxContainerToolset : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxContainerToolset"/> class.
        /// </summary>
        public MessageBoxContainerToolset()
        {
            InitializeComponent();

            // save the default sort order values to the button tags..
            tsbOrderByTime.Tag = default(SortOrder);
            tsbOrderByPriority.Tag = default(SortOrder);
            tsbOrderByType.Tag = default(SortOrder);

            PropertyChanged += messageBoxContainerStack_PropertyChanged;
            Disposed += messageBoxContainerStack_Disposed;
            messageBoxControlStackMain.MessageBoxClosed += messageBoxControlStackMain_MessageBoxClosed;
        }

        #region PublicMethods
        /// <summary>
        /// Gets the dialog count of the control.
        /// </summary>
        /// <value>The dialog count of the control.</value>
        [Browsable(false)]
        public int DialogCount => messageBoxControlStackMain.DialogCount;

        /// <summary>
        /// Gets or sets the action which is called when the dialog count is changed.
        /// </summary>
        /// <value>The action which is called when the dialog count is changed.</value>
        [Browsable(false)]
        public Action<int> DialogCountChanged
        {
            get => messageBoxControlStackMain.DialogCountChanged;

            set => messageBoxControlStackMain.DialogCountChanged = value;
        }

        /// <summary>
        /// Scrolls the view to the top.
        /// </summary>
        public void ScrollToTop() => messageBoxControlStackMain.ScrollToTop();

        /// <inheritdoc cref="MessageBoxControlStack.AddDialog(MessageBoxBase,bool)"/>
        public void AddDialog(MessageBoxBase messageBox, bool minimized) => messageBoxControlStackMain.AddDialog(messageBox, minimized);

        /// <inheritdoc cref="MessageBoxControlStack.AddDialog(MessageBoxBase,bool,uint)"/>
        public void AddDialog(MessageBoxBase messageBox, bool minimized, uint priority) => messageBoxControlStackMain.AddDialog(messageBox, minimized, priority);
        #endregion

        #region ToolStripProperties        
        /// <summary>
        /// Gets or sets the time sorting type.
        /// </summary>
        /// <value>The time sorting type.</value>
        [Description("Gets or sets the time sorting type.")]
        [Category("ToolStrip")]
        public SortOrder SortingTime { get; set; }

        /// <summary>
        /// Gets or sets the priority sorting type.
        /// </summary>
        /// <value>The priority sorting type.</value>
        [Description("Gets or sets the priority sorting type.")]
        [Category("ToolStrip")]
        public SortOrder SortingPriority { get; set; }

        /// <summary>
        /// Gets or sets the type sorting type.
        /// </summary>
        /// <value>The type sorting type.</value>
        [Description("Gets or sets the type sorting type.")]
        [Category("ToolStrip")]
        public SortOrder SortingType { get; set; }

        private Image imageSortingTypeNone = Properties.Resources.up_down_gray;

        /// <summary>
        /// Gets or sets the image for sorting type of none.
        /// </summary>
        /// <value>The image sorting type none.</value>
        [Description("Gets or sets the image for sorting type of none.")]
        [Category("ToolStrip")]
        public Image ImageSortingTypeNone
        {
            get => imageSortingTypeNone;

            set
            {
                if (value != imageSortingTypeNone)
                {
                    imageSortingTypeNone = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSortingTypeNone)));
                }
            }
        }

        private Image imageSortingTypeAscending = Properties.Resources.arrow_down;

        /// <summary>
        /// Gets or sets the image for sorting type of ascending.
        /// </summary>
        /// <value>The image sorting type none.</value>
        [Description("Gets or sets the image for sorting type of ascending.")]
        [Category("ToolStrip")]
        public Image ImageSortingTypeAscending
        {
            get => imageSortingTypeAscending;

            set
            {
                if (value != imageSortingTypeAscending)
                {
                    imageSortingTypeAscending = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSortingTypeAscending)));
                }
            }
        }        

        private Image imageSortingTypeDescending = Properties.Resources.arrow_up;

        /// <summary>
        /// Gets or sets the image for sorting type of descending.
        /// </summary>
        /// <value>The image sorting type none.</value>
        [Description("Gets or sets the image for sorting type of descending.")]
        [Category("ToolStrip")]
        public Image ImageSortingTypeDescending
        {
            get => imageSortingTypeDescending;

            set
            {
                if (value != imageSortingTypeDescending)
                {
                    imageSortingTypeDescending = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSortingTypeDescending)));
                }
            }
        }
        #endregion

        #region BehaviourProperties
        private bool resizable;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MessageBoxContainerToolset"/> is resizable.
        /// </summary>
        /// <value><c>true</c> if resizable; otherwise, <c>false</c>.</value>
        [Description("Gets or sets a value indicating whether this control is resizable.")]
        [Category("Behaviour")]
        public bool Resizable
        {
            get => resizable;
            set
            {
                if (value != resizable)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resizable)));
                    resizable = value;
                }
            }
        }
        #endregion

        #region AppearanceProperties
        /// <summary>
        /// Gets or sets the image for the toggle expand tool strip button.
        /// </summary>
        /// <value>The image for the toggle expand tool strip button.</value>
        [Description("The image for the toggle expand tool strip button.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Image ImageToolStripToggleExpand
        {
            get => tsbExpandCollapseDialogs.Image;
            set => tsbExpandCollapseDialogs.Image = value;
        }

        /// <summary>
        /// Gets or sets the image for the tool strip label indicating time based ordering.
        /// </summary>
        /// <value>The image for the tool strip label indicating time based ordering.</value>
        [Description("The image for the tool strip label indicating time based ordering.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Image ImageToolStripLabelOrderByTime
        {
            get => tslOrderByTime.Image;
            set => tslOrderByTime.Image = value;
        }

        /// <summary>
        /// Gets or sets the text tool strip label text indicating time based ordering.
        /// </summary>
        /// <value>The text tool strip label text indicating time based ordering.</value>
        [Description("The text tool strip label text indicating time based ordering.")]
        [Category("Appearance")]
        [Browsable(true)]
        public string TextToolStripLabelOrderByTime
        {
            get => tslOrderByTime.Text;
            set => tslOrderByTime.Text = value;
        }

        /// <summary>
        /// Gets or sets the image for the order by time tool strip button.
        /// </summary>
        /// <value>The image for the order by time tool strip button.</value>
        [Description("The image for the order by time tool strip button.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Image ImageToolStripOrderByTime
        {
            get => tsbOrderByTime.Image;
            set => tsbOrderByTime.Image = value;
        }

        /// <summary>
        /// Gets or sets the image for the tool strip label indicating priority based ordering.
        /// </summary>
        /// <value>The image for the tool strip label indicating priority based ordering.</value>
        [Description("The image for the tool strip label indicating priority based ordering.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Image ImageToolStripLabelOrderByPriority
        {
            get => tslOrderByPriority.Image;
            set => tslOrderByPriority.Image = value;
        }

        /// <summary>
        /// Gets or sets the text tool strip label text indicating priority based ordering.
        /// </summary>
        /// <value>The text tool strip label text indicating priority based ordering.</value>
        [Description("The text tool strip label text indicating priority based ordering.")]
        [Category("Appearance")]
        [Browsable(true)]
        public string TextToolStripLabelOrderByPriority
        {
            get => tslOrderByPriority.Text;
            set => tslOrderByPriority.Text = value;
        }

        /// <summary>
        /// Gets or sets the image for the order by priority tool strip button.
        /// </summary>
        /// <value>The image for the order by priority tool strip button.</value>
        [Description("The image for the order by priority tool strip button.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Image ImageToolStripOrderByPriority
        {
            get => tsbOrderByPriority.Image;
            set => tsbOrderByPriority.Image = value;
        }

        /// <summary>
        /// Gets or sets the image for the tool strip label indicating type based ordering.
        /// </summary>
        /// <value>The image for the tool strip label indicating type based ordering.</value>
        [Description("The image for the tool strip label indicating type based ordering.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Image ImageToolStripLabelOrderByType
        {
            get => tslOrderByType.Image;
            set => tslOrderByType.Image = value;
        }

        /// <summary>
        /// Gets or sets the text tool strip label text indicating type based ordering.
        /// </summary>
        /// <value>The text tool strip label text indicating type based ordering.</value>
        [Description("The text tool strip label text indicating type based ordering.")]
        [Category("Appearance")]
        [Browsable(true)]
        public string TextToolStripLabelOrderByType
        {
            get => tslOrderByType.Text;
            set => tslOrderByType.Text = value;
        }        

        /// <summary>
        /// Gets or sets the image for the order by priority tool strip button.
        /// </summary>
        /// <value>The image for the order by priority tool strip button.</value>
        [Description("The image for the order by priority tool strip button.")]
        [Category("Appearance")]
        [Browsable(true)]
        public Image ImageToolStripOrderByType
        {
            get => tsbOrderByType.Image;
            set => tsbOrderByTime.Image = value;
        }

        /// <summary>
        /// Gets the message box control stack containing the message box controls.
        /// </summary>
        /// <value>The message box control stack containing the message box controls.</value>
        [Description("The message box control stack containing the message box controls.")]
        [Category("Behaviour")]
        [Browsable(true)]
        public MessageBoxControlStack MessageBoxControlStack => messageBoxControlStackMain;
        #endregion

        #region PrivateMethods        
        /// <summary>
        /// Orders the dialogs within the <see cref="messageBoxControlStackMain"/> control based on the user selections.
        /// </summary>
        private void ApplyOrderBy()
        {
            var sorted = messageBoxControlStackMain;
            if (SortingTime != SortOrder.None)
            {
                sorted = sorted.OrderByTime(SortingTime == SortOrder.Descending);
            }

            if (SortingPriority != SortOrder.None)
            {
                sorted = sorted.OrderByPriority(SortingTime == SortOrder.Descending);
            }

            if (SortingType != SortOrder.None)
            {
                sorted.OrderByType(SortingTime == SortOrder.Descending);
            }
        }
        #endregion

        #region PropertyChanged
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private Image GetIconSortingType(SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.None:
                    return ImageSortingTypeNone;
                case SortOrder.Ascending:
                    return ImageSortingTypeAscending;
                case SortOrder.Descending:
                    return imageSortingTypeDescending;
                default:
                    return imageSortingTypeNone;
            }
        }

        private void ReAssignSortingIcons()
        {
            tsbOrderByTime.Image = GetIconSortingType(SortingTime);
            tsbOrderByPriority.Image = GetIconSortingType(SortingPriority);
            tsbOrderByType.Image = GetIconSortingType(SortingType);
        }

        private void messageBoxContainerStack_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(SortingTime) ||
                e.PropertyName == nameof(SortingPriority) ||
                e.PropertyName == nameof(SortingType))
            {
                tsbOrderByTime.Tag = SortingTime;
                tsbOrderByPriority.Tag = SortingPriority;
                tsbOrderByType.Tag = SortingType;

                ReAssignSortingIcons();

                ApplyOrderBy();
            }

            if (e.PropertyName == nameof(ImageSortingTypeNone) ||
                e.PropertyName == nameof(ImageSortingTypeAscending) ||
                e.PropertyName == nameof(ImageSortingTypeDescending))
            {
                ReAssignSortingIcons();
            }
        }

        private void messageBoxContainerStack_Disposed(object sender, EventArgs e)
        {
            PropertyChanged -= messageBoxContainerStack_PropertyChanged;
            Disposed -= messageBoxContainerStack_Disposed;
            messageBoxControlStackMain.MessageBoxClosed -= messageBoxControlStackMain_MessageBoxClosed;
        }
        #endregion

        #region InternalEvents
        private void tsbExpandCollapseDialogs_Click(object sender, EventArgs e)
        {
            messageBoxControlStackMain.ToggleExpandAll();
            ScrollToTop();
        }

        private void tsbOrderByTime_Click(object sender, EventArgs e)
        {
            var button = ((ToolStripButton) sender);

            var sorting = (SortOrder) button.Tag;
            if (sorting == SortOrder.None)
            {
                button.Tag = SortOrder.Ascending;
            }
            else if (sorting == SortOrder.Ascending)
            {
                button.Tag = SortOrder.Descending;
            }
            else if (sorting == SortOrder.Descending)
            {
                button.Tag = SortOrder.None;
            }

            if (button == tsbOrderByTime)
            {
                SortingTime = (SortOrder) button.Tag;
            }

            if (button == tsbOrderByPriority)
            {
                SortingPriority = (SortOrder) button.Tag;
            }

            if (button == tsbOrderByType)
            {
                SortingType = (SortOrder) button.Tag;
            }

            ReAssignSortingIcons();

            ApplyOrderBy();
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Gets the required creation parameters when the control handle is created.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams 
        {
            get 
            {
                if (!Resizable)
                {
                    return base.CreateParams;
                }

                var createParams = base.CreateParams;
                createParams.Style |= 0x00040000;  // WS_SIZEBOX..
                return createParams;
            }
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
            RaiseMessageBoxClosed(sender, e);
        }
        #endregion

    }
}
