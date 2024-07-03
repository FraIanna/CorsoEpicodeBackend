-- Es. 1
SELECT COUNT(*) as TotalOrders 
FROM Orders;

-- Es. 2
--SELECT COUNT(*) as TotalClients
--FROM Customers;

-- Es. 3
--SELECT COUNT(*) as TotalClientsFromLondon
--FROM Customers
--WHERE Customers.City = 'London'

-- Es. 4
--SELECT AVG(Freight) as AverageFreight
--FROM Orders

-- Es. 5
--SELECT AVG(Freight) as AverageFreight
--FROM Orders
--WHERE Orders.CustomerID = 'BOTTM'

-- Es. 6
--SELECT AVG(Freight) as AverageFreight, CustomerID
--FROM Orders
--GROUP BY CustomerID

-- Es. 7
--SELECT COUNT(*) as TotalClients, City
--FROM Employees
--GROUP BY City

-- Es. 8
--SELECT SUM((UnitPrice * Quantity)) as Total, OrderID
--FROM [Order Details]
--GROUP BY OrderID

-- Es. 9
--SELECT SUM((UnitPrice * Quantity)) as Total, OrderID
--FROM [Order Details]
--WHERE OrderID = 10248
--GROUP BY OrderID

-- Es. 10
--SELECT COUNT (*), c.CategoryID
--FROM Categories as c
--GROUP BY c.CategoryID

-- Es. 11
--SELECT COUNT (*), ShipCountry 
--FROM Orders
--GROUP BY ShipCountry

-- Es. 12
--SELECT AVG(Freight), ShipCountry
--FROM Orders
--GROUP BY ShipCountry