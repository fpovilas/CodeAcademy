-- Task3
--- Task3.1 Select from the table Employee the project ID which would be the minimum number and the maximum number.
SELECT MIN(ProjectID) AS MinProjectID, MAX(ProjectID) AS MaxProjectID From Employee;
--- Task3.2 Select data about the project and how many people are assigned to it from the table Employee (project number and the number of participants).
SELECT Count(ID) AS 'People working on project', Name FROM Project JOIN Employee ON Employee.ProjectID = Project.ID GROUP BY ID, Name;
--- Task3.3 Select data (project number, position, count) from the table Employee on how many developers are working for each project.
SELECT ProjectID, Position, COUNT(Position) as AmountOfPeople FROM Employee GROUP BY Position, ProjectID;
--- Task3.4 Amend the query from Task3.3 to show only those projects where at least 2 employees work.
SELECT ProjectID, Position, COUNT(Position) AS AmountOfPeople FROM Employee GROUP BY Position, ProjectID HAVING COUNT(Position) >= 2;
