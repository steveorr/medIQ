CREATE TABLE [dbo].[Error_Log] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [ErrorMsg]   VARCHAR (200) NOT NULL,
    [StackTrace] VARCHAR (MAX) NOT NULL,
    [ErrorDate]  DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

