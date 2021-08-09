CREATE DATABASE StudentsGrading;

DECLARE @JSON NVARCHAR(MAX);

SELECT @JSON=BulkColumn FROM 
OPENROWSET (BULK '/home/melika/RiderProjects/Phase04/Phase04/Phase04/JsonData/Students.json', SINGLE_CLOB) 
AS importData;


SELECT * INTO StudentsInformation
FROM OPENJSON (@JSON)
WITH
(
    [StudentNumber] BIGINT,
    [FirstName] NVARCHAR(10),
    [LastName] NVARCHAR(10)
);


SELECT @JSON=BulkColumn FROM 
OPENROWSET (BULK '/home/melika/RiderProjects/Phase04/Phase04/Phase04/JsonData/Scores.json', SINGLE_CLOB) 
AS importData;


SELECT * INTO StudentsGrades
FROM OPENJSON (@JSON)
WITH
(
    [StudentNumber] BIGINT,
    [Lesson] NVARCHAR(10),
    [Score] FLOAT(2)
);


SELECT StudentsInformation.StudentNumber, StudentsInformation.FirstName, StudentsInformation.LastName ,AVG(StudentsGrades.Score) AS average 
FROM StudentsInformation
INNER JOIN StudentsGrades ON StudentsGrades.StudentNumber = StudentsInformation.StudentNumber
GROUP BY StudentsInformation.StudentNumber, StudentsInformation.FirstName , StudentsInformation.LastName
ORDER BY average DESC;