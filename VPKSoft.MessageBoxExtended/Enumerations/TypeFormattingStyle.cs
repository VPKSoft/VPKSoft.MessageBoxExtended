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

namespace VPKSoft.MessageBoxExtended.Enumerations
{
    /// <summary>
    /// An enumeration representing the query types of the <see cref="MessageBoxQueryPrimitiveValue{T}"/>.
    /// </summary>
    public enum TypeFormattingStyle
    {
        /// <summary>
        /// A string value is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        String,

        /// <summary>
        /// A non-culture specific time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        TimeInvariant,

        /// <summary>
        /// A non-culture specific date is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        DateInvariant,

        /// <summary>
        /// A non-culture specific date and time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        DateTimeInvariant,

        /// <summary>
        /// A culture specific time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        TimeCurrentCulture,

        /// <summary>
        /// A culture specific date is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        DateCurrentCulture,

        /// <summary>
        /// A culture specific date and time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        DateTimeCurrentCulture,

        /// <summary>
        /// An integer is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        Integer,

        /// <summary>
        /// A floating point value (<c>float</c>, <c>double</c> or <c>decimal</c>) is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        FloatingPointInvariant,

        /// <summary>
        /// A culture specific formatted floating point value (<c>float</c>, <c>double</c> or <c>decimal</c>) is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue{T}"/> dialog box.
        /// </summary>
        FloatingPointCurrentCulture,
    }
}
