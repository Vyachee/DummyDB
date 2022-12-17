namespace DummyDB
{
    public class ReaderTicket
    {
        public FullName FullName { get; }
        public uint ID { get; }
        public List<TakenBook> TakenBooks { get; }
        public ReaderTicket(uint id, FullName  fullName)
        {
            FullName = fullName;
            ID = id;
            TakenBooks = new();
        }

        public void FillList(TakenBook[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ReaderId == ID)
                    TakenBooks.Add(input[i]);
            }

        }

    }

}