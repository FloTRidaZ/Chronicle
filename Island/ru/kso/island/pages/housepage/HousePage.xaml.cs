using Island.ru.kso.island.dialog.areadialog;
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


namespace Island.ru.kso.island.pages.housepage
{
    public sealed partial class HousePage : Page
    {
        private readonly ResourceLoader _resources;
        private ObservableCollection<House> _houseList;

        public HousePage()
        {
            this.InitializeComponent();
            _resources = ResourceLoader.GetForCurrentView();
            _houseList = IslandCollection.GetInstance().GetHouseList();
        }

        private void OnAdressLoaded(object sender, RoutedEventArgs e)
        {
            _adress.Text = _resources.GetString("Adress");
        }

        private void OnBuildDateLoaded(object sender, RoutedEventArgs e)
        {
            _buildDate.Text = _resources.GetString("BuildDate");
        }

        private void OnDestroyDateLoaded(object sender, RoutedEventArgs e)
        {
            _destroyDate.Text = _resources.GetString("DestroyDate");
        }

        private void OnAreaLoaded(object sender, RoutedEventArgs e)
        {
            _area.Text = _resources.GetString("Area");
        }

        private async void OnReareaItemClick(object sender, RoutedEventArgs e)
        {
            await new UpdateAreaDialog(_houseListView.SelectedItem as House).ShowAsync();
        }

        private void OnHouseListRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (((FrameworkElement) e.OriginalSource).DataContext is House selectedItem)
            {
                _houseListView.SelectedItem = selectedItem;
            }
        }
    }
}
