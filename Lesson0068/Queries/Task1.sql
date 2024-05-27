-- TASK1
--- TASK1.1 Select all data from the table “Employee”.
EXECUTE SelectAllEmployees;
--- TASK1.2 Select all data from the column “PersonalCode” in the table “Employee”.
EXECUTE SelectEmployeePersonalCode;
--- TASK1.3 Select all data from the columns “FirstName”, “LastName”, “Position” in the table “Employee”.
EXECUTE SelectEmplyeesFirstLastNamesAndPosition;
--- TASK1.4 Select distinct values from the column DepartmentName in the table “Employee”.
EXECUTE SelectDistinctDepartments;
--- TASK1.5 Select all data about employees who work in the C# department.
EXECUTE SelectEmployeeByDepartmentName 'C#';
--- TASK1.6 Select data on what position Giedrius holds.
EXECUTE GetGiedriusFromEmployee;
--- TASK1.7 Select all data about employees whose birth date is 1986-09-19.
EXECUTE GetEmployeeByBirthDate '1986-09-19';
--- TASK1.8 Select employee names whose last names are Sabutis.
EXECUTE GetEmployeeByLastName 'Sabutis';
--- TASK1.9 Select data (first and last names) about developers from the Java department.
EXECUTE GetEmployeeByDepartmentAndPosition 'Java', 'Developer';