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

namespace VPKSoft.MessageBoxExtended.Controls.Interfaces
{
    /// <summary>
    /// An interface for <see cref="MessageBoxControlBase"/> and its descendant class message box instance sorting.
    /// </summary>
    /// <typeparam name="T">The type of the class returned by the methods.</typeparam>
    /// <typeparam name="TFuncInput">The type the sorting/ordering function takes.</typeparam>
    public interface IMessageBoxContainerOrdering<out T, out TFuncInput> where T: class where TFuncInput: class
    {
        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in ascending order by their creation time <see cref="MessageBoxBase.DialogCreated"/>.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByTime();

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in descending order by their creation time <see cref="MessageBoxBase.DialogCreated"/>.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByTimeDescending();

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in a specified order by their creation time <see cref="MessageBoxBase.DialogCreated"/>.
        /// </summary>
        /// <param name="descending">if set to <c>true</c> the items are ordered in descending order.</param>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByTime(bool descending);

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in ascending order by their priority <see cref="MessageBoxBase.Priority"/>.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByPriority();

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in descending order by their priority <see cref="MessageBoxBase.Priority"/>.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByPriorityDescending();

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in a specified order by their priority <see cref="MessageBoxBase.DialogCreated"/>.
        /// </summary>
        /// <param name="descending">if set to <c>true</c> the items are ordered in descending order.</param>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByPriority(bool descending);

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in ascending order by their type <see cref="MessageBoxBase.MessageBoxType"/>.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByType();

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in descending order by their type <see cref="MessageBoxBase.MessageBoxType"/>.
        /// </summary>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByTypeDescending();

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in a specified order by their type <see cref="MessageBoxBase.MessageBoxType"/>.
        /// </summary>
        /// <param name="descending">if set to <c>true</c> the items are ordered in descending order.</param>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderByType(bool descending);

        /// <summary>
        /// Sorts the <see cref="MessageBoxBase" /> instances of the sequence in either ascending or descending order by their sorting Func <see cref="Func{TFunc,TContainerMember}"/>.
        /// </summary>
        /// <typeparam name="TContainerMember">The type of the container member.</typeparam>
        /// <param name="descending">if set to <c>true</c> the <see cref="MessageBoxBase" /> instances are ordered in a descending order.</param>
        /// <param name="orderFunc">The ordering/sorting function.</param>
        /// <returns>An instance to a class implementing the <see cref="IMessageBoxContainerOrdering{T,TFuncInput}"/> instance whose elements are sorted according to the method call.</returns>
        T OrderBy<TContainerMember>(bool descending, Func<TFuncInput, TContainerMember> orderFunc);
    }
}
