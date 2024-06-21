USE Northwind
GO

-- varchar vs nvarchar
--VARCHAR is for non-Unicode characters using 1 byte per character, suitable for English or ASCII text
--NVARCHAR is for Unicode characters using 2 bytes per character, supporting multiple languages and different writing systems

--1
SELECT DISTINCT
	e.City City
FROM 
	Employees e
JOIN
	Customers c
ON
	e.City = c.City
WHERE
	e.City IS NOT NULL AND c.City IS NOT NULL


--2
SELECT DISTINCT
	c.City City
FROM 
	Customers c
WHERE
	c.City IS NOT NULL AND c.City NOT IN (SELECT e.City FROM Employees e)

SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL
ORDER BY c.City;

--3
SELECT 
	p.ProductName, SUM(od.Quantity) TotalOrderQuantity
FROM
	Products p
JOIN
	[Order Details] od
ON
	od.ProductID = p.ProductID
GROUP BY
	p.ProductID, p.ProductName

--4
SELECT 
	c.City, SUM(od.Quantity) TotalOrderQuantity
FROM
	Customers c
JOIN
	Orders o
ON
	o.CustomerID = c.CustomerID
JOIN
	[Order Details] od
ON
	od.OrderID = o.OrderID

GROUP BY
	c.City

--5
SELECT 
	City
FROM 
	Customers
GROUP BY 
	City
HAVING 
	COUNT(CustomerID) >= 2

SELECT DISTINCT
	City
FROM 
	Customers
WHERE 
	City IN (
		SELECT 
			City
		FROM 
			Customers
		GROUP BY 
			City
		HAVING 
			COUNT(CustomerID) >= 2
)

--6
SELECT
	c.City, COUNT(DISTINCT od.ProductID) [Kinds of Products]
FROM
	Customers c
JOIN
	Orders o
ON
	o.CustomerID = c.CustomerID
JOIN
	[Order Details] od
ON
	od.OrderID = o.OrderID
GROUP BY
	c.City
HAVING
	COUNT(DISTINCT od.ProductID) >= 2

--7
SELECT DISTINCT
    c.CompanyName,
    c.City  CustomerCity,
    o.ShipCity ShipCity
FROM 
    Customers c
JOIN 
    Orders o ON c.CustomerID = o.CustomerID
WHERE 
    c.City <> o.ShipCity

--8
WITH CTE1 AS (
    SELECT 
        od.ProductID,
        SUM(od.Quantity) AS TotalQuantity,
        AVG(od.UnitPrice) AS AveragePrice
    FROM 
        [Order Details] od
    GROUP BY 
        od.ProductID
),
CTE2 AS (
    SELECT TOP 5
        CTE1.ProductID,
        CTE1.TotalQuantity,
        CTE1.AveragePrice
    FROM 
        CTE1
    ORDER BY 
        CTE1.TotalQuantity DESC
),
CTE3 AS (
    SELECT 
        od.ProductID,
        c.City,
        SUM(od.Quantity) AS CityQuantity
    FROM 
        [Order Details] od
    JOIN 
        Orders o ON od.OrderID = o.OrderID
    JOIN 
        Customers c ON o.CustomerID = c.CustomerID
    GROUP BY 
        od.ProductID,
        c.City
)
SELECT 
    CTE2.ProductID,
    CTE2.AveragePrice,
    c.City AS TopCustomerCity,
    CTE2.TotalQuantity
FROM 
    CTE2
JOIN 
    CTE3 c ON CTE2.ProductID = c.ProductID
JOIN 
    (
        SELECT 
            ProductID,
            MAX(CityQuantity) AS MaxCityQuantity
        FROM 
            CTE3
        GROUP BY 
            ProductID
    ) m ON c.ProductID = m.ProductID AND c.CityQuantity = m.MaxCityQuantity
ORDER BY 
    CTE2.TotalQuantity DESC;


--9
SELECT DISTINCT 
	e.City
FROM 
	Employees e
WHERE 
	e.City NOT IN (
		SELECT DISTINCT 
			o.ShipCity
		FROM 
			Orders o)


SELECT DISTINCT
	e.City
FROM 
	Employees e
LEFT JOIN 
	Orders o 
ON 
	e.City = o.ShipCity
WHERE 
	o.ShipCity IS NULL

--10
WITH CTE1 AS (
    SELECT 
        e.City,
        COUNT(o.OrderID) TotalOrders
    FROM 
        Employees e
    JOIN 
        Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY 
        e.City
),
CTE2 AS (
    SELECT 
        City
    FROM 
        CTE1
    WHERE 
        TotalOrders = (SELECT MAX(TotalOrders) FROM CTE1)
),
CTE3 AS (
    SELECT 
        c.City,
        SUM(od.Quantity) TotalQuantity
    FROM 
        Customers c
    JOIN 
        Orders o ON c.CustomerID = o.CustomerID
    JOIN 
        [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY 
        c.City
),
CTE4 AS (
    SELECT 
        City
    FROM 
        CTE3
    WHERE 
        TotalQuantity = (SELECT MAX(TotalQuantity) FROM CTE3)
)
SELECT 
    CTE2.City
FROM 
    CTE2
JOIN 
    CTE4  ON CTE2.City = CTE4.City


--11
--first create a user-defined function that uses RANK() to assign ranks within groups of duplicates based on specific columns (e.g., FirstName and LastName). 
--This function will return the IDs of rows with a rank greater than 1, indicating duplicates. 
--Insert these duplicate IDs into a temporary table, then delete the rows from the original table where the ID is in the temporary table. 
--Finally, drop the temporary table to clean up.
--For example:

--Create a sample 
CREATE TABLE EmployeesTemp (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(100),
    LastName VARCHAR(100)
);

INSERT INTO EmployeesTemp(EmployeeID, FirstName, LastName)
VALUES 
(1, 'John', 'Doe'),
(2, 'Jane', 'Doe'),
(3, 'John', 'Doe'),
(4, 'Jane', 'Smith'),
(5, 'John', 'Doe');

CREATE FUNCTION dbo.GetDuplicateEmployeeIDs()
RETURNS @DuplicateIDs TABLE (EmployeeID INT)
AS
BEGIN
    -- Insert the EmployeeIDs of duplicate rows into the table variable
    INSERT INTO @DuplicateIDs (EmployeeID)
    SELECT EmployeeID
    FROM (
        SELECT 
            EmployeeID,
            RANK() OVER (PARTITION BY FirstName, LastName ORDER BY EmployeeID)  [Employee Rank]
        FROM 
            EmployeesTemp
    ) RankedEmployees
    WHERE [Employee Rank] > 1;

    RETURN;
END;


CREATE TABLE #TempDuplicateIDs (EmployeeID INT);

INSERT INTO #TempDuplicateIDs (EmployeeID)
SELECT EmployeeID FROM dbo.GetDuplicateEmployeeIDs();

DELETE FROM EmployeesTemp
WHERE EmployeeID IN (SELECT EmployeeID FROM #TempDuplicateIDs);

DROP TABLE #TempDuplicateIDs;

SELECT * FROM EmployeesTemp;