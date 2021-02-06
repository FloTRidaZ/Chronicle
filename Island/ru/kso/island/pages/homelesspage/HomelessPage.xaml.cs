using Island.ru.kso.island.dialog.settling;
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

namespace Island.ru.kso.island.pages.homelesspage
{
    public sealed partial class HomelessPage : Page
    {
        private readonly ResourceLoader _resources;
        private ObservableCollection<Homeless> _homelesses;

        public HomelessPage()
        {
            this.InitializeComponent();
            _homelesses = IslandCollection.GetInstance().GetHomelessList();
            _resources = ResourceLoader.GetForCurrentView();
        }

        private void OnNameLoaded(object sender, RoutedEventArgs e)
        {
            _name.Text = _resources.GetString("Name");
        }

        private void OnSurnameLoaded(object sender, RoutedEventArgs e)
        {
            _surname.Text = _resources.GetString("Surname");
        }

        private void OnSexLoaded(object sender, RoutedEventArgs e)
        {
            _sex.Text = _resources.GetString("Sex");
        }

        private void OnBirthdayLoaded(object sender, RoutedEventArgs e)
        {
            _birthday.Text = _resources.GetString("Birthday");
        }

        private void OnDeathdayLoaded(object sender, RoutedEventArgs e)
        {
            _deathday.Text = _resources.GetString("Deathday");
        }

        private void OnFatherLoaded(object sender, RoutedEventArgs e)
        {
            _father.Text = _resources.GetString("Father");
        }

        private void OnMotherLoaded(object sender, RoutedEventArgs e)
        {
            _mother.Text = _resources.GetString("Mother");
        }

        private async void OnSettlingItemClick(object sender, RoutedEventArgs e)
        {
            Homeless current = _homelessListView.SelectedItem as Homeless;
            SettlingDialog dialog = new SettlingDialog(current);
            await dialog.ShowAsync();
            if (dialog.Status == -1)
            {
                await new ContentDialog
                {
                    Title = "Ошибка",
                    Content = "Нарушены нормы проживания",
                    PrimaryButtonText = "Ок"
                }.ShowAsync();
                return;
            }
            await new ContentDialog
            {
                Title = "Успех",
                Content = "Житель заселен",
                PrimaryButtonText = "Ок"
            }.ShowAsync();
            _homelesses.Remove(current);
        }

        private void OnHomelessListRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (((FrameworkElement) e.OriginalSource).DataContext is Homeless selectedItem)
            {
                _homelessListView.SelectedItem = selectedItem;
            }
        }
    }
}
