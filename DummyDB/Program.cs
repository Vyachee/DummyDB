using static System.Reflection.Metadata.BlobBuilder;

namespace DummyDB
{
    class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            string projectFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string[] booksData = GetData(projectFilePath, "Books");
            string[] readersData = GetData(projectFilePath, "Readers");


            if (readersData == null || booksData == null)
                return;


            Book[] books = FillBookArray(booksData);
            ReaderTicket[] readers = FillReadersArray(readersData);

            string[] takenBooksData = GetData(projectFilePath, "TakenBooks");

            if (takenBooksData == null)
                return;
            TakenBook[] takenBooks = FillTakenBooksArray(takenBooksData, books, readers);

            foreach (TakenBook tBook in takenBooks)
                Console.WriteLine(tBook);
        }


        private static Book[] FillBookArray(string[] input)
        {
            Book[] books = new Book[input.Length];
            for (int i = 0; i < books.Length; i++)
            {
                string[] line = input[i].Split(';');
                FullName authorName;
                if (line[2].Split(' ').Length == 2)
                    authorName = new FullName(line[2].Split(' ')[0], line[2].Split(' ')[1]);
                else
                    authorName = new FullName(line[2].Split(' ')[0], line[2].Split(' ')[1], line[2].Split(' ')[2]);
                books[i] = new Book(uint.Parse(line[0]), line[1], authorName, uint.Parse(line[3]), uint.Parse(line[4]), uint.Parse(line[5]));
            }

            return books;
        }

        private static ReaderTicket[] FillReadersArray(string[] input)
        {
            ReaderTicket[] readers = new ReaderTicket[input.Length];
            for (int i = 0; i < readers.Length; i++)
            {
                string[] line = input[i].Split(';');
                FullName name;
                if (line[1].Split(' ').Length == 2)
                    name = new FullName(line[1].Split(' ')[0], line[1].Split(' ')[1]);
                else
                    name = new FullName(line[1].Split(' ')[0], line[1].Split(' ')[1], line[1].Split(' ')[2]);
                readers[i] = new ReaderTicket(uint.Parse(line[0]), name);
            }

            return readers;
        }

        private static TakenBook[] FillTakenBooksArray(string[] input, Book[] books, ReaderTicket[] readers)
        {
            TakenBook[] result = new TakenBook[input.Length];
            for (int i = 0; i < result.Length; i++)
            {
                string[] line = input[i].Split(';');
                Book b = new();
                for (int j = 0; j < books.Length; j++)
                {
                    if (uint.Parse(line[0]) == books[j].ID)
                        b = books[j];
                }

                ReaderTicket r = new();
                for (int j = 0; j < readers.Length; j++)
                {
                    if (uint.Parse(line[1]) == readers[j].ID)
                        r = readers[j];
                }

                result[i] = new TakenBook(b, r, DateTime.Parse(line[2]), DateTime.Parse(line[3]));
            }

            return result;
        }

        private static string[] GetData(string filePath, string dataName)
        {
            string inCSVPath = filePath + "//Data in csv//" + dataName + ".csv";
            string inJsonPath = filePath + "//json schems//" + dataName + ".json";
            CSVReader reader = new();
            return reader.ReadFromCSV(inCSVPath, inJsonPath);
        }

    }

}