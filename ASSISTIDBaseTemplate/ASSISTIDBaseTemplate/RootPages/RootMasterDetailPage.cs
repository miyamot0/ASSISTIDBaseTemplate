/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using ASSISTIDBaseTemplate.DetailPages;
using System;
using Xamarin.Forms;

namespace ASSISTIDBaseTemplate.RootPages
{
    /// <summary>
    /// Root page for application
    /// </summary>
    public class RootMasterDetailPage : MasterDetailPage
    {
        private ListMasterPage masterPage;
        public ListMasterPage MasterPage
        {
            get
            {
                if (masterPage == null)
                {
                    masterPage = new ListMasterPage();
                }

                return masterPage;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public RootMasterDetailPage()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                Padding = new Thickness(0, 20, 0, 0);
            }

            Master = MasterPage;

            App.PageTypeShowing = typeof(HomePage);

            var titlePageNav = new NavigationPage(new HomePage());

            if (Device.OS == TargetPlatform.Android)
            {
                titlePageNav.BarTextColor = Color.White;
            }

            Detail = titlePageNav;

            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        /// <summary>
        /// On listview selection touched event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ListMasterPageItem;

            if (item != null)
            {
                if (App.PageTypeShowing != item.TargetType)
                {
                    App.PageTypeShowing = item.TargetType;

                    await Detail.Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetType));
                }

                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
