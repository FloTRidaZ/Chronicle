using Island.ru.kso.island.mssql.types;
using System.Collections.ObjectModel;

namespace Island.ru.kso.island.mssql.collection
{
    public sealed class BusinessmanCollection
    {
        public ObservableCollection<Businessman> BusinessmanList { get; }

        public BusinessmanCollection()
        {
            BusinessmanList = new ObservableCollection<Businessman>();
        }

        public void Add(Businessman businessman)
        {
            BusinessmanList.Add(businessman);
        }
    }
}
