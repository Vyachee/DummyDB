namespace DummyDB
{
    public class Bookcase
    {
        public uint Index { get; }
        public Shelf[] Shelfs { get; }
        public Bookcase(uint index, Shelf[] shelf)
        {
            Index = index;
            Shelfs = shelf;
        }

    }

}