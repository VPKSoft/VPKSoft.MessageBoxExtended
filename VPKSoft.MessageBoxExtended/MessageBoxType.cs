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

namespace VPKSoft.MessageBoxExtended
{
    /// <summary>
    /// An enumeration for the <see cref="MessageBoxBase.MessageBoxType"/> property.
    /// See <seealso cref="MessageBoxIcon"/> enumeration.
    /// </summary>
    [Flags]
    public enum MessageBoxType
    {
        /// <summary>
        /// The message box type is undefined.
        /// </summary>
        /// See <seealso cref="MessageBoxIcon.None"/> enumeration value.
        Undefined = 0,

        /// <summary>
        /// The message box contains a symbol consisting of a lowercase letter i in a circle.
        /// See <seealso cref="MessageBoxIcon.Asterisk"/> or <seealso cref="MessageBoxIcon.Information"/> enumeration value.
        /// </summary>
        Information = 1,

        /// <summary>
        /// The message box contains a symbol consisting of a question mark in a circle or is type of <see cref="MessageBoxQueryPrimitiveValue{T}"/>.
        /// See <seealso cref="MessageBoxIcon.Question"/> enumeration value.
        /// </summary>
        Question = 2,

        /// <summary>
        /// The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.
        /// See <seealso cref="MessageBoxIcon.Warning"/> or <seealso cref="MessageBoxIcon.Exclamation"/> enumeration value.
        /// </summary>
        Warning = 4,

        /// <summary>
        /// The message box contains a symbol consisting of white X in a circle with a red background.
        /// See <seealso cref="MessageBoxIcon.Error"/> or <seealso cref="MessageBoxIcon.Stop"/> enumeration value.
        /// </summary>
        Error = 8,

        /// <summary>
        /// The message box is type of <see cref="MessageBoxQueryPassword"/>.
        /// </summary>
        QueryPassword = 1073741824, // Password is very sensitive information..
    }
}
