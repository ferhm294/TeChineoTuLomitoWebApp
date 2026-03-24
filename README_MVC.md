# TeChineoTuLomito MVC 🐾

## Descripción

Esta rama contiene la aplicación web del administrador de la clínica veterinaria **TeChineoTuLomito**, desarrollada en **C# .NET Core** bajo el patrón **Model-View-Controller (MVC)**.  
El sistema permite gestionar clientes, empleados, mascotas y procedimientos veterinarios, conectándose con la base de datos definida en el repositorio:  
👉 [DataBaseTeChineoTuLomito](https://github.com/ferhm294/DataBaseTeChineoTuLomito)

## 📂 Estructura del Proyecto

- **Controllers/** → Controladores que gestionan la lógica de negocio y la comunicación con los modelos.  
- **Models/** → Definición de las entidades y clases que representan la información de la base de datos.  
- **Views/** → Vistas Razor para la interfaz de usuario.  
- **wwwroot/** → Archivos estáticos (CSS, JS, imágenes).  
- **Program.cs / Startup.cs** → Configuración inicial de la aplicación y servicios.  
- **appsettings.json** → Configuración de la aplicación (ej. cadena de conexión).  

## 🚀 Ejecución

1. Clonar el repositorio y cambiar a la rama **MVC**:
   ```bash
   git clone https://github.com/tuusuario/TeChineoTuLomitoWebApp.git
   cd TeChineoTuLomitoWebApp
   git checkout MVC
   ```

2. Restaurar dependencias:
   ```bash
   dotnet restore
   ```

3. Ejecutar la aplicación:
   ```bash
   dotnet run
   ```

4. Abrir en el navegador:
   ```
   http://localhost:5000
   ```

## 🛠️ Tecnologías Utilizadas

- **Lenguaje:** C#  
- **Framework:** .NET Core MVC  
- **Motor de vistas:** Razor  
- **Entorno de desarrollo:** Visual Studio / Visual Studio Code  
- **Base de datos:** SQL Server (repositorio externo)  

## 📌 Notas

- Esta rama está enfocada en la aplicación web del administrador.  
- La rama **API** contiene la implementación de la API REST con los CRUDs de la base de datos.  
- Cada rama tiene su propio README explicando su función.  

## 📜 Licencia

Licencia MIT  
Derechos de Autor (c) [2026] [Fernando Hernández]  
