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
