# Product Management App

Full-stack web application built with Angular and .NET 10 that allows users to manage products through a complete CRUD interface. This project was developed as part of a technical assessment and follows clean architecture principles and modern frontend practices.

---

# Overview

This application enables users to:

* Create products
* View all products
* Update existing products
* Delete products
* Validate form inputs
* Interact with a REST API

The solution is structured using a clear separation between frontend and backend layers.

---

# Tech Stack

## Backend

* .NET 8 Web API
* Entity Framework Core
* SQL Server LocalDB
* Swagger (OpenAPI)
* xUnit (Unit Testing)
* Clean Architecture principles

## Frontend

* Angular 17
* Angular Material
* Reactive Forms
* HttpClient
* TypeScript

---

# Architecture

The backend follows a layered architecture:

```
ProductApp.Api
    Controllers
    Services
    Data (DbContext)

ProductApp.Application
    Entities
    DTOs
    Interfaces

ProductApp.Tests
    Unit Tests
```

Frontend uses a feature-based structure:

```
products/
    models/
    services/
    pages/
        product-list/
        product-form/
```

---

# Project Structure

```
product-app/
│
├── backend/
│   ├── ProductApp.Api/
│   ├── ProductApp.Application/
│   ├── ProductApp.Tests/
│   └── ProductApp.sln
│
├── frontend/
│   └── product-app/
│
└── README.md
```

---

#Endpoints:

```
GET     /api/products
GET     /api/products/{id}
POST    /api/products
PUT     /api/products/{id}
DELETE  /api/products/{id}
```

---

# How to Run the Project

## Prerequisites

Make sure you have installed:

* .NET 8 SDK or later
* Angular CLI 17 or later
* Node.js 18 or later
* SQL Server LocalDB (included with Visual Studio)

---

# Run Backend

Navigate to backend folder:

```
cd backend/ProductApp.Api
```

Run:

```
dotnet run
```

Swagger will be available at:

```
http://localhost:<port>/swagger
```
Note: The port may vary depending on your local configuration. Please check the console output when running the backend.

Database will be created automatically using Entity Framework.

---

# Run Frontend

Navigate to frontend folder:

```
cd frontend/product-app
```

Install dependencies:

```
npm install
```

Run Angular:

```
ng serve
```

Application will run at:

```
http://localhost:4200
```

---

# Running Unit Tests

Navigate to:

```
cd backend/ProductApp.Tests
```

Run:

```
dotnet test
```

---

# Author

* Daniel Alzate
* Software Engineer
* Pontificia Universidad Javeriana

---
