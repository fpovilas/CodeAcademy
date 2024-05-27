----------------------------------------------
------------------ NewDB DB ------------------
----------------------------------------------
-- Task1
-- 1.Select the names of the staff members together with the name of the project they work on.
SELECT FirstName, Project.Name
FROM Employee
JOIN Project ON ProjectID = ID;
-- 2.Select the names of the staff working on the project in Kaunas and the name of the project.
SELECT FirstName, Project.Name
FROM Employee
JOIN Project ON ProjectID = ID
WHERE Project.Name = 'Kaunas';
-- 3.Select all the Registry Centre project implementers working in the Testing Department.
SELECT FirstName, Project.Name, DepartmentName
FROM Employee
LEFT JOIN Project ON ProjectID = ID
WHERE Project.Name = 'RegistryCenter' AND DepartmentName = 'Testing';
-- 4.Select all the women working in the Izola project and display their names and the name of the project.
SELECT Employee.FirstName, Project.Name, Employee.PersonalCode
FROM Employee
LEFT JOIN Project ON Employee.ProjectID = Project.ID
WHERE Project.Name = 'Izola' AND Employee.PersonalCode LIKE '4%';
-- 5.Select the names of the departments with the number of employees working in them.
SELECT DepartmentName, COUNT(DepartmentName) AS NumOfWorkers
FROM Employee
GROUP BY DepartmentName;
-- 6.Restrict the result of query #5 to show only departments with at least 5 employees.
SELECT DepartmentName, COUNT(DepartmentName) AS NumOfWorkers
FROM Employee
GROUP BY DepartmentName
HAVING COUNT(DepartmentName) > 5;
-- 7.Please select the names of the staff members, together with the names of the departments in which they work, but who are not the heads of those departments.
SELECT FirstName, DepartmentName
FROM Employee
WHERE Position != 'ProjectManager';
-- 8.Create a new record in the table "EMPLOYEE" (personal code: 38807117896, first name: Pranas, last name:Logis,
--         Employed since: 2009-11-12, year of birth: 1988-11-14, title: null, department_name: null, project_id: null).
INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID)
VALUES ('38807117869', 'Pranas', 'Logis', '2009-11-12', '1988-11-14', NULL, NULL, NULL);