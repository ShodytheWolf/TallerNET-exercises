namespace Ejemplo1.Models
{
    public class Tarea
    {
        
        //no es necesario tener constructor con parametros si te llegan los objetos serializados por parametro
        //como ocurre en TareaController con el POST para dar de alta la tarea.
        public Tarea(int id, string nombre, string descripcion, float duracion, string responsable)
        {
            //al hacer esto, automaticamente se usa el setter de la propiedad
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;  
            Duracion = duracion;
            Responsable = responsable;
        }


        //Por algo ahí medio raro de la deserialización, tengo que tener un constructor vacio
        //para poder dar de alta una Tarea.
        public Tarea() { } 
   

        //atributo privado de toda la vida, empiezan con _
        private int _id;

        //Me siento un poco sucio haciendo esto, pero es parecido
        //a como Python y GDScript manejan los getters y setters.
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }


        //esta es otra forma de escribir atributos, más rápida y declarativa
        private string? _nombre;
        public string? Nombre { set; get; }



        private string? _descripcion;
        public string? Descripcion { set; get; }


        private float? _duracion;
        public float? Duracion { set; get; }



        private string? _responsable;
        public string? Responsable {  set; get; }


        private DateTime _fecha;
        public DateTime Fecha { set; get; } = DateTime.Now;
    }
}
