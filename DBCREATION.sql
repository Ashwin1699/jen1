create database Student
use Student

Create table tbStudent(sID int primary key,sName varchar(20) not null,sDOB date,sphone int)
Create table tbCourse(cID int primary key,cName varchar(20) not null,cDuration varchar(20) ,cFees int)
alter table tbStudent alter column  sDOB varchar(20);
alter table tbStudent alter column  sphone nvarchar(20);
sp_help tbStudent

select * from tbStudent
select * from tbCourse20