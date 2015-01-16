
# Example ASP.NET 5 Web API w/ MongoDB

Walkthrough Post - [https://tattoocoder.com/building-vnext-web-api-using-mvc-6-mongodb-azure/](https://tattoocoder.com/building-vnext-web-api-using-mvc-6-mongodb-azure/)

Example application using MongoDB.

This is a quick walkthrough on using ASP.NET 5 to build a Web API layer using MongoDB. The overall concept is not too dissimilar from previous examples you may have seen using **X** type of database, however there are some areas covered that are either new in MVC 6 that you may find you didn't know are there. 

####Topics Covered
- ConfigurationModel
	- config.json
	- Environment Variables
- OptionsModel
- Dependency Injection (IServiceCollection)
- Forcing JSON or Removing XML Formatter, Content Negotiation
- MongoDB
	- Installation (OSX & Windows)
	- mongocsharpdriver (nuget package)

####Outline
- Project Creation
	- Visual Studio
		- File -> New -> Project -> ASP.NET 5 Empty
	- Yeoman Generator
- Setting up dependencies
	- IIS Hosting, Self Hosting
	- MVC
- Startup.cs
- Configuration
- Dependency Injection
- MongoDB
	- Installation (OSX & Windows)
	- Test Data
	- Tools
		- Robomongo
		- Powershell or Terminal
- Adding the Model
- Adding the Controller

