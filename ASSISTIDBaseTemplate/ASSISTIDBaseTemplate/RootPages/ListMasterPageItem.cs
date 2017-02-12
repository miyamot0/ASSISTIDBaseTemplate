/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using System;

namespace ASSISTIDBaseTemplate.RootPages
{
    /// <summary>
    /// List page item
    /// </summary>
    public class ListMasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string Color { get; set; }
    }
}
