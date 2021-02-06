using Island.ru.kso.island.mssql.collection;
using Island.ru.kso.island.mssql.types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Island.ru.kso.island.pages.businessmanpage
{
    public sealed partial class BusinessmanPage : Page
    {
        private readonly ResourceLoader _resources;
        private ObservableCollection<Businessman> _businessmanList;
        
        public BusinessmanPage()
        {
            this.InitializeComponent();
            _resources = ResourceLoader.GetForCurrentView();
            _businessmanList = IslandCollection.GetInstance().GetBusinessmanList();
        }

        private void OnSurnameLoaded(object sender, RoutedEventArgs e)
        {
            _surname.Text = _resources.GetString("Surname");
        }

        private void OnNameLoaded(object sender, RoutedEventArgs e)
        {
            _name.Text = _resources.GetString("Name");
        }

        private void OnCraftNameLoaded(object sender, RoutedEventArgs e)
        {
            _craftName.Text = _resources.GetString("NameCraft");
        }

        private void OnDescriptionLoaded(object sender, RoutedEventArgs e)
        {
            _description.Text = _resources.GetString("CraftDescription");
        }

        private void OnWorkmansLoaded(object sender, RoutedEventArgs e)
        {
            _workmans.Text = _resources.GetString("Workmans");
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
