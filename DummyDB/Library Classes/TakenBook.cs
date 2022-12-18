namespace DummyDB
{
    public class TakenBook
    {
        public Book Book { get; }
        public ReaderTicket Reader { get; }
        public DateTime GettingTime { get; }
        public DateTime ReturningTime { get; }
        public TakenBook(Book book, ReaderTicket reader, DateTime gettingTime, DateTime returningTime)
        {
            Book = book;
            Reader = reader;
            GettingTime = gettingTime;
            ReturningTime = returningTime;
        }

        public override string ToString()
        {
            return $"{Book.Title} | {Book.AuthorName} | {Reader.FullName} | {GettingTime}";
        }
    }

}