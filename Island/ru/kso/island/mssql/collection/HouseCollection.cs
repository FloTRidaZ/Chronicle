using Island.ru.kso.island.mssql.types;
using System.Collections.ObjectModel;

namespace Island.ru.kso.island.mssql.collection
{
    public sealed class HouseCollection
    {
        public ObservableCollection<House> HouseList { get; }
        
        public HouseCollection()
        {
            HouseList = new ObservableCollection<House>();
        }

        public void Add(House house)
        {
            HouseList.Add(house);
        }
    }
}
