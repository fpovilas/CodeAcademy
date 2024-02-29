-- Task2
--- Task2.1 Insert a new employee into the table “Employee”, filling in all required fields (personal code, first name, last name, start date, birth date, position, department name, and project number).
EXECUTE InsertEmployee '39705067782', 'Petras', 'Petrauskas', '2024-01-01', '1997-05-06', 'Developer', 'C#', 2;
--- Task2.2 Insert a new employee into the table “Employee”, only filling in fields (personal code, first name, last name, start date, birth date). Leave position, department name, and project number unfilled.
EXECUTE InsertEmployeeNotFull '39705267782', 'Laimonas', 'Laume', '2024-02-01', '1997-05-26';
--- Task2.3 Fill in the remaining empty fields in the table “Employee” for your previously inserted entry. Assign the employee a position, department, and project.
EXECUTE UpdateEmployeeNotFull '39705267782', 'Developer', 'C#', 1;
--- Task2.4 Delete the table “Employee” record whose personal code is the one you created.
EXECUTE DeleteEmployeeByPersonalCode '39705267782';
--- Task2.5 Insert two employees with the last name Antanaitis whose position would be “Developer”.
EXECUTE InsertEmployee '39711067852', 'Lukas', 'Antanaitis', '2023-01-01', '1997-11-06', 'Developer', 'C#', 1;
EXECUTE InsertEmployee '39703307992', 'Sasha', 'Antanaitis', '2024-01-01', '1997-05-06', 'Developer', 'C#', 3;
--- Task2.6 Change the positions of both Antanaitis to “Tester” in one sentence.
EXECUTE UpdateEmployeePositionByLastName 'Tester', 'Antanaitis';
--- Task2.7 Count how many Testers work in the company.
EXECUTE CountWorkersByPosition 'ProjectManager';