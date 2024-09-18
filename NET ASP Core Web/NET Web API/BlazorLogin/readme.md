# Consiga 3. (recomendada)

Objetivo: Poder realizar un pequeño desarrollo desde cero, relacionando ideas ya conocidas pero sin un proyecto de referencia del cual partir. 

Implementar la solución de login con verificación realizada con SignalR y ASP.NET Core MVC y JavaScript pero utilizando Blazor.

Deberá:
- analizar que componentes UI ofrece la librería Radzen y estudiar su comportamiento. (ejemplo: layout, botón, etiquetas, cajas de texto)
- integrar las ideas ya estudiadas para lograr la solución.

# Implementación
Siguiendo las pautas de la consigna, me creé un proyecto de Blazor con renderizado *Auto* quedándome la siguiente estructura:

![](_attachments/Pasted%20image%2020240918150818.png)

Donde la mayoría de la lógica se centra en los siguientes archivos:
- Login.razor (presentación y conexión usando SignalR)
- UserHub.cs (lógica del servidor usando SignalR)
- Program.cs (configuración de Radzen y SignalR)
- _Imports.razor (configuración de Radzen)

## Configuración de ambiente

#### Radzen
Siguiendo los pasos de la [página de Radzen](https://blazor.radzen.com/get-started) se instala haciendo uso de NuGet las dependencias para Radzen:
![](_attachments/Pasted%20image%2020240918151535.png)

Tanto para el proyecto del servidor como para el del cliente.

dentro del _Imports.razor se colocan las siguientes líneas:
```C#
@using Radzen
@using Radzen.Blazor
```

y dentro de App.razor del lado del servidor se añaden las siguientes líneas para configurar el tipo de renderizado:
```C#
<RadzenTheme Theme="material" @rendermode="InteractiveWebAssembly" />

<script src="_content/Radzen.Blazor/Radzen.Blazor.js?v=@(typeof(Radzen.Colors).Assembly.GetName().Version)"></script>
```

---
#### SignalR
del lado del servidor se instala la librería de SignalR tanto el Core como el Client usando nuGet:

![](_attachments/Pasted%20image%2020240918152628.png)


Y del lado del cliente simplemente se instala SignalR Client:

![](_attachments/Pasted%20image%2020240918152818.png)

---
## Lado del cliente
Tras configurar los proyectos, nos ponemos con el archivo que tiene casi toda la lógica del cliente; **Login.razor**

Insertamos un par de componentes de Radzen: [1 botón](https://blazor.radzen.com/button?theme=material3), [2 alerts](https://blazor.radzen.com/alert?theme=material3), y [2 FormFields](https://blazor.radzen.com/form-field?theme=material3)

![](_attachments/Pasted%20image%2020240918154107.png)


Después de esto, tenemos la lógica de SignalR para conectarlo al Hub:

![](_attachments/Pasted%20image%2020240918154556.png)


Y la lógica para llamar la función del hub que se encarga de loggear al usuario, además de mostar los Alert y deshabilitar el botón de Radzen:

![](_attachments/Pasted%20image%2020240918154641.png)

---
## Lado del servidor
La lógica del servidor se mantiene exactamente igual a la del proyecto pasado.

con un UserHub que se encarga de checkear las creedenciales del usuario

![](_attachments/Pasted%20image%2020240918160417.png)


y un endpoint que me permite autenticar el usuario dentro del Program.cs:

![](_attachments/Pasted%20image%2020240918160622.png)

el cual llamamos desde el CMD de windows.



# Demostración
Entramos al Login:

![](_attachments/Pasted%20image%2020240918161303.png)



Nos loggeamos con alguna creedencial válida (revisar archivo UserRepository)

![](_attachments/Pasted%20image%2020240918161407.png)


Le damos enter:

![](_attachments/Pasted%20image%2020240918161445.png)


Nos "autenticamos":
![](_attachments/Pasted%20image%2020240918161528.png)


Y la página nos direcciona automáticamente:

![](_attachments/Pasted%20image%2020240918161826.png)
