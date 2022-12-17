using static System.Reflection.Metadata.BlobBuilder;

namespace DummyDB
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            string projectFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string booksInCsvPath = projectFilePath + "//Data in csv//Books.csv";
            string booksInJsonPath = projectFilePath + "//json schems//Books.json";
            string readersInCsvPath = projectFilePath + "//Data in csv//Readers.csv";
            string readersInJsonPath = projectFilePath + "//json schems//Readers.json";

            CSVReader reader = new();
            string[] readersData = reader.ReadFromCSV(readersInCsvPath, readersInJsonPath);
            string[] booksData = reader.ReadFromCSV(booksInCsvPath, booksInJsonPath);


            if (readersData == null || booksData == null)
                return;


            Book[] books = FillBookArray(booksData);
            ReaderTicket[] readers = FillReadersArray(readersData);

            string takenBooksInJsonPath = projectFilePath + "//json schems//TakenBooks.json";
            string takenbooksInCsvPath = projectFilePath + "//Data in csv//TakenBooks.csv";
            string[] takenBooksData = reader.ReadFromCSV(takenbooksInCsvPath, takenBooksInJsonPath);

            if (takenBooksData == null)
                return;

            TakenBook[] takenBooks = FillTakenBooksArray(takenBooksData);
            foreach (TakenBook takenBook in takenBooks)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    for (int j = 0; j < readers.Length; j++)
                    {
                        if (takenBook.ReaderId == readers[j].ID && takenBook.BookId == books[i].ID)
                            books[i].A(readers[j]);
                    }

                }

            }

            foreach (Book book in books)
                Console.WriteLine(book);
        }


        static Book[] FillBookArray(string[] input)
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

        static ReaderTicket[] FillReadersArray(string[] input)
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

        static TakenBook[] FillTakenBooksArray(string[] input)
        {
            TakenBook[] result = new TakenBook[input.Length];
            for (int i = 0; i < result.Length; i++)
            {
                string[] line = input[i].Split(';');
                result[i] = new TakenBook(uint.Parse(line[0]), uint.Parse(line[1]), DateTime.Parse(line[2]), DateTime.Parse(line[3]));
            }

            return result;
        }

    }

}