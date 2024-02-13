/*
- Insert a new employee into the table “Employee”, filling in all required fields (personal code, first name, last name, start date, birth date, position, department name, and project number).
- Insert a new employee into the table “Employee”, only filling in fields (personal code, first name, last name, start date, birth date). Leave position, department name, and project number unfilled.
- Fill in the remaining empty fields in the table “Employee” for your previously inserted entry. Assign the employee a position, department, and project.
- Delete the table “Employee” record whose personal code is the one you created.
- Insert two employees with the last name Antanaitis whose position would be “Developer”.
- Change the positions of both Antanaitis to “Tester” in one sentence.
- Count how many Testers work in the company.
*/
-- Task2
--- Task2.1
INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID) VALUES ('39705067782', 'Petras', 'Petrauskas', '2024-01-01', '1997-05-06', 'Developer', 'C#', 2);
--- Task2.2
INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate) VALUES ('39705267782', 'Laimonas', 'Laume', '2024-02-01', '1997-05-26');
--- Task2.3
UPDATE Employee SET Position = 'Developer', DepartmentName = 'C#', ProjectID = 1 WHERE PersonalCode = '39705267782';
--- Task2.4
DELETE FROM Employee WHERE PersonalCode = '39705267782';
--- Task2.5
INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID) VALUES ('39711067852', 'Lukas', 'Antanaitis', '2023-01-01', '1997-11-06', 'Developer', 'C#', 1);
INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID) VALUES ('39703307992', 'Sasha', 'Antanaitis', '2024-01-01', '1997-05-06', 'Developer', 'C#', 3);
--- Task2.6
UPDATE Employee SET Position = 'Tester' WHERE LastName = 'Antanaitis';
--- Task2.7
SELECT COUNT(Position) AS NumberOfTesters From Employee WHERE Position = 'Tester';