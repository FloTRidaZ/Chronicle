using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island.ru.kso.island.mssql.types
{
    public sealed class House
    {
        public int Id { get; }
        public string Adress { get; }
        public string BuildDate { get; }
        public string DestroyDate { get; set; }
        public double Area { get; set; }

        public House (int id, string adress, DateTime buildDate, double area)
        {
            Id = id;
            Adress = adress;
            BuildDate = buildDate.ToString();
            Area = area;
            DestroyDate = "Неизвестно";
        }
    }
}
