using System;

namespace Island.ru.kso.island.mssql.types
{
    public sealed class Homeless
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Sex { get; }
        public string Birthday { get; }
        public string Deathday { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }

        public Homeless(int id, string name, string surname, int sex, DateTime birthday)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthday = birthday.ToString();
            Deathday = "Неизвестно";
            if (sex == 0)
            {
                Sex = "Мужской";
            }
            else
            {
                Sex = "Женский";
            }
            Father = "Неизвестно";
            Mother = "Неизвестно";
        }
    }
}
