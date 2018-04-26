CREATE TABLE [dbo].[Reviews] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [ProcedureID]    INT             NOT NULL,
    [Cost]           DECIMAL (15, 2) NULL,
    [ReviewComments] VARCHAR (MAX)   NULL,
    [ReviewRating]   INT             NOT NULL,
    [ReviewDate]     DATE            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reviews_ProcedureID] FOREIGN KEY ([ProcedureID]) REFERENCES [dbo].[Procedures] ([Id])
);

