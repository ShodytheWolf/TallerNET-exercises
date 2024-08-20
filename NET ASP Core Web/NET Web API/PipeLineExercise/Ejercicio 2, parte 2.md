
# Consigna
1) Implementar un pipeline que realice el procesamiento de imágenes. 
2) El pipeline deberá de contar de tres pasos: 
	a) leer imagen desde archivo
	b) aplicar filtro de color de la misma que remplace un color por otro
    c) generar nuevo archivo de imagen con el resultado*


# Introducción
Utilizando [el código visto en clase](https://github.com/gabrielaramburu/TallerNET/tree/main/01_02b_pipelinePattern/01_02b_pipelinePattern) se desarrolló un patrón de PipeLine en C# para reemplazar un color dado en una imágen.


# Configuración
Primero y más importante es decir que se configuro el programa para específicamente CPUs de 64 bits, para evitar problemas con limites a la hora de alocar la memoria.

Haciendole click derecho en el proyecto -> Propiedades -> Build
![](_attachments/Pasted%20image%2020240819204235.png)
se específica la arquitectura de CPU para la cual el compilador, compilará.


Tras esto, se añadió el paquete Nuget: **System.Drawing.Common** al proyecto en que estámos trabajando.

para eso hacemos doble click sobre la solución -> Manage NuGet packages for Solution
![](_attachments/Pasted%20image%2020240819204905.png)
Aquí, dentro de *Browse* buscamos la libreria **System.Drawing.Common** y la instalamos para el proyecto en cuestión.

---

# Implementación
### Program.cs
Es donde se ejecuta el orquestador de la Pipeline, añaden pasos a la misma, y se crea el contexto en donde trabajaremos.
![](_attachments/Pasted%20image%2020240819205241.png)
tal y cómo vimos en el código de ejemplo, hicimos una interfaz de los pasos **IStep**, y de el contexto **IContext**

que más tarde implementamos en clases concretas.


### ImageContext
Es la implementación del contexto que guarda ~~casi~~ todos los estádos necesarios para poder hacer correr el código.

![](_attachments/Pasted%20image%2020240819205722.png)
consiste de 3 propiedades, la imagen guardada, el cámino que se utilizara para cargar la imágen, y la extensión de la imágen en ese orden.


### ImageLoaderStep
Es el paso que se encarga de levantar la dirección del fichero (hardcodeada), guardarla en el contexto (incluída la extensión del mismo)

tras esto, chequea que la imagen no sea de tipo WEBP, pues este tipo de imagen falla con la implementación del siguiente paso, y siempre se queda sin memoria, sin importar el tamaño de la imagen.

por ultimo, hace un try and catch para asegurarse de que se haya cargado correctamente la imagen.
![](_attachments/Pasted%20image%2020240819205958.png)



### ColorChangerStep
Tras asegurarnos que todo se haya guardado correctamente en el contexto, procedemos a cambiar el color de la imagen, [haciendo uso del código que me encontré en Stack Overflow](https://stackoverflow.com/questions/9871262/replace-color-in-an-image-in-c-sharp)
Código que llama a la función que cambia el color de la imagen.
![](_attachments/Pasted%20image%2020240819211003.png)


Código mágico de Stack Overflow.
![](_attachments/Pasted%20image%2020240819211236.png)


### ImageSaverStep
Este último paso itera en un while hasta encontrar un nombre de archivo (hardcodeado) que no exista todavía.

Una vez lo hace, sale y guarda el archivo resultante en la dirección (hardcodeada) al final, concatenandole al nombre, el valor del iterador, y el tipo de extensión del archivo de imagen original.

![](_attachments/Pasted%20image%2020240819211552.png)
En este caso concreto, se guarda dentro de una carpeta "OutPuts" que se encuentra dentro del proyecto.

---

# Ejecución

Para hacer prueba del código utilizaremos tanto PNG cómo JPG.

Convertiremos de Rojo a azul la siguiente imágen con tolerancia 80:
![](_attachments/Pasted%20image%2020240819212029.png)


Ejecutamos el código:
![](_attachments/Pasted%20image%2020240819212152.png)


Y esta es la imagen resultante:
![](_attachments/Pasted%20image%2020240819212233.png)

---


Para probar el limite de que tan efectivo es el código, intenté pasar la siguiente imágen de naranja a azul con tolerancia 100:
![](_attachments/Pasted%20image%2020240819212926.png)



![](_attachments/Pasted%20image%2020240819212820.png)
Quizas me pasé un poco con el valor de la tolerancia, pero funciona.

# Referencias