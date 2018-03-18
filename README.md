# Meow
Meow is a cute, friendly web platform for cats and their owners. In Meow, despite you can brag with your cats, you can also adopt a kitty and give it love, care and such nice things.

![Meow Home](https://imgur.com/fN7JZN3.jpg)

## General Requirements
The application is implemented during the course [C# MVC Frameworks - ASP.NET Core](https://github.com/mdamyanova/C-Sharp-Web-Development/tree/master/09.C%23%20Web/09.02.C%23%20MVC%20Frameworks%20-%20ASP.NET%20Core) using **ASP.NET Core Framework** and follows the requirements of the project assignment.
-	View Engine for generating the UI – **Razor**
-	Using sections and partial views, editor and display templates
- Database back-end – **Microsoft SQL Server**
- Database access – **Entity Framework Core**
- **MVC Areas** – area for administration and cats
- Managing users and roles – **ASP.NET Identity System**
- **Unit tests** for controllers and services - xUnit
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

![MeowDb](https://imgur.com/daE10IU.jpg)

## Business Logic
Anonymous users can: 
-	Register
-	Login
-	View kitties for adoption page
- View About page

Logged in users can: 
-	Logout
-	Ask for adoption
-	View users profiles
- View cats details
-	CRUD operations of their cats

Volunteers can: 
- CRUD operations of their cats and all cats for adoption
- Listing and managing cats for adoption
- Move kitty from for adoption to adopted

Administrators can:
-	Manage all kitties
-	Manage all users and set them roles

## Team and Contribution
- [@mdamyanova](https://github.com/mdamyanova) - idea of Meow, development of the project, defense, deploy, documentation, giving assignments
- [@Dimitvp](https://github.com/Dimitvp) - refactoring, change structure of the projects, finding and fixing bugs, giving ideas for improvement
- [@ddxkalin](https://github.com/ddxkalin) - refactoring, front-end stuff, seed objects, giving ideas for improvement, help for documentation
- [iCatRescue](https://www.facebook.com/iCatRescue/) - allowing using real cats who need love and care

## Meow
Thank you for stoping by! They say Meow means I love you in kitty. So here's a dozen of Meows!🐈😻💕
<p align="center">
  <img src="https://i.pinimg.com/originals/92/60/1b/92601b2087dc6a24cf873495d27370ad.gif?raw=true" alt="Weird-girl-and-Mr-Whiskers"/>
</p>
