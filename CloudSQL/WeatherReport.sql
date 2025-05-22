CREATE TABLE WeatherReport (
    Id INT IDENTITY PRIMARY KEY,
    City NVARCHAR(100) NULL,
    Country CHAR(2) NULL,
    Temperature FLOAT NULL,
    TempMin FLOAT NULL,
    TempMax FLOAT NULL,
    LastUpdateTime DATETIME2 NULL,
    RawJson NVARCHAR(MAX) NULL,
    CreatedAt DATETIME2 NULL,
    [RequestId] INT NOT NULL UNIQUE,
    CONSTRAINT FK_Request FOREIGN KEY ([RequestId]) REFERENCES [dbo].[RequestLog]([Id])
);
