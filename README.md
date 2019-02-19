# SIGProject_TodoList
       ASP.NET Web APPLICATION: SIG Project Overview

Pre-requirements:
•	Visual Studio 2017
•	.NET Core SDK
•	SQL Server
•	Install Package using Nugget Manger 
•      PM>Install-Package Microsoft.jQuery.Unobtrusive.Ajax -Version 3.2.6 


Key components:
 Configuration Files:

 web.config file: contains all the necessary configuration information of this web application
 global.asax: contains all the URL routing rules

Models:

1.	TodoDetails: This model class contains all the properties need to link up with the database for a todo.  
2.	Identity Model: This is an automated model built at the time of the creating Project. This model deals with the user                    authentication. It is the model for identity. ApplicationdbContext is referring to data access layer and it is the database of          all the user as it inherits IdentityDbContext<ApplicationUser>. Also, I have added a table for todos that is a collection of            todos named as TodoDetails.

Views (TodoDetails/Views):
1.	_tabView: This is a partial view that is created for displaying the table of the TODOs for the current user.
2.	Index: This view returns the partial view using ajax and jQuery.
3.	allTodos: This will return the list of all the todos. 

Controllers:
1.	TodoDetailsController: contains navigation and crud logic of all todos.
2.	HomeController class: contains the main application navigation logic(such as default page and about page).

Steps on How to Run:
1)	Open the TodoDetails.sln in Visual Studio 2017.
2)	Enable the Migrations to look at the Database. 	
3)	Install the Ajax by running the command in to Tools>NuGet Package Manager>Package Manager Console
       PM> Install-Package Microsoft.jQuery.Unobtrusive.Ajax -Version 3.2.6 
4)	Run View/TodoDetails/Index.chstml.
5)	Log in by entering username u1@gmail.com and password: password to login. Or Register yourself.
6)	Write a todo in the text box and press enter.
7)	If the particular todo is done, mark the checkbox and it will get highlighted.
