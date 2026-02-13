\# Product Management App



Full-stack web application built with Angular and .NET 8 that allows users to manage products through a complete CRUD interface. This project was developed as part of a technical assessment and follows clean architecture principles and modern frontend practices.



---



\# Overview



This application enables users to:



\* Create products

\* View all products

\* Update existing products

\* Delete products

\* Validate form inputs

\* Interact with a REST API



The solution is structured using a clear separation between frontend and backend layers.



---



\# Tech Stack



\## Backend



\* .NET 8 Web API

\* Entity Framework Core

\* SQL Server LocalDB

\* Swagger (OpenAPI)

\* xUnit (Unit Testing)

\* Dependency Injection

\* Clean Architecture principles



\## Frontend



\* Angular 17 (Standalone Components)

\* Angular Material

\* Reactive Forms

\* HttpClient

\* TypeScript



---



\# Architecture



The backend follows a layered architecture:



```

ProductApp.Api

&nbsp;   Controllers

&nbsp;   Services

&nbsp;   Data (DbContext)



ProductApp.Application

&nbsp;   Entities

&nbsp;   DTOs

&nbsp;   Interfaces



ProductApp.Tests

&nbsp;   Unit Tests

```



Frontend uses a feature-based structure:



```

products/

&nbsp;   models/

&nbsp;   services/

&nbsp;   pages/

&nbsp;       product-list/

&nbsp;       product-form/

```



---



\# Project Structure



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



\# Features Implemented



\## Backend



\* REST API with full CRUD operations

\* Entity Framework Core integration

\* SQL Server database

\* DTO pattern

\* Service layer abstraction

\* Swagger documentation

\* Unit testing with xUnit



Endpoints:



```

GET     /api/products

GET     /api/products/{id}

POST    /api/products

PUT     /api/products/{id}

DELETE  /api/products/{id}

```



---



\## Frontend



\* Product list view

\* Product creation form

\* Product deletion

\* Form validation

\* Navigation between views

\* Angular Material UI



Form fields include:



\* Name

\* Description

\* Price

\* Stock

\* Category

\* Expiration Date

\* Active status



---



\# How to Run the Project



\## Prerequisites



Make sure you have installed:



\* .NET 8 SDK

\* Node.js (v18 or higher)

\* Angular CLI

\* SQL Server LocalDB (included with Visual Studio)



---



\# Run Backend



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

http://localhost:5168/swagger

```



Database will be created automatically using Entity Framework.



---



\# Run Frontend



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



\# Running Unit Tests



Navigate to:



```

cd backend/ProductApp.Tests

```



Run:



```

dotnet test

```



---



\# API Documentation



Swagger UI is enabled and available at runtime:



```

http://localhost:5168/swagger

```



This allows testing endpoints independently.



---



\# Author



Daniel Alzate

Software Engineer

Pontificia Universidad Javeriana



---



\# Notes



This project demonstrates full-stack development using Angular and .NET, applying clean architecture principles and best practices for maintainability and scalability.





