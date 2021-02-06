using Island.ru.kso.island.pages.businessmanpage;
using Island.ru.kso.island.pages.homelesspage;
using Island.ru.kso.island.pages.housepage;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Island.ru.kso.island.pages.parent
{
    public sealed partial class ParentPage : Page
    {
        private delegate void OnItemTapped();
        private List<(string Tag, OnItemTapped OnTapped)> _tapList = new List<(string tag, OnItemTapped onTapped)>();
        private readonly ResourceLoader _resources;

        public ParentPage()
        {
            this.InitializeComponent();
            _resources = ResourceLoader.GetForCurrentView();
        }

        private void OnHouseItemTapped()
        {
            Content.Navigate(typeof(HousePage));
        }

        private void OnBusinessmanItemTapped()
        {
            Content.Navigate(typeof(BusinessmanPage));
        }

        private void OnHomelessItemTapped()
        {
            Content.Navigate(typeof(HomelessPage));
        }

        private void OnNavigatorLoaded(object sender, RoutedEventArgs e)
        {
            IList<object> items = _navigator.MenuItems;
            NavigationViewItem homelessItem = (items[0] as NavigationViewItem);
            NavigationViewItem houseItem = (items[1] as NavigationViewItem);
            NavigationViewItem businessmanItem = (items[2] as NavigationViewItem);
            homelessItem.Content = _resources.GetString("HomelessNavItem");
            houseItem.Content = _resources.GetString("HouseNavItem");
            businessmanItem.Content = _resources.GetString("BusinessmanNavItem");
            _tapList.Add((homelessItem.Tag.ToString(), OnHomelessItemTapped));
            _tapList.Add((houseItem.Tag.ToString(), OnHouseItemTapped));
            _tapList.Add((businessmanItem.Tag.ToString(), OnBusinessmanItemTapped));
            _navigator.SelectedItem = homelessItem;
        }

        private void OnNavigatorSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            OnItemTapped onTapped = _tapList.Find(tapItem => tapItem.Tag == item.Tag.ToString()).OnTapped;
            onTapped();
        }
    }
}
