Taller NET, 4to Práctico, 1er consigna.
## Consigna 1

1. Crear un proyecto utilizando la plantilla correspondiente
2. Implementar operaciones CRUD de un catálogo de Libros.

	1. De cada libro se conoce su isbn, título, autor y fecha de publicación.
	2. No implementar la capa de persistencia (solo guardar el catálogo en memoria)
	3. Utilice los conceptos utilizados en clase.
	4. Recordar usar la herramienta de generación de código (Scaffolding)


# Overview

Utilizando la plantilla de Web App ASP. NET Core con páginas Razor
![](_attachments/Pasted%20image%2020240902194942.png)

Creé el siguiente proyecto con su correspondiente jerarquía:
![](_attachments/Pasted%20image%2020240902231303.png)

### Book (objeto de dominio)
El único objeto de dominio que hay en nuestra lógica, que consiste de un par de propiedades básicas.
![](_attachments/Pasted%20image%2020240903020519.png)

---
### Repositorio (memoria)
En donde tengo toda la lógica para manejar la persistencia en memoria del libro, que utiliza un diccionario tal y como nos mostró en [el ejemplo visto en clase](https://github.com/gabrielaramburu/TallerNET/tree/main/01_3_webAppEjemplo)


En dicho repositorio, tengo su constructor que carga 3 libros de ejemplo para que se puedan ver en la páginas:
![](_attachments/Pasted%20image%2020240902235800.png)

Y las respectivas operaciones CRUD de las cuales se hará uso en el *BookController*
![](_attachments/Pasted%20image%2020240902235921.png)

---
### Controller
Y por último el controlador, localizado dentro de *Controllers*, siendo el único que hay, para el único objeto de dominio, llamado *BookController*
en donde se ubican todas las acciones que una vista podría llegar a hacer.
Crear, borrar, editar y mostrar.
![](_attachments/Pasted%20image%2020240902234938.png)
![](_attachments/Pasted%20image%2020240902235133.png)
![](_attachments/Pasted%20image%2020240902235315.png)

---
### Páginas/Vistas
Todas las páginas y vistas se encuentran guardadas dentro de la carpeta *Pages*, ya que por convenio el scope del archivo *_ViewImports* es tan solo para el directorio que se encuentra parado, y cualquier otro directorio dentro de este de forma recursiva.
![](_attachments/Pasted%20image%2020240903023622.png)

dentro de *_ViewImports* se encuentran las líneas para poder hacer uso de las *TagHelpers* que nos permiten injectar automaticamente lógica de nuestro servidor en las páginas HTML.
![](_attachments/Pasted%20image%2020240903023836.png)


Y hablando de *TagHelpers* estos se usan constantemente en las páginas generadas con scaffolding para facilitar el desarrollo.

Por ejemplo:
![](_attachments/Pasted%20image%2020240903024041.png)
![](_attachments/Pasted%20image%2020240903024153.png)

Este patrón se repite en el resto de páginas que se utilizan dentro del directorio *Books*
más allá del scaffolding inicial que te proveé Visual Studio, algunas de las páginas fuerón modificadas ligeramente para poder tener una mayor congruencia la una con la otra.


El cambio más llamativo, fue el pasar un parámetro extra a la función de editar libro 
```C#
EditBook(Book newBook, string oldIsbn)
```

haciendo uso de una de las funciones de los *TagHelpers* (*asp-route-NombreParametro*) para que podamos tener tanto la instancia del ISBN antes, y después de la modificación.
Lo cual nos permite modificar libremente el ISBN de un libro dado sin tener que duplicarlo.
![](_attachments/Pasted%20image%2020240903024846.png)

Cabe destacar que este parámetro extra, matchea por convención, así que necesitamos que el parámetro del lado del controlador tenga **exactamente** el mismo nombre que el nombre que el damos desde la vista, evidenciando en la susodicha función:
![](_attachments/Pasted%20image%2020240903025005.png)

---

# Demostración

Aquí va un paso a paso de todas las funcionalidades del CRUD.

### Mostrar todos los libros
Está es la más básica, y la que más se usará.
![](_attachments/Pasted%20image%2020240903031608.png)

En este caso solo muestra los libros previamente añadidos a través del constructor del repositorio del libro.

Código del controlador que se llama en este caso de uso:
![](_attachments/Pasted%20image%2020240903033327.png)

---
### Crear libro
Accediendo a través del hipervinculo *Añadir Libro* accedemos a la página de creación de libro.
Creemos uno para probarlo:
![](_attachments/Pasted%20image%2020240903031905.png)


Y una vez creado, lo vemos reflejado automáticamente en la lista de libros (y en consola del programa):
![](_attachments/Pasted%20image%2020240903031956.png)

Aquí están las funciones del controlador que se llaman en este caso de uso:
![](_attachments/Pasted%20image%2020240903034526.png)

---
### Editar libro
Para esto, editaremos el libro recién añadido, para esto nos dirigimos al hipervinculo *Editar* que se encuentra en la lista de libros:
![](_attachments/Pasted%20image%2020240903032223.png)

Le cambiaremos el ISBN del libro "100 desafios Javascript"
Y tras darle a guardar, nos llevará nuevamente a la lista de libros para revisar su funcionamiento:
![](_attachments/Pasted%20image%2020240903032339.png)

Además que en la consola se muestra tanto el ISBN cambiado, como el antiguo.


Código del controlador que se llama para la vista, y para la lógica:
![](_attachments/Pasted%20image%2020240903033542.png)

---
### Borrar libro
Para esto borraremos el libro con ISBN: i32
![](_attachments/Pasted%20image%2020240903033110.png)

Y tras darle al botón de borrar, otra vez nos reenviará a la lista de libros para observar el libro borrado:
![](_attachments/Pasted%20image%2020240903033209.png)

Código del lado del controlador que se utiliza en este caso de uso:
![](_attachments/Pasted%20image%2020240903035006.png)