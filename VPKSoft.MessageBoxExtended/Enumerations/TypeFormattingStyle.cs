namespace VPKSoft.MessageBoxExtended.Enumerations
{
    /// <summary>
    /// An enumeration representing the query types of the <see cref="MessageBoxQueryPrimitiveValue"/>.
    /// </summary>
    public enum TypeFormattingStyle
    {
        /// <summary>
        /// A string value is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        String,

        /// <summary>
        /// A non-culture specific time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        TimeInvariant,

        /// <summary>
        /// A non-culture specific date is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        DateInvariant,

        /// <summary>
        /// A non-culture specific date and time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        DateTimeInvariant,

        /// <summary>
        /// A culture specific time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        TimeCurrentCulture,

        /// <summary>
        /// A culture specific date is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        DateCurrentCulture,

        /// <summary>
        /// A culture specific date and time is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        DateTimeCurrentCulture,

        /// <summary>
        /// An integer is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        Integer,

        /// <summary>
        /// A floating point value (<c>float</c>, <c>double</c> or <c>decimal</c>) is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        FloatingPointInvariant,

        /// <summary>
        /// A culture specific formatted floating point value (<c>float</c>, <c>double</c> or <c>decimal</c>) is asked from the user via the <see cref="MessageBoxQueryPrimitiveValue"/> dialog box.
        /// </summary>
        FloatingPointCurrentCulture,
    }
}
