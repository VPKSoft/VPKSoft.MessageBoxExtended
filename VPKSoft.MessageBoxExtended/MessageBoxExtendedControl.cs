using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended
{
    /// <summary>
    /// A class to control open modal <see cref="MessageBoxBase"/> class instances.
    /// </summary>
    public class MessageBoxExtendedControl
    {
        /// <summary>
        /// Closes all <see cref="MessageBoxBase"/> class instances with the specified result.
        /// </summary>
        /// <param name="dialogResult">The dialog result to return upon close.</param>
        // ReSharper disable once UnusedMember.Global, A class library..
        public static void CloseAllBoxesWithResult(DialogResultExtended dialogResult)
        {
            for (int i = MessageBoxBase.MessageBoxInstances.Count - 1; i >= 0; i--)
            {
                MessageBoxBase.MessageBoxInstances[i].Result = dialogResult;
                MessageBoxBase.MessageBoxInstances[i].DialogResult = DialogResult.Cancel;
                MessageBoxBase.MessageBoxInstances[i].Close();
            }
        }
    }
}
