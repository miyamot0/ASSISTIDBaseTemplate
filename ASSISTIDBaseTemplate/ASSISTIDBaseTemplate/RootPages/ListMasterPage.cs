/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using ASSISTIDBaseTemplate.DetailPages;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ASSISTIDBaseTemplate.RootPages
{
    /// <summary>
    /// Side pane for application
    /// </summary>
    public class ListMasterPage : ContentPage
    {
        private ListView listView;
        public ListView ListView
        {
            get { return listView; }
        }

        private ObservableCollection<ListMasterPageItem> masterPageItems;

        /// <summary>
        /// Constructor
        /// </summary>
        public ListMasterPage()
        {
            masterPageItems = new ObservableCollection<ListMasterPageItem>();

            masterPageItems.Add(new ListMasterPageItem
            {
                Title = "Home",
                TargetType = typeof(HomePage),
                Color = "Gray"
            });

            masterPageItems.Add(new ListMasterPageItem
            {
                Title = "Data Entry Page",
                TargetType = typeof(EntryPage),
                Color = "Green"
            });

            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var stackLayoutTemplate = new StackLayout()
                    {
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Orientation = StackOrientation.Horizontal,
                        Margin = new Thickness(25, 5, 0, 5)
                    };

                    var mLabel = new Label
                    {
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        Margin = new Thickness(5, 0, 0, 0)
                    };

                    mLabel.SetBinding(Label.TextProperty, "Title");
                    mLabel.SetBinding(Label.TextColorProperty, "Color");

                    stackLayoutTemplate.Children.Add(mLabel);

                    return new ViewCell()
                    {
                        View = stackLayoutTemplate,
                    };

                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None,
            };

            StackLayout stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new Label
                    {
                        Text = "ApplicationTitle",
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        Margin = new Thickness(0, 20, 0, 0)
                    },
                    listView,
                },
            };

            Icon = "hamburger.png";
            Title = "Discounting Series";
            Content = stackLayout;
        }
    }
}
