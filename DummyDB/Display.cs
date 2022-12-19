namespace DummyDB
{
    public class Display
    {
        public TakenBook[] TakenBooks { get; }
        private int _titles;
        private int _authors;
        private int _readers;
        private int _dates;
        public Display(TakenBook[] takenBooks)
        {
            TakenBooks = takenBooks;
        }

        public void Start()
        {
            string[] titles = new string[TakenBooks.Length];
            for (int i = 0; i < titles.Length; i++)
            {
                titles[i] = TakenBooks[i].Book.Title;
            }
            _titles = GetMaxLength(titles);

            string[] authors = new string[TakenBooks.Length];
            for (int i = 0; i < authors.Length; i++)
            {
                authors[i] = TakenBooks[i].Book.AuthorName.Surname;
            }
            _authors = GetMaxLength(authors);

            string[] readers = new string[TakenBooks.Length];
            for (int i = 0; i < readers.Length; i++)
            {
                readers[i] = TakenBooks[i].Reader.FullName.Surname + " " + TakenBooks[i].Reader.FullName.Name;
            }
            _readers = GetMaxLength(readers);

            string[] dates = new string[TakenBooks.Length];
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i] = TakenBooks[i].GettingTime.ToString();
            }
            _dates = GetMaxLength(dates);
            string header = DrawHeader(_titles, _authors, _readers, _dates);
            Console.WriteLine(header);
            string border = DrawBorder(_titles, _authors, _readers, _dates);
            Console.WriteLine(border);
            for (int i = 0; i < TakenBooks.Length; i++)
            {
                string floor = DrawFloor(TakenBooks[i]);
                Console.WriteLine(floor);
                Console.WriteLine(border);
            }

        }

        private string DrawHeader(int titles, int authors, int readers, int dates)
        {
            string result = "| Название";
            for (int i = 0; i < titles - 9; i++)
                result += ' ';
            result += " | ";
            result += "Автор";
            for (int i = 0; i < authors - 6; i++)
                result += ' ';
            result += " | ";
            result += "Читает";
            for (int i = 0; i < readers - 7; i++)
                result += ' ';
            result += " | ";
            result += "Взял";
            for (int i = 0; i < dates - 5; i++)
                result += ' ';
            result += " |";
            return result;
        }

        private string DrawBorder(int titles, int authors, int readers, int dates)
        {
            string result = "|";
            for (int i = 0; i < titles + 1; i++)
                result += "-";
            result += "|";
            for (int i = 0; i < authors + 1; i++)
                result += "-";
            result += "|";
            for (int i = 0; i < readers + 1; i++)
                result += "-";
            result += "|";
            for (int i = 0; i < dates + 1; i++)
                result += "-";
            result += "|";
            return result;
        }

        private string DrawFloor(TakenBook book)
        {
            string result = "|";
            string title = book.Book.Title;
            result += title;
            for (int i = 0; i < _titles - title.Length; i++)
                result += " ";
            result += " |";

            string author = book.Book.AuthorName.Surname;
            result += author;
            for (int i = 0; i < _authors - author.Length; i++)
                result += " ";
            result += " |";

            string reader = book.Reader.FullName.Surname + " " + book.Reader.FullName.Name;
            result += reader;
            for (int i = 0; i < _readers - reader.Length; i++)
                result += " ";
            result += " |";

            string date = book.GettingTime.ToString();
            if (date == "01.01.0001 0:00:00")
                date = "";
            result += date;
            for (int i = 0; i < _dates - date.Length; i++)
                result += " ";
            result += " |";
            return result;
        }

        private int GetMaxLength(string[] input)
        {
            int maxLen = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length > maxLen)
                    maxLen = input[i].Length;
            }

            return maxLen;
        }

    }

}