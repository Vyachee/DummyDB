namespace DummyDB
{
    public class Book
    {
        public string Title { get; }
        public FullName AuthorName { get; }
        public uint PublicationYear { get; }
        public ReaderTicket CurrentOwner { get; private set; }
        public uint ShelfIndex { get; }
        public uint BookcaseIndex { get; }
        public uint ID { get; }
        private uint _id;
        public Book(uint id, string title, FullName authorName, uint publicationYear, uint shelfIndex, uint bookcaseIndex)
        {
            ID = id;
            Title = title;
            AuthorName = authorName;
            PublicationYear = publicationYear;
            ShelfIndex = shelfIndex;
            BookcaseIndex = bookcaseIndex;
        }

        public override string ToString()
        {
            return $"{ID} | {Title} | {AuthorName}";
        }

        public void AddConnectionToReader(ReaderTicket a)
        {
            CurrentOwner = a;
        }

    }

}