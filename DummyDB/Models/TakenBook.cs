namespace DummyDB
{
    public class TakenBook
    {
        public Book Book { get; }
        public ReaderTicket Reader { get; }
        public DateTime GettingTime { get; }
        public DateTime ReturningTime { get; }

        private string _gettingTime;
        public TakenBook(Book book, ReaderTicket reader, DateTime gettingTime)
        {
            Book = book;
            Reader = reader;
            GettingTime = gettingTime;
        }

        public override string ToString()
        {
            if (GettingTime == DateTime.MinValue)
                _gettingTime = " ";
            else
                _gettingTime = GettingTime.ToString();
            return $"{Book.Title} | {Book.AuthorName} | {Reader.FullName} | {_gettingTime}";
        }
    }

}