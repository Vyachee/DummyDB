using System.Text;

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
            string header = DrawHeader();
            Console.WriteLine(header);
            string border = DrawBorder();
            Console.WriteLine(border);
            for (int i = 0; i < TakenBooks.Length; i++)
            {
                string floor = DrawFloor(TakenBooks[i]);
                Console.WriteLine(floor);
                Console.WriteLine(border);
            }

        }

        private string DrawHeader()
        {
            StringBuilder result = new StringBuilder("| Название");
            for (int i = 0; i < _titles - 9; i++)
                result.Append(" ");
            result.Append(" | Автор");

            for (int i = 0; i < _authors - 6; i++)
                result.Append(" ");
            result.Append(" | Читает");

            for (int i = 0; i < _readers - 7; i++)
                result.Append(" ");
            result.Append(" | Взял");
            for (int i = 0; i < _dates - 5; i++)
                result.Append(" ");
            result.Append(" |");
            return result.ToString();
        }

        private string DrawBorder()
        {
            StringBuilder result = new StringBuilder("|");
            for (int i = 0; i < _titles + 1; i++)
                result.Append("-");
            result.Append("|");

            for (int i = 0; i < _authors + 1; i++)
                result.Append("-");
            result.Append("|");

            for (int i = 0; i < _readers + 1; i++)
                result.Append("-");
            result.Append("|");

            for (int i = 0; i < _dates + 1; i++)
                result.Append("-");
            result.Append("|");

            return result.ToString();
        }

        private string DrawFloor(TakenBook book)
        {
            StringBuilder result = new StringBuilder("|");
            string title = book.Book.Title;
            result.Append(title);
            for (int i = 0; i < _titles - title.Length; i++)
                result.Append(" ");
            result.Append(" |");

            string author = book.Book.AuthorName.Surname;
            result.Append(author);
            for (int i = 0; i < _authors - author.Length; i++)
                result.Append(" ");
            result.Append(" |");

            string reader = book.Reader.FullName.Surname;
            result.Append(reader);
            for (int i = 0; i < _readers - reader.Length; i++)
                result.Append(" ");
            result.Append(" |");

            string date = book.GettingTime.ToString();
            if (date == DateTime.MinValue.ToString())
                date = "";
            result.Append(date);
            for (int i = 0; i < _dates - date.Length; i++)
                result.Append(" ");
            result.Append(" |");

            return result.ToString();
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