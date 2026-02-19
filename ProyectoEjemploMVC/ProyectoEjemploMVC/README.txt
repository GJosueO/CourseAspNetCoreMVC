SEGURIDAD EN .NET 10

ASP.NET CORE ESTA DISEÑADO CON LLA SEGURIDAD COMO UN PILAR FUNDAMENTAL DESDE SU ARQUITECTURA.

Algunos principios clave son:
 - La seguridad se aplica en el servidor, no en la vista  "cliente".
 - Todo acceso debe validarse explicitamente.
 - El framework ofrece mecanismos integrados para evitar errores comunes.

 ASP.NET CORE incluye protección nativa contra:
 -Accesos no autorizados.
 -Manipulación de datos.
 -Ataque comunes en aplicaciones web.

 Esto permite construir aplicaciones seguras sin necesidad de soluciones externas desde el inicio del desarrollo.


 ASP.NET Core separa claramente dos conceptos:

 AUTENTICACION:
 - Determina quie es el usuario.
 - Se basa en Identity, cookies o tokens.
 - Controla el iniciao y cierre de sesión.
 
 AUTORIZACION:
 - Determina qué puede hacer el usuario.
 - Se basa en roles, claims o politicas.
 - Protege controladores y acciones.

 Esta separacion permite aplicar reglas de acceso claras y flexibles en toda la aplicacion.




 BUENAS PRACTICAS DE SEGURIDAD EN PROYECTOS REALES:
 Para mantener una aplicacion segura es importante:
 - Proteger rutas con [Authorize]
 - Validadr siempre los datos del usuario.
 - Usaar roles para controlar accesos
 - Evitar expones informaicon sensible.
 - Aplicar validaciones del lado del servidor como cliente.

 ASP.NET Core facilita estas practicas de forma integrada , lo que permite enfocarse en la logica del negocio sin descuidar la seguridad.



 ¿QUE ES UN MIDDLEWARE?
 -Es un componente que forma parte del pipeline de processamiento de una peticion HTTP en ASP.NET.

 Cada solicitud que llega a la aplicacion:
  - Pasa por una serie de middlewares.
  - Cada uno puede procesar la peticion y decidir si continua o la detiene.

 Los middlewares permiten:
  - Interceptar solicitudes.
  - Modificar respuestas.
  - Aplicar logica transversal a toda la aplicacion (como seguridad, logging, etc).


  ¿COMO FUNCIONA EL PIPELINE DE MIDDLEWARES?
  - El pipeline se ejecuta en el orden en que los middelwares se registran en Promgram.cs.

  Flujo tipico:
   - Llega la peticion.
   - Pasa por cada middleware en orden.
   - Llega al enpoint (controlador o Razor Page).
   - La respuesta regresa por el mismo camino.

  Esto significa que:
  - El orden es clitico.
  - Un middleware puede bloquear el acceso.
  - Otro puede modificar la respuesta final.



  MIDDLEWARES Comunes en ASP.NET CORE:
  ASP.NET Core incluye middlewares integrados, como:

  * Manejo de errores.
  * Redireccion HTTPS.
  * Archivos estaticos.
  * Autenticacion.
  * Autorizacion.

  Ejemplos practicos:
   - Autenticacion valida al usuario.
   - Autorizacion controla el acceso.
   - StaticFiles permite servir CSS, JS e imagenes.

   Cada uno de ellos cumple una funcion especifica dentro del flujo de la aplicacion, lo que facilita la implementacion de funcionalidades comunes sin necesidad de escribir codigo adicional.


   ¿CUAL ES LA IMPORTANCIA DE LOS MIDDLEWARES?
   - Los middlewares permiten:
     - Centralizar logica comun.
     - Mantener el codigo limpio y organizado.
     - Aplicar seguridad de forma global.
     - Controlar el comportamiento de la aplicacion.

   En proyectos reales, entender lo middlewares es clave para:
    -Depurar errores.
    -Configurar seguridad.
    -Optimizar el rendimiento.


    ¿QUE ES EL ROUNTING EN ASP.NET CORE?
El routing en un mecanismo para decidir que controlador y que acciones deben ejecutarse cuando un suario accede a una URL especifica.
En otras palabras:
- El routing analiza la URL.
- Interpreta sus segmentos.
- Los traduce en una accion del servidor.

Sin routing, una aplicacion MVC no sabria:
- Que controlador usar.
- Que metodo ejecutar.
- Que parametros recibir.

El routing es fundamental para cualquier aplicacion web basada en mvc.

Tipo de routing
ASP:NET Core soporta dos tipos de routing:
1. Routing convencional:
 - Se define de forma centralizada en Program.cs
 - Usa patrones como  "{controller}/{action}/{id?}"
2. Routing por atributos:
 - Se define directamente sobre controladores y acciones.
 - Usa atributos como [Route("ruta")]




 TAG HELPERS:
 Los Tag Helpers son una caracteristica de asp.net core que permite integrar codigo del servidor directamnte en el HTML  de una forma clara y legible.
 Su objetivo principal es:
 - Facilitar la generacion de HTML dinamico.
 - Reducir errores al escribir enlaces y formularios.
 - Mantener el codigo mas limpio y mantenible.

 Los TAG HELPERS se reconocen por que usan atributos especiales como:
 asp-controller
 asp-action
 asp-route-*
 asp-for


 VENTAJAS AL UTILIZAR TAG HELPERS
 Ofrece varias ventajas importante:
 - Evitan URLs  escritas a mano.
 - Se adaptan automaticamente a cambios en rutas.
 - Integran validaciones y modelos.
 - Hacen el HTML mas expesivo.

 Por ejemplo, un enlace con TAG HELPERS se ajusta solo si cambia el nombre del controlador o la accion, sin necesidad de modificar la vista manualmante.

 Esto los hace ideales para aplicaciones MVC mantenibles y seguras.

 TAG HELPERS mas utilizados en MVC
 * asp-controller y asp-action
    - Para generar enlaces y redirecciones.
 * asp-for
    - Para enlazar campos del modelo con inputs.
 * asp-validation-for
    - Para mostrar mensajes de validacion.
 * asp-route-*
    - Para enviar parametros por la URL.



¿QUE SON LAS DATA ANNOTATIONS?
Las Data annotations son atributos que se aplican directamente sobre las propiedades de un modelo para definir reglas y comportamientos.

Se utilizan principalmente para:
 - Validar datos de entrada.
 - Definir restricciones.
 - Controlar como se muestran los datos.

 Las Data Annotations forman parte de:
 System.ComponentModel.DataAnnotations.
 Y permiten agregar validaciones sin escribir logica adicional en el controlador.


Las Data Annotations se colocan directamente sobre las propiedades del modelo:

* Campos ablicagorios.
* Longitud minima o maxima.
* Formato de datos.
* Mensaje personalizados

Estas reglas se aplican automaticamente cuando el modelo se envia desde una vista al controlador, ayudando a mantener datos consistentes y seguros.


BENEFICIOS DATA ANNOTATIONS:
Permiten:
- Centralizar las reglas del modelo.
- Reutilizar validaciones en toda la aplicacion.
- Integrarse con validaciones del lado cliente.
- Reducir codigo repetitivo en controladores.



EVOLUCION DE LA VERSIONES DE .NET
.NET ha evolucionado de forma constante, mantenniendo compatiblilidad y mejorando rendimiento en cada version.

* .NET unifico . NET FRAMEWORK, .NET CORE y XAMARIN.
* Cada version trae optimizaciones internas sin romper codigo existente.
* Las versiones LTS garantizan estabilidad a largo plazo.

Esto permite que:
- El mismo codigo MVC funcione en varias versiones.
- Los conveptos aprendidos sigan siendo validos.
- Las aplicaciones puedan actualizarse sin reescribirse.

Por eso, proyectos creados en .NET 8 o 9 Funcionan correctamente en .NET 10.


.NET 10 Y MEJORAS DE RENDIMIENTO.
Continua el enfoque de Microsoft en:

- Mejor rendimiento.
- Menor consumo de memoria.
- Arranque mas rapido de aplicaciones.

La mejoras en .NET 10 son principalmente internas:
- Optimizacion de runtime.
- Mejor manejo de memoria.
- Mejor rendimiento en aplicaciones web y APIs.

Para el desarrollador MVC:
- No hay cambios en la forma de programar.
- El codigo es el mismo.
- La aplicacion simplemente corre mejor.






CURSO ASP.NET CORE  10

-SEGURIDAD ASP.NET
- MIDDLEWARE
- ROUTING
- TAG HELPERS
- DATA ANNOTATATIONS
- EVOLUCION DE VERSIONES .NET

SECCION 2:
 - DEMO DE PROYECTO
 * CREACION DEL PROYECTO 


