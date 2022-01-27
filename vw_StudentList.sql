CREATE VIEW vw_StudentList AS                 
SELECT 								
	c.Name as 'CourseName',
	CONCAT(s.Name,' ' , s.LastName) as 'Student'
FROM CourseStudents cs
JOIN Students s ON (s.Id = cs.StudentId)
JOIN Courses c ON (c.Id = cs.CourseId)
ORDER BY c.Name, s.Name offset 0 rows 
--offset 0 rows used because of 'ORDER BY' clause is invalid in views without using some expression like it