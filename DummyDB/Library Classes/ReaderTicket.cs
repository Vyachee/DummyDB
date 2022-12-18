namespace DummyDB
{
    public class ReaderTicket
    {
        public FullName FullName { get; }
        public uint ID { get; }
        public ReaderTicket(uint id, FullName  fullName)
        {
            FullName = fullName;
            ID = id;
        }

        public ReaderTicket()
        {

        }
    }

}