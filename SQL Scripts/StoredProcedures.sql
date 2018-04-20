use AdventureWorks2012

--Accepts CustomerID and returns SalesOrderID, OrderDate, ShipDate, Salesperson name,
-- city and state, total amount on order.

GO
CREATE PROC spSalesOrderSearch (@CustomerID int)
AS

select soh.SalesOrderID, soh.OrderDate, soh.ShipDate, CONCAT(pp.firstname, ' ', pp.lastname) [Sales Person], 
		a.City, sp.Name [State], soh.TotalDue [Total Amount]
from sales.Customer c
inner join
sales.SalesOrderHeader soh
on soh.CustomerID = c.CustomerID
inner join
Person.Person pp
on pp.BusinessEntityID = soh.SalesPersonID
inner join
Person.[Address] a
on a.AddressID = soh.ShipToAddressID
inner join
Person.StateProvince sp 
on sp.StateProvinceID = a.StateProvinceID
where c.CustomerID = @CustomerID

--Second Procedure
GO
CREATE PROC spCustomerList
AS
select c.CustomerID, concat(pp.firstname, ' ', pp.lastname) [Customer Name]
from sales.Customer c
inner join
Person.Person pp
on pp.BusinessEntityID = c.CustomerID

exec spCustomerList
