using Island.ru.kso.island.mssql.types;
using System.Collections.ObjectModel;

namespace Island.ru.kso.island.mssql.collection
{
    public sealed class IslandCollection
    {
        private static IslandCollection _instance;
        private readonly HomelessCollection _homelessCollection;
        private readonly HouseCollection _houseCollection;
        private readonly BusinessmanCollection _businessmanCollection;

        public static void CreateInstance()
        {
            if (_instance != null)
            {
                return;
            }
            _instance = new IslandCollection();
        }

        public static IslandCollection GetInstance()
        {
            return _instance;
        }

        private IslandCollection()
        {
            _homelessCollection = new HomelessCollection();
            _houseCollection = new HouseCollection();
            _businessmanCollection = new BusinessmanCollection();
        }

        public void AddHouse(House house)
        {
            _houseCollection.Add(house);
        }

        public void AddHomeless(Homeless homeless)
        {
            _homelessCollection.Add(homeless);
        }

        public void AddBusinessman(Businessman businessman)
        {
            _businessmanCollection.Add(businessman);
        }

        public ObservableCollection<Businessman> GetBusinessmanList()
        {
            return _businessmanCollection.BusinessmanList;
        }

        public ObservableCollection<House> GetHouseList()
        {
            return _houseCollection.HouseList;
        }

        public ObservableCollection<Homeless> GetHomelessList()
        {
            return _homelessCollection.HomelessList;
        }
    }
}
