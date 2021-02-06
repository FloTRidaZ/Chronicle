namespace Island.ru.kso.island.mssql.types
{
    public sealed class Businessman
    {
        public Businessman(string surname, string name, string nameCraft, string craftDescription, int workmans)
        {
            Surname = surname;
            Name = name;
            NameCraft = nameCraft;
            CraftDescription = craftDescription;
            Workmans = workmans;
        }

        public string Surname { get; }
        public string Name { get; }
        public string NameCraft { get; }
        public string CraftDescription { get; }
        public int Workmans { get; set; }
    }
}
