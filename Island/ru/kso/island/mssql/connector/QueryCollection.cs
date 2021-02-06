using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island.ru.kso.island.mssql.connector
{
    public sealed class QueryCollection
    {
        public const string SELECT_HOMELESS_QUERY = "EXEC homelessProc";
        public const string SELECT_HOUSE_QUERY = "SELECT * FROM house";
        public const string SETTLING_QUERY = "EXEC settlingProc {0}, '{1}'";
        public const string SELECT_BUSINESSMAN_QUERY = "SELECT * FROM businessmanView";
        public const string UPDATE_HOUSE_AREA = "UPDATE house SET Area = {0} WHERE ID_house LIKE {1}";

        private QueryCollection()
        {

        }
    }
}
