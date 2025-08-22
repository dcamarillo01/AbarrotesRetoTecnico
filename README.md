Instrucciones de ejecución 
1️⃣ Crear la base de datos

Ejecuta el script script.sql que viene en el repositorio en tu SQL Server. Esto creará la base de datos AbarrotesDB junto con sus tablas y datos iniciales.

2️⃣ Hacer Scaffolding a base de datos.

🛠️ Scaffolding (DB-First)

1-En Visual Studio, ve a la pestaña Tools (Herramientas) → NuGet Package Manager → Package Manager Console. 2-En la consola que se abre en la parte inferior, asegúrate de seleccionar el proyecto DataLayer en el desplegable Default Project (Proyecto predeterminado). 3-Ejecuta el siguiente comando, cambiando los datos de conexión por los de tu base de datos:

Scaffold-DbContext "Server=YourServer;Database=AbarrotesDB;TrustServerCertificate=true;User ID=yourUser;Password=yourPassword;" Microsoft.EntityFrameworkCore.SqlServer

3️⃣ Configurar la cadena de conexión

1.En la capa ServiceLayer se ecnuentra el archivo appsettings.json 2.En ese archivo agregar el connection string cambiando los datos de conexion por los de tu base de datos:

{ "ConnectionStrings": { "AbarrotesBD": "Server=localhost; Database=AbarrotesDB;User Id=yourID;Password=yourpassword;TrustServerCertificate=True;" } }
