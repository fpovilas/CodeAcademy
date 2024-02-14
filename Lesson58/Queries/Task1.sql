-- TASK1
--- Task 1.1 Select data about the employee (personal code, first name, and last name) from the table Employee who were born on July 20, 1988.
SELECT PersonalCode, FirstName, LastName FROM Employee WHERE BirthDate = '1988-07-20';
--- Task 1.2 Select all data about employees from the table Employee who were born up to July 29, 1988.
SELECT * FROM Employee WHERE BirthDate = '1988-07-29';
---Select data about employees (start date and birth year) from the table Employee who were employed from October 30, 2009, to November 11, 2012.
SELECT FirstName, StartDate, BirthDate FROM Employee WHERE StartDate BETWEEN '2009-10-30' AND '2012-11-11';
---Select data about employees (first name, Department, and Project ID) from the table Employee who work on projects 2 and 3. (Use the IN operator).
SELECT FirstName, DepartmentName, ProjectID FROM Employee WHERE ProjectID BETWEEN 2 AND 3;
---Select data (first name, last name, and personal code) about all females from the table Employee (using the LIKE operator).
SELECT FirstName, LastName, ProjectID, PersonalCode FROM Employee WHERE PersonalCode LIKE '4%';
---Select all data about all employees from the table Employee who were born on the 12th day (using the LIKE operator).
SELECT * FROM Employee WHERE BirthDate LIKE '%12';
---Select all projects from the table Project where the third letter of the project name is ‘u’.
SELECT * FROM Project WHERE Name Like '__u%';
