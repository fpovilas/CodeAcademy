----------------------------------------------
------------------ NewDB DB ------------------
----------------------------------------------
-- Task2
--- 9.Select the names of the staff and the name of the department. Show even staff who do not work in any department (take the department name from the DEPARTMENT table).
SELECT
	FirstName,
	LastName,
	Department.Name AS DepartmentName
FROM
	Employee
LEFT JOIN
	Department ON DepartmentName = Department.Name;
--- 10.Please modify the query in point 1# to show only names and project names with more than 4 employees.
SELECT FirstName, Project.Name AS ProjectName
FROM Employee
JOIN Project ON ProjectID = ID
JOIN (SELECT ProjectID
	  FROM
		Employee
	  GROUP BY
		ProjectID
	  HAVING
		COUNT(ProjectID) > 4) AS VT ON VT.ProjectID = Project.ID;
-------------------------------------------------
------------------ Lesson59 DB ------------------
-------------------------------------------------
--- 11. Select all developers working on the Accounting project
SELECT
	LastName,
	Execution.Status,
	Projects.Name
FROM
	Executors
LEFT JOIN Execution
	ON	Executors.ID = Execution.Executor
LEFT JOIN Projects
	ON  Projects.ID = Execution.Project
WHERE
	Status = 'Developer'
	AND
	Name = 'Accounting';
--- 12. Please select the projects that have people without a degree
SELECT
	LastName,
	Education,
	Projects.Name
FROM
	Executors
LEFT JOIN Execution
	ON Executors.ID = Execution.Executor
LEFT JOIN Projects
	ON Projects.ID = Execution.Project
WHERE
	Education IS NULL;
--- 13. List the names and qualifications of the people working on the Medium Priority Project
SELECT
	Executors.LastName,
	Executors.Qualification,
	Projects.Importance
FROM
	Executors
LEFT JOIN Execution
	ON Executors.ID = Execution.Executor
LEFT JOIN Projects
	ON Projects.ID = Execution.Project
WHERE
	Projects.Importance = 'Medium';
--- 14. Please select the names of the people working on projects prior to 01.05.2005
SELECT
	Executors.LastName,
	Projects.Start
FROM
	Executors
LEFT JOIN Execution
	ON Executors.ID = Execution.Executor
LEFT JOIN Projects
	ON Projects.ID = Execution.Project
WHERE
	Projects.Start > '2005-05-01';
--- 15. Please select the projects that have VU-educated people
SELECT
	Projects.Name,
	Executors.Education,
	Executors.LastName
FROM
	Executors
JOIN Execution
	ON Executors.ID = Execution.Executor
JOIN Projects
	ON Projects.ID = Execution.Project
WHERE
	Executors.Education LIKE 'VU';