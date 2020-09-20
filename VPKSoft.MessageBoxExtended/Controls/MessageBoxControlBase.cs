using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// A base class for a control docking multiple <see cref="MessageBoxBase"/> instances into a control.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class MessageBoxControlBase : UserControl, IEnumerable<MessageBoxBase>, IEnumerator<MessageBoxBase>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxControlBase"/> class.
        /// </summary>
        protected MessageBoxControlBase()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateProperties
        /// <summary>
        /// Gets the message <see cref="MessageBoxBase"/> message boxes contained within this control.
        /// </summary>
        /// <value>The message boxes.</value>
        private List<MessageBoxBase> MessageBoxes { get; } = new List<MessageBoxBase>();
        #endregion

        #region ProtectedMethods
        /// <summary>
        /// Creates the container control for the dialog box to be added to the control.
        /// </summary>
        /// <param name="messageBox">The message box to add to the control.</param>
        /// <param name="minimized">A value indicating whether the message box should be minimized in the container control.</param>
        /// <returns>The container control for the dialog box to be added to the control.</returns>
        protected virtual Control CreateContainerControl(MessageBoxBase messageBox, bool minimized)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IEnum
        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>The element in the collection at the current position of the enumerator.</value>
        object IEnumerator.Current => Current;

        // ReSharper disable once InconsistentNaming
        private int location = -1;

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            location = -1;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns><see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (location + 1 < MessageBoxes.Count || location + 1 < MessageBoxes.Count - 1)
            {
                return false;
            }

            location++;

            return true;
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Adds the dialog to the control.
        /// </summary>
        /// <param name="messageBox">The dialog to add to the control.</param>
        /// <param name="minimized">A value indicated whether the message box should be added as minimized.</param>
        public virtual void AddDialog(MessageBoxBase messageBox, bool minimized)
        {
            MessageBoxes.Add(messageBox);
        }

        /// <summary>
        /// Removes the dialog to the control.
        /// </summary>
        /// <param name="messageBox">The dialog to remove from the control.</param>
        /// <returns><c>true</c> if <paramref name="messageBox"/> is successfully removed, <c>false</c> otherwise. This method also returns <c>false</c> if <paramref name="messageBox"/> was not found in the control's collection.</returns>
        public virtual bool RemoveDialog(MessageBoxBase messageBox)
        {
            return MessageBoxes.Remove(messageBox);
        }
        #endregion

        #region PublicProperties        
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<MessageBoxBase> GetEnumerator()
        {
            return MessageBoxes.GetEnumerator();
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>The current.</value>
        [Browsable(false)]
        public MessageBoxBase Current 
        {
            get
            {
                if (location < 0 || location + 1 > MessageBoxes.Count)
                {
                    return null;
                }

                return MessageBoxes[location];
            }
        }
        #endregion
    }
}
