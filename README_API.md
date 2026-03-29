# TeChineoTuLomito API 🐾

## Descripción

Esta rama contiene la **API REST** de la clínica veterinaria **TeChineoTuLomito**, desarrollada en **C# .NET 8.0**.  
La API expone los **CRUDs** de las entidades principales del sistema (clientes, empleados, mascotas, procedimientos y procedimientos aplicados), además de un controlador de reportes para consultas específicas.  
La API se conecta con la base de datos definida en el repositorio:  
👉 [DataBaseTeChineoTuLomito](https://github.com/ferhm294/DataBaseTeChineoTuLomito)

## 📂 Estructura del Proyecto

- **Controllers/** → Controladores de la API que definen los endpoints REST.  
- **Models/** → Clases que representan las entidades de la base de datos.  
- **Data/** → Contexto de Entity Framework Core para la conexión con SQL Server.  
- **Program.cs** → Configuración inicial de la API, middlewares y servicios.  
- **appsettings.json** → Configuración de la aplicación (ej. cadena de conexión).  

## 🚀 Ejecución

1. Clonar el repositorio y cambiar a la rama **API**:
   ```bash
   git clone https://github.com/ferhm294/TeChineoTuLomitoWebApp.git
   cd TeChineoTuLomitoWebApp
   git checkout API
   ```

2. Restaurar dependencias:
   ```bash
   dotnet restore
   ```

3. Ejecutar la API:
   ```bash
   dotnet run
   ```

4. Abrir en el navegador o cliente REST:
   ```
   http://localhost:5000/swagger
   ```
   *(Swagger UI está habilitado gracias a **Swashbuckle.AspNetCore**)*

## 🛠️ Tecnologías Utilizadas

- **Lenguaje:** C#  
- **Framework:** .NET 8.0  
- **ORM:** Entity Framework Core (SQL Server)  
- **Documentación de API:** Swagger (Swashbuckle.AspNetCore)  
- **Entorno de desarrollo:** Visual Studio / Visual Studio Code  

## 📌 Endpoints

### Cliente
- `GET /api/Cliente` → Lista todos los clientes.  
- `GET /api/Cliente/{identificacion}` → Obtiene un cliente por identificación.  
- `POST /api/Cliente` → Crea un nuevo cliente.  
- `PUT /api/Cliente/{identificacion}` → Actualiza un cliente existente.  
- `DELETE /api/Cliente/{identificacion}` → Elimina un cliente.  

### Empleado
- `GET /api/Empleado` → Lista todos los empleados.  
- `GET /api/Empleado/{identificacion}` → Obtiene un empleado por identificación.  
- `POST /api/Empleado` → Crea un nuevo empleado.  
- `PUT /api/Empleado/{identificacion}` → Actualiza un empleado existente.  
- `DELETE /api/Empleado/{identificacion}` → Elimina un empleado.  

### Mascota
- `GET /api/Mascota` → Lista todas las mascotas.  
- `GET /api/Mascota/{id}` → Obtiene una mascota por ID.  
- `POST /api/Mascota` → Crea una nueva mascota.  
- `PUT /api/Mascota/{id}` → Actualiza una mascota existente.  
- `DELETE /api/Mascota/{id}` → Elimina una mascota.  

### Procedimiento
- `GET /api/Procedimiento` → Lista todos los procedimientos.  
- `GET /api/Procedimiento/{id}` → Obtiene un procedimiento por ID.  
- `POST /api/Procedimiento` → Crea un nuevo procedimiento.  
- `PUT /api/Procedimiento/{id}` → Actualiza un procedimiento existente.  
- `DELETE /api/Procedimiento/{id}` → Elimina un procedimiento.  

### ProcedimientoAplicado
- `GET /api/ProcedimientoAplicado` → Lista todos los procedimientos aplicados.  
- `GET /api/ProcedimientoAplicado/{id}` → Obtiene un procedimiento aplicado por ID.  
- `POST /api/ProcedimientoAplicado` → Registra un nuevo procedimiento aplicado (validando existencia de mascota y procedimiento).  
- `PUT /api/ProcedimientoAplicado/{id}` → Actualiza un procedimiento aplicado existente.  
- `DELETE /api/ProcedimientoAplicado/{id}` → Elimina un procedimiento aplicado.  

### Reporte
- `GET /api/Reporte/VacunacionProximaSemana` → Obtiene la lista de clientes con mascotas que requieren vacunación en la próxima semana.  

## 📜 Licencia

Licencia MIT  
Derechos de Autor (c) [2025] [Fernando Hernández]  
