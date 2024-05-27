-- Task2
--- Task2.1 Select all employees from the table Employee who have no assigned position.
SELECT * FROM Employee WHERE Position IS NULL;
--- Task2.2 Select data about the employee (first name, last name, start date, and position) that meet the conditions: (working from 2011-02-12 and their position is Developers).
SELECT FirstName, LastName, StartDate, Position FROM Employee WHERE Position = 'Developer' AND StartDate > '2011-02-12';
--- Task2.3 Select data about employees (first name, last name, department name, and project ID) from the table Employee with the condition that they are from the Java department or project 1.
SELECT FirstName, LastName, DepartmentName, ProjectID FROM Employee WHERE DepartmentName = 'Java' OR ProjectID = 1;
--- Task2.4 Select all employee names except those whose names start with the letter ‘S’.
SELECT FirstName, LastName FROM Employee WHERE FirstName LIKE 'S%';
--- Task2.5 Select data (first name, start date, and birth year) from the table Employee about all employees except those who were employed from October 30, 2009, to November 11, 2012.
SELECT FirstName, StartDate, BirthDate FROM Employee WHERE StartDate BETWEEN '2009-10-30' AND '2012-11-11';
--- Task2.6 Select data about employees (first name, last name, and birth year) from the table Employee and sort all data from the oldest person to the youngest.
SELECT FirstName, LastName, BirthDate FROM Employee ORDER BY BirthDate ASC;
--- Task2.7 Select data about employees (first name, last name, and birth year) from the table Employee and sort all data from the youngest person to the oldest.
SELECT FirstName, LastName, BirthDate FROM Employee ORDER BY BirthDate DESC;