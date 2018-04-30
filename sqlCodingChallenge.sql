create database cc

use cc
go
create table Prod.Products
(
ID int identity(1,1) primary key not null,
[Name] nvarchar(50) not null,
Price float not null
)


create table Prod.Customers
(
ID int identity(1,1) primary key not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
CardNumber int not null
)

create table Prod.Orders
(
ID int identity(1,1) primary key not null,
ProductID int not null foreign key references Prod.Products (ID),
CustomerID int not null foreign key references Prod.Customers (ID)
)

insert into Prod.Products([Name],Price)
values('shoes',120)

insert into Prod.Customers(FirstName,LastName,Cardnumber)
values('Jack','Richardson',12344331)

insert into Prod.Products([Name],Price)
values('iPhone',200)



insert into Prod.Orders(ProductID,CustomerID)
values((select ID from Prod.Products where [Name]='iPhone'),
(select ID from Prod.Customers where FirstName='Tina'))

select FirstName, Orders.ID from Prod.Orders 
left join Prod.Customers 
on Customers.ID=CustomerID
where FirstName='Tina'

select Price*count(Orders.ID) as total_sale from Prod.Orders
join Prod.Products
on Orders.CustomerID=Customers.ID
where Products.[Name] ='iPhone'



update Prod.Products
set Price = 250
where [Name]='iPhone'
