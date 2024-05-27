-- TASK1
--- TASK1.1 Select all data from the table “Employee”.
CREATE PROCEDURE SelectAllEmployees
AS
	BEGIN
		SELECT * FROM Employee;
	END;
--- TASK1.2 Select all data from the column “PersonalCode” in the table “Employee”.
CREATE PROCEDURE SelectEmployeePersonalCode
AS
	BEGIN
		SELECT PersonalCode FROM Employee;
	END;
--- TASK1.3 Select all data from the columns “FirstName”, “LastName”, “Position” in the table “Employee”.
CREATE PROCEDURE SelectEmplyeesFirstLastNamesAndPosition
AS
	BEGIN
		SELECT FirstName, LastName, Position FROM Employee;
	END;
--- TASK1.4 Select distinct values from the column DepartmentName in the table “Employee”.
CREATE PROCEDURE SelectDistinctDepartments
AS
	BEGIN
		SELECT DISTINCT DepartmentName From Employee;
	END;
--- TASK1.5 Select all data about employees who work in the C# department.
CREATE PROCEDURE SelectEmployeeByDepartmentName
@departmentName nvarchar(100)
AS
	BEGIN
		SELECT * From Employee WHERE DepartmentName = @departmentName;
	END;
--- TASK1.6 Select data on what position Giedrius holds.
CREATE PROCEDURE GetGiedriusFromEmployee
AS
	BEGIN
		SELECT FirstName, LastName, Position FROM Employee WHERE FirstName = 'Giedrius';
	END;
--- TASK1.7 Select all data about employees whose birth date is 1986-09-19.
CREATE PROCEDURE GetEmployeeByBirthDate
@birthDate nvarchar(11)
AS
	BEGIN
		SELECT * FROM Employee WHERE BirthDate = @birthDate;
	END;
--- TASK1.8 Select employee names whose last names are Sabutis.
CREATE PROCEDURE GetEmployeeByLastName
@lastName nvarchar(30)
AS
	BEGIN
		SELECT * FROM Employee WHERE LastName = @lastName;
	END;
--- TASK1.9 Select data (first and last names) about developers from the Java department.
CREATE PROCEDURE GetEmployeeByDepartmentAndPosition
@depName nvarchar(30), @position nvarchar(30)
AS
	BEGIN
		SELECT FirstName, LastName, Position FROM Employee WHERE DepartmentName = @depName AND Position = @position;
	END;
-- Task2
--- Task2.1 Insert a new employee into the table “Employee”, filling in all required fields (personal code, first name, last name, start date, birth date, position, department name, and project number).
CREATE PROCEDURE InsertEmployee
@personalCode char(11), @firstName varchar(255), @lastName varchar(255), @startDate date, @birthDate date, @position varchar(255), @depName varchar(255), @pID int
AS
	BEGIN
		INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID)
		VALUES (@personalCode, @firstName, @lastName, @startDate, @birthDate, @position, @depName, @pID);
	END;
--- Task2.2 Insert a new employee into the table “Employee”, only filling in fields (personal code, first name, last name, start date, birth date). Leave position, department name, and project number unfilled.
CREATE PROCEDURE InsertEmployeeNotFull
@personalCode char(11), @firstName varchar(255), @lastName varchar(255), @startDate date, @birthDate date
AS
	BEGIN
		INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate)
		VALUES (@personalCode, @firstName, @lastName, @startDate, @birthDate);
	END;
--- Task2.3 Fill in the remaining empty fields in the table “Employee” for your previously inserted entry. Assign the employee a position, department, and project.
CREATE PROCEDURE UpdateEmployeeNotFull
@personalCode char(11), @position varchar(255), @depName varchar(255), @pID int
AS
	BEGIN
		UPDATE Employee
		SET Position = @position, DepartmentName = @depName, ProjectID = @pID
		WHERE PersonalCode = @personalCode;
	END;
--- Task2.4 Delete the table “Employee” record whose personal code is the one you created.
CREATE PROCEDURE DeleteEmployeeByPersonalCode
@personalCode char(11)
AS
	BEGIN
		DELETE FROM Employee WHERE PersonalCode = @personalCode;
	END;
--- Task2.6 Change the positions of both Antanaitis to “Tester” in one sentence.
CREATE PROCEDURE UpdateEmployeePositionByLastName
@position varchar(255), @lastName varchar(255)
AS
	BEGIN
		UPDATE Employee SET Position = @position WHERE LastName = @lastName;
	END;
--- Task2.7 Count how many Testers work in the company.
CREATE PROCEDURE CountWorkersByPosition
@position varchar(255)
AS
	BEGIN
		SELECT COUNT(Position) AS NumberOfTesters From Employee WHERE Position = @position;
	END;