# API REST con Entity Framework Core (Code First)

## Descripción

Este proyecto consiste en la ampliación de una API REST desarrollada en C# utilizando **ASP.NET Core** y **Entity Framework Core (Code First)**.

Se implementaron nuevas entidades (**Producto, Proveedor y Categoría**) con sus respectivas relaciones, además de endpoints CRUD y consultas avanzadas utilizando LINQ.

---

## Objetivo

El objetivo principal es gestionar productos junto a su proveedor y categoría, así como realizar operaciones de agregación sobre los datos.

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

## Modelo de Datos

### Producto

* Id
* Nombre
* Precio
* Stock
* IdProveedor
* IdCategoria

### Proveedor

* Id
* Nombre
* Contacto

### Categoría

* Id
* Nombre

---

## Relaciones

* Un **Producto** pertenece a un **Proveedor**
* Un **Producto** pertenece a una **Categoría**
* Un **Proveedor** tiene muchos **Productos**
* Una **Categoría** tiene muchos **Productos**

---

## Cómo Probar la API (Postman / Swagger)

### 🔹 Paso 1: Crear Proveedor

```plaintext
POST: /api/proveedores
```

```json
{
  "nombre": "Proveedor 1",
  "contacto": "809-000-0000"
}
```

<img width="994" height="505" alt="Crear Proveedor" src="https://github.com/user-attachments/assets/9d9d6312-8c56-4e98-a359-6243f23d5a55" />

---

### 🔹 Paso 2: Crear Categoría

```plaintext
POST: /api/categorias
```

```json
{
  "nombre": "Electrónica"
}
```

<img width="1001" height="469" alt="Crear Categoria" src="https://github.com/user-attachments/assets/e4210296-ba60-4714-b13e-c6bdeb85bf72" />

---

### 🔹 Paso 3: Crear Producto

```plaintext
POST: /api/productos
```

```json
{
  "nombre": "Laptop",
  "precio": 1200,
  "stock": 10,
  "idProveedor": 1,
  "idCategoria": 1
}
```

<img width="1055" height="812" alt="Crear Producto" src="https://github.com/user-attachments/assets/4f1485ff-7092-4dec-9a9c-de7151de105c" />

---

### 🔹 Paso 4: Obtener Categorias

```bash
GET /api/categorias
```

<img width="1053" height="610" alt="Get Categorias" src="https://github.com/user-attachments/assets/f1b20995-f046-419b-bd47-41c099ff99c2" />

---

### 🔹 Paso 5: Obtener Proveedores

```bash
GET /api/proveedores
```

<img width="1039" height="664" alt="Get Proveedores" src="https://github.com/user-attachments/assets/3c75ed63-6892-458e-b2bf-5b764442ab45" />

---

### 🔹 Paso 6: Obtener Productos

```bash
GET /api/productos
```

<img width="1042" height="1031" alt="Get Productos" src="https://github.com/user-attachments/assets/fa0f80e2-ff05-4dd8-80f9-90e2cfdddd54" />

---

### 🔹 Paso 7: Obtener por Categorias

```bash
GET /api/productos/categoria/{id}
```

<img width="1043" height="636" alt="Por categoría" src="https://github.com/user-attachments/assets/a87528b2-a534-46df-a072-0fc5f0d86a2e" />

---

### 🔹 Paso 8: Obtener total

```bash
GET /api/productos/total
```

<img width="701" height="376" alt="Get Total" src="https://github.com/user-attachments/assets/8ef5672a-1a2a-4524-8ecf-b9f7b6f9fa0e" />

---

### 🔹 Paso 9: Actualizar Proveedor

```bash
PUT /api/proveedores/{id}
```

<img width="755" height="420" alt="image" src="https://github.com/user-attachments/assets/fcf73b6a-8c83-4b13-9c00-780609d18e64" />

---

### 🔹 Paso 10: Actualizar Categoria

```bash
PUT /api/categorias/{id}
```

<img width="752" height="415" alt="image" src="https://github.com/user-attachments/assets/3723b0c2-b9cc-4694-b2c4-8c56fba9e495" />

---

### 🔹 Paso 11: Actualizar Producto

```bash
PUT /api/productos/{id}
```

<img width="752" height="694" alt="image" src="https://github.com/user-attachments/assets/0c31a4c5-e84a-49d1-9056-63b1aca03681" />

---

### 🔹 Paso 12: Borrar Producto

```bash
DELETE /api/productos/{id}
```

<img width="743" height="355" alt="image" src="https://github.com/user-attachments/assets/593dd751-c975-4869-a947-ee2f26c34fcb" />

---

## Uso de LINQ

Se implementaron consultas como:

* Ordenamiento (OrderBy, OrderByDescending)
* Agregaciones (Sum, Average)
* Filtros (Where)
* Conteo (Count)

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

## Consideraciones

* Se utilizó **InMemory Database**, por lo que los datos se reinician al ejecutar nuevamente la aplicación.
* Se usó `Include()` para cargar relaciones entre entidades.
* Se utilizó `[JsonIgnore]` para evitar ciclos en las respuestas JSON.

---
