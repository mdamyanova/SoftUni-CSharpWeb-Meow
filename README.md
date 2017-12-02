# Meow
Meow is a cute, friendly web platform for cats and their future owners. In Meow you can adopt a kitty and give it love, care and such nice things. 

## General Requirements
The application is implemented using **ASP.NET Core framework**.
-	Web Pages (views) – (count)
-	Entity Models – (count)
-	Controllers – (count)
Using Visual Studio 2017
-	View Engine for generating the UI – **Razor**
-	Using sections and partial views, editor and display templates
- JavaScript  - Front-end *todo*
- Database back-end – **Microsoft SQL Server**
- Database access – **Entity Framework Core**
- MVC Areas – area for administration
- Theme – *todo*
- Managing users and roles – **ASP.NET Identity System**
- AJAX ? *todo*
- Unit tests – I really hope to have time for this. *todo*
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
- Name, ImageUrl, Description, Location, information if it's adopted, Gender

Users 
- the default ASP.NET Identity System + Name, Birthdate

Relations 
- one cat can have only one owner, and one owner can have many cats adopted

## Business Logic
Anonymous users can: 
-	Register
-	Login
-	View kitties page

Logged in users can: 
-	Logout
-	Ask for adoption
-	View users profiles
-	Edit their profile

Administrators can:
-	View admin panel
  		- admin panel consists list of users, all kitties, when they can manage them
-	Edit kitty profile, set if it’s adopted
-	Very bonus thing: users can send message to admin with founded kitties. This is too deep for now.  
