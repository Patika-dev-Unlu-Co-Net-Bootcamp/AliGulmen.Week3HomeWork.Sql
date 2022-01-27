CREATE TRIGGER TR_CourseAbsences_InsteadOfInsert ON CourseAbsences
INSTEAD OF INSERT 
--This trigger will work instead of insert query, 
--We will work with "instead of" because if there is an issue with date information, we won't run query and we will give an error
AS
BEGIN
	
	--First, lets take all informations from inserted table
	DECLARE @courseStudentId int , @date smalldatetime, @present bit
	SELECT @courseStudentId = CourseStudentId, @date = Date, @present = Present FROM inserted    
	
	--We need;
	--Course duration(week) to calculate points we need,
	--And course date-range to validate date information
	DECLARE @weekCount int, @start smalldatetime, @end smalldatetime, @studentMark smallint, @courseId int 
	SELECT @courseId= CourseId FROM CourseStudents WHERE Id=@courseStudentId
	SELECT @weekCount = DurationWeek FROM Courses WHERE Id = @courseId
	SELECT @start = StartDate, @end = EndDate FROM CourseDates WHERE CourseId = @courseId 
	
	IF(@date NOT BETWEEN @start AND @end)
		BEGIN 
			RAISERROR('Incorrect date information for this course!',1,1) 
			ROLLBACK TRANSACTION -- Don't run the query
		END
		--If everything is good, we are going to check attendance. if the student has attended the course,
		--we have two scenario ; insert new record if it is first time or 
		--update if student already has some marks for this course
	ELSE IF(@present=1)
		BEGIN
			
			

			IF EXISTS(SELECT * FROM Grades WHERE CourseStudentId=@courseStudentId)
			BEGIN
				SELECT @studentMark = mark FROM Grades WHERE CourseStudentId=@courseStudentId
				Set @studentMark = @studentMark + ROUND(100/@weekCount,0)
				IF(@studentMark>100) Set @studentMark=100
				UPDATE Grades SET Mark=@studentMark WHERE CourseStudentId=@courseStudentId
			END
			ELSE
			BEGIN
				INSERT INTO Grades VALUES(@courseStudentId, ROUND(100/@weekCount,0)) 
			END
		
		END
		--if the student has not attended the course, we don't need to give any mark. Just give 0 if it is first lesson
	ELSE IF(@present=0)
		BEGIN
				IF NOT EXISTS(SELECT * FROM Grades WHERE CourseStudentId=@courseStudentId)
				INSERT INTO Grades VALUES(@courseStudentId, 0) 
		END
		--and after finishing everything, we can insert main record now
	INSERT INTO CourseAbsences VALUES (@courseStudentId, @date, @present) 
END
