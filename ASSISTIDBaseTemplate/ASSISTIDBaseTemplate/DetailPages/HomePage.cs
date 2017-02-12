/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace ASSISTIDBaseTemplate.DetailPages
{
    public class HomePage : ContentPage
    {
        private string PageTitle = "Application Template";

        /// <summary>
        /// Constructor
        /// </summary>
        public HomePage()
        {
            #region PageDefaults

            if (Device.OS == TargetPlatform.iOS)
            {
                Padding = new Thickness(0, 20, 0, 0);
            }

            NavigationPage.SetHasBackButton(this, false);

            Title = PageTitle;

            #endregion

            var licenseButton = new ToolbarItem
            {
                Text = "Licenses"
            };

            licenseButton.Clicked += LicenseButton_Clicked;

            ToolbarItems.Add(licenseButton);

            StackLayout stackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = 10
            };

            Label subtitle = new Label
            {
                Text = "The Application Template provides samples and models for controls and methods used often in the prototyping of mobile applications for research purposes.",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Margin = 10,
            };

            Label credits = new Label
            {
                Text = " • Xamarin Forms (MIT; display and framework)\r\n • NewtonSoft.Json (MIT; server communication)\r\n • SQLite-net (MIT; data persistence)\r\n • Forms.Checkbox (MIT; Lightweight checkbox control)\r\n",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(10, 0, 10, 10),
            };

            stackLayout.Children.Add(subtitle);
            stackLayout.Children.Add(credits);

            Content = new ScrollView
            {
                Content = stackLayout
            };
        }

        /// <summary>
        /// Show the embedded license file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LicenseButton_Clicked(object sender, System.EventArgs e)
        {
            var assembly = typeof(HomePage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("ASSISTIDBaseTemplate.Licenses.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            await DisplayAlert("Licenses", text, "Close");
        }
    }
}
