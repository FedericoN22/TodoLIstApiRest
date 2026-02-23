# 🔐 Todo List RESTful API

RESTful API desarrollada con **ASP.NET Core (.NET 8)** para la gestión
de tareas (Todo List), implementando autenticación y autorización
mediante **JWT (JSON Web Tokens)** y control de acceso basado en roles.

El proyecto fue creado como práctica backend para aplicar diseño de APIs
modernas, seguridad y organización profesional de endpoints usando
**Minimal APIs**.

------------------------------------------------------------------------

## 🚀 Features

-   ✅ Registro de usuarios
-   🔐 Login con JWT
-   🪪 Autenticación mediante Bearer Token
-   👮 Autorización basada en roles
-   📝 CRUD completo de tareas
-   🧱 Arquitectura modular por endpoints
-   📦 Uso de DTOs para transferencia de datos
-   🗄️ Persistencia con Entity Framework Core + SQLite
-   📑 Swagger configurado con autenticación JWT

------------------------------------------------------------------------

## 🛠️ Tecnologías utilizadas

-   **.NET 8**
-   **ASP.NET Core Minimal API**
-   **Entity Framework Core**
-   **SQLite**
-   **JWT Authentication**
-   **Swagger / OpenAPI**
-   C#

------------------------------------------------------------------------

## 📂 Estructura del proyecto

    Todo-List-Restful-Api/
    │
    ├── DTOs/              # Objetos de transferencia de datos
    │   ├── ItemDto.cs
    │   └── UserDto.cs
    │
    ├── Entitys/           # Entidades de base de datos
    │   ├── TODO-Item.cs
    │   └── User.cs
    │
    ├── Endpoints/
    │   ├── User/
    │   │   ├── Register.cs
    │   │   └── Login.cs
    │   │
    │   ├── Item/
    │   │   └── Item.cs
    │   │
    │   └── Admin/
    │       └── AdminEnd.cs
    │
    ├── Migrations/
    ├── ApplicationDbContext.cs
    ├── Program.cs
    └── appsettings.json

------------------------------------------------------------------------

## 🔐 Autenticación JWT

La API utiliza **JSON Web Tokens** para autenticar usuarios.

### Flujo de autenticación

1.  Usuario se registra (`/user/register`)
2.  Usuario inicia sesión (`/user/login`)
3.  La API genera un **JWT**
4.  El cliente envía el token en cada request:

```{=html}
<!-- -->
```
    Authorization: Bearer {token}

El token incluye claims:

-   UserId
-   Username
-   Role

------------------------------------------------------------------------

## 👮 Autorización por Roles

El sistema implementa control de acceso mediante roles almacenados en la
base de datos.

Ejemplo:

-   `USER` → acceso a operaciones básicas
-   `ADMIN` → endpoints administrativos protegidos

------------------------------------------------------------------------

## 📡 Endpoints principales

### 👤 Usuario

  Method   Endpoint           Descripción
  -------- ------------------ -------------------
  POST     `/user/register`   Registrar usuario
  POST     `/user/login`      Obtener JWT

### 📝 Tasks

  Method   Endpoint        Descripción
  -------- --------------- ------------------
  GET      `/items`        Obtener tareas
  POST     `/items`        Crear tarea
  PUT      `/items/{id}`   Actualizar tarea
  DELETE   `/items/{id}`   Eliminar tarea

### 🔒 Admin

Endpoints protegidos mediante autorización por rol.

------------------------------------------------------------------------

## ⚙️ Configuración y ejecución

### 1️⃣ Clonar repositorio

``` bash
git clone https://github.com/FedericoN22/TodoLIstApiRest.git
```

### 2️⃣ Entrar al proyecto

``` bash
cd TodoLIstApiRest/Todo-List-Restful-Api
```

### 3️⃣ Restaurar dependencias

``` bash
dotnet restore
```

### 4️⃣ Aplicar migraciones

``` bash
dotnet ef database update
```

### 5️⃣ Ejecutar la API

``` bash
dotnet run
```

------------------------------------------------------------------------

## 🧪 Probar la API

Abrir Swagger:

    https://localhost:<port>/swagger

1.  Hacer login
2.  Copiar el token
3.  Click en **Authorize**
4.  Pegar:

```{=html}
<!-- -->
```
    Bearer TU_TOKEN

------------------------------------------------------------------------

## 🧠 Conceptos aplicados

-   Minimal APIs pattern
-   JWT authentication
-   Claims & Roles authorization
-   Entity Framework Core
-   DTO pattern
-   Endpoint modularization
-   RESTful design

------------------------------------------------------------------------


## 👨‍💻 Autor

**Federico Núñez**

GitHub: https://github.com/FedericoN22

------------------------------------------------------------------------

## 📄 License

Proyecto educativo para aprendizaje backend.

https://roadmap.sh/projects/todo-list-api
