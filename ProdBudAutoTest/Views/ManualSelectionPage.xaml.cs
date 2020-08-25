using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ProdBudAutoTest.Views
{
    public partial class ManualSelectionPage : ContentPage
    {
        public ManualSelectionPage()
        {
            InitializeComponent();
            modelListView.ItemsSource = ModelList;
            subModelListView.ItemsSource = SubModelList;
            modelYearListView.ItemsSource = ModelYearList;
        }


        List<string> ModelList = new List<string>
            {
               "Model 1", "Model 2", "Model 3", "Model 4", "Model 5", "Model 6",
            };
        List<string> SubModelList = new List<string>
            {
                "Sub Model 1","Sub Model 2","Sub Model 3","Sub Model 4","Sub Model 5","Sub Model 6",
            };
        List<string> ModelYearList = new List<string>
            {
                "Year 1","Year 2","Year 3","Year 4","Year 5","Year 6"
            };



        private void modelSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var btn = sender as SearchBar;
            var param = btn.SearchCommandParameter;
            switch (param)
            {
                case "Model":
                    modelListView.IsVisible = true;
                    subModelListView.IsVisible = false;
                    modelYearListView.IsVisible = false;
                    break;
                case "SubModel":
                    modelListView.IsVisible = false;
                    subModelListView.IsVisible = true;
                    modelYearListView.IsVisible = false;
                    break;
                case "Year":
                    modelListView.IsVisible = false;
                    subModelListView.IsVisible = false;
                    modelYearListView.IsVisible = true;
                    break;
            }
            var modelKeyword = modelSearchBar.Text;
            var subModelKeyword = subModelSearchBar.Text;
            var modelYearKeyword = mdelYearSearchBar.Text;

            modelListView.ItemsSource = ModelList.Where(name => name.ToLower().Contains(modelKeyword.ToLower()));
            subModelListView.ItemsSource = SubModelList.Where(name => name.ToLower().Contains(subModelKeyword.ToLower()));
            modelYearListView.ItemsSource = ModelYearList.Where(name => name.ToLower().Contains(modelYearKeyword.ToLower()));
        }

        private void modelSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                var btn = sender as SearchBar;
                var param = btn.SearchCommandParameter;
                switch (param)
                {
                    case "Model":
                        modelListView.IsVisible = true;
                        subModelListView.IsVisible = false;
                        modelYearListView.IsVisible = false;

                        var modelKeyword = modelSearchBar.Text;
                        modelListView.ItemsSource = ModelList.Where(name => name.ToLower().Contains(modelKeyword.ToLower()));

                        break;
                    case "SubModel":
                        modelListView.IsVisible = false;
                        subModelListView.IsVisible = true;
                        modelYearListView.IsVisible = false;

                        var subModelKeyword = subModelSearchBar.Text;
                        subModelListView.ItemsSource = SubModelList.Where(name => name.ToLower().Contains(subModelKeyword.ToLower()));
                        break;
                    case "Year":
                        modelListView.IsVisible = false;
                        subModelListView.IsVisible = false;
                        modelYearListView.IsVisible = true;

                        var modelYearKeyword = mdelYearSearchBar.Text;
                        modelYearListView.ItemsSource = ModelYearList.Where(name => name.ToLower().Contains(modelYearKeyword.ToLower()));
                        break;
                }
            }
            else
            {
                modelListView.IsVisible = false;
                subModelListView.IsVisible = false;
                modelYearListView.IsVisible = false;
            }
        }

        private void modelListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            modelListView.IsVisible = false;
            subModelListView.IsVisible = false;
            modelYearListView.IsVisible = false;
        }
    }
}