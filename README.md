# Registro de Usuarios con Logs en Archivo (JSON)

## Descripción

En esta práctica se amplió la funcionalidad de la API REST desarrollada previamente, implementando un sistema de registro de usuarios que, además de almacenar la información en la base de datos, genera un **log en formato JSON** en un archivo de texto por cada nuevo usuario registrado. 

También se implementó un endpoint que permite consultar el historial de logs almacenados.

---

## Objetivos

* Registrar usuarios en la base de datos.
* Generar un log en archivo por cada usuario registrado.
* Almacenar los logs en formato JSON.
* Permitir consultar el historial de logs mediante un endpoint.

---

## Tecnologías Utilizadas

* C#
* ASP.NET Core Web API
* Entity Framework Core (InMemory)
* LINQ
* JWT (Json Web Tokens)
* Data Annotations
* Swagger / Postman

---

## Modelo de Usuario

### El modelo de usuario incluye:

* Id
* Username
* Password (encriptado con SHA-256)
* Nombre
* Correo
* FechaDeNacimiento

---

## Sistema de Logs

Cada vez que se registra un usuario:

✔ Se guarda en la base de datos

✔ Se genera un registro en archivo `logs_usuarios.txt`

---

## Archivo de Logs

* Nombre: `logs_usuarios.txt`
* Formato: JSON (una línea por registro)
* Se crea automáticamente si no existe
* No sobrescribe datos, solo agrega nuevos registros

---

## Endpoints

### Autenticación

| Método | Endpoint        | Descripción       |
| ------ | --------------- | ----------------- |
| POST   | /api/auth/login | Generar token JWT |

---

### Usuarios

| Método | Endpoint           | Descripción                       |
| ------ | ------------------ | --------------------------------- |
| POST   | /api/usuarios      | Registrar usuario (público)       |
| GET    | /api/usuarios      | Obtener usuarios (requiere token) |
| GET    | /api/usuarios/{id} | Obtener usuario por ID            |
| PUT    | /api/usuarios/{id} | Actualizar usuario                |
| DELETE | /api/usuarios/{id} | Eliminar usuario                  |

---

### Logs

| Método | Endpoint           | Descripción               |
| ------ | ------------------ | ------------------------- |
| GET    | /api/usuarios/logs | Obtener historial de logs |

---

## Cómo Probar la API (Postman / Swagger)

### 🔹 1. Obtener Token

```plaintext
POST /api/auth/login
```

```json
{
  "username": "admin",
  "password": "admin123"
}
```

<img width="1043" height="469" alt="image" src="https://github.com/user-attachments/assets/a98e99c7-539d-448f-a7ee-c13ea00d7054" />

---

### 🔹 2. Registrar Usuario (✔ No requiere token)

```plaintext
POST /api/usuarios
```

```json
{
  "username": "victor",
  "password": "1234",
  "nombre": "Victor",
  "correo": "victor@test.com"
}
```

<img width="1047" height="596" alt="image" src="https://github.com/user-attachments/assets/400a5012-c14c-4335-9c62-ded1a281e154" />

---

### 🔹 3. Obtener Usuarios

```plaintext
GET /api/usuarios
```

<img width="1049" height="515" alt="image" src="https://github.com/user-attachments/assets/77ad59ca-63e6-4dd6-aeb6-5a0906d90f54" />

Header:

```plaintext
Authorization: Bearer TU_TOKEN
```

<img width="1041" height="189" alt="image" src="https://github.com/user-attachments/assets/6f4d689a-b905-45ab-b3fa-bdaa13686fd9" />

---

### 🔹 4. Obtener Logs

```plaintext
GET /api/usuarios/logs
```

<img width="1050" height="851" alt="image" src="https://github.com/user-attachments/assets/8f6dc731-8fe2-4ffe-acaa-ef5999128bc3" />

---

## Estructura del Proyecto

```
APIAplicacion/
│
├── Controllers/
│   ├── UsuariosController.cs
│   └── AuthController.cs
|   └── CategoriasController.cs
|   └── ProveedoresController.cs
|   └── ProductosController.cs
│
├── Models/
│   ├── Usuario.cs
│   └── LoginRequest.cs
│   ├── Categoria.cs
│   ├── Producto.cs
│   ├── Proveedor.cs
│
├── Services/
│   └── JwtService.cs
│   └── LogService.cs
│
├── Helpers/
│   └── HashHelper.cs
│
├── Data/
│   └── AppDbContext.cs
│
└── Program.cs
└── logs_usuarios.txt
```

---

## Consideraciones

* La base de datos es InMemory (se reinicia al reiniciar la app).
* Los logs permanecen en el archivo aunque la aplicación se reinicie.
* Se ignoran errores de lectura en líneas corruptas del archivo.

---
