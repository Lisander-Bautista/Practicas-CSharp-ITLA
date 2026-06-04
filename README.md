# API REST - Gestión de Usuarios

## Descripción

Esta aplicación es una API REST desarrollada en C# utilizando ASP.NET Core y Entity Framework. Permite gestionar usuarios mediante operaciones CRUD (Crear, Leer, Actualizar y Eliminar).

---

## Objetivo

Implementar una API REST funcional aplicando buenas prácticas de desarrollo, uso de Entity Framework y validaciones de negocio.

---

## Tecnologías utilizadas

* ASP.NET Core Web API
* Entity Framework Core (InMemory)
* Swagger / OpenAPI

---

## Funcionalidades

* 🔹 Obtener todos los usuarios
* 🔹 Obtener usuario por ID
* 🔹 Crear usuario
* 🔹 Actualizar usuario
* 🔹 Eliminar usuario

---

## Validaciones

* No se permite registrar usuarios con correos electrónicos duplicados.
* Se valida la existencia del usuario antes de actualizar o eliminar.

---

## Pruebas

La API fue probada utilizando Postman (capturas de pantalla mas abajo), verificando:

* Operaciones CRUD completas
* Validación de correo duplicado
* Respuestas HTTP correctas

---

## Ejecución del proyecto

1. Abrir el proyecto en Visual Studio
2. Ejecutar la aplicación
3. Acceder a Swagger o usar Postman

### URL base:

```plaintext
http://localhost:5064/api/usuarios
```

---

## Endpoints

### 🔹 GET - Obtener todos los usuarios

```
GET /api/usuarios
```

<img width="1569" height="579" alt="image" src="https://github.com/user-attachments/assets/5094e782-d52c-4a5d-a298-b64da1ba4479" />

---

### 🔹 GET - Obtener usuario por ID

```
GET /api/usuarios/{id}
```

<img width="1574" height="518" alt="image" src="https://github.com/user-attachments/assets/7c8548b6-91c6-40d6-9c4f-baa907d2206b" />

---

### 🔹 POST - Crear usuario

```
POST /api/usuarios
```

#### Body (JSON):

```json
{
  "nombre": "Victor",
  "correo": "victor@email.com",
  "fechaDeNacimiento": "2000-01-01"
}
```

<img width="1563" height="517" alt="image" src="https://github.com/user-attachments/assets/ddcbe8c4-0ea4-4cb3-875e-d5ca4bff1348" />

---

### 🔹 PUT - Actualizar usuario

```
PUT /api/usuarios/{id}
```

<img width="1564" height="437" alt="image" src="https://github.com/user-attachments/assets/f53f96cc-31f2-4171-82ba-8966db106aca" />


---

### 🔹 DELETE - Eliminar usuario

```
DELETE /api/usuarios/{id}
```

<img width="1559" height="404" alt="image" src="https://github.com/user-attachments/assets/86fb39d4-fa5c-44e7-80ea-47451e9c9f3f" />

---

## Estructura del proyecto

* Controllers → Manejo de endpoints
* Models → Definición de entidades
* Data → Contexto de base de datos

---

## Nota importante

La base de datos utilizada es en memoria, por lo que los datos se reinician cada vez que se detiene la aplicación.

---
