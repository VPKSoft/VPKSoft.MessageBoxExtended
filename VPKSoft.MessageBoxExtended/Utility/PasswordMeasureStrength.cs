#region License
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VPKSoft.MessageBoxExtended.Utility
{
    /// <summary>
    /// A class for analyzing a password and giving it a strength score.
    /// </summary>
    public class PasswordMeasureStrength
    {
        /// <summary>
        /// The standard deviation limit of the character values to add one point.
        /// </summary>
        public static double StandardDeviationLimit { get; set; } = 17;

        /// <summary>
        /// Gets or sets the minimum length of a good password.
        /// </summary>
        public static int GoodPasswordLength { get; set; } = 10;

        /// <summary>
        /// Gets or sets the evaluator functions to add to the <see cref="PasswordStrength"/> method's result.
        /// The <see cref="Func{T1,TResult}"/> must return a value between zero to one; larger values are ignored. I.e. "new Func&lt;string, double&gt;(delegate(string s) { return s.ToUpper() != s ? 1 : 0; });".
        /// </summary>
        public static List<Func<string, double>> EvaluatorFunctions { get; set; } = new List<Func<string, double>>();

        /// <summary>
        /// Calculates the standards the deviation for the password by converting the characters to double floating point values.
        /// </summary>
        /// <param name="password">The password to be used for the calculation.</param>
        /// <returns>A value given as points for the given password for this from this comparison.</returns>
        public  static double StandardDeviation(string password)
        {
            if (password.Length == 0)
            {
                return 0;
            }

            var mean = password.Sum(c => (double) c);

            mean /= password.Length;

            var dev = 0.0;

            foreach (var c in password)
            {
                dev += Math.Pow(c - mean, 2);
            }

            dev /= password.Length;

            return Math.Sqrt(dev);
        }

        /// <summary>
        /// Compares the password converted to ASCII versus the UTF8 encoding character bytes 
        /// </summary>
        /// <param name="password">The password which ASCII and UTF8 bytes to compare.</param>
        /// <returns>A value given as points for the given password for this from this comparison.</returns>
        private static double AsciiMatchScore(string password)
        {
            var bytes1 = Encoding.ASCII.GetBytes(password);
            var bytes2 = Encoding.UTF8.GetBytes(password);

            return bytes1.Length != bytes2.Length ? 1 : 0;
        }

        /// <summary>
        /// Calculates the strength of a given password.
        /// </summary>
        /// <param name="password">The password to analyze.</param>
        /// <returns>A double between 0 to 10 indicating the strength of the password.</returns>
        public static double PasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return 0;
            }

            var score = 0.0;
            var scoreMax = 0.0;

            scoreMax++;
            if (StandardDeviation(password) > StandardDeviationLimit) // max 1 points..
            {
                score++;
            }

            scoreMax++;
            score += AsciiMatchScore(password); // max 2 points..

            scoreMax++;
            if (Regex.IsMatch(password, "[a-z]")) // max 3 points..
            {
                score++;
            }

            scoreMax++;
            if (Regex.IsMatch(password, "[A-Z]")) // max 4 points..
            {
                score++;
            }

            scoreMax++;
            if (Regex.IsMatch(password, "[0-9]")) // max 5 points..
            {
                score++;
            }

            scoreMax++;
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) // max 6 points..
            {
                score++;
            }

            scoreMax++;
            if (password.Length >= GoodPasswordLength) // max 7 points..
            {
                score++;
            }

            // run the evaluator functions..
            foreach (var evaluatorFunction in EvaluatorFunctions)
            {
                var evaluationValue = evaluatorFunction(password);
                if (evaluationValue > 1) // invalid function returning a larger number than one..
                {
                    score++;
                }
                else if (evaluationValue > 0) // a valid function returning 0 to 1 value..
                {
                    score += evaluationValue;
                }
                else if (evaluationValue < 0) // invalid function returning lesser than a zero value..
                {
                    continue;
                }

                scoreMax++; // max n points..
            }

            return score * 10 / scoreMax; // a value between 0 to 10..
        }
    }
}
