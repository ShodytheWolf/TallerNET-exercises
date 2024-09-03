using Microsoft.AspNetCore.Mvc;
using RazorExercise.Models;
using RazorExercise.Repositories;

namespace RazorExercise.Controllers
{
    [Route("Book")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            _logger.LogInformation("Mostré todos los libros!");

            //retorno las views con este formato porqué tras mover los archivos de un lado para otro
            //retornar las views por el nombre del archivo ya no me funcionaba más
            return View("~/Pages/Book/ListBooks.cshtml", _bookRepository.GetAll().Values);

        }

        [HttpGet]
        [Route("ViewDelete/{id}")]
        public IActionResult ViewDelete(string id)
        {
            return View("~/Pages/Book/DeleteBooks.cshtml", _bookRepository.GetById(id));
        }

        [HttpPost]
        [ActionName("DeleteBook")]
        public IActionResult Delete(string id){

            _logger.LogInformation("llegué al delete con ISBN: " + id);

            try
            {
                this._bookRepository.Remove(id);
                return RedirectToAction("GetAllBooks");

            }
            catch (Exception e) {

                _logger.LogError(e.Message);
                return View("~/Pages/Error.cshtml");
            }
        }

        [HttpGet]
        [Route("ViewEdit/{id}")]
        public IActionResult ViewEdit(string id){

            _logger.LogInformation("Editando libro con ISBN: " + id);
            return View("~/Pages/Book/EditBooks.cshtml", _bookRepository.GetById(id));
        }

        
        [HttpPost]
        [Route("EditBook")]
        public IActionResult EditBook(Book newBook, string oldIsbn){

            _logger.LogInformation("Estoy dentro de EditBook con libro: " + newBook.Title + " e ISBN: " + newBook.Isbn);
            _logger.LogInformation("ISBN original: " + oldIsbn);

            this._bookRepository.Remove(oldIsbn);
            this._bookRepository.Add(newBook);  

            return RedirectToAction("GetAllBooks");
        }

        [HttpGet]
        [Route("ViewAddBook")]
        public IActionResult ViewAddBook() {

            _logger.LogInformation("Accediendo a la vista ViewAddBook");
            return View("~/Pages/Book/AddBooks.cshtml");
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(Book bookToAdd){

            _logger.LogInformation("Se va a añadir el libro: " + bookToAdd.Title + " con ISBN: " + bookToAdd.Isbn);
            this._bookRepository.Add(bookToAdd);

            return RedirectToAction("GetAllBooks");
        }
    }
}
