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
using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended.Controls.Enumerations
{
    /// <summary>
    /// An enumeration to indicate a button state to a simulated <see cref="Panel"/> button stored in the <see cref="Control.Tag"/> property.
    /// </summary>
    [Flags]
    public enum ControlButtonState
    {
        /// <summary>
        /// No specific state.
        /// </summary>
        None = 0,

        /// <summary>
        /// The mouse is hovering over the control.
        /// </summary>
        MouseHover = 1,

        /// <summary>
        /// The "button" state is expanded.
        /// </summary>
        Expanded = 2,

        /// <summary>
        /// The "button" state is minimized.
        /// </summary>
        Minimized = 4,
    }
}
