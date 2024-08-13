using Ejemplo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo1.Controllers
{
    [ApiController]

    [Route("Tarea/API")]

    public class TareaController : Controller
    {
        //lista de las tareas que se guarda en memoria
        List<Tarea> tareas = new List<Tarea>();

        //logger que nos permitirá enviar mensajes a la consola para mayor legibilidad
        private readonly ILogger<TareaController> _logger;


        public TareaController(ILogger<TareaController> logger)
        {

            //inyectamos la dependencia del logger
            this._logger = logger;


            //creamos un par de tareas de ejemplo
            tareas.Add(new Tarea(0, "Aprender D bemol", "Es cómo aprender C#, pero una tonalidad distinta", 23F, "Jaime Altozano"));
            tareas.Add(new Tarea(1, "Aprender Für Elise", "Dependiendo hasta donde quieras aprenderte la pieza, es fácil o MUY difícil", 20, "Beethoven"));

        }

        //comenté este IActionResult porqué sino me explotaba el Swagger
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        [HttpGet]
        public ActionResult<IList<Tarea>> GetAll()
        {
            return Ok(this.tareas);
        }

        [HttpGet]
        [Route("{id}")] //el Route va sin la / sino no sigue el patrón de rutas previamente establecido
        //para la clase
        public ActionResult<Tarea> GetById(int id)
        {

            //find Tarea by ID imperative style 😎

            _logger.LogInformation("Se está buscando la tarea con ID: " + id);

            foreach (Tarea tarea in tareas)
            {

                if (tarea.Id == id)
                {

                    _logger.LogInformation("Se encontró la tarea: " + tarea.Nombre);
                    return Ok(tarea);
                }
            }
            return NotFound();
        }

        //el FromBody es innecesario siempre y cuando hayamos configurado como [ApiController] la clase del controlador
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(Tarea tarea)
        {

            this.tareas.Add(tarea);

            _logger.LogInformation($"Se añadió la tarea " + tarea.Nombre + " con ID: " + tarea.Id);

            return Ok("La tarea ha sido creada con exito");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {

            foreach (Tarea tarea in tareas)
            {
                if (tarea.Id == id)
                {

                    _logger.LogInformation("se encontró y borró la tarea con ID: " + tarea.Id);

                    tareas.Remove(tarea);

                    return Ok("La tarea se borró con exito.");
                }
            }

            return NotFound("No se pudó encontrar la tarea con ID: " + id);
        }
    }
}
