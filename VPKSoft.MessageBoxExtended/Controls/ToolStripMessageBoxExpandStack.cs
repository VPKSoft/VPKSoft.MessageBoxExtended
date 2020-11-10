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

using System.Windows.Forms;

namespace VPKSoft.MessageBoxExtended.Controls
{
    /// <summary>
    /// A class to add a <see cref="MessageBoxExpandStack"/> control to a <see cref="ToolStrip"/> or a <see cref="StatusStrip"/> control.
    /// Implements the <see cref="System.Windows.Forms.ToolStripControlHost" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripControlHost" />
    public class ToolStripMessageBoxExpandStack: ToolStripControlHost 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripMessageBoxExpandStack"/> class.
        /// </summary>
        public ToolStripMessageBoxExpandStack() : base(
            new MessageBoxExpandStack
            {
                Dock = DockStyle.Fill,
                AutoSize = false, Width = 200,
                Margin = new Padding(0),
                Padding = new Padding(1), 
                OpenDownWards = true
            })
        {
            MessageBoxExpandStack = (MessageBoxExpandStack) base.Control;
            AutoSize = false;
            Width = 200;
        }

        /// <summary>
        /// Gets or sets the inner <see cref="MessageBoxExpandStack"/> control.
        /// </summary>
        /// <value>The inner <see cref="MessageBoxExpandStack"/> control.</value>
        public MessageBoxExpandStack MessageBoxExpandStack { get; set; }
    }
}
