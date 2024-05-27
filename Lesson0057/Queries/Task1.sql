-- TASK1
--- TASK1.1
SELECT * FROM Employee;
--- TASK1.2
SELECT PersonalCode FROM Employee;
--- TASK1.3
SELECT FirstName, LastName, Position FROM Employee;
--- TASK1.4
SELECT DISTINCT DepartmentName From Employee;
--- TASK1.5
SELECT * From Employee WHERE DepartmentName = 'C#';
--- TASK1.6
SELECT FirstName, LastName, Position FROM Employee WHERE FirstName = 'Giedrius';
--- TASK1.7
SELECT * FROM Employee WHERE BirthDate = '1986-09-19';
--- TASK1.8
SELECT * FROM Employee WHERE LastName = 'Sabutis';
--- TASK1.9
SELECT FirstName, LastName, Position FROM Employee WHERE DepartmentName = 'Java' AND Position = 'Developer';