/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using ASSISTIDBaseTemplate.Interfaces;
using ASSISTIDBaseTemplate.RootPages;
using ASSISTIDBaseTemplate.Storage;
using System;
using Xamarin.Forms;

namespace ASSISTIDBaseTemplate
{
    /// <summary>
    /// Public and static handlers for application methods
    /// </summary>
    public class App : Application
    {
        private static ApplicationDatabase database;
        public static ApplicationDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ApplicationDatabase(DependencyService.Get<InterfaceFileHelper>().GetLocalFilePath("Database.db3"));
                }

                return database;
            }
        }

        private static RootMasterDetailPage rootPage;
        public static RootMasterDetailPage RootPage
        {
            get
            {
                if (rootPage == null)
                {
                    rootPage = new RootMasterDetailPage();
                }

                return rootPage;
            }
        }

        public static Type PageTypeShowing;

        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            MainPage = RootPage;
        }

        /// <summary>
        /// Blank lifestyle event
        /// </summary>
        protected override void OnStart() { }

        /// <summary>
        /// Blank lifestyle event
        /// </summary>
        protected override void OnSleep() { }

        /// <summary>
        /// Blank lifestyle event
        /// </summary>
        protected override void OnResume() { }
    }
}
