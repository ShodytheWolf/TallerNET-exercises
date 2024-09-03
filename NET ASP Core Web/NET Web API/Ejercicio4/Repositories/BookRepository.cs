using RazorExercise.Models;

namespace RazorExercise.Repositories
{
    public class BookRepository : IBookRepository{

        private IDictionary<string,Book> _books;
        public BookRepository(){

            _books = new Dictionary<string,Book>();

            Book book1 = new Book("000", "Structure and Interpretation of coso pum pere", "Harold Abelson", DateTime.Now);
            Book book2 = new Book("i32", "Compilers, principles, techniques & tools", "Jeffrey D Ullman", DateTime.Now);
            Book book3 = new Book("LTN-2JFR", "Histoire au Revachol", "Mart .In DuAuntunois", DateTime.Now);

            _books.Add(book1.Isbn,book1);
            _books.Add(book2.Isbn,book2);
            _books.Add(book3.Isbn,book3);
        }

        public IDictionary<string, Book> GetAll(){
            return _books;
        }


        public void Add(Book book) { 
            this._books.Add(book.Isbn,book);
        }


        public void Remove(string isbn){ 

            if(isbn == null){
                throw new Exception("No se puede borrar un ISBN null");
            }


            try{
                this._books.Remove(isbn);
            }
            catch (Exception e){
                throw new Exception("No se pudo encontrar el libro. Causa: " + e.InnerException.Message);
            }
        }

        public Book GetById(string isbn){

            return this._books[isbn];

        }
    }
}
