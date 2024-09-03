namespace RazorExercise.Models
{
    public interface IBookRepository
    {
        public IDictionary<string, Book> GetAll();
        public void Add(Book book);

        public void Remove(string isbn);

        public Book GetById(string isbn);

    }
}
