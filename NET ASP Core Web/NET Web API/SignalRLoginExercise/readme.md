
# Consigna

1. Crear un proyecto ASP.NET Core MVC con Razor Pages
    
2. Agregar la librería SignalR para ser utilizada del lado del cliente (ver ppt Introducción WebAssembly y SignalR)
    
3. Implementar Hub, configurar middleware (Program.cs) y crear recursos estáticos (html, css, js) que permitan resolver el problema descrito a continuación
    
4. Tomar en cuenta los proyectos de ejemplos subidos al repositorio.

# Overview
Se crea el proyecto ASP NET Core con Razor Pages tal y como pide la consigna:
![](_attachments/Pasted%20image%2020240909091604.png)

Con el siguiente estructura:
![](_attachments/Pasted%20image%2020240909091701.png)

 pese a la cantidad de archivos, realmente la mayoría de la lógica ocurre en 3 lugares, Login.cshtml, Program.cs & UserHub.

### Login.cshtml
en la página de Login es donde se controla el input del usuario y realiza la conexión con SignalR (haciendo uso de la librería del cliente previamente añadida tal y como [indica la diapositiva](https://docs.google.com/presentation/d/18EQRljguiqB98YfcZlFVGY9XAKDvkCocMZYXx_Mylhk/edit#slide=id.g22091b6084c_1_13))
![](_attachments/Pasted%20image%2020240909094401.png)

Con esta, se establece la conexión al Hub:
![](_attachments/Pasted%20image%2020240909094953.png)

Y una vez confirmado su conexión, se ingresan los datos y se controlan por parte del cliente, tras pasar este control, invocamos a una función (la única) dentro del Hub para avisarle que nos hemos loggeado:

![](_attachments/Pasted%20image%2020240909095114.png)


### UserHub
Ya del lado del hub, recibimos la petición de logeo con la información del email y la contraseña (que pasamos en texto plano. . .) 
![](_attachments/Pasted%20image%2020240909095530.png)
Se hacen un par de controles para asegurarnos de que la el usuario y la contraseña son correctos, son válidos y que no me lleguen en null.

Entre esos controles, nos aseguramos que el usuario esté previamente registrado, aunque no haya página de registro, dentro del repositorio en memoria del Usuario, se encuentran 3 usuario añadidos por motivos de pruebas.
![](_attachments/Pasted%20image%2020240909100613.png)

tras esto, printeamos en la consola el curl con el endpoint al que llamar para "autenticar" al usuario, esta última (localizada en Program.cs en formato de Minimal API) es la finalmente nos dará el visto bueno, y avisará al usuario correspondiente que actualize su página

### Program.cs
Como previamente indicado, aquí está la lógica final que se encarga de avisarle al usuario que actualizé la página (además de un par de configuraciones extras):
![](_attachments/Pasted%20image%2020240909100044.png)

tras avisar al cliente del cambio, tenemos que catchearlo, código que se encuentra de vuelta en la página de login:
![](_attachments/Pasted%20image%2020240909100454.png)

en donde simplemente se guarda el email del usuario en el sessionStorage y se re-envia la página a la de bienvenida.


# Demostración
Ahora haremos un pequeño recorrido del camino critico del *único* caso de uso de esta aplicación.

Primeramente iniciaremos sesión con alguno de los usuarios previamente añadidos, aparte de abrir varias ventanas del Login para demostrar el correcto funcionamiento del envio de confirmación al cliente:
![](_attachments/Pasted%20image%2020240909101133.png)

tras esto iniciamos sesión con estás credenciales *email: pepe@gmail.com & password:pepito*
![](_attachments/Pasted%20image%2020240909101259.png)

nos saltará un js alert para indicarnos que se enviarón los datos,  y podremos observar como se printean los datos del usuario (un **poquito** inseguro) dentro de la consola, junto con la URL del endpoint al que hay que llamar para autenticar.

Al hacerle curl a este endpoint haciendo uso del cmd de Windows, podremos observar lo siguiente:
![](_attachments/Pasted%20image%2020240909101539.png)
La página del Login se actualiza automáticamente, y la consola nos printea los datos del userId dentro de la función al estilo minimal API dentro del Program.cs.

También podemos observar como solo un cliente fue actualizado, las otras 2 páginas siguen en el Login:
![](_attachments/Pasted%20image%2020240909102025.png)

Cabe añadir que actualmente no hay control para cantidad de dispositivos conectados, podriamos loggearnos como Pepe en las 3 páginas por igual.
