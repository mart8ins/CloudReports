CREATE TABLE [dbo].[RequestLog]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [TimeStamp] DATETIMEOFFSET NOT NULL, 
    [HttpMethod] VARCHAR(6) NOT NULL, 
    [StatusCode] INT NOT NULL, 
    [IsSuccess] BIT NOT NULL, 
    [ErrorMessage] VARCHAR(MAX) NULL, 
    [RequestUrl] VARCHAR(MAX) NOT NULL
)
