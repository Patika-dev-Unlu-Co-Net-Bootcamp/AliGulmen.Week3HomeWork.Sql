CREATE procedure proc_JoinCourse(@courseId int, @studentId int) 
As
Begin
DECLARE @start smalldatetime, @end smalldatetime
--Get start and end date for the course
SELECT @start = StartDate, @end = EndDate FROM CourseDates WHERE CourseId=@courseId

--There are 3 possibilities to overlap courses
-- Starting date of new course may overlap with the existing course dates  OR
-- End date of new course may overlap with the existing course dates  OR
-- New course starts before existing date of a course and ends after end date of that course.

IF EXISTS(SELECT * FROM CourseStudents cs
					JOIN CourseDates cd ON (cs.CourseId = cd.CourseId)
					WHERE cs.StudentId = @studentId AND ((@start BETWEEN StartDate AND EndDate)
														OR (@end BETWEEN StartDate AND EndDate)
												OR  (@start < StartDate AND @end > EndDate)))
SELECT ('The dates of this course overlap with a course date the student is enrolled in!');
-- Check capacity for new course.
ELSE IF((select COUNT(*) from CourseStudents WHERE CourseId=@courseId) >= (select Capacity from Courses WHERE Id=@courseId))
SELECT ('The capacity is full for this course!');
ELSE
	INSERT INTO CourseStudents VALUES (@courseId,@studentId)  
End
