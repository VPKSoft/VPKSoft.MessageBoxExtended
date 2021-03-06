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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using VPKSoft.MessageBoxExtended.Events;

namespace VPKSoft.MessageBoxExtended
{
    /// <summary>
    /// A message box to query a primitive, decimal, a generic <see cref="List{T}"/> or a string value from the user.
    /// Implements the <see cref="VPKSoft.MessageBoxExtended.MessageBoxBase" />
    /// </summary>
    /// <typeparam name="T">Type type of single value to query in the message box or the <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/></typeparam>
    /// <seealso cref="VPKSoft.MessageBoxExtended.MessageBoxBase" />
    public partial class MessageBoxQueryPrimitiveValue<T> : MessageBoxBase
    {
        #region ConstructorsPrimitive
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxQueryPrimitiveValue{T}"/> class.
        /// </summary>
        public MessageBoxQueryPrimitiveValue()
        {
            InitializeComponent();

            lbInvalidValidationText.Text = string.Empty;
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin, decimal upDownMax, 
            string checkBoxText, Action<DialogResultExtended, bool, object> dialogResultAction) : this()
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            // non-primitive type was requested..
            if (!typeof(T).IsPrimitive && typeof(T) != 
                typeof(string) && typeof(T) != 
                typeof(decimal) &&
                typeof(T) != typeof(DateTime)) 
            {
                throw new ArgumentException("The type to be queried must be a primitive type, a decimal, a DateTime or a string.");
            }

            DialogResultAction = dialogResultAction;

            InstancePrimitiveType = typeof(T);
            SetEditorByType(typeof(T), floatDecimals);

            if (typeof(T) == typeof(DateTime)) // something special with date and/or time..
            {
                dtpDateTimeValue.Format = dateTimeFormat;
                dtpDateTimeValue.CustomFormat = dateTimeFormatting;
            }

            SetButtons(CreateButtons(), useMnemonic);


            lbText.Text = text;
            base.Text = caption;
            pbMessageBoxIcon.Image = icon;


            cbBooleanValue.Text = checkBoxText;
            nudNumericValue.Minimum = upDownMin;
            nudNumericValue.Maximum = upDownMax == 0m ? 100m : upDownMax;

            SetValue(value);

            SuspendValidation = false;

            value = GetValue();

            MessageBoxType = MessageBoxType.Question;
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText) : this(text, caption, icon, useMnemonic, dateTimeFormatting, floatDecimals,
            dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText) : this(text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
            floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText, Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
            floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value) : this(text, caption, GetMessageBoxIcon(icon), true, dateTimeFormatting,
        0, dateTimeFormat, ref value, 0M, 100M, "", null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption,
            GetMessageBoxIcon(icon), true, dateTimeFormatting,
            0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, ref T value) : this(text, caption, GetMessageBoxIcon(icon), true, null,
            0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction) : this(
            text, caption, GetMessageBoxIcon(icon), true, null,
            0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value) : this(text, caption, icon, useMnemonic,
            dateTimeFormatting,
            0, dateTimeFormat, ref value, 0M, 100M, "", null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, icon, useMnemonic,
            dateTimeFormatting,
            0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax): this (text, caption, GetMessageBoxIcon(icon), true, null,
            floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption,
            GetMessageBoxIcon(icon), true, null,
            floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value) : this(text, caption, icon, true, dateTimeFormatting,
            0, dateTimeFormat, ref value, 0M, 100M, "", null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, icon, true, dateTimeFormatting,
            0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, ref T value) : this(text, caption, icon, true, null,
            0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, icon, true, null,
            0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax) : this(text, caption, icon, true, null,
            floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, input control, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, icon, true, null,
            floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, dialogResultAction)
        {
        }
        #endregion

        #region ConstructorsPrimitiveList
        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this()
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            // non-primitive type was requested..
            if (!IsGenericList(valuesList))
            {
                throw new ArgumentException("The type to be queried must be a generic List{TList}.");
            }

            DialogResultAction = dialogResultAction;

            InstancePrimitiveType = typeof(T);
            SetEditorByType(valuesList.GetType(), 0);

            SetButtons(buttons == MessageBoxButtonsExtended.OKCancel ? CreateButtons() : base.CreateButtons(buttons), useMnemonic);

            lbText.Text = text;
            base.Text = caption;
            pbMessageBoxIcon.Image = icon;

            cmbDropDownValue.Visible = true;
            FocusControl = cmbDropDownValue;

            foreach (var listValue in valuesList)
            {
                cmbDropDownValue.Items.Add(listValue);
            }

            cmbDropDownValue.DropDownStyle = dropDownStyle;

            cmbDropDownValue.AutoCompleteMode = autoCompleteMode;
            cmbDropDownValue.DisplayMember = displayMember ?? "";

            cmbDropDownValue.DropDownStyle = dropDownStyle;
            cmbDropDownValue.SelectedItem = value;

            SuspendValidation = false;

            MessageBoxType = MessageBoxType.Question;
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value) :
            this(text, caption, buttons, icon, useMnemonic, displayMember, dropDownStyle, autoCompleteMode, valuesList,
                ref value, null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value) :
            this(text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, buttons,
            GetMessageBoxIcon(icon), useMnemonic, displayMember,
            dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(
            string text, string caption, MessageBoxButtonsExtended buttons, MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value) :
            this(text, caption, buttons, GetMessageBoxIcon(icon), true, displayMember, dropDownStyle, autoCompleteMode,
                valuesList, ref value)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(
            string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, buttons,
            GetMessageBoxIcon(icon), true, displayMember,
            dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value) :
            this(text, caption, MessageBoxButtonsExtended.OKCancel, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) :
            this(text, caption, MessageBoxButtonsExtended.OKCancel, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption, MessageBoxButtonsExtended buttons, Image icon,
            string displayMember, ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList,
            ref T value) : this(text, caption, buttons, icon, true, displayMember, dropDownStyle, autoCompleteMode,
            valuesList, ref value, null)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) : this(text, caption, buttons, icon, true,
            displayMember,
            dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption, MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value) :
            this(text, caption, MessageBoxButtonsExtended.OKCancel, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value)
        {
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Initializes a generic message box message box with the specified type, items to select <see cref="ComboBox"/>, text, caption, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public MessageBoxQueryPrimitiveValue(string text, string caption,
            MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction) :
            this(text, caption, MessageBoxButtonsExtended.OKCancel, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction)
        {
        }
        #endregion

        #region ShowMethodsPrimitive
        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin, decimal upDownMax, 
            string checkBoxText,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            // non-primitive type was requested..
            if (!typeof(T).IsPrimitive && typeof(T) != 
                typeof(string) && typeof(T) != 
                typeof(decimal) &&
                typeof(T) != typeof(DateTime)) 
            {
                throw new ArgumentException("The type to be queried must be a primitive type, a decimal, a DateTime or a string.");
            }

            using (var messageBoxQuery = new MessageBoxQueryPrimitiveValue<T>(text, caption, icon, useMnemonic,
                dateTimeFormatting, floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, dialogResultAction))
            {
                messageBoxQuery.ShowDialog(owner ?? DefaultOwner);

                value = messageBoxQuery.GetValue();

                return messageBoxQuery.Result;
            }
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, ref T value)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(owner, text, caption, icon, useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(owner, text, caption, icon, true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, ref T value)
        {
            return Show(owner, text, caption, icon, true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax)
        {
            return Show(owner, text, caption, icon, true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText)
        {
            return Show(null, text, caption, icon, useMnemonic, dateTimeFormatting,
                floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, ref T value)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(null, text, caption, icon, useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value)
        {
            return Show(null, text, caption, icon, true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, ref T value)
        {
            return Show(null, text, caption, icon, true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax)
        {
            return Show(null, text, caption, icon, true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, GetMessageBoxIcon(icon), true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, icon, useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, icon, true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, icon, true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, icon, true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="checkBoxText">An optional text for a <see cref="CheckBox"/> in case of a boolean type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            int floatDecimals, DateTimePickerFormat dateTimeFormat, ref T value, decimal upDownMin,
            decimal upDownMax,
            string checkBoxText, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, icon, useMnemonic, dateTimeFormatting,
                floatDecimals, dateTimeFormat, ref value, upDownMin, upDownMax, checkBoxText, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Windows.Forms.MessageBoxIcon" /> values that specifies which icon to display in the message box.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, GetMessageBoxIcon(icon), true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, bool useMnemonic, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, icon, useMnemonic, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="dateTimeFormatting">An optional date and/or time formatting string in case a <see cref="DateTime"/> value is queried.</param>
        /// <param name="dateTimeFormat">A <see cref="DateTimePickerFormat"/> enumeration value in case a date and/or time is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, string dateTimeFormatting,
            DateTimePickerFormat dateTimeFormat, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, icon, true, dateTimeFormatting,
                0, dateTimeFormat, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, ref T value, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, icon, true, null,
                0, DateTimePickerFormat.Long, ref value, 0M, 100M, "", dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        /// <param name="value">A value of type of T the user entered if the dialog was accepted.</param>
        /// <param name="upDownMin">The minimum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="upDownMax">The maximum value of a see <see cref="NumericUpDown"/> control in case of a numeric type.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, int floatDecimals, ref T value, decimal upDownMin,
            decimal upDownMax, Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, icon, true, null,
                floatDecimals, DateTimePickerFormat.Long, ref value, upDownMin, upDownMax, null, dialogResultAction);
        }
        #endregion

        #region ShowMethodsGenericList
        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            if (LocalizeOnCreate)
            {
                Localize();
            }

            // non-primitive type was requested..
            if (!IsGenericList(valuesList)) 
            {
                throw new ArgumentException("The type to be queried must be a generic List{T}.");
            }

            using (var messageBoxQuery = new MessageBoxQueryPrimitiveValue<T>(text, caption, buttons, icon,
                useMnemonic, displayMember, dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction)) 
            {
                if (owner == null)
                {
                    messageBoxQuery.ShowDialog();
                }
                else
                {
                    messageBoxQuery.ShowDialog(owner);
                }

                value = (T)messageBoxQuery.cmbDropDownValue.SelectedItem;

                return messageBoxQuery.Result;
            }
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(owner, text, caption, MessageBoxButtonsExtended.OKCancel, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(owner, text, caption, buttons, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(owner, text, caption, MessageBoxButtonsExtended.OKCancel, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(null, text, caption, buttons, icon, useMnemonic, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(null, text, caption, MessageBoxButtonsExtended.OKCancel, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(null, text, caption, buttons, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value)
        {
            return Show(null, text, caption, MessageBoxButtonsExtended.OKCancel, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, null);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, buttons, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, MessageBoxButtonsExtended.OKCancel, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, buttons, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box in front of the specified object and with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(IWin32Window owner, string text, string caption,
            Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(owner, text, caption, MessageBoxButtonsExtended.OKCancel, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), useMnemonic, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="useMnemonic">A value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key for the buttons within the dialog.</param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, bool useMnemonic, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, icon, useMnemonic, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxIcon icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, MessageBoxButtonsExtended.OKCancel, GetMessageBoxIcon(icon), true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the <see cref="T:ScriptNotepad.DialogForms.MessageBoxButtonsExtended" /> values that specifies which buttons to display in the message box. </param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            MessageBoxButtonsExtended buttons, Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, buttons, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }

        // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
        /// <summary>
        /// Displays a generic message box with the specified text, caption, items to select <see cref="ComboBox"/>, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="icon">One of the <see cref="T:System.Drawing.Image" /> values that specifies which icon to display in the message box. </param>
        /// <param name="displayMember">The property to display in the <see cref="ComboBox"/> querying an item selection from the user in the dialog.</param>
        /// <param name="dropDownStyle">A value specifying the style of the combo box querying an item selection from the user.</param>
        /// <param name="autoCompleteMode">The option that controls how automatic completion works for the <see cref="ComboBox"/> in the dialog querying an item selection from the user in the dialog.</param>
        /// <param name="valuesList">A <see cref="List{T}"/> containing the values to display in the <see cref="ComboBox"/> in the dialog.</param>
        /// <param name="value">The value the user selected from the <see cref="ComboBox"/> by accepting the dialog.</param>
        /// <param name="dialogResultAction">A <see cref="Action{DialogResultExtended, Boolean, Object}"/> action to call upon returning from the dialog.</param>
        /// <returns>One of the <see cref="T:ScriptNotepad.DialogForms.DialogResultExtended" /> values.</returns>
        /// <exception cref="ArgumentException">The type to be queried must be a generic <see cref="List{T}"/>.</exception>
        // ReSharper disable once UnusedMember.Global (this is a class library)..
        public static DialogResultExtended Show(string text, string caption,
            Image icon, string displayMember,
            ComboBoxStyle dropDownStyle, AutoCompleteMode autoCompleteMode, List<T> valuesList, ref T value,
            Action<DialogResultExtended, bool, object> dialogResultAction)
        {
            return Show(null, text, caption, MessageBoxButtonsExtended.OKCancel, icon, true, displayMember,
                dropDownStyle, autoCompleteMode, valuesList, ref value, dialogResultAction);
        }
        #endregion

        #region GetSetValue
        /// <summary>
        /// Sets the value of a value editor control.
        /// </summary>
        /// <param name="value">The value to set to the editor control.</param>
        private void SetValue(T value)
        {
            if (typeof(T) == typeof(string))
            {
                tbStringValue.Text = value?.ToString();
            }

            if (typeof(T) == typeof(char))
            {
                tbStringValue.Text = value?.ToString();
            }

            if (typeof(T) == typeof(bool))
            {
                cbBooleanValue.Checked = (bool) Convert.ChangeType(value, typeof(T));
            }

            if (typeof(T) == typeof(DateTime))
            {
                if (value == null)
                {
                    dtpDateTimeValue.Value = DateTime.Now;
                }
                else
                {
                    dtpDateTimeValue.Value = (DateTime)Convert.ChangeType(value, typeof(T));
                }
            }

            if (IsGenericList(typeof(T)))
            {
                if (value != null)
                {
                    foreach (var listValue in (IList) value)
                    {
                        cmbDropDownValue.Items.Add(listValue);
                    }
                }
            }

            if (IsNumericType(typeof(T)))
            {
                var range = GetNumericTypeRange(typeof(T));
                nudNumericValue.Minimum = (decimal) range.min;
                nudNumericValue.Maximum = (decimal) range.max;
                nudNumericValue.Value = (decimal) Convert.ChangeType(value, typeof(T));
            }
        }

        /// <summary>
        /// Gets the value of an editor control.
        /// </summary>
        /// <returns>A value of type of T of an editor control.</returns>
        private T GetValue()
        {
            try
            {
                if (IsGenericList(typeof(T)))
                {
                    return (T) cmbDropDownValue.SelectedItem;
                }

                if (typeof(T) == typeof(string))
                {
                    return (T) Convert.ChangeType(tbStringValue.Text, typeof(T));
                }

                if (typeof(T) == typeof(char))
                {
                    if (!string.IsNullOrEmpty(tbStringValue.Text))
                    {
                        return (T) Convert.ChangeType(tbStringValue.Text[0], typeof(T));
                    }
                    return default;
                }

                if (typeof(T) == typeof(bool))
                {
                    return (T) Convert.ChangeType(cbBooleanValue.Checked, typeof(T));
                }

                if (typeof(T) == typeof(DateTime))
                {
                    return (T) Convert.ChangeType(dtpDateTimeValue.Value, typeof(T));
                }

                if (IsNumericType(typeof(T)))
                {
                    return (T) Convert.ChangeType(nudNumericValue.Value, typeof(T));
                }
            }
            catch (InvalidCastException ex)
            {
                if (SuspendInvalidCastException)
                {
                    ValidateTypeValue?.Invoke(this,
                        new TypeValueValidationEventArgs {Exception = ex, IsValid = false, Type = typeof(T)});
                }
                else
                {
                    throw;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the type of the editor by the type being queried.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="floatDecimals">A number of decimals in case a floating point value is queried.</param>
        private void SetEditorByType(Type type, int floatDecimals)
        {
            if (IsGenericList(type))
            {
                cmbDropDownValue.Visible = true;
                FocusControl = cmbDropDownValue;
                return;
            }

            var typeCode = TypeCodeDictionary[type];

            switch (typeCode)
            {
                case TypeCode.String: tbStringValue.Visible = true;
                    FocusControl = tbStringValue; return;

                case TypeCode.DateTime: dtpDateTimeValue.Visible = true;
                    FocusControl = dtpDateTimeValue; return;

                case TypeCode.Boolean: cbBooleanValue.Visible = true;
                    FocusControl = cbBooleanValue; return;

                case TypeCode.Char: tbStringValue.Visible = true;
                    FocusControl = tbStringValue;
                    tbStringValue.MaxLength = 1; return;
            }

            if (IsNumericType(type))
            {
                nudNumericValue.Visible = true;
                FocusControl = nudNumericValue;

                if (IsFloatingPoint(type))
                {
                    nudNumericValue.DecimalPlaces = floatDecimals;
                }
            }
        }
        #endregion

        #region PublicProperties
        /// <summary>
        /// Gets or sets a value indicating whether suspend the <see cref="InvalidCastException"/> and report it via the <see cref="ValidateTypeValue"/> event.
        /// </summary>
        // ReSharper disable once StaticMemberInGenericType (this class is only for the primitive types and primitive lists..)
        public static bool SuspendInvalidCastException { get; set; } = true;

        /// <summary>
        /// Gets or sets the type of the value being queried by this dialog.
        /// </summary>
        public Type InstancePrimitiveType { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to suspend raising <see cref="ValidateTypeValue"/> events.
        /// </summary>
        public bool SuspendValidation { get; set; } = true;
        #endregion

        #region PrivateProperties
        /// <summary>
        /// Gets or sets the editor control to be focused when the dialog is shown.
        /// </summary>
        private Control FocusControl { get; set; }
        #endregion

        #region Events
        /// <summary>
        /// A delegate for the <see cref="ValidateTypeValue"/> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TypeValueValidationEventArgs"/> instance containing the event data.</param>
        public delegate void OnValidateTypeValue(object sender, TypeValueValidationEventArgs e);

        /// <summary>
        /// Occurs when the user entered value is changed and the value might need validating.
        /// </summary>
        public static event OnValidateTypeValue ValidateTypeValue;        
        #endregion

        #region InternalEvents
        // focus to the visible control..
        private void MessageBoxQueryPrimitiveValue_Shown(object sender, EventArgs e)
        {
            FocusControl?.Focus();
        }

        // raise the ValidateTypeValue if subscribed..
        private void genericValue_Changed(object sender, EventArgs e)
        {
            // this will be executed if assigned ignoring other flags..
            DialogResultAction?.Invoke(DialogResultExtended.None, false,
                sender.Equals(cmbDropDownValue) ? cmbDropDownValue.SelectedItem : GetValueTypeParam());

            if (SuspendValidation) // before the "possible" value is set, "suspend" the event handler..
            {
                return;
            }

            var args = new TypeValueValidationEventArgs
            {
                IsValid = true,
                TypeValue = sender.Equals(cmbDropDownValue) ? cmbDropDownValue.SelectedItem : GetValueTypeParam(),
                Type = typeof(T),
                DropDownMode = sender.Equals(cmbDropDownValue),
            };

            ValidateTypeValue?.Invoke(this, args);
            OkButtonEnabled = args.IsValid;
            lbInvalidValidationText.Text = args.IsValid ? string.Empty : args.ValidationErrorMessage;
        }
        #endregion

        #region Miscallenous
        /// <summary>
        /// A work-around to call the <see cref="GetValue"/> method with a type.
        /// </summary>
        /// <returns>System.Object representing the value returned by the <see cref="GetValue"/> method call.</returns>
        private object GetValueTypeParam()
        {
            return GetType().GetMethod("GetValue", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.Invoke(this, new object[0]);
        }

        /// <summary>
        /// Creates the buttons for the dialog box with the given <see cref="MessageBoxBase"/> enumeration value.
        /// </summary>
        /// <returns>A List&lt;Button&gt;. <see cref="Button"/> class instances based on th given parameters.</returns>
        protected sealed override List<Button> CreateButtons()
        {
            AcceptButton = ButtonOk;
            CancelButton = ButtonCancel;
            return new List<Button> {ButtonOk, ButtonCancel};
        }
        #endregion

        #region Types        
        /// <summary>
        /// Determines whether the given object type is type of generic <see cref="List{T}"/>.
        /// </summary>
        /// <param name="value">The value which type to check for.</param>
        /// <returns><c>true</c> if the given object type is type of generic <see cref="List{T}"/>; otherwise, <c>false</c>.</returns>
        private static bool IsGenericList(object value)
        {
            return IsGenericList(value.GetType());
        }

        /// <summary>
        /// Determines whether given type is of type of generic <see cref="List{T}"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the given type is type of is of type of generic <see cref="List{T}"/>; otherwise, <c>false</c>.</returns>
        private static bool IsGenericList(Type type)
        {
            return type.IsGenericType &&
                   type.GetGenericTypeDefinition() == typeof(List<>);
        }

        /// <summary>
        /// A <see cref="Dictionary{TKey,TValue}"/> for possible <see cref="Type"/>-<see cref="TypeCode"/> pairs.
        /// </summary>
        // ReSharper disable once StaticMemberInGenericType (this class is only for the primitive types and primitive lists..)
        private static readonly Dictionary<Type, TypeCode> TypeCodeDictionary =
            new Dictionary<Type, TypeCode>
            {
                {typeof(bool), TypeCode.Boolean},
                {typeof(byte), TypeCode.Byte}, 
                {typeof(char), TypeCode.Char},
                {typeof(DateTime), TypeCode.DateTime},
                //{typeof(DBNull), TypeCode.DBNull}, Not this one..
                {typeof(decimal), TypeCode.Decimal}, 
                {typeof(double), TypeCode.Double},
                {typeof(short), TypeCode.Int16},
                {typeof(int), TypeCode.Int32},
                {typeof(long), TypeCode.Int64}, 
                //{typeof(object), TypeCode.Object}, Not this one..
                {typeof(sbyte), TypeCode.SByte}, 
                {typeof(float), TypeCode.Single}, 
                {typeof(string), TypeCode.String},
                {typeof(ushort), TypeCode.UInt16},
                {typeof(uint), TypeCode.UInt32},
                {typeof(ulong), TypeCode.UInt64},
            };

        /// <summary>
        /// Determines whether the given <see cref="Type"/> is a numeric primitive type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>True if the given type is a numeric primitive type, otherwise false;</returns>
        private bool IsNumericType(Type type)
        {
            return IsFloatingPoint(type) || IsSignedInteger(type) || IsUnsignedInteger(type);
        }
        
        /// <summary>
        /// Gets the primitive numeric type minimum to maximum value range.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.ValueTuple&lt;System.Double, System.Double&gt;.</returns>
        private static (double min, double max) GetNumericTypeRange(Type type)
        {
            var typeCode = TypeCodeDictionary[type];

            switch (typeCode)
            {
                case TypeCode.SByte: return (sbyte.MinValue, sbyte.MaxValue);
                case TypeCode.Byte: return (byte.MinValue, byte.MaxValue);
                case TypeCode.Int16: return (short.MinValue, short.MaxValue);
                case TypeCode.UInt16: return (ushort.MinValue, ushort.MaxValue);
                case TypeCode.Int32: return (int.MinValue, int.MaxValue);
                case TypeCode.UInt32: return (uint.MinValue, uint.MaxValue);
                case TypeCode.Int64: return (long.MinValue, long.MaxValue);
                case TypeCode.UInt64: return (ulong.MinValue, ulong.MaxValue);
                case TypeCode.Single: return (float.MinValue, float.MaxValue);

                // a double is too large for the NumericUpDown..
                case TypeCode.Double: return (decimal.ToDouble(DecimalDoubleMin), decimal.ToDouble(DecimalDoubleMax));

                // special case with decimal as the precision of a decimal is way larger than a double..
                case TypeCode.Decimal: return (decimal.ToDouble(DecimalDoubleMin), decimal.ToDouble(DecimalDoubleMax));
            }

            return default;
        }

        /// <summary>
        /// A <see cref="decimal"/> minimum value that can be converted to a double without the rounding causing an arithmetic overflow.
        /// </summary>
        private const decimal DecimalDoubleMin = -7922816251426430000000000000m;

        /// <summary>
        /// A <see cref="decimal"/> maximum value that can be converted to a double without the rounding causing an arithmetic overflow.
        /// </summary>
        private const decimal DecimalDoubleMax = 79228162514264330000000000000m;

        /// <summary>
        /// Determines whether the given <see cref="Type"/> is a signed integer type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>True if the given type is a signed integer type, otherwise false;</returns>
        private bool IsSignedInteger(Type type)
        {
            return (type == typeof(sbyte) ||
                    type == typeof(short) ||
                    type == typeof(int) ||
                    type == typeof(long));
        }

        /// <summary>
        /// Determines whether the given <see cref="Type"/> is an unsigned integer type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>True if the given type is an unsigned integer type, otherwise false;</returns>
        private bool IsUnsignedInteger(Type type)
        {
            return (type == typeof(byte) ||
                    type == typeof(ushort) ||
                    type == typeof(uint) ||
                    type == typeof(ulong));
        }

        /// <summary>
        /// Determines whether the given <see cref="Type"/> is a floating point or a decimal type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>True if the given type is a floating point or a decimal type, otherwise false;</returns>
        private bool IsFloatingPoint(Type type)
        {
            return (type == typeof(float) ||
                    type == typeof(double) ||
                    type == typeof(decimal));
        }
        #endregion
    }
}
