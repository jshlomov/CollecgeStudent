SELECT * FROM Courses;
SELECT * FROM Cycles;
SELECT * FROM Subjects;
SELECT * FROM Students;
SELECT * FROM Lecturers;

IF EXISTS (SELECT 1 FROM Students
			WHERE IdentityNumber = '100')
BEGIN
	SELECT * FROM Students
	WHERE IdentityNumber = '1001'
END
ELSE
BEGIN
	SELECT 0
END

SELECT cr.ID as CourseID, Name, cy.ID as CycleID, BeginningDate
                            FROM Courses cr
                            JOIN Cycles cy
                            ON cr.ID = cy.Course_ID
                            JOIN StudentsInCycles si
                            ON si.Cycle_ID = cr.ID
                            WHERE si.ID = 3;


update Students
set Balance = Balance - 1000
where ID = 3;

select * from Students
select * from Payments
select * from StudentsInCycles



BEGIN TRANSACTION
INSERT INTO Payments (TotalPayment ,Students_ID, Cycle_ID) VALUES
(10000, 3, 1)
                        
update Students
set Balance = Balance - 10000
where ID = 3;
COMMIT TRANSACTION

IF NOT EXISTS (SELECT 1 FROM StudentsInCycles
				WHERE Students_ID = 3
				AND Cycle_ID = 3)
	BEGIN
		INSERT INTO StudentsInCycles (Cycle_ID, Students_ID) values
		(3, 3);
	END
ELSE
	BEGIN
		SELECT 0;
	END
select * from StudentsInCycles


