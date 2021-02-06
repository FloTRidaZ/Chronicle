using Island.ru.kso.island.mssql.connector;
using Island.ru.kso.island.mssql.types;
using Windows.UI.Xaml.Controls;

namespace Island.ru.kso.island.dialog.areadialog
{
    public sealed partial class UpdateAreaDialog : ContentDialog
    {
        private House _house;

        public UpdateAreaDialog(House house)
        {
            this.InitializeComponent();
            _house = house;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            IslandConnector.UpdateArea(_house.Id, int.Parse(_areaInput.Text));
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
