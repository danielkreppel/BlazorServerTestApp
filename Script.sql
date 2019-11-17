--drop database BlazorTestDB
Create database BlazorTestDB;
go
use [BlazorTestDB]

Create table Person(        
    Id int IDENTITY(1,1) NOT NULL,        
    Name varchar(20) NOT NULL,        
    Age varchar(20) NOT NULL,        
    BirthDate DateTime NOT NULL,        
    Gender varchar(6) NOT NULL        
)



