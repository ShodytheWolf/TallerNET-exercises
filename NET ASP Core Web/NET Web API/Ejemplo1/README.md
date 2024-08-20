En este documento expondremos el funcionamiento de una *RESTful API* construida en C# con *ASP.NET Core MVC* utilizando el servidor web *Kestrel*

Primero se creó una plantilla de ASP .NET Core Web API tal y cómo nos indica Visual Studio
![](_attachments/Pasted%20image%2020240812204644.png)

---

Una vez creada la plantilla, tal y cómo pide la letra del ejercicio, se creó un objeto de domino dentro de la carpeta Models con los siguientes atributos:
![](_attachments/Pasted%20image%2020240812205745.png)
![](_attachments/Pasted%20image%2020240812205818.png)
Utilizando las [propiedades](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties#auto-implemented-properties) de C#, se pueden crear setters y getters muy rápidamente.

---

Además, se creo el siguiente controlador con todas las operaciones CRUD que pide la letra para dicho objeto de dominio:
![](_attachments/Pasted%20image%2020240812211445.png)
![](_attachments/Pasted%20image%2020240812211527.png)
![](_attachments/Pasted%20image%2020240812211559.png)


Para que dichas operaciones funcionaran correctamente (especialmente añadir y borrar una tarea) se tuvierón que añadir un par de configuraciones al archivo *Program.cs*
![](_attachments/Pasted%20image%2020240812211742.png)

---

# Pruebas
Aquí se corrobora el correcto funcionamiento de las operaciones, haciendo uso de Swagger.
![](_attachments/Pasted%20image%2020240812212326.png)



## Ver todas las tareas
![](_attachments/Pasted%20image%2020240812212108.png)
Aquí se muestran las tareas ya existentes que fuerón añadidas con el constructor del controlador.



## Ver tarea específica
En caso de que la tarea exista, el funcionamiento sería el siguiente:
![](_attachments/Pasted%20image%2020240812212527.png)


Y en caso de que **NO** se encuentre la tarea, ocurre lo siguiente:
![](_attachments/Pasted%20image%2020240812212638.png)




## Añadir una tarea
Se añade una tarea en formato JSON a través de Json/Application
![](_attachments/Pasted%20image%2020240812213224.png)


Se demuestra el correcto añadido de la tarea a la lista:
![](_attachments/Pasted%20image%2020240812213357.png)



## Eliminar una tarea
Aquí se elimina la tarea con ID número 1
![](_attachments/Pasted%20image%2020240812213932.png)


Se comprueba que se haya eliminado correctamente la tarea con ID 1:
![](_attachments/Pasted%20image%2020240812214109.png)


Si intentamos borrar una tarea que no existe, como la 1 de nuevo, nos devuelve lo siguiente:
![](_attachments/Pasted%20image%2020240812214358.png)
