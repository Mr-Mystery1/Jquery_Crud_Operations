# Jquery_Crud_Operations
A Simple Crud operation performed using JQuery(AJAX), SQL Server , ADO Dotnet on MVC.


<---------------------------------------SQL Queries--------------------------------->
Create Database DatabaseName
Use DatabaseName
Create Table TableName
(Id int Primary Key Identity,
Name Varchar(50),
Email Varchar(50),
Phone Varchar(12)
)
<--------------------------------------Procedures----------------------------------->
Create Procedure spAddEmployee  
(  
 @Name Varchar(50),  
 @Email Varchar(50),  
 @Phone Varchar(12)  
)  
As Begin  
 insert into  Employees (Name, Email,Phone)  
 values(@Name,@Email,@Phone)  
End


Create Procedure spGetAllEmployees  
As   
Begin  
 Select * from Employees  
End



Create Procedure spGetEmployeeId  
(  
 @Id int  
)  
As Begin  
 Select * from Employees Where Id=@Id  
End



Create Procedure spUpdateEmployee  
(  
 @Id int,  
 @Name Varchar(50),  
 @Email Varchar(50),  
 @Phone Varchar(12)  
)  
As Begin  
 Update Employees set Name=@Name, Email=@Email,Phone=@Phone  
 where @Id=Id  
  
End


Create Procedure spDeleteEmployee  
(  
 @Id int  
)  
As Begin  
 Delete from Employees Where Id=@Id  
End
