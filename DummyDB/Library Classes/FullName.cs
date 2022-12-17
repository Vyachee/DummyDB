namespace DummyDB
{
    public class FullName
    {
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public FullName(string name, string patronymic, string surname)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }

        public FullName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Surname}, {Name} {Patronymic}";
        }
    }

}