namespace NhibernateConsole
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}";
        }
    }
}
