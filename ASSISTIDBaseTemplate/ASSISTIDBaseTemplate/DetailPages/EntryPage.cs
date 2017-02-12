/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using ASSISTIDBaseTemplate.Models;
using ASSISTIDBaseTemplate.Storage;
using Messier16.Forms.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ASSISTIDBaseTemplate.DetailPages
{
    public class EntryPage : ContentPage
    {
        private string PageTitle = "DataEntry Template";
        private Dictionary<string, bool> mResponses = new Dictionary<string, bool>();
        private DateTime md = DateTime.Now;
        private string mdStr = string.Empty;
        private List<DatabaseEntryModel> mEntry;
        private UserQuery mQueries = new UserQuery();
        private bool hasData = false;

        /// <summary>
        /// Constructor for entry page
        /// </summary>
        public EntryPage()
        {
            #region PageDefaults

            if (Device.OS == TargetPlatform.iOS)
            {
                Padding = new Thickness(0, 20, 0, 0);
            }

            NavigationPage.SetHasBackButton(this, false);

            Title = PageTitle;

            #endregion

            StackLayout stackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = 10
            };

            mdStr = md.ToString(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            mEntry = App.Database.GetItemsMatchingDateString(mdStr);

            if (mEntry.Count != 0)
            {
                mResponses = JsonConvert.DeserializeObject<Dictionary<string, bool>>(mEntry.FirstOrDefault().JsonData);

                hasData = true;
            }
            else
            {
                mResponses = new Dictionary<string, bool>();
            }

            for (int i=0; i<mQueries.Questions.Count; i++)
            {
                var mGrid = new Grid();

                mGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Auto)
                });

                mGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
                mGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
                mGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
                mGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });

                var mLabel = new Label()
                {
                    Text = mQueries.Questions[i]
                };

                mGrid.Children.Add(mLabel, 0, 0);
                Grid.SetColumnSpan(mLabel, 3);

                var mCheckBox = new Checkbox()
                {
                    Checked = false,
                    StyleId = i.ToString()
                };

                if (!hasData)
                {
                    mResponses.Add(i.ToString(), false);
                }
                else
                {
                    mCheckBox.Checked = mResponses[i.ToString()];
                }

                mCheckBox.PropertyChanged += MCheckBox_PropertyChanged;

                mGrid.Children.Add(mCheckBox, 3, 0);

                stackLayout.Children.Add(mGrid);
            }

            Content = new ScrollView
            {
                Content = stackLayout
            };
        }

        /// <summary>
        /// Override back button
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        /// <summary>
        /// Checked save event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MCheckBox_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Checked"))
            {
                var item = sender as Checkbox;

                if (item != null)
                {
                    var dictItem = mResponses.Where(d => d.Key == item.StyleId).FirstOrDefault();
                    mResponses[dictItem.Key] = item.Checked;

                    mEntry = App.Database.GetItemsMatchingDateString(mdStr);

                    if (mEntry.Count == 0)
                    {
                        var mSaveData = new DatabaseEntryModel();
                        mSaveData.DateString = mdStr;
                        mSaveData.JsonData = JsonConvert.SerializeObject(mResponses);

                        int result = await App.Database.SaveItemAsync(mSaveData);
                    }
                    else
                    {
                        var mSaveData = mEntry.FirstOrDefault();
                        mSaveData.JsonData = JsonConvert.SerializeObject(mResponses);

                        int result = await App.Database.SaveItemAsync(mSaveData);
                    }
                }
            }
        }
    }
}
