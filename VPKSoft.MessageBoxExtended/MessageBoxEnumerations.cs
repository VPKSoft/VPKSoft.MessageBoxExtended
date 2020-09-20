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

using System.Runtime.InteropServices;

namespace VPKSoft.MessageBoxExtended
{
    // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
    /// <summary>
    /// An enumeration for the Show(..) method return values.
    /// </summary>
    [ComVisible(true)]
    public enum DialogResultExtended
    {
        /// <summary>
        /// <see langword="Nothing" /> is returned from the dialog box.
        /// This means that the modal dialog continues running.
        /// </summary>
        None,

        /// <summary>
        /// The dialog box return value is <see langword="OK" /> (usually sent from a button labeled OK).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        OK,

        /// <summary>
        /// The dialog box return value is <see langword="Cancel" /> (usually sent from a button labeled Cancel).
        /// </summary>
        Cancel,

        /// <summary>
        /// The dialog box return value is <see langword="Abort" /> (usually sent from a button labeled Abort).
        /// </summary>
        Abort,

        /// <summary>
        /// The dialog box return value is <see langword="Retry" /> (usually sent from a button labeled Retry).
        /// </summary>
        Retry,

        /// <summary>
        /// The dialog box return value is <see langword="Ignore" /> (usually sent from a button labeled Ignore).
        /// </summary>
        Ignore,

        /// <summary>
        /// The dialog box return value is <see langword="Yes" /> (usually sent from a button labeled Yes).
        /// </summary>
        Yes,
        /// <summary>
        /// The dialog box return value is <see langword="No" /> (usually sent from a button labeled No).
        /// </summary>
        No,

        /// <summary>
        /// The dialog box return value is <see langword="YesToAll" /> (usually sent from a button labeled YesToAll).
        /// </summary>
        YesToAll,

        /// <summary>
        /// The dialog box return value is <see langword="YesToAllRemember" /> (usually sent from a button labeled YesToAll) with the remember check box checked.
        /// </summary>
        YesToAllRemember,

        /// <summary>
        /// The dialog box return value is <see langword="NoToAll" /> (usually sent from a button labeled NoToAll).
        /// </summary>
        NoToAll,

        /// <summary>
        /// The dialog box return value is <see langword="NoToAll" /> (usually sent from a button labeled NoToAll) with the remember check box checked.
        /// </summary>
        NoToAllRemember,
    }

    // Documentation: (©): Microsoft (copy/paste) documentation with modifications (by VPKSoft)....
    /// <summary>
    /// An enumeration for the buttons for the dialog boxes used contained within the library.
    /// </summary>
    public enum MessageBoxButtonsExtended
    {
        /// <summary>
        /// The message box contains an OK button.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        OK,

        /// <summary>
        /// The message box contains OK and Cancel buttons.
        /// </summary>
        /// 
        // ReSharper disable once InconsistentNaming
        OKCancel,

        /// <summary>
        /// The message box contains Abort, Retry, and Ignore buttons.
        /// </summary>
        AbortRetryIgnore,

        /// <summary>
        /// The message box contains Yes, No, and Cancel buttons.
        /// </summary>
        YesNoCancel,

        /// <summary>
        /// The message box contains Yes and No buttons.
        /// </summary>
        YesNo,

        /// <summary>
        /// The message box contains Retry and Cancel buttons.
        /// </summary>
        RetryCancel,

        /// <summary>
        /// The message box contains Yes, No and Yes to all buttons.
        /// </summary>
        YesNoYesToAll,

        /// <summary>
        /// The message box contains Yes, No and Yes to all (with remember choice check box unchecked) buttons.
        /// </summary>
        YesNoYesToAllRemember,

        /// <summary>
        /// The message box contains Yes, No and Yes to all (with remember choice check box checked) buttons.
        /// </summary>
        YesNoYesToAllRememberChecked,

        /// <summary>
        /// The message box contains Yes, No, Yes to all and No to all buttons.
        /// </summary>
        YesNoYesToAllNoToAll,

        /// <summary>
        /// The message box contains Yes, No, Yes to all and No to all (with remember choice check box unchecked) buttons.
        /// </summary>
        YesNoYesToAllRememberNoToAllRemember,

        /// <summary>
        /// The message box contains Yes, No, Yes to all and No to all (with remember choice check box checked) buttons.
        /// </summary>
        YesNoYesToAllNoToAllRememberChecked,

        /// <summary>
        /// The message box contains Yes, No and No to all buttons.
        /// </summary>
        YesNoNoToAll,

        /// <summary>
        /// The message box contains Yes, No and No to all (with remember choice check box unchecked) buttons.
        /// </summary>
        YesNoNoToAllRemember,

        /// <summary>
        /// The message box contains Yes, No and No to all (with remember choice check box checked) buttons.
        /// </summary>
        YesNoNoToAllRememberChecked,
    }
}
