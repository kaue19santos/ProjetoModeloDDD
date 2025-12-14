# DDD Architecture Study with C# and ASP.NET

This repository was created as part of my studies on **C#**, **Domain-Driven Design (DDD)**, and **layered architecture**.

## 📚 About the Project

The project is based on a **tutorial series from YouTube**, where a complete DDD-based application was originally developed using:

- Visual Studio 2013  
- ASP.NET 5  
- Entity Framework (classic)

During my studies, I followed the original project and **adapted it to modern technologies**, including:

- Visual Studio 2022  
- ASP.NET Core MVC  
- Entity Framework Core (EF Core)

The main goal was to understand how a **DDD architecture** is structured and how its layers communicate with each other, while also learning how to migrate and modernize older ASP.NET projects.

## 🏗️ Architecture Overview

The solution follows a layered DDD approach, separating responsibilities into distinct projects, such as:

- **Domain**: Core business rules, entities, and domain services  
- **Application**: Application services and ViewModels, acting as a bridge between UI and Domain  
- **Infrastructure**: Data access (EF Core), repositories, and cross-cutting concerns  
- **MVC (UI)**: Controllers and Views responsible for handling HTTP requests and responses  

This separation improves **maintainability**, **testability**, and **scalability**.

## 🎯 Learning Objectives

- Understand Domain-Driven Design concepts  
- Apply layered architecture in a real project  
- Learn dependency injection in ASP.NET Core  
- Migrate legacy ASP.NET code to modern ASP.NET Core  
- Use Entity Framework Core with repositories  

## ⚠️ Disclaimer

This project is for **learning purposes only** and was not intended for production use.

---

## 🚀 Technologies Used

- C#  
- ASP.NET Core MVC  
- Entity Framework Core  
- Dependency Injection  
- Visual Studio 2022  

---

Feel free to explore the code and follow the architectural decisions made throughout the project.
