/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;

namespace ASSISTIDBaseTemplate.Models
{
    /// <summary>
    /// Questions to be displayed to the user
    /// </summary>
    public class UserQuery
    {
        public List<string> Questions;

        /// <summary>
        /// Load list with the questions to be presented
        /// </summary>
        public UserQuery()
        {
            Questions = new List<string>();
            Questions.Add("Question One: ...");
            Questions.Add("Question Two: ...");
            Questions.Add("Question Three: ...");
            Questions.Add("Question Four: ...");
            Questions.Add("Question Five: ...");
            Questions.Add("Question Six: ...");
            Questions.Add("Question Seven: ...");
            Questions.Add("Question Eight: ...");
            Questions.Add("Question Nine: ...");
            Questions.Add("Question Ten: ...");
            Questions.Add("Question Eleven: ...");
            Questions.Add("Question Twelve: ...");
            Questions.Add("Question Thirteen: ...");
            Questions.Add("Question Fourteen: ...");
            Questions.Add("Question Fifteen: ...");
        }
    }
}
