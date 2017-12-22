# Meow
Meow is a cute, friendly web platform for cats and their future owners. In Meow you can adopt a kitty and give it love, care and such nice things. 

## General Requirements
The application is implemented using **ASP.NET Core framework**.
Using Visual Studio 2017
-	View Engine for generating the UI – **Razor**
-	Using sections and partial views, editor and display templates
- Database back-end – **Microsoft SQL Server**
- Database access – **Entity Framework Core**
- MVC Areas – area for administration and volunteers
- Managing users and roles – **ASP.NET Identity System**
- Error handling and data validation
- HTML crazy stuff (escaping)
- **Dependency Injection**
- **AutoMapping**
- Preventing from security vulnerabilities, like SQL Injection, XSS, CSRF – that’s for ASP. :)

## Additional Requirements
Best practices for Object-oriented design and High-quality code
-	Data encapsulation
-	Exception handling
-	OOP Principles
-	Strong cohesion and loose coupling
-	Correctly format and structure the code, naming identifiers and readable code
- Well looking user interface
- Good usability 
- Supporting of all modern Web browsers
- Using caching where appropriate
- Using source control system - **GitHub**

## Data Structure 
In this cat database we have the following tables and relations 

Cats 
- Home Cat - Name, Age, Image, Description, Location, Gender, Owner
- Adoption Cat -  Name, Age, Image, Description, Location, Gender, IsAdopted, IsRequested, RequestedOwnerId, Owner

Users 
- the default ASP.NET Identity System + Name, Location, Birthdate, Profile Photo, Gender, Home Cats, Adopted Cats

Relations 
- one cat can have only one owner, and one owner can have many home and adopted cats

## Business Logic
Anonymous users can: 
-	Register
-	Login
-	View kitties page

Logged in users can: 
-	Logout
-	Ask for adoption
-	View users profiles
- View cats details
-	Edit their profile

Volunteers can: 
- View kitties for adoption and add, edit, delete them
- Move kitty from for adoption to adopted

Administrators can:
-	Manage users, all kitties
-	Edit kitty profile, set if it’s adopted
