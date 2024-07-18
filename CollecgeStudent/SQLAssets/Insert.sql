INSERT INTO Courses (Name) VALUES
('Full Stack'),
('Data Science'),
('AI');

INSERT INTO Cycles (BeginningDate, Price, Course_ID) VALUES
('2024-09-01', 20000, 1),
('2024-12-01', 20000, 1),
('2025-01-01', 25000, 2),
('2025-02-01', 27000, 3);

INSERT INTO Subjects (SubjectName, TotalHours) VALUES
('NodeJS', 50),
('React', 100),
('SQL', 70),
('C#', 150),
('Data Stracturs', 50),
('Python', 100),
('C++', 120),
('MongoDB', 50);

INSERT INTO Lecturers (IdentityNumber, FirstName, LastName, HourlyRate) VALUES
('0001', N'���', N'���', 100),
('0002', N'�����', N'������', 100),
('0003', N'�����', N'�� ����', 100),
('0004', N'����', N'��������', 100),
('0005', N'����', N'����', 100);

INSERT INTO Students (IdentityNumber, FirstName, LastName, Phone, Balance) VALUES
('1001',  N'�����', N'����','0542323545', 0),
('1002',  N'������', N'�����', '0548881823', 0),
('1003',  N'����', N'�����', '0585454515', 0),
('1004',  N'����', N'���', '0581547952', 0),
('1005',  N'���', N'�����', '0552258741', 0),
('1006',  N'�����', N'���', '0524598521', 0),
('1007',  N'�����', N'���', '0528216754', 0);

INSERT INTO Students (IdentityNumber, FirstName, LastName, Phone) VALUES
('1001',  N'�����', N'����','0542323545'),
('1001',  N'������', N'�����', '0548881823'),
('1001',  N'����', N'�����', '0585454515'),
('1001',  N'����', N'���', '0581547952'),
('1001',  N'���', N'�����', '0552258741'),
('1001',  N'�����', N'���', '0524598521'),
('1001',  N'�����', N'���', '0528216754'),
('1001',  N'�����', N'�����', '0528216754'),
('1001',  N'�����', N'���', '0528216754'),
('1001',  N'�����', N'���', '0528216754'),
('1001',  N'���', N'�����', '0528216754')�


INSERT INTO StudentsInCycles (Cycle_ID, Students_ID) values
(1, 3),
(1, 4),
(1, 5),
(2, 3),
(3, 4);