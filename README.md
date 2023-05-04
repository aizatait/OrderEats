# OrderEats

Welcome to this OrderEats API project! This project is developed using the Clean Code architecture, utilizing .NET 6 and written in C#. It follows a code-first migration approach for Object-Relational Mapping (ORM) using Entity Framework Core, with object mapping using Mapster. Additionally, input data validation is implemented using FluentValidation for the Category and Product entities and DataAnnotations for the Cart entity. The relationships between entities and other database-related tasks are configured using the fluent API for the Cart entity and DataAnnotations for the Category and Product entities.

To provide a better user experience, this API project also utilizes Swashbuckle, an open-source tool that generates an interactive API documentation page. Users can explore and test the API endpoints directly from the documentation page, making it easier to understand how to interact with the API.

This API project also includes a repository and Generic CRUD service that can be inherited to create a service for simple models, such as the Category model. Additionally, a DbContext is directly used without applying a repository to create a service for more complicated models, such as the Product and Cart models.

Please note that this project is not a fully functional application but rather a demonstration of how different technologies can be used together in a project. Hope that this project will be a useful resource for learning how to develop APIs using .NET 6, Entity Framework Core, Mapster, FluentValidation, Fluent API, Swashbuckle, and implementing a repository and CRUD service for simple models, as well as a DbContext for complicated ones.
