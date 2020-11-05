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

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// A class for the events used in <see cref="MessageBoxBase"/> and their descendant container controls.
    /// Implements the <see cref="System.EventArgs" />
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MessageBoxEventArgs: EventArgs
    {
        /// <summary>
        /// Gets or sets the message box.
        /// </summary>
        /// <value>The message box.</value>
        public MessageBoxBase MessageBox { get; set; }

        /// <summary>
        /// Gets or sets the dialog result of the <see cref="MessageBox"/> instance.
        /// </summary>
        /// <value>The dialog result of the <see cref="MessageBox"/> instance.</value>
        public DialogResultExtended DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the data if some additional data was passed to the <see cref="MessageBoxBase"/> or one of its descendants.
        /// </summary>
        /// <value>The data if some additional data was passed to the <see cref="MessageBoxBase"/> or one of its descendants.</value>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user selected the <see cref="MessageBoxBase"/> dialog instance to remember the given answer.
        /// </summary>
        /// <value><c>true</c> if the user selected the <see cref="MessageBoxBase"/> dialog instance to remember the given answer; otherwise, <c>false</c>.</value>
        public bool RememberAnswer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow the message box to close after the event is handled.
        /// </summary>
        /// <value><c>true</c> if to allow the message box to close after the event is handled; otherwise, <c>false</c>.</value>
        public bool AllowMessageBoxClose { get; set; }

        /// <summary>
        /// Gets the message box identifier.
        /// </summary>
        /// <value>The message box identifier.</value>
        public ulong MessageBoxId { get; internal set; }
    }
}
