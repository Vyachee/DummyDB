namespace DummyDB
{
    public class TakenBook
    {
        public uint BookId { get; }
        public uint ReaderId { get; }
        public DateTime GettingTime { get; }
        public DateTime ReturningTime { get; }
        public TakenBook(uint bookId, uint readerId, DateTime gettingTime, DateTime returningTime)
        {
            BookId = bookId;
            ReaderId = readerId;
            GettingTime = gettingTime;
            ReturningTime = returningTime;
        }

    }

}