﻿#region License
/*
MIT License

Copyright(c) 2021 Petteri Kautonen

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
using System.Windows.Forms;
using VPKSoft.MessageBoxExtended.Controls.Interfaces;

namespace VPKSoft.MessageBoxExtended.Controls.Classes
{
    /// <summary>
    /// A container class for the dialog boxes within this control.
    /// Implements the <see cref="System.Windows.Forms.TableLayoutPanel" />
    /// Implements the <see cref="VPKSoft.MessageBoxExtended.Controls.Interfaces.IMessageBoxContainer" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TableLayoutPanel" />
    /// <seealso cref="VPKSoft.MessageBoxExtended.Controls.Interfaces.IMessageBoxContainer" />
    public class TableLayoutDialogBox : TableLayoutPanel, IMessageBoxContainer
    {
        /// <summary>
        /// Gets or sets the <see cref="MessageBox" /> or one of it's descendant class the container is holding.
        /// </summary>
        /// <value>The <see cref="MessageBox" /> or one of it's descendant class the container is holding.</value>
        public MessageBoxBase MessageBox { get; set; }

        /// <summary>
        /// Gets or sets the action to minimize/maximize the message box contained within the container.
        /// </summary>
        /// <value>The action to minimize/maximize the message box contained within the container.</value>
        public Action<bool> ToggleExpandAction { get; set; }

        /// <summary>
        /// Gets or sets the func to check if the message box is expanded for the <see cref="Expanded" /> property
        /// </summary>
        /// <value>The is expanded.</value>
        public Func<bool> IsExpanded { get; set; }

        /// <summary>
        /// Gets a value indicating whether the message box in this container is minimized.
        /// </summary>
        /// <value><c>true</c> if expanded the message box in this container is minimized; otherwise, <c>false</c>.</value>
        public bool Expanded => IsExpanded?.Invoke() == true;

        /// <summary>
        /// Gets or sets the close dialog action.
        /// </summary>
        /// <value>The close dialog action.</value>
        public Action<DialogResultExtended> CloseDialogAction { get; set; }
    }
}
