namespace RazorExercise.Models
{
    public class Book{

        //contructor vacio para que la deserialización de datos y el data binding funcionen
        public Book() { }

        public Book(string isbn, string title, string author, DateTime publicationDate){

            Isbn = isbn;
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }
        public string Isbn { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
