USE AdventureWorks2019
GO

--1
SELECT 
	COUNT(*) 'Number of Product'
FROM 
	Production.Product
-- 504 products counted

--2
SELECT 
    COUNT(*) AS 'Number of Product in Subcategory'
FROM 
    Production.Product
WHERE 
    ProductSubcategoryID IS NOT NULL;

--3
SELECT
	pp.ProductSubcategoryID ProductSubcategoryID, COUNT(*) CountedProducts
FROM
	Production.Product as pp
WHERE
	pp.ProductSubcategoryID IS NOT NULL
GROUP BY
	pp.ProductSubcategoryID

--4
SELECT
	COUNT(*) 'Number of Product no Subcategory'
FROM
	Production.Product as pp
WHERE
	pp.ProductSubcategoryID IS NULL

--5
SELECT
	SUM(Quantity) 'Sum of Products Quantity'
FROM
	Production.ProductInventory

--6
SELECT
	ProductID, SUM(Quantity) TheSum
FROM
	Production.ProductInventory
WHERE
	LocationID = 40
GROUP BY
	ProductID
Having
	SUM(Quantity) < 100

--7
SELECT
	Shelf,ProductID, SUM(Quantity) TheSum
FROM
	Production.ProductInventory
WHERE
	LocationID = 40
GROUP BY
	ProductID, Shelf
Having
	SUM(Quantity) < 100

--8
 SELECT
	ProductID, AVG(Quantity) TheAVG
FROM
	Production.ProductInventory
WHERE
	LocationID = 10
GROUP BY
	ProductID

--9
 SELECT
	ProductID,Shelf, AVG(Quantity) TheAVG
FROM
	Production.ProductInventory
WHERE
	LocationID = 10
GROUP BY
	ProductID, Shelf

--10
 SELECT
	ProductID,Shelf, AVG(Quantity) TheAVG
FROM
	Production.ProductInventory
WHERE
	Shelf <> 'N/A'
GROUP BY
	ProductID, Shelf


 --11
 SELECT 
	Color, Class, COUNT(*) TheCount, AVG(ListPrice) AvgPrice
FROM
	Production.Product
WHERE
	Color IS NOT NULL
	AND
	Class IS NOT NULL
GROUP BY
	Color,Class

--12
SELECT
	pc.Name Country, ps.Name Province
FROM
	Person.CountryRegion pc
RIGHT JOIN
	Person.StateProvince ps
ON
	pc.CountryRegionCode = ps.CountryRegionCode

--13
SELECT
	pc.Name Country, ps.Name Province
FROM
	Person.CountryRegion pc
RIGHT JOIN
	Person.StateProvince ps
ON
	pc.CountryRegionCode = ps.CountryRegionCode
WHERE
	pc.Name in ('Canada','Germany')

---------------------------------------------------------------
USE Northwind
GO
--14
SELECT DISTINCT 
	p.ProductID ProductID, p.ProductName ProductName
FROM
	Products p
JOIN 
	[Order Details] od
ON	
	p.ProductID = od.ProductID
JOIN
	Orders o
ON
	od.OrderID = o.OrderID
WHERE
	o.OrderDate >= DATEADD(YEAR,-27,GETDATE())
ORDER BY
	p.ProductID


--15
SELECT TOP 5
	o.ShipPostalCode [Location], COUNT(*) TheCount
FROM
	Products p
JOIN 
	[Order Details] od
ON	
	p.ProductID = od.ProductID
JOIN
	Orders o
ON
	od.OrderID = o.OrderID
GROUP BY
	o.ShipPostalCode
ORDER BY
	TheCount DESC

--16
SELECT TOP 5
	o.ShipPostalCode [Location], COUNT(*) TheCount
FROM
	Products p
JOIN 
	[Order Details] od
ON	
	p.ProductID = od.ProductID
JOIN
	Orders o
ON
	od.OrderID = o.OrderID
WHERE
	o.OrderDate >= DATEADD(YEAR,-27,GETDATE())
GROUP BY
	o.ShipPostalCode
ORDER BY
	TheCount DESC

--17
SELECT
	City, COUNT(*) 'Number of Customers'
FROM
	Customers c
GROUP BY
	c.City

--18
SELECT
	City, COUNT(*) 'Number of Customers'
FROM
	Customers c
GROUP BY
	c.City
HAVING
	COUNT(*) >= 2

--19
SELECT DISTINCT
	c.ContactName
FROM
	Customers c
JOIN
	Orders o
ON
	c.CustomerID = o.CustomerID
WHERE
	o.OrderDate > '1998-01-01'

--20
SELECT 
    c.ContactName, 
    MAX(o.OrderDate) AS MostRecentOrderDate
FROM 
    Customers c
JOIN 
    Orders o 
ON 
	c.CustomerID = o.CustomerID
GROUP BY 
    c.ContactName
ORDER BY 
    MostRecentOrderDate DESC;

--21
WITH
	CTE1 AS (	SELECT 
					COUNT(od.ProductID) ProductCount, od.OrderID OrderID, o.CustomerID CustomerID
				FROM
					[Order Details] od
				JOIN
					Orders o
				ON
					o.OrderID = od.OrderID
				GROUP BY
					od.OrderID,o.CustomerID)
SELECT
	c.CustomerID,c.ContactName, SUM(CTE1.ProductCount) ProductCount
FROM
	Customers c
JOIN
	CTE1
ON 
	c.CustomerID = CTE1.CustomerID
GROUP BY
	c.CustomerID,c.ContactName;


--22
WITH
	CTE1 AS (	SELECT 
					COUNT(od.ProductID) ProductCount, od.OrderID OrderID, o.CustomerID CustomerID
				FROM
					[Order Details] od
				JOIN
					Orders o
				ON
					o.OrderID = od.OrderID
				GROUP BY
					od.OrderID,o.CustomerID)
SELECT
	c.CustomerID, SUM(CTE1.ProductCount) ProductCount
FROM
	Customers c
JOIN
	CTE1
ON 
	c.CustomerID = CTE1.CustomerID
GROUP BY
	c.CustomerID
HAVING
	SUM(CTE1.ProductCount) > 100

--23
WITH
	CTE1 AS(
		SELECT
			s.CompanyName [Supplier Company Name], p.ProductID ProductID, s.SupplierID SupplierID
		FROM
			Suppliers s
		JOIN
			Products p
		ON
			p.SupplierID = s.SupplierID
	),
	CTE2 AS(
		SELECT
			od.OrderID OrderID, od.ProductID ProductID, o.ShipVia ShipID, sh.CompanyName [Shipping Company Name]
		FROM
			[Order Details] od
		JOIN
			Orders o
		ON
			od.OrderID = o.OrderID
		JOIN
			Shippers sh
		ON
			o.ShipVia = sh.ShipperID 
	)
SELECT DISTINCT
	CTE1.[Supplier Company Name], CTE2.[Shipping Company Name]
FROM
	CTE1
JOIN
	CTE2
ON
	CTE1.ProductID = CTE2.ProductID
ORDER BY
	CTE1.[Supplier Company Name]


--24
SELECT 
    o.OrderDate OrderDate,
    p.ProductName ProductName
FROM 
    Orders o
JOIN 
    [Order Details] od ON o.OrderID = od.OrderID
JOIN 
    Products p ON od.ProductID = p.ProductID
ORDER BY 
    o.OrderDate, 
    p.ProductName;

--25
SELECT DISTINCT
	e1.EmployeeID EmployeeID1,
	e1.FirstName + ' ' + e1.LastName EmployeeName1,
	e2.EmployeeID EmployeeID2,
	e2.FirstName + ' ' + e2.LastName EmployeeName2,
	e1.Title
FROM
	Employees e1
JOIN
	Employees e2
ON
	e1.Title = e2.Title AND  e1.EmployeeID <> e2.EmployeeID

--26
SELECT
	e2.EmployeeID EmployeeID,
	e2.FirstName + ' ' + e2.LastName ManagersName,
	COUNT(*) [Number of employees]
FROM
	Employees e1
JOIN
	Employees e2
ON
	e1.ReportsTo = e2.EmployeeID
GROUP BY
	e2.EmployeeID, e2.FirstName, e2.LastName
HAVING
	COUNT(*) > 2

--27
SELECT 
    City City,
    CompanyName 'Name',
    ContactName ContactName,
    'Customer' 'Type'
FROM 
    Customers
UNION
SELECT 
    City City,
    CompanyName 'Name',
    ContactName ContactName,
    'Supplier' 'Type'
FROM 
    Suppliers
ORDER BY
	'Type'