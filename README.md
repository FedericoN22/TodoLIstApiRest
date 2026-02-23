# 📝 Todo List RESTful API

API RESTful desarrollada en **.NET 8** siguiendo buenas prácticas de arquitectura backend moderna.  
El proyecto implementa autenticación segura mediante **JWT** y protección de contraseñas usando **hashing**, simulando un backend real listo para producción.

---

## 🚀 Descripción

Esta API permite gestionar tareas (ToDo) con autenticación de usuarios.  
Cada usuario puede registrarse, iniciar sesión y administrar sus propias tareas protegidas mediante autorización basada en tokens.

El objetivo del proyecto fue practicar:

- Diseño de APIs REST
- Autenticación y autorización
- Seguridad backend
- Arquitectura limpia en Minimal APIs
- Persistencia de datos con Entity Framework Core

---

## 🧰 Tecnologías utilizadas

- **.NET 8**
- **ASP.NET Core Minimal API**
- **Entity Framework Core**
- **SQLite**
- **JWT (JSON Web Tokens)**
- **Password Hashing (BCrypt)**
- **Swagger / OpenAPI**

---

## 🔐 Autenticación y Seguridad

El proyecto implementa un flujo completo de autenticación profesional:

### 1️⃣ Registro de usuario
- El usuario crea una cuenta.
- La contraseña **NO se guarda en texto plano**.
- Se aplica hashing usando **BCrypt**.

```csharp
BCrypt.Net.BCrypt.HashPassword(password);
```

👉 Esto genera un hash irreversible que protege las credenciales incluso si la base de datos se filtra.

---

### 2️⃣ Login
- Se verifica la contraseña con:

```csharp
BCrypt.Net.BCrypt.Verify(password, storedHash);
```

- Si es válida, el servidor genera un **JWT**.

---

### 3️⃣ JWT (JSON Web Token)

El token contiene *claims* que identifican al usuario:

- UserId
- Username
- Expiration time

Ejemplo conceptual:

```
HEADER.PAYLOAD.SIGNATURE
```

El cliente debe enviar el token en cada request:

```
Authorization: Bearer <token>
```

---

### 4️⃣ Autorización

Los endpoints protegidos requieren autenticación:

```csharp
app.MapGet("/tasks", ...).RequireAuthorization();
```

Solo usuarios autenticados pueden acceder a sus tareas.

---

## 📂 Estructura del Proyecto

```
Todo-List-Restful-Api/
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Models/
│   ├── User.cs
│   └── TodoItem.cs
│
├── Endpoints/
│   ├── AuthEndpoints.cs
│   └── TodoEndpoints.cs
│
├── Services/
│   └── TokenService.cs
│
├── Program.cs
└── appsettings.json
```

---

## 📌 Funcionalidades

✅ Registro de usuario  
✅ Login con JWT  
✅ Hash seguro de contraseñas  
✅ CRUD completo de tareas  
✅ Endpoints protegidos  
✅ Documentación Swagger  

---

## ▶️ Cómo ejecutar el proyecto

### 1. Clonar repositorio

```bash
git clone https://github.com/FedericoN22/TodoLIstApiRest.git
```

### 2. Entrar al proyecto

```bash
cd Todo-List-Restful-Api
```

### 3. Restaurar dependencias

```bash
dotnet restore
```

### 4. Ejecutar migraciones

```bash
dotnet ef database update
```

### 5. Ejecutar API

```bash
dotnet run
```

---

## 🧪 Probar la API

Abrir Swagger:

```
https://localhost:<port>/swagger
```

Flujo recomendado:

1. Register
2. Login
3. Copiar JWT
4. Authorize en Swagger
5. Usar endpoints protegidos

---

## 🧠 Conceptos backend aplicados

- RESTful design
- Dependency Injection
- Authentication vs Authorization
- JWT Claims
- Password Hashing & Security
- Separation of concerns
- Minimal API architecture

---

## 📈 Posibles mejoras futuras

- Refresh Tokens
- Roles y Policies
- Logging estructurado
- Tests unitarios
- Dockerización
- Deploy en cloud

---

## 👨‍💻 Autor

**Federico Nuñez**

Proyecto realizado con fines educativos y portfolio backend.

---

⭐ Si te resulta útil, puedes darle una estrella al repositorio.
