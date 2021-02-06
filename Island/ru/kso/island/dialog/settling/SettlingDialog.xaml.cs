using Island.ru.kso.island.mssql.collection;
using Island.ru.kso.island.mssql.connector;
using Island.ru.kso.island.mssql.types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Island.ru.kso.island.dialog.settling
{
    public sealed partial class SettlingDialog : ContentDialog
    {
        private readonly Homeless _homeless;
        public int Status { get; private set; }
        public SettlingDialog(Homeless homeless)
        {
            this.InitializeComponent();
            _homeless = homeless;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string selectedHouse = (_houseBox.SelectedItem as ComboBoxItem).Content.ToString();
            Status = IslandConnector.Settling(_homeless.Id, selectedHouse);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }

        private void OnHouseBoxLoaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<House> houseList = IslandCollection.GetInstance().GetHouseList();
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            foreach (House house in houseList)
            {
                comboBoxItems.Add(new ComboBoxItem 
                {
                    Content = house.Adress
                });
            }
            _houseBox.ItemsSource = comboBoxItems;
            _houseBox.SelectedItem = comboBoxItems[0];
        }
    }
}
