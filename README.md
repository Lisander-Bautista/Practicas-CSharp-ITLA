# API REST con Autenticación JWT

## Descripción

Esta aplicación es una API REST desarrollada anteriormente en C# utilizando ASP.NET Core, la cual implementa autenticación mediante JSON Web Tokens (JWT). Permite gestionar usuarios y proteger los endpoints mediante un sistema de autenticación basado en tokens.

---

## Objetivo

Aplicar conceptos de seguridad en aplicaciones .NET mediante la implementación de autenticación JWT, validación de datos y protección de endpoints, garantizando el acceso seguro a los recursos.

---

## Tecnologías utilizadas

* C#
* ASP.NET Core Web API
* Entity Framework Core (InMemory)
* JWT (Json Web Tokens)
* Data Annotations
* Postman / Swagger

---

## Funcionalidades implementadas

* Autenticación de usuarios mediante JWT
* Generación de tokens seguros
* Endpoint para refrescar tokens
* Protección de endpoints con `[Authorize]`
* Validación de datos con DataAnnotations
* Encriptación de contraseñas usando SHA-256

---

## Cómo ejecutar el proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/Lisander-Bautista/Practicas-CSharp-ITLA.git
```

2. Abrir el proyecto en Visual Studio

3. Ejecutar la API

4. Acceder a:

```plaintext
https://localhost:7029
```

---

## Endpoints principales

---

### 🔹 1. Login (Obtener token)

**POST** `/api/auth/login`

#### Body:

```json
{
  "username": "admin",
  "password": "admin123"
}
```

#### Respuesta:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

<img width="1559" height="649" alt="Screenshot 2026-06-05 012622" src="https://github.com/user-attachments/assets/f2bf74f7-6892-48d3-a7f3-fd6689d86ca2" />

---

### 🔹 2. Refresh Token

**POST** `/api/auth/refresh`

#### Headers:

```plaintext
Authorization: Bearer TU_TOKEN
```

#### Respuesta:

```json
{
  "token": "nuevo_token"
}
```

<img width="1568" height="626" alt="Screenshot 2026-06-05 013323" src="https://github.com/user-attachments/assets/55b6d9fd-8b84-4687-bdcb-bcc32d0262ca" />

---

### 🔹 3. Obtener usuarios (PROTEGIDO)

**GET** `/api/usuarios`

#### Headers:

```plaintext
Authorization: Bearer TU_TOKEN
```

<img width="1570" height="547" alt="Screenshot 2026-06-05 013105" src="https://github.com/user-attachments/assets/fb491119-5cf0-4b5a-9e32-9325bd1349b5" />

---

## Seguridad implementada

* Uso de JWT para autenticación
* Tokens con expiración
* Protección de endpoints con `[Authorize]`
* Contraseñas encriptadas con SHA-256
* Validación de datos con DataAnnotations

---

## Estructura del proyecto

```plaintext
APIAplicacion/
│
├── Controllers/
│   ├── UsuariosController.cs
│   └── AuthController.cs
│
├── Models/
│   ├── Usuario.cs
│   └── LoginRequest.cs
│
├── Services/
│   └── JwtService.cs
│
├── Helpers/
│   └── HashHelper.cs
│
├── Data/
│   └── AppDbContext.cs
│
└── Program.cs
```

---

## Notas

* La base de datos es en memoria, por lo que los datos se reinician al detener la aplicación.
* Se recomienda probar los endpoints usando Postman.
