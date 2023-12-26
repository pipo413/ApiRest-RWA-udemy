# ApiRest-CodePulse
## Sección 1
### Prerequisitos:
1. instalar .net sdk y .net runtime
1. instalar visual studio
1. instalar sql server
1. instalar visual studio code (y extenciones)
1. instalar Node.js
	1.Para utilizar angular es necesario descargar node.js en nuestro sistema 
1. Instalar Angular CLI
    1. `npm uninstall -g @angular/cli`
    1. `npm install -g @angular/cli@16.0.2`
    1. para comprobar la versión instalada `ng version`
## Sección 2
### Create new web api
1. creamos dos carpetas `mkdir API UI`
1. En visual studio creamos un nuevo proyecto *ASP.NET core Web APi*
### Entendiendo la arquitectura de carpetas
```
/Solucion
    -Proyecto 1
        --Properties
            --lunchSettings.json
        -- Controllers
            --c1
            --c2
            --...
        --appsettings.json
        --Program.cs
    -Proyecto 2


```

1. Una solución puede tener múltiples proyectos
1. Si hacemos click en uno de los proyecto se podrá ver las propiedades, el framework, etc. es más si utilizamos **NuGet** aquí podemos también ver esa información.
1. Archivo **lunchSettings.json** : aca se puede observar la configuración global del proyecto

1. Carpeta **Controllers** : aca se pueden observar los diferentes **endpoits** o **Controllers** de nuestra aplicación 

1. Archivo **appsettings.json** : es usado para la configuración del proyecto como ser el **conectionstring** de la bbdd 

1. Archivo **Program.cs** : Es el **entry point** de nuestra aplicación (Utiliza el **dependency inyection** como *pattern design*)

### Entendiendo REST y HTTP Verbs:
#### REST
**REST**, que significa Transferencia de Estado Representacional (Representational State Transfer, en inglés), es un estilo arquitectónico utilizado en el desarrollo de servicios web y sistemas distribuidos. 

Conceptos clave asociados con REST:

1. **Recursos**:
En el contexto de REST, un recurso es cualquier cosa identificable para la que se pueda definir un estado y que pueda ser manipulada a través de la red. Ejemplos de recursos incluyen datos, servicios, o cualquier entidad que tenga un identificador único.

1. **URI** (Identificador de Recurso Uniforme):
Cada recurso en un sistema *RESTful* tiene una *URI* única que lo identifica de manera única. Las *URI* *se utilizan para acceder y manipular los recursos*. Por ejemplo, en una API de usuarios, los recursos pueden ser representados por *URIs* como /usuarios/123.

1. **Operaciones HTTP**:
REST utiliza los métodos HTTP estándar para realizar operaciones en los recursos. Los métodos más comunes son:

**GET**: Recupera información del recurso.
**POST**: Crea un nuevo recurso.
**PUT** o **PATCH**: Actualiza un recurso existente.
**DELETE**: Elimina un recurso.

1. **Representación**:
La representación es la *forma en que un recurso se presenta* o se devuelve al cliente. Puede ser en formato JSON, XML, HTML, o cualquier otro formato de representación que ambas partes (cliente y servidor) entiendan.

1. **Estado de la Aplicación**:
RESTful no mantiene información sobre el estado de la sesión del cliente en el servidor entre solicitudes. Cada solicitud del cliente al servidor debe contener toda la información necesaria para comprender y procesar la solicitud. *La idea es que el servidor no guarda el estado del cliente entre solicitudes*.

1. **Sin Estado (Stateless)**:
Cada solicitud del cliente al servidor en un sistema RESTful debe contener toda la información necesaria para comprender y procesar la solicitud. El servidor no mantiene un estado sobre el cliente entre solicitudes.

1. **HATEOAS** (Hypermedia As The Engine Of Application State):
HATEOAS es un principio que sugiere que la interfaz de una aplicación debe ser descubrible por el cliente a través del hipervínculo dinámico proporcionado en las aplicaciones dentro de los datos servidos. En otras palabras, *el cliente interactúa con la aplicación exclusivamente a través de hipermedios proporcionados de manera dinámica por las aplicaciones* servidas de las aplicaciones recopiladas en la ejecución de la aplicación alojada.

El enfoque REST se utiliza comúnmente en la implementación de servicios web y APIs (interfaces de programación de aplicaciones) debido a su simplicidad, escalabilidad y facilidad de uso. Es una opción popular para construir aplicaciones distribuidas y servicios web debido a su enfoque ligero y basado en estándares HTTP.

### Etendiendo routing en asp.net core web api




En ASP.NET Core Web API, el enrutamiento (routing) es el proceso de asignar las solicitudes HTTP entrantes a los controladores y acciones correspondientes. El sistema de enrutamiento es fundamental para definir cómo se estructuran las URLs y cómo se relacionan con las acciones en tus controladores.

Aquí hay una descripción básica de cómo funciona el enrutamiento en ASP.NET Core Web API:

1. **Configuración del Enrutamiento**:
El enrutamiento en ASP.NET Core Web API se configura en la clase **Startup** en el método **ConfigureServices** mediante el uso del servicio **AddControllers** y, opcionalmente, configurando las opciones de enrutamiento.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
}
```
2. **Definición de Rutas**:
Las rutas se definen en el método Configure de la clase Startup. La configuración predeterminada incluye una ruta por defecto que sigue la convención `{controller}/{action}/{id?}`.

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```
Puedes personalizar las rutas y los parámetros de la ruta utilizando el método MapControllerRoute en lugar de MapControllers si necesitas una configuración de enrutamiento más específica.

1. **Controladores y Acciones**:
Los controladores en ASP.NET Core Web API son clases que contienen métodos (acciones) que responden a las solicitudes HTTP. La convención por defecto es {controller}/{action}/{id?}, lo que significa que el nombre del controlador y el nombre de la acción en el controlador determinan la ruta.

```csharp
[ApiController]
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // Lógica de la acción
        return Ok("Hello from Get method!");
    }
}
```
En este ejemplo, la acción Get del controlador MyController responderá a las solicitudes HTTP GET en la ruta /api/my.

Atributos de Ruta:
También puedes utilizar atributos de ruta para personalizar las rutas en tus controladores y acciones.


```csharp
[ApiController]
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        // Lógica de la acción
        return Ok($"Hello from GetById method with id {id}!");
    }
}
```
En este ejemplo, la acción GetById responderá a las solicitudes HTTP GET en la ruta `/api/my/123`, donde 123 sería el valor del parámetro id.

Estos son solo conceptos básicos del enrutamiento en ASP.NET Core Web API. Puedes realizar configuraciones más avanzadas según tus necesidades específicas, como enrutamiento basado en atributos, restricciones, y más. La documentación oficial de Microsoft sobre enrutamiento en ASP.NET Core es una excelente referencia para obtener más detalles y ejemplos: Routing en ASP.NET Core.

### Estructura del proyecto:

El proyecto manejará blogs, que cada blog tendrá los siguientes datos:

1. **Blogs**

| Propiedad          | Type              | Nullable  |
| ------------------ | ----------------- | --------- |
| Id                 | int               | No        |
| Title              | varchar(max)      | No        |
| ShortDescription   | varchar(max)      | No        |
| Content            | text              | No        |
| UrlHandle          | varchar(max)      | No        |
| FeaturedImageUrl   | varchar(max)      | No        |
| DateCreated        | datetime          | No        |
| Author             | varchar(max)      | No        |
| IsVisible          | bit               | No        |

1. **Las categorías de los blogs serán:**

| Category           | Type              | Nullable  |
| ------------------ | ----------------- | --------- |
| Id                 | int               | No        |
| Name               | varchar(max)      | No        |
| UrlHandle          | varchar(max)      | No        |

1. Las relaciones entre las tablas serán : 
    
    *Many to Many* esto quiere decir que:

    1. 1 categoría puede tener muchos blogpost 
    1. 1 blogpost puede tener muchos categorías

### Creando los Domain models.

1. En visual studio:
    1. Creamos una nueva carpeta dentro del proyecto **Models** y dentro otra carpeta dentro **domains** y creamos las clases (blogpost y category) quedando:

    ```
    /Solution CodePulse_API
    -CodePulse_API
        --Properties
            --lunchSettings.json
        -- Controllers
            --c1
            --c2
            --...
        -- Models
            -- Domain
                --BLogPost.cs
                --Category.cs
        --appsettings.json
        --Program.cs
    -Proyecto 2

    ``` 

    Luego dentro de BLogPost.cs y Category.cs asignamos las propiedades de los modelos según la tabla.

```csharp
    namespace CodePulse_API.Models
{
    public class BlogPost
    {
        public  Guid Id { get; set; }
        public  string Title { get; set; }
        public  string ShortDescription { get; set; }
        public  string Content { get; set; }
        public  string FeaturedImageURL { get; set; }
        public  string UrlHandle { get; set; }
        public  DateTime PublishedDate { get; set; }
        public  string Author { get; set; }
        public  bool IsVisible { get; set; }
    }
}
```

y

```csharp
namespace CodePulse_API.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public string UrlHandle{ get; set; }
    }
}
```

### Instalando los paquetes de Nuget
1) Entity Framework Core (instalar entityframeworkcore.sqlserver y .tools)

### entendiendo y creando dbcontext class

En **ASP.NET Core**, DbContext es una clase fundamental cuando trabajas con Entity Framework Core (EF Core), que es un framework de mapeo objeto-relacional (ORM). Su principal responsabilidad es facilitar la conexión y la interacción con la base de datos a través de modelos de datos en forma de clases de C#.

#### Representación de la Base de Datos:

La clase que hereda de **DbContext** actúa como una representación en código de tu base de datos. Cada instancia de esta clase representa una "sesión" con la base de datos.
Definición de Modelos:

Dentro de la clase **DbContext**, defines *propiedades* que representan *conjuntos de datos específicos* (tablas en la base de datos). Cada conjunto de datos se representa mediante una propiedad de tipo **`DbSet<T>`**, donde T es la entidad que corresponde a una tabla en la base de datos.

```csharp
public class BlogDbContext : DbContext
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    // Otros DbSets y configuraciones...
}
```

1. **Configuración de Conexión a la Base de Datos**:

    DbContext también *se encarga de la configuración de la conexión* a la base de datos. Puedes especificar el tipo de base de datos, la cadena de conexión y otras configuraciones relacionadas.

    ```csharp
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("cadenaDeConexion");
    }
    ```

1. **Migraciones y Actualizaciones de la Base de Datos:**

    Una de las funcionalidades poderosas de **DbContext** es que te permite trabajar con migraciones. Puedes modificar tu modelo de datos en código y luego generar automáticamente scripts de migración para aplicar esos cambios a la base de datos.

    ```bash
    dotnet ef migrations add MiMigracion
    dotnet ef database update
    ```
    
1. **Operaciones CRUD (Crear, Leer, Actualizar, Eliminar):**

    **DbContext** facilita las operaciones CRUD en la base de datos. Puedes utilizar métodos como **Add, Find, Update y Remove** para realizar estas operaciones en tus entidades.

    ```csharp
    var nuevoBlogPost = new BlogPost { Title = "Nuevo Post", Content = "Contenido..." };
    dbContext.BlogPosts.Add(nuevoBlogPost);
    dbContext.SaveChanges();
    ```


~~~
En resumen, **DbContext en ASP.NET Core** proporciona una interfaz para interactuar con la base de datos utilizando modelos de datos en C#. Facilita la configuración de la conexión a la base de datos, define modelos de datos y ofrece herramientas para realizar operaciones CRUD y gestionar cambios en el esquema de la base de datos.
~~~

#### Creando un dbcontext
1. Creamos una carpeta **Data** dentro del proyecto y dentro creamos la clase **ApplicationDbContext.cs** 

    ```
    /Solution CodePulse_API
    -CodePulse_API
        --Properties
            --lunchSettings.json
        -- Controllers
            --c1
            --c2
            --...
        -- Data
            --ApplicationDbContext.cs
        -- Models
            -- Domain
                --BLogPost.cs
                --Category.cs
        --appsettings.json
        --Program.cs
    -Proyecto 2
    ```
    y hacemos que **ApplicationDbContext.cs**  herede de **DbContext** , Luego creamos el contructor de la clase y a demás las propiedades, que son de type dbset y reciben como parametro un objeto que serán nuestros modelos de tablas.
    ```csharp
    using CodePulse_API.Models;
    using Microsoft.EntityFrameworkCore;

    namespace CodePulse_API.Data
    {
        public class ApplicationDbContext : DbContext
        {
            // Creamos el contructor con opciones
            public ApplicationDbContext(DbContextOptions options) : base(options)
            {
            }

            // Creamos las propiedades
            // el tipo DbSet recibe como objeto nuestros modelos de db que son Data/Models/BlogPost.cs y  Data/Models/Category.cs
            public DbSet<BlogPost> BlogPosts{ get; set; }
            public DbSet<Category> Categories { get; set; }
        }
    }
    ```

### Creando con conection string 

1. Entramos  a **appsettings.json**
1. Creamos un nuevo objeto debajo de "AllowedHosts" que sea  ```"ConnectionStrings":{"CodePulseConnectionString":"(...)"}```
Este objeto recibe como params un dicionario de tipo keyvalue donde podemos poner múltiples conection strings. en "(...)" vamos a colocar el conection string que dependerá de nuestra ddbb por ejemplo 
```"Data Source=NombreServidor;Initial Catalog=NombreBaseDeDatos;User Id=NombreUsuario;Password=TuContraseña;"```

    También puede usarse ```"Server=NombreServidor;Initial Catalog=NombreBaseDeDatos;User Id=NombreUsuario;Password=TuContraseña;"```

    También puede usarse ```"Server=NombreServidor;;Database=NombreBaseDeDatos;TrustServerCertificate=True;Trusted_Connection=True;"```

### Utilizando Dependency Injecction

    La Inyección de Dependencias (Dependency Injection, DI) es un patrón de diseño ampliamente utilizado en el desarrollo de software y se implementa de manera nativa en ASP.NET Core y Entity Framework Core. Aquí tienes un resumen de Dependency Injection en el contexto de .NET con Entity Framework Core:

1. **¿Qué es Dependency Injection?**

    Dependency Injection es un patrón en el que las dependencias de un componente se suministran desde el exterior. En lugar de que un componente cree sus propias dependencias, se le proporcionan desde el exterior, generalmente a través de un contenedor de inversión de control (IoC).

2. **IoC Container en ASP.NET Core:**

    En ASP.NET Core, el contenedor de inversión de control (IoC) está integrado y se puede acceder a través de la interfaz IServiceProvider. ASP.NET Core utiliza el patrón de diseño de contenedor IoC para gestionar las instancias de servicios y facilitar la inyección de dependencias.

3. **Inyección de Dependencias en Controladores y Servicios**:

    En ASP.NET Core, puedes usar la inyección de dependencias directamente en los controladores y servicios. Por ejemplo, en un controlador, puedes solicitar un servicio a través del constructor y ASP.NET Core se encargará de proporcionar la instancia.

    ```csharp
    public class MiController : Controller
    {
        private readonly IMiServicio _miServicio;

        public MiController(IMiServicio miServicio)
        {
            _miServicio = miServicio;
        }

        // Resto del código...
    }```

4. **Entity Framework Core y Inyección de Dependencias:**

    Entity Framework Core se integra de manera natural con la inyección de dependencias. Puedes inyectar instancias de tu DbContext en tus servicios o controladores.

    ```csharp
    public class MiServicio : IMiServicio
    {
        private readonly MiDbContext _dbContext;

        public MiServicio(MiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Resto del código...
    }```

5. **Configuración de Servicios en Startup:**

    En la clase Startup, puedes configurar tus servicios y sus implementaciones. Esto se hace mediante el método ConfigureServices, donde registras tus servicios y sus implementaciones en el contenedor IoC.

   ``` csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MiDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient<IMiServicio, MiServicio>();
        // Otros servicios...
    }```

6. **Ámbito de Servicios:**

    Puedes configurar la duración (alcance) de tus servicios, como AddTransient, AddScoped, o AddSingleton, dependiendo de si deseas que se cree una nueva instancia cada vez, una por solicitud, o una única instancia para toda la aplicación.
   ``` csharp
    services.AddTransient<IMiServicioTransient, MiServicioTransient>();
    services.AddScoped<IMiServicioScoped, MiServicioScoped>();
    services.AddSingleton<IMiServicioSingleton, MiServicioSingleton>();
    ```
    ~~~
    La inyección de dependencias es una parte integral del desarrollo en ASP.NET Core y se extiende naturalmente a Entity Framework Core. Proporciona una forma eficiente y organizada de manejar las dependencias y facilita la creación de aplicaciones más mantenibles y testeables.
    ~~~

---
Explicado con comida
---
usando el ejemplo de un restaurante, con comida real en lugar de servicios abstractos.

1. Registro de Platos (Comida):

Antes de abrir el restaurante, decides qué platos (comida) vas a ofrecer. Cada plato es un tipo de comida específico.

```csharp
// Registra los platos en el menú (registra los tipos de comida)
services.AddTransient<IComida, Pizza>();     // Comida tipo Pizza
services.AddTransient<IComida, Ensalada>();  // Comida tipo Ensalada
```
Aquí dices: "Cuando alguien pida comida ('IComida'), puede ser tanto una 
'Pizza' como una 'Ensalada'".

2. Pedir Comida en el Controlador (o en otro lugar):

Ahora, cuando alguien en tu restaurante (tu aplicación) tiene hambre, pide los tipos de comida que desee.
```csharp

public class MiControlador : Controller
{
    private readonly IEnumerable<IComida> _comidas;

    // ASP.NET Core proporcionará automáticamente los tipos de comida que has registrado
    public MiControlador(IEnumerable<IComida> comidas)
    {
        _comidas = comidas;
    }

    // Ahora puedes ofrecer diferentes tipos de comida a tus clientes
}
```

Aquí dices: "Cuando alguien tiene hambre en este controlador, dame todos los tipos de comida que estén disponibles".

3. Ciclo de Vida de los Tipos de Comida:

Además, decides cómo se deben preparar los platos. Puedes hacer uno nuevo cada vez que alguien lo pida, usar el mismo plato para todos en la misma "mesa", o hacer un plato único para que todos en el restaurante lo compartan.
```csharp
// Opciones para cómo se preparan los platos
services.AddTransient<IComida, ComidaNueva>();        // Una comida nueva cada vez
services.AddScoped<IComida, ComidaPorMesa>();         // Una comida compartida por mesa
services.AddSingleton<IComida, ComidaCompartida>();   // Una comida compartida por todos
```

Aquí dices: "Cuando alguien pida comida, ¿quieres que sea una nueva cada vez, compartida por mesa o compartida por todos?".
~~~
En resumen, la Inyección de Dependencias (DI) en ASP.NET Core, representada con la analogía de un restaurante, es como gestionar un menú de platos de comida. Registras los tipos de comida que ofreces, y cuando alguien tiene hambre, simplemente pides los tipos de comida que deseas, y la cocina (contenedor IoC) se encarga de prepararlos según tus preferencias (ciclo de vida).
~~~

#### Construcción en la app 

1. Tal como vimos en el ejemplo primeo vamos a **Program.cs** y ahí(antes que la aplicación se construya ```var app = buildier.Build()``` ) tenemos la ID entonces agregamos la intanciación de DbContext de la siguiente manera:

```cSharp
(...)
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Aquí lo agregamos
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CodePulseConnectionString")));

var app = builder.Build();
(...)
```

Tal como vimos en el ejemplo del restaurante, aquí estamos registrando servicios en el contenedor de DI (En este contexto y generalmente el contenedor "services" refiere al contenedor de DI), y cuando tu aplicación necesite trabajar con estos servicios (controladores, Swagger, DbContext), la DI proporcionará automáticamente las instancias correspondientes. Esto hace que tu código sea más modular y fácil de mantener, ya que las dependencias están claramente definidas y gestionadas por el contenedor DI.


## Running EF Core Migrations (EntityFramework)
1. Fantásticamente podemos luego de hacer toda la contrucción del contexto podemos aplicar el comando de migración, esto nos genera un archivo de generación de tablas en cs que luego podemos correr y esto nos va a crear las tablas necesarias en nuestra DB, esto lo hacemos de la sieguiente manera 
    Nota: los comandos deben ser corridos en la consola de Nuget [Herramientas -> Administrador de paquetes de nuguet -> Consola del administrador de paquetes]
    1. PRimero corremos el comando de migrations : 
        ```bash
        Add-Migration "Name Of Migration" 
        ```
        (Por ejemplo ponemos el nombre de Initial Migration)
        en esta etapa vamos a ver que se crea una capeta nueva en el proyecto "Migrations" y luego se ejecu
    2. Cuando corremos el comando ```Update-Database``` en la misma consola lo que sucederá es que se ejecutará el código del archivo generado en la carpeta de Migrations creando la tabla si ésta no existe.   

## **Creando los controllers**
1. en la carpeta de controllers agregamos controllers del tipo de planti "API Controlleer - empty" 
    ~~~
    NOTA: Al crear el nombre es importante mantener el "Controller.cs" en el nombre es decir en esta caso podemos hacer "CategoryController.cs"
    ~~~

## **DTO**


Un DTO (Data Transfer Object) es un patrón de diseño utilizado para transportar datos entre componentes de un sistema, especialmente entre la capa de presentación y la capa de servicio o persistencia. Su propósito principal es encapsular datos y transferirlos eficientemente, minimizando la cantidad de información transmitida.

1. Principales características de un DTO:

    **Encapsulación de Datos:** Un DTO encapsula datos y proporciona una interfaz simple para acceder a ellos. Solo contiene propiedades y no debería contener lógica de negocio.

    **Transferencia Eficiente:** Se utiliza para transferir datos entre capas de una aplicación, especialmente en situaciones en las que se requiere enviar un conjunto específico de datos y no la entidad completa.

    **Independiente del Contexto de Persistencia:** Los DTOs son independientes del contexto de persistencia (base de datos). Pueden contener solo los datos relevantes para una operación específica, sin cargar datos innecesarios.

    **Serializable:** Los DTOs suelen ser serializables, lo que facilita su transporte a través de la red o su almacenamiento en un formato que puede ser recuperado posteriormente.

    **Inmutable (Opcional):** A veces, se diseñan como objetos inmutables para garantizar que los datos no cambien una vez que se han creado.

Ejemplo en código (C#):

```csharp
public class OrderDTO
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
}
```
En este ejemplo, OrderDTO es un DTO que encapsula datos relacionados con una orden. Se podría utilizar para transferir información específica de una orden entre capas de la aplicación, como desde la capa de servicios hasta la capa de presentación.

1. Ventajas y desventajas:

    | Aspecto                                | Ventajas                                                                                                                                                             | Desventajas                                                                                                                    |
    |----------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|
    | **Reducción de la Sobrecarga de Datos** | - Eficiencia en la transferencia de datos. <br/> - Minimiza el tráfico de red.                                                                                     | - Requiere el diseño y mantenimiento de DTOs adicionales.                                                                     |
    | **Separación de Responsabilidades**     | - Aísla la lógica de presentación de la lógica de negocio. <br/> - Mejora la modularidad del código.                                                            | - Aumenta la complejidad al introducir una capa adicional de abstracción.                                                     |
    | **Versionado y Evolución Independiente** | - Permite cambios graduales en diferentes capas. <br/> - Facilita la evolución independiente.                                                                     | - Requiere gestión cuidadosa de versiones si hay cambios significativos.                                                       |
    | **Optimización del Rendimiento**        | - Selecciona específicamente los datos necesarios. <br/> - Mejora el rendimiento, especialmente en entornos distribuidos.                                         | - Puede generar una mayor complejidad al tener múltiples DTOs para diferentes operaciones.                                     |
    | **Seguridad y Control de Acceso**       | - Facilita la exposición selectiva de datos. <br/> - Aumenta el control sobre el acceso a la información.                                                         | - Puede introducir complejidades adicionales al manejar la seguridad a nivel de DTO.                                        |
    | **Facilita la Implementación de Interfaces de Usuario** | - Estructura datos de manera eficiente para la interfaz de usuario. <br/> - Adaptabilidad a requisitos específicos de presentación.                          | - Puede requerir un mapeo entre DTOs y entidades, lo que añade complejidad.                                                  |
    | **Flexibilidad en la Representación de Datos** | - Adapta la estructura del DTO según las necesidades de operación. <br/> - Mayor flexibilidad en la representación de datos.                                    | - Requiere un diseño cuidadoso para no comprometer la consistencia de los datos.                                               |
    | **Mejora la Cohesión y Claridad del Código** | - Centra el código en datos necesarios para una tarea específica. <br/> - Mejora la cohesión del código. <br/> - Mayor claridad en la estructura del código. | - Puede resultar en la creación de numerosos DTOs si no se planifica adecuadamente.                                          |
    | **Facilita la Documentación y Entendimiento del Sistema** | - Define contratos claros para la transferencia de datos. <br/> - Facilita la documentación del sistema.                                                     | - Introduce una capa adicional que debe entenderse y documentarse.                                                            |
    | **Compatibilidad con Diversos Clientes** | - Permite adaptar la información para diferentes clientes. <br/> - Mayor flexibilidad en la presentación de datos.                                             | - Puede aumentar la complejidad si hay muchos clientes con requisitos diferentes.                                           |
    | **Seguridad y Control de Acceso**       | - Facilita la exposición selectiva de datos. <br/> - Aumenta el control sobre el acceso a la información.                                                         | - Puede introducir complejidades adicionales al manejar la seguridad a nivel de DTO.                                        |




## **Creando el método Post**

1. En el archivo de controlador **CategoriesController.cs** agregamos el método **httpPost** ahora bien al método que va a ejecutar el verbo post "CreateCategory" necesita como argumentos estos DTO ***NUNCA PASAR AQUI LOS MODELOS DIRECTAMENTE***, para esto...
2. Creamos la carpeta **DTO** donde aquí haremos la selección y el manejo de los datos entre el cliente y la api. dentro creamos  ```CreateCategoryRequestDto.cs``` 
3. Si nos fijamos en models/domain el modelo de category tiene el id /name /urlhandle pero no queremos permitirle al usuario la interacción con el id enonces en la DTO vamos a tener sólo estas propiedades.
    ```csharp
        namespace CodePulse_API.Models.DTO
    {
        public class CreateCategoryRequestDTO
        {
            public string Name { get; set; }
            public string UrlHandle { get; set; }
        }
    }
    ```

4. Luego en la parte del controller le pasamos
    ```csharp
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using CodePulse_API.Models.DTO
    namespace CodePulse_API.Controllers
    {
        //https://localhost:xxxx/api/categories
        [Route("api/[controller]")]
        [ApiController]
        public class CategoriesController : ControllerBase
        {
            [HttpPost]
            public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO request)
            {
                //aca va a mapear DTO a un Domain Model

            }
        }
    }
    ```

* Nota: ```request``` es una convención para referirse a los datos de la solicitud HTTP y facilita la comprensión del propósito del parámetro en el contexto de un controlador de API.