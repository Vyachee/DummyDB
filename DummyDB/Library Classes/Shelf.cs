namespace DummyDB
{
    public class Shelf
    {
        public uint Index { get; }
        public Book[] Books { get; }
        public Shelf(uint index, Book[] books)
        {
            Index = index;
            Books = books;
        }

    }

}