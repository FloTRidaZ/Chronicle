using Island.ru.kso.island.mssql.collection;
using Island.ru.kso.island.mssql.types;
using System;
using System.Data.SqlClient;

namespace Island.ru.kso.island.mssql.connector
{
    public sealed class IslandConnector
    {
        private const string CONNECTION_STRING = @"Data Source = DESKTOP-HBEEL2G\SQLEXPRESS; Initial Catalog = IslandChronicle; User = sa; Password = flotridaz58rus;";

        private IslandConnector()
        {

        }

        public static int Settling(int peopleId, string adress)
        {
            int status;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format(QueryCollection.SETTLING_QUERY, peopleId, adress);
                status = cmd.ExecuteNonQuery();
            }
            return status;
        }

        public static void UpdateArea(int houseId, double area)
        {
            IslandCollection islandCollection = IslandCollection.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format(QueryCollection.UPDATE_HOUSE_AREA, area, houseId);
                cmd.ExecuteNonQuery();
                islandCollection.GetHouseList().Clear();
                FillHouseCollection(islandCollection, cmd);
            }
        }

        public static void FillIslandCollection()
        {
            IslandCollection islandCollection = IslandCollection.GetInstance();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                FillHomelessCollection(islandCollection, cmd);
                FillHouseCollection(islandCollection, cmd);
                FillBusinessmanCollection(islandCollection, cmd);
            }
        }

        private static void FillBusinessmanCollection(IslandCollection islandCollection, SqlCommand cmd)
        {
            cmd.CommandText = QueryCollection.SELECT_BUSINESSMAN_QUERY;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string surname = reader.GetString(0);
                    string name = reader.GetString(1);
                    string nameCraft = reader.GetString(2);
                    string craftDescription = reader.GetString(3);
                    int workmans = reader.GetInt32(4);
                    Businessman businessman = new Businessman(surname, name, nameCraft, craftDescription, workmans);
                    islandCollection.AddBusinessman(businessman);
                }
            }
        }

        private static void FillHouseCollection(IslandCollection islandCollection, SqlCommand cmd)
        {
            cmd.CommandText = QueryCollection.SELECT_HOUSE_QUERY;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string adress = reader.GetString(1);
                    DateTime buildDate = reader.GetDateTime(2);
                    double area = reader.GetSqlSingle(4).Value;
                    House house = new House(id, adress, buildDate, area);
                    if (reader.IsDBNull(3))
                    {
                        house.DestroyDate = reader.GetDateTime(3).ToString();
                    }
                    islandCollection.AddHouse(house);
                }
            }
        }

        private static void FillHomelessCollection(IslandCollection islandCollection, SqlCommand cmd)
        {
            cmd.CommandText = QueryCollection.SELECT_HOMELESS_QUERY;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string surname = reader.GetString(1);
                    string name = reader.GetString(2);
                    int sex = int.Parse(reader.GetString(3));
                    DateTime birthday = reader.GetDateTime(4);
                    Homeless homeless = new Homeless(id, name, surname, sex, birthday);
                    if (!reader.IsDBNull(5))
                    {
                        homeless.Deathday = reader.GetDateTime(4).ToString();
                    }
                    if (!reader.IsDBNull(6))
                    {
                        homeless.Father = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        homeless.Mother = reader.GetString(6);
                    }
                    islandCollection.AddHomeless(homeless);
                }
            }
        }
    }
}
