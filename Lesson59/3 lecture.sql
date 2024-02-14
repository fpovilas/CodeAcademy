CREATE TABLE Projects (
    "ID" integer NOT NULL,
    "Name" VARCHAR(255),
    "Importance" VARCHAR(255),
    "Start" date,
    "Duration" integer
);

CREATE TABLE Execution (
    "Project" integer NOT NULL,
    "Executor" integer NOT NULL,
    "Status" VARCHAR(255),
    "Hours" integer
);

CREATE TABLE Executors (
    "ID" integer NOT NULL,
    "LastName" VARCHAR(255),
    "Qualification" VARCHAR(255),
    "Category" integer,
    "Education" VARCHAR(255)
);

INSERT INTO Projects ("ID", "Name", "Importance", "Start", "Duration") VALUES
(1, 'Student Accounting', 'High', '2015-01-01', 12),
(2, 'Accounting', 'Medium', '2005-03-01', 10),
(3, 'WWW Site', 'Special', '2005-06-01', 2);

INSERT INTO Execution ("Project", "Executor", "Status", "Hours") VALUES
(1, 1, 'Developer', 30),
(1, 2, 'Documenter', 100),
(1, 3, 'Tester', 100),
(1, 4, 'Manager', 100),
(2, 1, 'Developer', 300),
(2, 2, 'Analyst', 250),
(2, 34, 'Manager', 100),
(3, 1, 'Developer', 250),
(3, 2, 'Manager', 400),
(3, 3, 'Designer', 150);

INSERT INTO Executors ("ID", "LastName", "Qualification", "Category", "Education") VALUES
(1, 'Jonaitis', 'Computer Scientist', 2, 'VU'),
(2, 'Petraitis', 'Statistician', 3, 'VU'),
(3, 'Grazulyte', 'Engineer', 1, NULL),
(4, 'Onaityte', 'Manager', 5, 'VDU'),
(5, 'Antanaitis', 'Computer Scientist', 3, 'VU');

ALTER TABLE "Projects"
    ADD CONSTRAINT "Projects_pkey" PRIMARY KEY ("ID");

ALTER TABLE "Execution"
ADD CONSTRAINT "Execution_pkey" PRIMARY KEY ("Project", "Executor");

ALTER TABLE "Executors"
    ADD CONSTRAINT "Executors_pkey" PRIMARY KEY ("ID");
