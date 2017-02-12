/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using SQLite;

namespace ASSISTIDBaseTemplate.Storage
{
    /// <summary>
    /// Model for daily data collection parameters
    /// </summary>
    public class DatabaseEntryModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string DateString { get; set; }
        public string JsonData { get; set; }

        // ... modify to suit
    }
}
