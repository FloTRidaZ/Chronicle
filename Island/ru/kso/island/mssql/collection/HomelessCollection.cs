using Island.ru.kso.island.mssql.types;
using System.Collections.ObjectModel;

namespace Island.ru.kso.island.mssql.collection
{
    public sealed class HomelessCollection
    {
        public ObservableCollection<Homeless> HomelessList { get; }

        public HomelessCollection()
        {
            HomelessList = new ObservableCollection<Homeless>();
        }

        public void Add(Homeless homeless)
        {
            HomelessList.Add(homeless);
        }
    }
}
