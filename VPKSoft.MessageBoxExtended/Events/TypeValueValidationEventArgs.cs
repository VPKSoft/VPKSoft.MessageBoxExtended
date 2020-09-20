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

namespace VPKSoft.MessageBoxExtended.Events
{
    /// <summary>
    /// Event arguments for the <see cref="MessageBoxQueryPrimitiveValue{T}.ValidateTypeValue"/> event.
    /// Implements the <see cref="System.EventArgs" />
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TypeValueValidationEventArgs: EventArgs
    {
        /// <summary>
        /// Gets or sets the value of the type.
        /// </summary>
        /// <value>The type value.</value>
        public object TypeValue { get; set; }

        /// <summary>
        /// Gets or sets the value whether the type value is valid.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the type of the <see cref="TypeValue"/> object.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="MessageBoxQueryPrimitiveValue{T}"/> instance is drop-down selection mode.
        /// </summary>
        public bool DropDownMode { get; set; }

        /// <summary>
        /// Gets or sets the validation error message.
        /// </summary>
        public string ValidationErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the exception if the user entered value can't be cast to the requested type.
        /// </summary>
        public InvalidCastException Exception { get; set; }
    }
}
